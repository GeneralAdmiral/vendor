/// <reference path="../../common/models/product.model.ts" />
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { ProductService } from "../../services/product.service";
import { Product } from "../../common/models/product.model";

@Component({
    moduleId: module.id,
    selector: "my-dashboard",
    templateUrl: "dashboard.component.html",
    styleUrls: ["dashboard.component.css"]
})
export class DashboardComponent implements OnInit{

    constructor(private router: Router, private productService: ProductService) {

    }

    products: Product[] = [];

    ngOnInit(): void {
        this.productService.getProducts()
            .then((products: Product[]) => this.products = products.slice(1, 5));
    }

    gotoDetail(product: Product): void {
        let link = ["/detail", product.id];
        this.router.navigate(link);
    }
}