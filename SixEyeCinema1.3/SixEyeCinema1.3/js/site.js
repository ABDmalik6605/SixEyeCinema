// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var button = document.getElementById("log_out");
button.onclick = function () {

    if (1) {
        Session["name"] = null;
        Session["email"] = null;
        Session["age"] = null;
        Session["username"] = null;
        Session["pass"] = null;
        Session.close();
    }

};