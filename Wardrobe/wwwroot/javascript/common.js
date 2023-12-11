﻿window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 5000 });
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 5000 });
    }
}

function focusInputText(element) {
    setTimeout(function () {
        var inputElement = document.querySelector(element);
        if (inputElement) {
            inputElement.focus();
        }
    }, 10);
}

window.toggleBodyOverflowY = (isChecked) => {
    document.body.style.overflowY = isChecked ? 'hidden' : 'auto';
};

// For _ProductFilter
let filterIsOpened;
let productFilterReference
window.setupOutsideClickListener = function (dotNetObjectReference, isChecked) {
    productFilterReference = dotNetObjectReference;
    filterIsOpened = isChecked;
    dotNetObjectReference.invokeMethodAsync('OutsideClickHandler');

    filterIsOpened = !filterIsOpened;
    document.body.style.overflowY = filterIsOpened ? 'hidden' : 'auto';
    document.getElementById('filter-toggle').checked = filterIsOpened;
}

document.addEventListener('click', function (event) {
    if (filterIsOpened) {
        let filterContent = document.querySelector('.filter-container__content');
        let dropdowns = document.querySelectorAll('.rz-popup');
        let isClickedInsideFilter = filterContent.contains(event.target);

        let isClickedInsideDropdown = Array.from(dropdowns).some(dropdown => dropdown.contains(event.target));

        if (!isClickedInsideFilter && !isClickedInsideDropdown) {
            productFilterReference.invokeMethodAsync('ToggleFilter');
        }
    }
});