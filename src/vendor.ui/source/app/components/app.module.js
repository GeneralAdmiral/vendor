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
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
var forms_1 = require('@angular/forms');
var http_1 = require('@angular/http');
var material_1 = require('@angular/material');
var angular_in_memory_web_api_1 = require('angular-in-memory-web-api');
var in_memory_data_service_1 = require('../services/in-memory-data.service');
var app_component_1 = require('./app.component');
var product_detail_component_1 = require('./product/product-detail.component');
var product_service_1 = require('../services/product.service');
var product_component_1 = require('./product/product.component');
var dashboard_component_1 = require('./panel/dashboard.component');
var product_search_component_1 = require('./product/product-search.component');
var router_1 = require('../router');
require('./rxjs-extensions');
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule(({
            imports: [platform_browser_1.BrowserModule, forms_1.FormsModule, router_1.routing, angular_in_memory_web_api_1.InMemoryWebApiModule.forRoot(in_memory_data_service_1.InMemoryDataService), http_1.HttpModule, material_1.MaterialModule.forRoot()],
            declarations: [app_component_1.AppComponent, product_component_1.ProductComponent, product_detail_component_1.ProductDetailComponent, dashboard_component_1.DashboardComponent, product_search_component_1.ProductSearchComponent],
            providers: [product_service_1.ProductService],
            bootstrap: [app_component_1.AppComponent]
        })), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map