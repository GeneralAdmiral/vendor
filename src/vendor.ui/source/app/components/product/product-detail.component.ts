/// <reference path="../../common/models/product.model.ts" />
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Location }                 from '@angular/common';

import { Product } from '../../common/models/product.model';
import { ProductService } from '../../services/product.service';

@Component({
    moduleId: module.id,
    selector: 'my-product-detail',
    templateUrl: './app/components/product/product-detail.component.html',
    styleUrls: ['./app/components/product/product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
    constructor(
        private productService: ProductService,
        private route: ActivatedRoute,
        private location: Location)
    {
    }

    @Input() product: Product;

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            let id = +params['id'];
            this.productService.getProduct(id).then((product: Product)=> this.product = product);
        });
    }

    goBack(): void {
        this.location.back();
    }

    save(): void {
        this.productService
            .update(this.product)
            .then(() => this.goBack());
    }
}