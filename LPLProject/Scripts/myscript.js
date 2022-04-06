

function fetch() {
    var get = document.getElementById("range").value;
    document.getElementById("getvalue").value = get;

}
function fetchtask() {
    var get = document.getElementById("rangenew").value;
    document.getElementById("getnewvalue").value = get;

}


$(document).ready(function () {
    //$(function () {
    //    $('input[type=range]').val();
    //});
    $("#btnsubmit").click(function ()
    {
        var data = $("#myform").serialize();
        $.ajax({
            type: "POST",
            url: "/Home/add_project",
            data: data
        })
    })
    
});
function fetch() {
    var get = document.getElementById("range").value;
    document.getElementById("getvalue").value = get;

}
$('#getpassword, #confirm_password').on('keyup', function () {
    if ($('#getpassword').val() == $('#confirm_password').val()) {
        $('#message').html('Matching').css('color', 'green');
    } else
        $('#message').html('Not Matching').css('color', 'red');
});
function BtnClick() {
    var id = $("#getid").val();
    var fname = $("#getfirstname").val();
    var lname = $("#getlastname").val();
    var uname = $("#getusername").val();
    var pass = $("#getpassword").val();
    var cpass = $("#confirm_password").val();
    var obj = {
        emp_ID: id,
        first_Name: fname,

        last_Name: lname,
        Username: uname,
        Password: pass,
        confirm_Password:cpass
    }
    Submitform(obj)
}


function Submitform(obj) {
    $.ajax({
        url: "/Home/Partial_View",
        method: "POST",
        data: obj,
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
        },
        error: function (err) {
            console.error(err);
        }
    })
}
//function hideshow() {
//    $("#hide").click(function () {
//        $("#mydiv").hide();

//    });
//    $("#show").click(function () {
//        $("#mydiv").show();

//    });
//}
$(document).ready(function () {
    function Contains(text_one, text_two) {
        if (text_one.indexOf(text_two) != -1)
            return true;
    }
    $("#Search").keyup(function () {
        var searchtext = $("#Search").val().toLowerCase();
        $(".Search").each(function () {
            if (!Contains($(this).text().toLowerCase(), searchtext)) {
                $(this).hide();

            }
            else {
                $(this).show();
            }
        })
    })
})

//$(document).ready(function () {
//    //$(function () {
//    //    $('input[type=range]').val();
//    //});
//    $("#btnsubmit").click(function () {
//        var data = $("#myform").serialize();
//        $.ajax({
//            type: "POST",
//            url: "/Home/add_project",
//            data: data
//        })
//    })
//});