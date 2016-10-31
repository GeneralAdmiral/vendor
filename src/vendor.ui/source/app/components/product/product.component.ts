/// <reference path="../../common/models/product.model.ts" />
import { Component, Input, OnInit } from "@angular/core";
import { Router } from '@angular/router';

import { Product } from "../../common/models/product.model";
import { ProductService } from "../../services/product.service"


@Component({
    moduleId: module.id,
    selector: "my-product",
    templateUrl: "product.component.html",
    styleUrls: ["product.component.css"],
    providers: [ProductService]
})
export class ProductComponent implements OnInit {

    products: Product[];

    selectedProduct: Product;

    constructor(private router: Router, private productService: ProductService) { }

    getProducts(): void {
        this.productService.getProducts().then((products: Product[]) => this.products = products);
    }

    onSelect(product: Product): void {
        this.selectedProduct = product;
    }

    ngOnInit(): void {
        this.productService.getProducts().then(pr => this.products = pr);
    }

    gotoDetail(): void {
        this.router.navigate(['/detail', this.selectedProduct.id]);
    }

    add(name: string): void {
        name = name.trim();
        if (!name) { return; }
        this.productService
            .create(name)
            .then(product => {
                this.products.push(product);
                this.selectedProduct = null;
            });
    }


    delete(product: Product): void {
        this.productService
            .delete(product.id)
            .then(() => {

                this.products = this.products.filter(h => h !== product);

                if (this.selectedProduct === product) {

                    this.selectedProduct = null;
                }
            });
    }
}

