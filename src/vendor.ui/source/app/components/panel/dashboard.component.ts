/// <reference path="../../common/models/product.model.ts" />
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ProductService } from '../../services/product.service';
import { Product } from '../../common/models/product.model';

@Component({
    moduleId: module.id,
    selector: 'my-dashboard',
    templateUrl: './app/components/panel/dashboard.component.html',
    styleUrls: ['./app/components/panel/dashboard.component.css']
})
export class DashboardComponent implements OnInit{

    constructor(private router: Router, private productService: ProductService) {
        // tslint:disable-next-line:quotemark
        let hte = "hellow world";
    }

    products: Product[] = [];

    ngOnInit(): void {
        //this.productService.getProducts()
        //    .then((products: Product[]) => this.products = products);// products.slice(1, 5)
    }

    gotoDetail(product: Product): void {
        let link = ['/detail', product.id];
        this.router.navigate(link);
    }
}