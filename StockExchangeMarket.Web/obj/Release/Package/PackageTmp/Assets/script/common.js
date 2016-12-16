var uri = '/StockExchangeMarket.Web';
function displaySignUpModal() {
    var renderedData = new EJS({ url: uri + '/Templates/Register.ejs' }).render({ open: 1 });
    $(renderedData).modal('show');
}

function registerUser(argGuid) {
    var username = $('#regUsername' + argGuid).val();
    var pass = $('#regPass' + argGuid).val();
    var passAgain = $('#regPassAgain' + argGuid).val();
    $('#registerButton' + argGuid).addClass('disabled');
    checkUsernameAndPassword(username, pass, function () {
        if (passAgain == pass) {
            $.ajax({
                type: "POST",
                url: uri + "/Services/RegisterService.asmx/Register",
                data: '{ argUsername: "' + username + '", argPassword: "' + pass + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    location.href = "stock.html";
                },
                error: function (msg) {
                    alert(jQuery.parseJSON(msg.responseText).Message);
                },
                complete: function () {
                    $('#registerButton' + argGuid).removeClass('disabled');
                }
            });
        } else {
            alert('Passwords are not matched.');
            $('#registerButton' + argGuid).removeClass('disabled');
        }
    }, '#registerButton' + argGuid);
}

function loginUser() {
    var username = $('#loginUsername').val();
    var pass = $('#loginPassword').val();
    $('#loginButton').addClass('disabled');
    checkUsernameAndPassword(username, pass, function () {
        $.ajax({
            type: "POST",
            url: uri + "/Services/LoginService.asmx/Login",
            data: '{ argUsername: "' + username + '", argPassword: "' + pass + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                location.href = "stock.html";
            },
            error: function (msg) {
                alert(jQuery.parseJSON(msg.responseText).Message);
            },
            complete: function () {
                $('#loginButton').removeClass('disabled');
            }
        });
    }, '#loginButton');
}

function checkUsernameAndPassword(argUsername, argPassword, argSuccessMethod, argElementId) {
    if (argUsername.length > 0) {
        if (argPassword.length >= 6) {
            argSuccessMethod();
        } else {
            alert('Please enter a valid Password. (Passwords can be at least 6 character)');
            $(argElementId).removeClass('disabled')
        }
    } else {
        alert('Please enter a valid Username.');
        $(argElementId).removeClass('disabled')
    }
}

function logoutUser() {
    $.ajax({
        type: "POST",
        url: uri + "/Services/LoginService.asmx/Logout",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            location.href = "index.html";
        },
        error: function (msg) {
            alert(jQuery.parseJSON(msg.responseText).Message);
        }
    });
}