$(document).ready(function () {

    $("#inputUser").keypress(function () {
        $("#message").empty();
    });

    $("#inputPassword").keypress(function () {
        $("#message").empty();
    });

    setTimeout(function () {
        document.getElementById("message").style.display = "none";
    }, 4000);

}); // End document ready
