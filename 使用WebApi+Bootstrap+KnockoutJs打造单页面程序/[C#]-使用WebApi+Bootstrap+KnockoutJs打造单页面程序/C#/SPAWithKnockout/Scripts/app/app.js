
var taskListViewModel = {
    tasks: ko.observableArray(),
    canCreate:ko.observable(true)
};

var taskModel = function () {
    this.id = 0;
    this.name = ko.observable();
    this.description = ko.observable();
    this.finishTime = ko.observable();
    this.owner = ko.observable();
    this.state = ko.observable();
    this.fromJS = function(data) {
        this.id = data.id;
        this.name(data.name);
        this.description(data.description);
        this.finishTime(data.finishTime);
        this.owner(data.owner);
        this.state(data.state);
    };
};

function getAllTasks() {
    sendAjaxRequest("GET", function (data) {
        taskListViewModel.tasks.removeAll();
        for (var i = 0; i < data.length; i++) {
            taskListViewModel.tasks.push(data[i]);
        }
    }, 'GetByState', { 'state': 'all' });
}

function setTaskList(state) {
    sendAjaxRequest("GET", function(data) {
        taskListViewModel.tasks.removeAll();
        for (var i = 0; i < data.length; i++) {
            taskListViewModel.tasks.push(data[i]);
        }},'GetByState',{ 'state': state });
}

function remove(item) {
    sendAjaxRequest("DELETE", function () {
        getAllTasks();
    }, item.id);
}

var task = new taskModel();

function handleCreateOrUpdate(item) {
    task.fromJS(item);
    initDatePicker();
    taskListViewModel.canCreate(false);
    $('#create').css('visibility', 'visible');
}

function handleBackClick() {
    taskListViewModel.canCreate(true);
    $('#create').css('visibility', 'hidden');
}

function handleSaveClick(item) {
    if (item.id == undefined) {
        sendAjaxRequest("POST", function (newItem) { //newitem是返回的对象。
            taskListViewModel.tasks.push(newItem);
        }, null, {
            name: item.name,
            description: item.description,
            finishTime: item.finishTime,
            owner: item.owner,
            state: item.state
        });
    } else {
        sendAjaxRequest("PUT", function () {
            getAllTasks();
        }, null, {
            id:item.id,
            name: item.name,
            description: item.description,
            finishTime: item.finishTime,
            owner: item.owner,
            state: item.state
        });
    }
    
    taskListViewModel.canCreate(true);
    $('#create').css('visibility', 'hidden');
}
function sendAjaxRequest(httpMethod, callback, url, reqData) {
    $.ajax("/api/tasks" + (url ? "/" + url : ""), {
        type: httpMethod,
        success: callback,
        data: reqData
    });
}

var initDatePicker = function() {
    $('#create .datepicker').datepicker({
        autoclose: true
    });
};

$('.nav').on('click', 'li', function() {
    $('.nav li.active').removeClass('active');
    $(this).addClass('active');
});

$(document).ready(function () {
    getAllTasks();
    // 使用KnockoutJs进行绑定
    ko.applyBindings(taskListViewModel, $('#list').get(0));
    ko.applyBindings(task, $('#create').get(0));
});


