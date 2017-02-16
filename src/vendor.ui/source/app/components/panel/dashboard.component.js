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
var DashboardComponent = (function () {
    function DashboardComponent(router, productService) {
        this.router = router;
        this.productService = productService;
        this.products = [];
        // tslint:disable-next-line:quotemark
        var hte = "hellow world";
    }
    DashboardComponent.prototype.ngOnInit = function () {
        //this.productService.getProducts()
        //    .then((products: Product[]) => this.products = products);// products.slice(1, 5)
    };
    DashboardComponent.prototype.gotoDetail = function (product) {
        var link = ['/detail', product.id];
        this.router.navigate(link);
    };
    DashboardComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'my-dashboard',
            templateUrl: './app/components/panel/dashboard.component.html',
            styleUrls: ['./app/components/panel/dashboard.component.css']
        }), 
        __metadata('design:paramtypes', [router_1.Router, product_service_1.ProductService])
    ], DashboardComponent);
    return DashboardComponent;
}());
exports.DashboardComponent = DashboardComponent;
//# sourceMappingURL=dashboard.component.js.map