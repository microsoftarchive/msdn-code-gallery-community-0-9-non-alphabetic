(function () {

    "use strict"

    const None = 0;
    // states
    const Play = 1;
    const AddRemove = 2;
    const Spinning = 3;
    // tasks
    const RemovingPiece = 4;
    const GhostingPiece = 5;
    const ReachingPiece = 6;

    var currentState = None;
    var previousState = None;

    var currentTask = None;
    var previousTask = None;
    var removedPieceType = null;

    var states = new Set();
    states.add(None);
    states.add(Play);
    states.add(AddRemove);
    states.add(Spinning);

    var tasks = new Set();
    tasks.add(None);
    tasks.add(RemovingPiece);
    // Defines task in which we're selecting a hard-to-reach piece
    // during either game play or add-remove mode.
    tasks.add(GhostingPiece);
    tasks.add(ReachingPiece);

    function updateState(newState) {
        if (states.has(newState)) {
            // Allows user to alter post-rotation (i.e., previous)
            // state during a rotation.
            // ToDo: Test side effects, or take no action.
            if (currentState == Spinning) {
                previousState = newState;
            }
            else {
                previousState = currentState;
                currentState = newState;
            }
        }
        else {
            throw Error("bad state");
        }
    }

    function completedState(oldState) {
        if (states.has(oldState)) {
            if (oldState == Spinning) {
                // reset to pre-rotating state.
                currentState = previousState;
            }
            else {
                previousState = oldState;
                currentState = None;
            }
        }
        else {
            throw Error("bad state");
        }
    }

    function getState() {
        return currentState;
    }

    function isSpinning() {
        if (currentState == Spinning) {
            return true;
        }
        return false;
    }

    function isPlayMode() {
        if (currentState == Play) {
            return true;
        }
        return false;
    }

    function isAddRemoveMode() {
        if (currentState == AddRemove) {
            return true;
        }
        return false;
    }

    function updateTask(newTask, pieceType) {
        if (tasks.has(newTask)) {

            previousTask = currentTask;
            currentTask = newTask;

            if (pieceType != null) {
                removedPieceType = pieceType;
            }
        }
        // ToDo: Remove from final code.
        else {
            throw Error("bad task");
        }
    }

    function completedTask(oldTask) {
        if (tasks.has(oldTask)) {
            previousTask = currentTask;
            currentTask = None;
        }
        else {
            throw Error("bad task");
        }
    }

    function getTask() {
        return currentTask;
    }

    function getRemovedPieceType() {
        return removedPieceType;
    }

    var members = {
        // state and task constants
        None: None,
        Play: Play,
        AddRemove: AddRemove,
        Spinning: Spinning,
        RemovingPiece: RemovingPiece,
        GhostingPiece: GhostingPiece,
        ReachingPiece: ReachingPiece,
        // functions
        updateState: updateState,
        completedState: completedState,
        getState: getState,
        isSpinning: isSpinning,
        isPlayMode: isPlayMode,
        isAddRemoveMode: isAddRemoveMode,
        updateTask: updateTask,
        completedTask: completedTask,
        getRemovedPieceType: getRemovedPieceType,
        getTask: getTask
    }

    WinJS.Namespace.define("State", members);

})();