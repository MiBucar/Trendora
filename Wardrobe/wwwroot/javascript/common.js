function focusInputText(element) {
    setTimeout(function () {
        var inputElement = document.querySelector(element);
        if (inputElement) {
            inputElement.focus();
        }
    }, 10);
}