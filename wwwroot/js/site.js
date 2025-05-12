document.addEventListener("DOMContentLoaded", function () {
    const dropdownBtn = document.getElementById("dropdown-btn");
    const dropdownMenu = dropdownBtn.nextElementSibling;

    dropdownBtn.addEventListener("click", function (e) {
        e.preventDefault();
        dropdownMenu.classList.toggle("show");
    });
});


