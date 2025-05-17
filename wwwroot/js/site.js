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



    document.addEventListener("DOMContentLoaded", function () {
        const removeButtons = document.querySelectorAll(".remove-btn");

        removeButtons.forEach(button => {
        button.addEventListener("click", function () {
            const item = this.closest(".cart-item");
            item.remove();
            updateTotal();
        });
        });

    function updateTotal() {
        let total = 0;
    const items = document.querySelectorAll(".cart-item");

            items.forEach(item => {
                const priceText = item.querySelector("p:nth-of-type(2)").textContent;
    const price = parseFloat(priceText.replace("Цена: ", "").replace("лв", "").trim());
    total += price;
            });

    const summary = document.querySelector(".cart-summary");
    let totalElement = document.getElementById("total-price");

    if (!totalElement) {
        totalElement = document.createElement("p");
    totalElement.id = "total-price";
    summary.insertBefore(totalElement, summary.firstChild);
            }

    totalElement.textContent = "Обща сума: " + total.toFixed(2) + " лв";
        }

    updateTotal(); 
    });

