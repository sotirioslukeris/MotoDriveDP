document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".dropdown").forEach(function (dropdown) {
        const btn = dropdown.querySelector("#dropdown-btn");
        const menu = dropdown.querySelector(".dropdown-menu");

        btn.addEventListener("click", function (e) {
            e.preventDefault();
            menu.classList.toggle("show");
        });
    });
});


    
