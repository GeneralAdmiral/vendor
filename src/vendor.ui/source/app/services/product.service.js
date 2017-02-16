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
/// <reference path="../common/models/product.model.ts" />
var core_1 = require('@angular/core');
var http_1 = require('@angular/http');
require('rxjs/add/operator/toPromise');
var product_model_1 = require('../common/models/product.model');
var product_language_model_1 = require('../common/models/many_to_many/product.language.model');
var ProductService = (function () {
    function ProductService(http) {
        this.http = http;
        this.productsUrl = 'product'; // url to web api
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
    }
    ProductService.prototype.handleError = function (error) {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    };
    ProductService.prototype.getProducts = function () {
        var url = this.productsUrl + "/list";
        return this.http.get(url)
            .toPromise()
            .then(function (response) { return response.json().data; })
            .catch(this.handleError);
    };
    // getProductsSlowly(): Promise<Product[]> {
    //     return new Promise<Product[]>((resolve) =>
    //         setTimeout(resolve, 2000)) // delay 2 seconds
    //         .then(() => this.getProducts());
    // }
    ProductService.prototype.getProduct = function (id) {
        var prs = [];
        var url = this.productsUrl + "/list";
        var pr = this.http.get(url)
            .toPromise()
            .then(function (response) { return response.json().data; })
            .catch(this.handleError);
        return pr;
        // return this.getProducts()
        //    .then((products: Product[]) => products.find((product: Product) => product.id === id));
    };
    ProductService.prototype.delete = function (id) {
        var url = this.productsUrl + "/" + id;
        return this.http
            .delete(url, { headers: this.headers })
            .toPromise()
            .then(function () { return null; })
            .catch(this.handleError);
    };
    ProductService.prototype.update = function (product) {
        var url = this.productsUrl + "/" + product.id;
        return this.http
            .put(url, JSON.stringify(product), { headers: this.headers })
            .toPromise()
            .then(function () { return product; })
            .catch(this.handleError);
    };
    ProductService.prototype.create = function (name) {
        return this.http
            .post(this.productsUrl, JSON.stringify(this.set()), { headers: this.headers })
            .toPromise()
            .then(function (response) {
            var pr = response.json();
            return pr;
        })
            .catch(this.handleError);
    };
    ProductService.prototype.set = function () {
        var product = new product_model_1.Product();
        product.image = [];
        var lang = new product_language_model_1.ProductLanguage();
        lang.description = 'Test Prodct';
        lang.name = 'Tester';
        lang.languageId = 0;
        lang.parentId = lang.userUpdateId = 0;
        // lang.update = Date.now.toString();
        product.productLanguages.push(lang);
        return product;
    };
    ProductService.prototype.setTime = function (d) {
        var currentTime = d;
    };
    ProductService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ProductService);
    return ProductService;
}());
exports.ProductService = ProductService;
//# sourceMappingURL=product.service.js.map