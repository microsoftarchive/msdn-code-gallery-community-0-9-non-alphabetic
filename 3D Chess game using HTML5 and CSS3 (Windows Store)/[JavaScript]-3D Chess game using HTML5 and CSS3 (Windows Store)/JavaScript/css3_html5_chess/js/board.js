// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    var overlay;
    var wrapper;
    var inner;
    var innerOverlay;
    var rotater;

    var btnStart;
    var btnAdd;
    var btnSpin;
    var btnGhost;
    var choosePiece;
    var ghostElem;

    var boardOffsetLeft;
    var boardOffsetTop;
    var boardScale;

    var pieces = new Map();
    var rows = new Map();

    var pieceUidCounter = 0;
    var pieceTypes;

    var cssRuleEnter;
    var cssRuleCapture;
    var cssRuleAdjustScale;
    var cssRuleAdjustScaleBack;
    var cssRuleChangeScale;
    var cssRuleChangeScaleBack;
    var cssRuleGhostPiece;
    var cssRuleUnGhostPiece;

    var requestId;
    var spinCount = 0;
    var frameCount = 0;

    var members = {
        initializeAll: initializeAll
    }

    WinJS.Namespace.define("Board", members);

    function initializeAll() {

        wrapper = document.getElementById("wrapper");
        inner = document.getElementById("inner");
        overlay = document.getElementById("overlay");
        innerOverlay = document.getElementById("innerOverlay");
        rotater = document.getElementById("rotateOverlay");
        choosePiece = document.querySelector(".choosePiece");

        btnStart = document.querySelector(".start");
        btnStart.addEventListener("click", startPlay);
        btnAdd = document.querySelector(".add");
        btnAdd.addEventListener("click", addRemovePieces);
        btnSpin = document.querySelector(".spin");
        btnSpin.addEventListener("click", spinAction);
        btnGhost = document.querySelector(".ghost");
        btnGhost.addEventListener("click", ghostAction);

        inner.addEventListener("MSAnimationStart", cancelAnim);
        window.onresize = onSizeChanged;
        var len = inner.children.length;

        // Capture events on the rows.
        for (var x = 0; x < len; x++) {
            inner.children[x].addEventListener("mousedown", squareSelected);
        }

        pieceTypes = Pieces.setPieceTypes();
        setRowData();
        getRules();
        initializeImages();
    }

    // Returns a reference to the specified CSS @keyframes rule(s).
    function getRules() {

        var rule;
        var ss = document.styleSheets;
        for (var i = 0; i < ss.length; ++i) {
            // loop through all the rules!
            for (var x = 0; x < ss[i].cssRules.length; ++x) {

                rule = ss[i].cssRules[x];
                if (rule.name == "enterPiece" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleEnter = rule;
                }

                if (rule.name == "enterCapture" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleCapture = rule;
                }

                if (rule.name == "adjustScale" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleAdjustScale = rule;
                }

                if (rule.name == "adjustScaleBack" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleAdjustScaleBack = rule;
                }

                if (rule.name == "changeScale" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleChangeScale = rule;
                }

                if (rule.name == "changeScaleBack" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleChangeScaleBack = rule;
                }

                if (rule.name == "ghostPiece" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleGhostPiece = rule;
                }

                if (rule.name == "unGhostPiece" && rule.type == CSSRule.KEYFRAMES_RULE) {
                    cssRuleUnGhostPiece = rule;
                }
            }
        }
    }

    function removePiece(args, id) {

        var piece;
        var point;
        var animation;
        var timeout;
        var duration;

        if (args !== null) {
            id = args.target.id;
            animation = "exit";
            duration = "1.5s";
            timeout = 1500;
        }
        else {
            animation = "exitCaptured";
            duration = "4s";
            timeout = 4000;
            setTimeout(function () {
                playSound("snd1");
            }, 200);

            setTimeout(function () {
                playSound("snd2");
            }, 2000);
        }

        piece = document.getElementById(id);
        point = document.getElementById(id + "_point");

        piece.style.animationDuration = duration;
        piece.style.animationTimingFunction = "linear";
        piece.style.animationName = animation;

        // Prevent additional events
        // on the element about to be removed.
        piece.style.pointerEvents = "none";      
        pieces.delete(id);

        setTimeout(function () {
            piece.removeNode(true);
            point.removeNode(true);
        }, timeout)

        return;
    }

    // Renders offscreen elements for re-use.
    function initializeImages() {

        pieceTypes.forEach(function (t, key, mapObj) {

            var img;
            var imgHeight;
            var offscreen = document.getElementById("offscreen");

            var image = new Image();
            var el = document.createElement("canvas");
            el.id = t + "_canvas";
            var typeInfo = Pieces.getTypeImageInfo(t);

            image.src = typeInfo[0];
            el.height = typeInfo[1];
            el.width = typeInfo[2];

            offscreen.appendChild(el);
            var canvas = document.getElementById(t + "_canvas");
            var ctx = canvas.getContext("2d");
            ctx.drawImage(image, 0, 0);
        });
    }

    // Generates the unique ID for a new piece,
    // and validates the new type.
    function generatePieceId(newType) {

        var type;

        if (State.getTask() == State.RemovingPiece) {
            type = State.getRemovedPieceType();
        }
        else if (newType != null) {
            type = newType;
        }
        else {
            // default
            type = "knight";
        }

        // Guarantee unique key/ID
        var key = type + pieceUidCounter;
        var pieceInfo = [ key, type ];
        return pieceInfo;
    }

    // Adds a new piece or a removed piece.
    function createAction(args, currentTarget, newType) {
     
        var currentRow;
        var pieceInfo;
        var rawScaleValue;
        var cssScaleValue;
        var rowHeight = 100;

        var offsetY = args.offsetY;
        var offsetX = args.offsetX;

        var duration = "1.5s";
        var animName = "enterPiece";

        var rowNumber = getRowNumber(currentTarget.id);
        var colNumber = getColNumber(args.offsetX);
        // Make sure a row has been selected.
        if (rowNumber == null) {
            return;
        }

        var pos = WinJS.Utilities.getPosition(currentTarget.parentElement);
        boardOffsetLeft = pos.left;
        boardOffsetTop = pos.top;

        pieceInfo = generatePieceId(newType);

        var newNode = document.createElement("canvas");
        newNode.id = pieceInfo[0];
        newNode.style.zIndex = 2;
        newNode.style.position = "absolute";
        newNode.addEventListener("mousedown", pieceSelected);
        var piece = new Game.Piece(newNode.id, pieceInfo[1], null);
        pieces.set(newNode.id, piece);

        var image = new Image();
        image.src = pieces.get(newNode.id).img;
        piece.image = image;

        var pieceHeight = piece.imgHeight;
        var pieceWidth = piece.imgWidth;
        newNode.height = pieceHeight;
        newNode.width = pieceWidth;

        // Set piece properties in untransformed space.
        var row = rows.get(rowNumber);
        piece.row = rowNumber;
        piece.col = colNumber;
        piece.scale = getRowScale(rowNumber);

        // Test whether the new piece is entering
        // an occupired square; remove any old piece.
        if (State.getTask() == State.RemovingPiece) {
            var removed = removeCapturedPiece(piece.row, piece.col, newNode.id);
            if (removed == true) {
                duration = ".75s";
                animName = "enterCapture";
            }
        }

        // Set DOM element (piece) values in transformed (rotated) space.
        // This code checks whether board is rotated for getting
        // the current row of the piece.
        // If board is rotated, spinCount % 2 will not == 0;
        if (spinCount % 2 != 0) {
            currentRow = getOppositeRow(rowNumber);
            cssScaleValue = getRowScale(currentRow);
            row = rows.get(currentRow);
        }
        else {
            currentRow = rowNumber;
            cssScaleValue = getRowScale(rowNumber);
        }

        piece.currentRow = currentRow;

        // Create point to track location of piece
        // in transformed space.
        var pointNode = document.createElement("div");
        pointNode.id = pieceInfo[0] + "_point";
        pointNode.style.height = "1px";
        pointNode.style.width = "1px";
        pointNode.style.zIndex = "20";
        // When debugging, use a color like red to make point visible.
        pointNode.style.backgroundColor = "transparent";
        pointNode.style.position = "absolute";
        pointNode.style.left = offsetX + "px";
        // Calculate y offset using row
        pointNode.style.top = offsetY + (piece.row * rowHeight) + "px";

        newNode.style.animationName = animName;
        newNode.style.animationDuration = duration;
        newNode.style.animationFillMode = "forwards";

        if (piece.row != undefined && piece.row != null ) {
            inner.appendChild(pointNode);
            positionPiece(piece, newNode, newNode.id, false);

            // Update @keyframes rule for entering piece.
            cssRuleEnter.deleteRule("0");
            cssRuleEnter.deleteRule("1");

            cssRuleEnter.appendRule("0% { transform: translateY(-150px) " + cssScaleValue +
                "; -ms-transform-origin-y: 50%; opacity: 0; }");
            cssRuleEnter.appendRule("100% { transform: translateY(0px) " + cssScaleValue + "; opacity: 1; }");

            // Update @keyframes rule for capturing piece.
            cssRuleCapture.deleteRule("0");
            cssRuleCapture.deleteRule("1");

            cssRuleCapture.appendRule("0% { transform: translateX(-150px) " + cssScaleValue +
                "; opacity: 0; }");
            cssRuleCapture.appendRule("100% { transform: translateX(0px) " + cssScaleValue + "; opacity: 1; }");

            innerOverlay.appendChild(newNode);
            var canvasEl = document.getElementById(newNode.id);
            var ctx2 = canvasEl.getContext("2d");
            ctx2.drawImage(image, 0, 0);

            pieceUidCounter++;
        }
    }

    // Handles selection of a piece on the board.
    function pieceSelected(args) {

        // If about to 'reach' for a piece, disable pointer events on the piece
        // in front and make it partially transparent.
        if (State.getTask() == State.GhostingPiece) {
            ghostElem = document.getElementById(args.currentTarget.id);
            var piece = pieces.get(args.currentTarget.id);
            ghostElem.style.pointerEvents = "none";

            var start = piece.currentCssScaleValue + "; opacity: 1";
            var end = piece.currentCssScaleValue + "; opacity: .7";
            resetCssRule(ghostElem, "ghostPiece", cssRuleGhostPiece, start, end, "1s");

            State.updateTask(State.ReachingPiece, null);
        }
        else {
            if (State.getTask() == State.ReachingPiece) {
                cancelGhostAction();
                State.completedTask(State.getTask());
            }
            if (State.isPlayMode() == true) {
                pieces.forEach(function (piece, key, mapObj) {
                    var elem = document.getElementById(key);
                    elem.style.pointerEvents = "none";
                });

                var piece = pieces.get(args.currentTarget.id);
                State.updateTask(State.RemovingPiece, piece.type);
            }
            removePiece(args);
        }

        args.preventDefault();

    }

    // Handles selection of a square (row) on the board.
    function squareSelected(args) {

        // Avoid taking any action during a rotation.
        if (State.isSpinning() != true) {
            if (State.isAddRemoveMode() == true) {
                var selection = choosePiece.value;
                var newType = pieceTypes.get(selection);
                createAction(args, args.currentTarget, newType);
            }
            if (State.isPlayMode() == true && State.getTask() == State.RemovingPiece) {
                createAction(args, args.currentTarget, null);
            }
            // In all other cases, do nothing. In play mode,
            // selecting an empty square should have no effect unless
            // a piece is ready to move.
            // We do re-enable events, however,
            // just to guarantee that the pieces are selectable.
            pieces.forEach(function (piece, key, mapObj) {
                var elem = document.getElementById(key);
                elem.style.pointerEvents = "visiblePainted";
            });
        }
        cancelGhostAction();
    }

    // Enables play mode
    function startPlay(args) {

        var b1 = document.querySelector(".add");
        var b2 = document.querySelector(".start");

        b1.style.backgroundColor = "transparent";
        b2.style.backgroundColor = "green";
        choosePiece.style.display = "none";

        State.updateState(State.Play);
        // If board is empty, set up board.
        if (pieces.size == 0) {
            setupBoard();
        }
    }

    // Enables add-remove mode
    function addRemovePieces(args) {

        var b1 = document.querySelector(".add");
        var b2 = document.querySelector(".start");

        b1.style.backgroundColor = "green";
        b2.style.backgroundColor = "transparent";
        choosePiece.style.display = "block";

        if (State.getTask() == State.RemovingPiece) {
            State.completedTask(State.RemovingPiece);
        }
        State.updateState(State.AddRemove);
    }

    // Enables reaching through a piece to select
    // another, hard-ro-reach piece (The alternative is to rotate the board).
    function ghostAction(args) {

        // If a piece has just been removed, it has already
        // been selected, and there is no need to enable a 'reach'.
        if (State.getTask() != State.RemovingPiece) {
            State.updateTask(State.GhostingPiece, null);
            var b4 = document.querySelector(".ghost");
            b4.style.backgroundColor = "green";
        }
    }

    function cancelGhostAction() {

        var b4 = document.querySelector(".ghost");
        b4.style.backgroundColor = "transparent";

        if (State.getTask() == State.GhostingPiece | State.getTask() == State.ReachingPiece) {
            if (ghostElem) {
                var piece = pieces.get(ghostElem.id);
                ghostElem.style.pointerEvents = "visiblePainted";

                var start = piece.currentCssScaleValue + "; opacity: .7";
                var end = piece.currentCssScaleValue + "; opacity: 1";
                resetCssRule(ghostElem, "unGhostPiece", cssRuleUnGhostPiece, start, end, "1s");
            }
        }

        State.completedTask(State.getTask());

    }

    // Sorts pieces during a board rotation.
    function zIndexSorter(first, second) {

        if (first.topRect == second.topRect)
            return 0;
        if (first.topRect < second.topRect)
            return -1;
        else
            return 1;
    }

    function cancelAnim(args) {

        setTimeout(function () {
            window.cancelAnimationFrame(requestId);
            // Bug: gets called twice
            State.completedState(State.Spinning);
            frameCount = 0;

            var mainCtx = rotater.getContext("2d");
            mainCtx.clearRect(0, 0, 1400, 1400);
            rotater.style.zIndex = "-20";

            pieces.forEach(function (thisPiece, key, mapObj) {
                var piece = document.getElementById(key);
                piece.style.pointerEvents = "visiblePainted";

                piece.style.left = thisPiece.endRotationLeft + "px";
                piece.style.top = thisPiece.endRotationTop + "px";
            });

        }, 6000);
    }

    // Animation frames for board rotation. Uses <canvas> element.
    function animFrame(args) {

        var mainCtx = rotater.getContext("2d");
        mainCtx.clearRect(0, 0, 1400, 1400);

        var unsortedPieces = new Array();
        var unsortedPiecesIdx = 0;
        // Sets framecount start/end values for rescale adjustments.
        var rescaleStart = 60;
        var rescaleEnd = 180;
        // Sets the frequency of rescale adjustments (4 = 1 rescale per 4 frames).
        var rescaleInterval = 4;

        pieces.forEach(function (thisPiece, key, mapObj) {
            var point = document.getElementById(key + "_point");

            thisPiece.topRect = point.getBoundingClientRect().top;
            thisPiece.leftRect = point.getBoundingClientRect().left;

            unsortedPieces[unsortedPiecesIdx] = thisPiece;
            unsortedPiecesIdx++;
        });

        // For canvas, need to draw images in z-index order.
        var sortedPieces = unsortedPieces.sort(zIndexSorter);

        sortedPieces.forEach(function (thisPiece, index, arrayObj) {
            var piece = document.getElementById(thisPiece.id);
            var height = thisPiece.imgHeight;
            var width = thisPiece.imgWidth;
            piece.style.zIndex = Math.round(thisPiece.topRect);
            // Moving elements offscreen during rotation.
            // Instead, we will paint them on one canvas.
            piece.style.left = "4000px";

            thisPiece.frameLeftValues[thisPiece.frameIdx] = thisPiece.leftRect;
            thisPiece.frameTopValues[thisPiece.frameIdx] = thisPiece.topRect;

            var aveLeftRect = smoothFrames(thisPiece.frameLeftValues);
            var aveTopRect = smoothFrames(thisPiece.frameTopValues);

            var scaledHeight = Math.round(height * thisPiece.rotationScaleValue);
            var scaledWidth = Math.round(width * thisPiece.rotationScaleValue);

            thisPiece.endRotationLeft = aveLeftRect - boardOffsetLeft - (width / 2);
            thisPiece.endRotationTop = aveTopRect - boardOffsetTop - height + ((height - scaledHeight) / 2) + 15;

            // For canvas, pieces are scaled from top/left instead of middle. This necessitates
            // a position adjustment based on scaled width/height.
            // In addition, the canvas used for rotation requires different offsets (adj. by +300/+350).
            var leftVal = thisPiece.endRotationLeft + ((width - scaledWidth) / 2) + 300;
            var topVal = aveTopRect - boardOffsetTop - scaledHeight + 15 + 350;

            var scaleIncrement = thisPiece.rotationScaleChange / ((rescaleEnd - rescaleStart) / rescaleInterval);
            // Grab the offscreen rendered images for the rotation.
            var canvas = document.getElementById(thisPiece.type + "_canvas");
            
            if (frameCount >= rescaleStart && frameCount < rescaleEnd) {
                // Adjust scale 1x per rescaleInterval, e.g., 1x every 4 frames.
                if (frameCount % rescaleInterval == 0) {

                    thisPiece.rotationScaleValue = thisPiece.rotationScaleValue - scaleIncrement;
                }
            }

            mainCtx.drawImage(canvas, leftVal, topVal, scaledWidth, scaledHeight);

            thisPiece.frameIdx++;

            if (thisPiece.frameIdx > 2) { thisPiece.frameIdx = 0; }
        });

        if (pieces.size == 0) {
            window.cancelAnimationFrame(requestId);
            return;
        }
        frameCount++;
        requestId = window.requestAnimationFrame(animFrame);
    }

    // Initiates board rotation.
    function spinAction(args) {

        var point;
        var piece;
        var currentScale;
        var targetScale;
        var targetRow;
        var rawScaleValue;
        var rawTargetScaleValue;
        var perFrameIncrement;

        if (State.isSpinning() == true) {
            // If board is already spinning, do nothing.
            return;
        }

        rotater.style.zIndex = 1000;

        State.updateState(State.Spinning);
        spinCount++;
        frameCount = 0;

        if (spinCount % 2 != 0) {
            inner.style.animationName = "rotate";
        }
        else {
            inner.style.animationName = "rotateBack";
        }

        pieces.forEach(function (thisPiece, key, mapObj) {
            piece = document.getElementById(key);
            point = document.getElementById(key + "_point");
            // Disable mouse/touch during rotation.
            piece.style.pointerEvents = "none";

            var boardOffset = WinJS.Utilities.getPosition(point.parentElement);
            boardOffsetLeft = boardOffset.left;
            boardOffsetTop = boardOffset.top;

            var elementRow = thisPiece.row;
            var oppositeRow = getOppositeRow(elementRow);
            var normalScale = thisPiece.scale;

            // spinCount just incremented; this
            // equals a normal spin to back.
            if (spinCount % 2 != 0) {
                currentScale = normalScale;
                targetScale = getRowScale(oppositeRow);
                rawScaleValue = getRawRowScale(elementRow);
                rawTargetScaleValue = getRawRowScale(oppositeRow);
                targetRow = oppositeRow;

                var rule = cssRuleAdjustScale;
                resetCssRule(piece, "adjustScale", rule, currentScale, targetScale, ".5s");
            }
            else {
                currentScale = getRowScale(oppositeRow);
                targetScale = normalScale;
                rawScaleValue = getRawRowScale(oppositeRow);
                rawTargetScaleValue = getRawRowScale(elementRow);
                targetRow = elementRow;

                var rule = cssRuleAdjustScaleBack;
                resetCssRule(piece, "adjustScaleBack", rule, currentScale, targetScale, ".5s");
            }

            thisPiece.currentCssScaleValue = targetScale;
            thisPiece.currentRawScaleValue = rawScaleValue;

            // Setting post-rotation current row early
            // because the value is not used during the rotation.
            thisPiece.currentRow = targetRow;

            var scaleAdjustment = rawScaleValue - rawTargetScaleValue;
            thisPiece.rotationScaleChange = scaleAdjustment;
            thisPiece.rotationScaleValue = rawScaleValue;

        });

        inner.focus();
        requestId = window.requestAnimationFrame(animFrame);
        //cancelAnim();

    }

    // Averaging function for setting top/left values during a rotation.
    function smoothFrames(frameValues) {
        var average = 0;
        var count = 0;

        frameValues.forEach(function (value) {
            if (value != 0) {
                average = average + value;
                count++;
            }
        });
        return average / count;
    }

    // Initializes row data. Currently only scale value is used/needed.
    function setRowData() {
        rows.set(0, [.65]);
        rows.set(1, [.68]);
        rows.set(2, [.72]);
        rows.set(3, [.76]);
        rows.set(4, [.8]);
        rows.set(5, [.85]);
        rows.set(6, [.90]);
        rows.set(7, [.95]);
    }

    // Initializes row data. Currently only scale value is used/needed.
    function setRowDataSmall() {
        rows.set(0, [.55]);
        rows.set(1, [.58]);
        rows.set(2, [.61]);
        rows.set(3, [.64]);
        rows.set(4, [.67]);
        rows.set(5, [.71]);
        rows.set(6, [.75]);
        rows.set(7, [.8]);
    }
    
    function getRowNumber(rowId) {

        var row;

        switch (rowId) {
            case "a":
                row = 0;
                break;
            case "b":
                row = 1;
                break;
            case "c":
                row = 2;
                break;
            case "d":
                row = 3;
                break;
            case "e":
                row = 4;
                break;
            case "f":
                row = 5;
                break;
            case "g":
                row = 6;
                break;
            case "h":
                row = 7;
                break;
            default:
                row = null;
        }
        return row;
    }

    function getColNumber(x) {

        var col;
        // Provide untransformed x coordinates.
        var colValues = new Array(100, 200, 300, 400, 500, 600, 700, 1500);

        for (var i = 0; i < colValues.length; i++) {
            if (x < colValues[i]) {
                col = i;
                return col;
            }
        }
        return col;
    }

    // Returns valid CSS scaling value for the row.
    function getRowScale(rowNumber) {

        var row = rows.get(rowNumber);
        var str = "scale(" + row[0] + ")";
        return str;
    }

    // Returns raw scale value for the row.
    function getRawRowScale(rowNumber) {

        var row = rows.get(rowNumber);
        var str = row[0];
        return str;
    }

    function getOppositeRow(rowNumber) {
        var opp = 7 - rowNumber;
        return opp;
    }

    function getOppositeCol(colNumber) {
        var opp = 7 - colNumber;
        return opp;
    }

    function removeCapturedPiece(row, col, newId) {

        var p = null;
        var removed = false;

        pieces.forEach(function (piece) {
            if (piece.row == row && piece.col == col) {
                if (piece.id !== newId) {
                    removePiece(null, piece.id);
                    removed = true;
                }
            }
        });
        return removed;
    }

    // Sets pre-arranged values for board setup,
    // and calls create function.
    function setupBoard() {

        var row;
        var type;
        var pieces = new Array();
        var delay = 0;

        // Matched to available pieces.
        var firstRowPieces = new Array("knight", "bishop", "queen", "bishop", "knight");
        var lastRowPieces = new Array("knight_b", "bishop_b", "bishop_b", "knight_b");
        var firstRowIdx = 0;
        var lastRowIdx = 0;

        // For setup, manually set X-coordinate offsets, matched to available pieces
        // that can be set up on the board. Currently, 16 pawns and 9 other pieces.
        var oX = new Array(150, 250, 350, 550, 650, 50, 150, 250, 350, 450, 540, 650,
            750, 50, 150, 250, 350, 450, 550, 650, 750, 150, 250, 550, 650);
        // Y-coordinate offset, adjusted based on row.
        var oY;

        for (var i = 0; i < oX.length; i++) {

            oY = 55;
            // Two bishops and two knights in top row.
            if (i < 5) {
                row = "a";
                oY = 45;
                type = firstRowPieces[firstRowIdx];
                firstRowIdx++;
            }
            // Pawns in second row.
            else if (i < 13) {
                row = "b";
                type = "pawn";
            }
            // Pawns in seventh row.
            else if (i < 21) {
                row = "g";
                type = "pawn_b";
            }
            // Various pieces in eighth row.
            else if (i < 25) {
                row = "h";
                oY = 60;
                type = lastRowPieces[lastRowIdx];
                lastRowIdx++;
            }

            var piece = new Object();
            var currentTarget = new Object();

            piece.offsetX = oX[i];
            piece.offsetY = oY;

            var elem = document.getElementById(row);
            currentTarget.id = row;
            currentTarget.parentElement = elem.parentElement;
            piece.type = type;
            piece.cTarget = currentTarget;
            pieces[i] = piece;

        }

        var pieceIdx = 0;

        for (var idx = 0; idx < oX.length; idx++) {
            delay = delay + 250;
            // For UX, avoid setting these pieces down too fast. Also, avoids possible perf hit.
            setTimeout(function () {
                createAction(pieces[pieceIdx], pieces[pieceIdx].cTarget, pieces[pieceIdx].type);
                pieceIdx++;
            }, delay);
        }
    }

    function playSound(id) {
        var elem = document.getElementById(id);
        elem.controls = false;
        elem.play();
    }
    
    // Handles layout changes.
    function onSizeChanged() {

        resetBoard();
    }

    function resetBoard() {

        if (State.isSpinning() == true) {
            // Currently not supporting resize during a rotation.
            // Alternatively, could call cancelAnimation().
            return;
        }

        var outer = document.getElementById("resizer");
        // Get window size
        var windowWidth = document.documentElement.offsetWidth;
        var windowHeight = document.documentElement.offsetHeight;

        if (windowWidth < 1450) {

            wrapper.style.left = "100px";
            wrapper.style.top = "250px";
            overlay.style.left = "100px";
            overlay.style.top = "250px";
            rotater.style.left = "-200px";
            rotater.style.top = "-100px";

            btnStart.style.left = "935px";
            btnSpin.style.left = "965px";
            btnAdd.style.left = "1000px";
            btnGhost.style.left = "1030px";
            choosePiece.style.left = "1140px";
            choosePiece.style.top = "295px";

            setRowDataSmall();
            boardScale = .85;
            resizer.style.transform = "scale(" + boardScale + ")";
            resetPieces();
        }
        else {

            wrapper.style.left = "300px";
            wrapper.style.top = "350px";
            overlay.style.left = "300px";
            overlay.style.top = "350px";
            rotater.style.left = "0px";
            rotater.style.top = "0px";

            btnStart.style.left = "1235px";
            btnSpin.style.left = "1265px";
            btnAdd.style.left = "1300px";
            btnGhost.style.left = "1330px";
            choosePiece.style.left = "1450px";
            choosePiece.style.top = "295px";

            setRowData();
            boardScale = 1;
            resizer.style.transform = "scale(" + boardScale + ")";
            resetPieces();
        }

        if (windowWidth < 1200) {
            btnStart.style.left = "835px";
            btnSpin.style.left = "865px";
            btnAdd.style.left = "900px";
            btnGhost.style.left = "930px";
            choosePiece.style.top = "90px";
            choosePiece.style.left = "810px";
        }
    }

    // Repositions pieces on resize.
    function resetPieces() {

        var firstRow = document.getElementById("a");
        var pos = WinJS.Utilities.getPosition(firstRow.parentElement);
        boardOffsetLeft = pos.left;
        boardOffsetTop = pos.top;

        pieces.forEach(function (thisPiece, key, mapObj) {
            var elem = document.getElementById(key);
            positionPiece(thisPiece, elem, key, true);
        });
    }

    function resetCssRule(piece, ruleName, rule, currentCssVal, targetCssVal, duration) {

        rule.deleteRule("0");
        rule.deleteRule("1");

        rule.appendRule("0% { transform: " + currentCssVal + "; }");
        rule.appendRule("100% { transform: " + targetCssVal + "; }");

        piece.style.animationDuration = duration;
        piece.style.animationName = ruleName;
    }

    // Positions a piece using the tracking point.
    function positionPiece(currentPiece, elem, id, updateScale) {

        var height = currentPiece.imgHeight;
        var width = currentPiece.imgWidth;
        var point = document.getElementById(id + "_point");

        var row = rows.get(currentPiece.currentRow);
        var rawScaleValue = row[0];

        // For rotation support, we need to reset untransformed CSS value.
        currentPiece.scale = getRowScale(currentPiece.row);
        var oldScale = currentPiece.currentCssScaleValue;
        currentPiece.currentCssScaleValue = getRowScale(currentPiece.currentRow);
        currentPiece.currentRawScaleValue = rawScaleValue;

        var scaledHeight = Math.round(height * rawScaleValue);

        var topRect = point.getBoundingClientRect().top;
        var leftRect = point.getBoundingClientRect().left;

        if (updateScale == true) {
            var rule;
            var ruleName;

            if (currentPiece.currentScaleRule == "changeScale") {
                rule = cssRuleChangeScaleBack;
                ruleName = "changeScaleBack";
                currentPiece.currentScaleRule = "changeScaleBack";
            }
            else {
                rule = cssRuleChangeScale;
                ruleName = "changeScale";
                currentPiece.currentScaleRule = "changeScale";
            }

            resetCssRule(elem, ruleName, rule, oldScale, currentPiece.currentCssScaleValue, ".1s");
        }
        elem.style.left = leftRect - boardOffsetLeft - (width / 2) + "px";
        elem.style.zIndex = Math.round(topRect);
        elem.style.top = topRect - boardOffsetTop - height + ((height - scaledHeight) / 2) + 15 + "px";
    }
})();
