// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateControl(value, idValidationMessage) {
    var vm = $("#" + idValidationMessage + "");
    if (value.trim().length == 0) {
        vm.css('display', 'inline');
        return true;
    } else {
        vm.css('display', 'none');
        return false;
    }
};