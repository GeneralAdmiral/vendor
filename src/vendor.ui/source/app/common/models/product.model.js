"use strict";
var user_model_1 = require('./user.model');
var Product = (function () {
    function Product() {
        this.update = new Date();
        this.productLanguages = [];
        this.userProducts = [];
        this.userUpdate = new user_model_1.User();
    }
    return Product;
}());
exports.Product = Product;
//# sourceMappingURL=product.model.js.map