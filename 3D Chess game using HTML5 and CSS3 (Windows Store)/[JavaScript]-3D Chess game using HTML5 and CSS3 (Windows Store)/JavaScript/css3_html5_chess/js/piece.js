(function () {

    "use strict"

    WinJS.Namespace.define("Game", {
        Piece: WinJS.Class.define(
            // Location object stores both location & location state.
            function pieceConstructor(id, type, row) {

                this.type = type;
                this.row = row;
                this.id = id;
                this.frameIdx = 0;
                this.scaleIdx = 0;
                this.imgHeight = 220; // default;
                this.frameTopValues = new Array(0, 0, 0);
                this.frameLeftValues = new Array(0, 0, 0);

                var typeInfo = getTypeImageInfo(type);

                this.img = typeInfo[0];
                this.imgHeight = typeInfo[1];
                this.imgWidth = typeInfo[2];
            })
    });

    // Gets image data for supported pieces.
    function getTypeImageInfo(t) {

        var typeInfo = new Array(3);

        switch (t) {
            case "queen":
                typeInfo[0] = "/images/queen_white.png";
                // Image height;
                // By setting h/w explicity, we avoid
                // request for h/w before image is rendered.
                // Optimization: use the offscreen images when adding a piece.
                // Currently, offscreen images are used only in <canvas> rotation.
                typeInfo[1] = 265;
                // Image width;
                typeInfo[2] = 114;
                break;
            case "bishop":
                typeInfo[0] = "/images/bishop_white.png";
                typeInfo[1] = 235;
                typeInfo[2] = 106;
                break;
            case "bishop_b":
                typeInfo[0] = "/images/bishop_black.png";
                typeInfo[1] = 230;
                typeInfo[2] = 112;
                break;
            case "knight":
                typeInfo[0] = "/images/knight_white.png";
                typeInfo[1] = 195;
                typeInfo[2] = 101;
                break;
            case "knight_b":
                typeInfo[0] = "/images/knight_black.png";
                typeInfo[1] = 195;
                typeInfo[2] = 100;
                break;
            case "pawn_b":
                typeInfo[0] = "/images/pawn_black.png";
                typeInfo[1] = 157;
                typeInfo[2] = 92;
                break;
            case "pawn":
                typeInfo[0] = "/images/pawn_white.png";
                typeInfo[1] = 157;
                typeInfo[2] = 94;
                break;
            default:
        }
        return typeInfo;
    }

    var pieceTypes = new Map();

    // Specifies currently supported piece types.
    function setPieceTypes() {

        pieceTypes.set("knight - white", "knight");
        pieceTypes.set("knight - black", "knight_b");
        pieceTypes.set("pawn - white", "pawn");
        pieceTypes.set("pawn - black", "pawn_b");
        pieceTypes.set("bishop - white", "bishop");
        pieceTypes.set("bishop - black", "bishop_b");
        pieceTypes.set("queen - white", "queen");

        return pieceTypes;
    }

    var members = {
        getTypeImageInfo: getTypeImageInfo,
        setPieceTypes: setPieceTypes
    }

    WinJS.Namespace.define("Pieces", members);

})();