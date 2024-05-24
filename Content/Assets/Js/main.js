function updateCartStatus(itemsCount) {
    $("#cartItemsCount")[0].innerHTML = itemsCount;
}

//$("#goToCartLink").on('click', function () {
//    debugger
//    fetch("/Product/GetCart", {
//        method: "POST",
//        headers: {
//            'Content-Type': 'application/json'
//        },
//        body: JSON.stringify(cart)
//    })
//});

var cart = JSON.parse(localStorage.getItem("cart")) ? JSON.parse(localStorage.getItem("cart")) : { "totalItems": 0, "products": {} };
updateCartStatus(JSON.parse(localStorage.getItem("cart")) ? JSON.parse(localStorage.getItem("cart"))["totalItems"]:0);
console.log('success load')
let ProductsDataTblInstance = $("#products_table").DataTable(
            {
                "ajax": {
                    "url": "/Product/GetPagedProducts",
                    "type": "POST"
                },
                "serverSide": true,
                "processing": true,
                "searchable": true,
                "order": [],
                "language": {
                    "emptyTable": "No Products Available......"
                },
                "columns": [
                    {
                        data: "product_id",
                        "autoWidth": true,
                        "searchable": true
                    },
                    {
                        data: "product_name",
                        "autoWidth": true,
                        "orderable": true
                    },
                    {
                        data: "product_price",
                        "autoWidth": true,
                        "orderable": true
                    },
                    {
                        data: null,
                        "render": function (data, type, row) {
                            row.productId = row.product_id;
                            row.productPrice = row.product_price;
                            row.productName = row.product_name;
                            return "<button class='btn btn-small btn-primary btn-addtocart'>Add to cart</button>"
                        },
                        "sorting": false
                    }
                ]
            }
        );

ProductsDataTblInstance.on('draw', function () {
            $(".btn-addtocart").each(function (index, btn) {
                console.log(btn)
                $(btn).on('click', function (event) {
                    debugger
                    let product_id = ProductsDataTblInstance.row($(event.target.parentElement.parentElement)).data().productId;
                    let product_price = ProductsDataTblInstance.row($(event.target.parentElement.parentElement)).data().productPrice;
                    let product_name = ProductsDataTblInstance.row($(event.target.parentElement.parentElement)).data().productName;

                    if (cart["products"][product_id]) {
                            debugger
                        cart["products"][product_id]["quantity"]++;
                        cart["totalItems"]++;
                        } else {
                        cart["products"][product_id] = {
                            "productId": product_id,
                            "quantity": 1,
                            "productPrice": product_price,
                            "productName": product_name
                        }
                        cart["totalItems"]++;
                        }
                    localStorage.setItem("cart", JSON.stringify(cart));
                    updateCartStatus(cart["totalItems"]);
                })
            })
        });