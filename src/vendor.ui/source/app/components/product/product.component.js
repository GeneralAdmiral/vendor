"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
/// <reference path="../../common/models/product.model.ts" />
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var product_service_1 = require('../../services/product.service');
var ProductComponent = (function () {
    function ProductComponent(router, productService) {
        this.router = router;
        this.productService = productService;
        this.products = [];
    }
    // getProducts(): void {
    //    this.productService.getProducts().then((products: Product[]) => this.products = products);
    // }
    ProductComponent.prototype.onSelect = function (product) {
        this.selectedProduct = product;
    };
    ProductComponent.prototype.ngOnInit = function () {
        // this.productService.getProducts().then(pr => this.products = pr);
    };
    ProductComponent.prototype.gotoDetail = function () {
        this.router.navigate(['/detail', this.selectedProduct.id]);
    };
    ProductComponent.prototype.add = function (name) {
        var _this = this;
        name = name.trim();
        if (!name) {
            return;
        }
        this.productService
            .create(name)
            .then(function (result) {
            _this.products.push(result.results[0]);
            _this.selectedProduct = null;
        });
    };
    ProductComponent.prototype.delete = function (product) {
        var _this = this;
        this.productService
            .delete(product.id)
            .then(function () {
            _this.products = _this.products.filter(function (h) { return h !== product; });
            if (_this.selectedProduct === product) {
                _this.selectedProduct = null;
            }
        });
    };
    ProductComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'my-product',
            templateUrl: './app/components/product/product.component.html',
            styleUrls: ['./app/components/product/product.component.css'],
            providers: [product_service_1.ProductService]
        }), 
        __metadata('design:paramtypes', [router_1.Router, product_service_1.ProductService])
    ], ProductComponent);
    return ProductComponent;
}());
exports.ProductComponent = ProductComponent;
//# sourceMappingURL=product.component.js.map