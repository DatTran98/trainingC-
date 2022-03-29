var isShift = false;

function keyUP(keyCode) {

    if (keyCode == 16)

        isShift = false;

}
function isNumeric(keyCode) {

    if (keyCode == 16)

        isShift = true;

    return ((keyCode >= 48 && keyCode <= 57 || keyCode == 8 ||

        (keyCode >= 96 && keyCode <= 105)) && isShift == false);

}
function isAlpha(keyCode) {

    return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8)

}
function isAlphaNumeric(keyCode) {

    return (((keyCode >= 48 && keyCode <= 57) && isShift == false) ||

        (keyCode >= 65 && keyCode <= 90) || keyCode == 8 ||

        (keyCode >= 96 && keyCode <= 105))

}
function showModal() {
    $("#modal").modal("show");
}
function Validate() {
    var isValid = true;

    var tblForm = document.getElementById("tblForm");

    var inputs = document.getElementsByTagName("input");
    var dropView = document.getElementById("NewJob");
    var selectedValue = dropView.value

    for (var i = 0; i < inputs.length; i++) {

        if (inputs[i].type == "text") {
            if (Trim(inputs[i].value) == "" && inputs[i].className.indexOf("required") != 1) {
                isValid = false;
                ShowHideError(inputs[i], "block");
                inputs[i].value = "";
            } else {
                ShowHideError(inputs[i], "none");
            }
        }
    }
    if (selectedValue == "") {
        isValid = false
        document.getElementById("errorDropDown").style.display = "block";
    } else {
        document.getElementById("errorDropDown").style.display = "none";
    }
    return isValid;
};

function ShowHideError(textbox, display) {
    var row = textbox.parentNode.parentNode;
    var errorMsg = row.getElementsByTagName("span")[0];
    if (errorMsg != null) {
        errorMsg.style.display = display;
    }
};

function Trim(value) {
    return value.replace(/^\s+|\s+$/g, '');
};
function showMessge() {
    document.getElementById("MessageAdd").innerHTML = "1234578";

    setTimeout(function () {
        document.getElementById("MessageAdd").innerHTML = '';
    }, 3000);
};