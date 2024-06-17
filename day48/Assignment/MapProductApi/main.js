document.addEventListener("DOMContentLoaded", () => {
    var Container = document.getElementById("product_list");

    const FetchProduct = async () => {
        try {
            const res = await fetch("https://dummyjson.com/products");
            const data = await res.json();
            return data.products;
        } catch (err) {
            console.log(err);
        }
    };

    const displayProducts = async () => {
        var product_list = await FetchProduct();
        console.log(product_list);

        product_list.forEach((product) => {
            var productCard = document.createElement("div");
            productCard.className = "w-full sm:w-1/2 md:w-1/2 xl:w-1/4 p-4";
            productCard.innerHTML = `        
            <div class="card bg-white shadow-lg rounded-lg overflow-hidden h-full flex flex-col">
                <div class="relative">
                    <img src="${product.thumbnail}" alt="${product.title}" class="w-full h-48 md:h-56 object-cover">
                    <div class="absolute top-0 right-0 p-2 bg-white bg-opacity-50 rounded-bl-lg">
                        <span class="text-xs text-gray-500">${product.category}</span>
                    </div>
                </div>
                <div class="p-4 flex-grow flex flex-col">
                    <h2 class="text-xl font-semibold mb-2">${product.title}</h2>
                    <p class="text-gray-500 mb-4 flex-grow">${product.description}</p>
                    <div class="mt-auto">
                        <span class="text-xl font-semibold text-gray-400 line-through mr-2">${product.price.toFixed(2)} ₹</span> 
                        <span class="text-xl font-semibold text-gray-500">${(product.price - (product.price * product.discountPercentage / 100)).toFixed(2)} ₹</span>
                        <button class="bg-blue-500 text-white px-4 py-2 rounded-lg float-right mt-2" id="show-more">Show More</button>
                    </div>
                </div>
            </div> 
        `;
            Container.appendChild(productCard);
        });
    };

    displayProducts();
});
