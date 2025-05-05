document.addEventListener("DOMContentLoaded", function () {
    const dropdownBtn = document.querySelector(".dropdown-btn");
    const dropdownMenu = document.querySelector(".dropdown-menu");

    dropdownBtn.addEventListener("click", function (event) {
        event.stopPropagation();
        dropdownMenu.style.display =
            dropdownMenu.style.display === "block" ? "none" : "block";
        dropdownBtn.classList.toggle("active");
    });


    document.addEventListener("click", function (event) {
        if (!dropdownMenu.contains(event.target) && !dropdownBtn.contains(event.target)) {
            dropdownMenu.style.display = "none";
            dropdownBtn.classList.remove("active");
        }
    });
});

let slideIndex = 0;

