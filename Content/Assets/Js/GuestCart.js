
let cart = JSON.parse(localStorage.getItem("cart")) ? JSON.parse(localStorage.getItem("cart")): null;


if (cart) {
    for (let key in cart["products"]) {
        let CurrentProduct = { ...cart["products"][key] };
        let ProductCartTemp = `<div class="card d-inline-block me-5" style="width: 18rem;">
          <div class="card-body">
            <h5 class="card-title">${CurrentProduct["productName"]}</h5>
            <p class="card-text">Product Quantity <input type="number" value="${CurrentProduct["quantity"]}"></p>
            <p class="card-text">Product Price <input type="text" value="${CurrentProduct["quantity"] * CurrentProduct["productPrice"]}" disabled></p>
            <a href="#" class="btn btn-primary" onclick="updateCart(this, ${cart[key]["productId"]})">Update</a>
            <a href="#" class="btn btn-danger" onclick="removeFromCart(this, ${cart[key]["productId"]})">Remove</a>
          </div>
        </div>`;
        $(".GuestCartContentWrapper").append(ProductCartTemp);
    }
}

function updateCart(target, productId) {
    
}