window.showBanner = (selector, message, type) => {
    const bannersContainer = document.querySelector(".banners-container");

    const banner = document.createElement("div");
    banner.classList.add("banner", type);
    banner.innerHTML = `
        <div class="banner-icon"><i data-eva="checkmark-circle-outline" data-eva-fill="#ffffff" data-eva-height="48" data-eva-width="48"></i></div>
        <div class="banner-message">${message}</div>
        <div class="banner-close" onclick="hideBanner(this.parentNode)"><i data-eva="close-outline" data-eva-fill="#ffffff"></i></div>
    `;

    bannersContainer.appendChild(banner);

    requestAnimationFrame(() => {
        banner.classList.add("visible");

        setTimeout(() => {
            banner.classList.add("closing");
            setTimeout(() => {
                banner.classList.remove("visible", "closing");
                bannersContainer.removeChild(banner);
            }, 600); // Animation duration (adjust as needed)
        }, 3000); // Show duration (adjust as needed)
    });
};

let flickityInstance;
function initializeFlickityOnElement(selector) {
    var carouselElem = document.querySelector(selector);
    if (carouselElem) {
        if (flickityInstance) {
            flickityInstance.destroy();
        }
        flickityInstance = new Flickity(carouselElem, {
            wrapAround: true
        });
    }
}

document.addEventListener('DOMContentLoaded', function () {
    initializeFlickityOnElement('.main-carousel');
});

window.reinitializeFlickity = function () {
    initializeFlickityOnElement('.main-carousel');
};

function toggleMobileMenu(menu) {
    console.log("Toggling mobile menu");
    var isOpen = menu.classList.contains('hamburger-open');
    menu.classList.toggle('hamburger-open');
    document.body.style.overflowY = isOpen ? 'auto' : 'hidden';
}

function closeMobileMenu() {
    console.log("Closing mobile menu");
    var menu = document.querySelector('.hamburger-icon');
    if (menu.classList.contains('hamburger-open')) {
        menu.classList.remove('hamburger-open');
        document.body.style.overflowY = 'auto'; 
    }
}

function focusInputText(element) {
    console.log("Focusing input text");
    setTimeout(function () {
        var inputElement = document.querySelector(element);
        if (inputElement) {
            inputElement.focus();
        }
    }, 10);
}

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

window.SetSessionStorage = (key, data) => {
    return sessionStorage.setItem(key, data);
}

window.GetSessionStorage = (key) => {
    return sessionStorage.getItem(key);
}