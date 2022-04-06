$(function () {
    ko.applyBindings(modelCreate);
});
var modelCreate = {
    emp_ID: ko.observable(),
    first_Name: ko.observable(),
    last_Name: ko.observable(),
    createemloyee: function () {
        try {
            $.ajax({
                url: '/Employees/Create',
                type: 'post',
                dataType: 'json',
                data: ko.toJSON(this), //Here the data wil be converted to JSON  
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/Home/Read/';
        }
    }
};  
function successCallback(data) {
    window.location.href = '/Home/Index/';
}

function errorCallback(err) {
    window.location.href = '/Home/Read/';
}  
$(function () {
    ko.applyBindings(modelCreate);
}); 