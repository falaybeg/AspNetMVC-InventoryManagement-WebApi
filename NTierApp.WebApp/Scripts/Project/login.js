$(document).ready(function () {

    $('#btnLogin').click(function () {
        $.ajax({
            // Post username, password & the grant type to /token
            url: '/Token',
            method: 'POST',
            contentType: 'application/json',
            data: {
                username: $('#username').val(),
                password: $('#password').val(),
                grant_type: 'password'
            },
            // When the request completes successfully, save the
            // access token in the browser session storage and
            // redirect the user to Data.html page. We do not have
            // this page yet. So please add it to the
            // EmployeeService project before running it
            success: function (response) {
                sessionStorage.setItem("accessToken", response.access_token);
                debugger;
                window.location.href = '/Home/Index';

                //window.location.href = "Data.html";
            },
            // Display errors if any in the Bootstrap alert <div>
            error: function (jqXHR) {
                $('#divErrorText').text(jqXHR.responseText);
                $('#divError').show('fade');
            }
        });

    });


    

});