
//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});
//Load Data function
function loadData() {    
    $.ajax({
        url: "/Home/GetList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",        
        success: function (result) { 
            $('#tasksList').html('');
            var html = '';            
            $.each(result, function (key, item) {
                document.getElementById('newTask').value = "";
                if (item.isDeleted) {
                    html += '<div class="tasksItem">';
                    html += '<input type="checkbox" disabled="disabled" checked id="chk+' + item.id + '" class="chkTodo">'
                    html += '<div class="vertListLine"></div>';
                    html += '<div class="textArea"><input type="text" readonly="readonly" id="taskNameDeleted" class="taskTextDeleted" value="' + item.name + '"></div>';
                    html += '<div class="trashDiv">';
                    html += '<i style="font-size:24px" id="trash' + item.id + '" class="gg-trash"></i>';
                    html += '</div>';
                    html += '<div class="upperlowerDiv">';
                    if (item.priority != 1) {
                        html += '<a href="" onclick="ChangeUp(' + item.id + ')">'
                        html += '<i class="arrow up" id="arrowUp' + item.id + '"></i>';
                        html += '</a>';
                    }
                    if (item.priority != result.length) {
                        html += '<a href="" onclick="ChangeDown(' + item.id + ')">'
                        html += '<i class="arrow down" style="opacity:0px;" id="arrowDown' + item.id + '"></i>';
                        html += '</a>';
                    }
                    html += '</div>';
                    html += '</div>';
                }
                else {
                    html += '<div class="tasksItem">';
                    html += '<input type="checkbox" disabled="disabled" id="chk+' + item.id + '" class="chkTodo">'
                    html += '<div class="vertListLine"></div>';
                    html += '<div class="textArea"><input type="text" readonly="readonly" id="taskName" class="taskeTxt" value="' + item.name + '"></div>';
                    html += '<div class="trashDiv">';
                    html += '<a href="" onclick="Delete('+item.id+')">'
                    html += '<i style="font-size:24px" id="trash' + item.id + '" class="gg-trash"></i>';
                    html += '</a>';
                    html += '</div>';
                    html += '<div class="upperlowerDiv">';
                    if (item.priority != 1) {
                        html += '<a href="" onclick="ChangeUp(' + item.id + ')">'
                        html += '<i class="arrow up" id="arrowUp' + item.id + '"></i>';
                        html += '</a>';
                    }
                    if (item.priority != result.length) {                        
                        html += '<a href="" onclick="ChangeDown(' + item.id + ')">'
                        html += '<i class="arrow down" style="opacity:0px;" id="arrowDown' + item.id + '"></i>';
                        html += '</a>';
                    }
                    html += '</div>';
                    html += '</div>';
                }
            });
            $('#tasksList').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data function
function AddNew() {
    var name = $('#newTask').val();
    $.ajax({
        url: "/Home/AddToDo",
        data: { 'input':name},
        type: "POST",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Delete a task
function Delete(id) {    
    $.ajax({
        url: "/Home/Delete",
        data: { 'input': id },
        type: "POST",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Downgrade the priority of a task
function ChangeDown(id) {
    
    $.ajax({
        url: "/Home/DownwardsPriority",
        data: { 'input': id },
        type: "POST",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Upgrade the priority of a task
function ChangeUp(id) {
    
    $.ajax({
        url: "/Home/UpwardsPriority",
        data: { 'input': id },
        type: "POST",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}