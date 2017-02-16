/// <reference path="../../common/models/product.model.ts" />
import { Component, Input, OnInit, ElementRef } from '@angular/core';
import { Router } from '@angular/router';

import { Product } from '../../common/models/product.model';
import { ProductService } from '../../services/product.service';
import { ResultProduct } from '../../common/models/result/product.result';


@Component({
    moduleId: module.id,
    selector: 'my-product',
    templateUrl: './app/components/product/product.component.html',
    styleUrls: ['./app/components/product/product.component.css'],
    providers: [ProductService]
})
export class ProductComponent implements OnInit {

    products: Product[] = [];

    selectedProduct: Product;

    constructor(private router: Router, private productService: ProductService, private element: ElementRef) { }

    // getProducts(): void {
    //    this.productService.getProducts().then((products: Product[]) => this.products = products);
    // }

    onSelect(product: Product): void {
        this.selectedProduct = product;
    }

    ngOnInit(): void {
        // this.productService.getProducts().then(pr => this.products = pr);
    }

    gotoDetail(): void {
        this.router.navigate(['/detail', this.selectedProduct.id]);
    }

    changeListner(event) {
        var reader = new FileReader();
        var image = this.element.nativeElement.querySelector('.image');

        reader.onload = function (e) {
            var src = e.target.result;
            image.src = src;
        };

        reader.readAsDataURL(event.target.files[0]);
    }

    add(name: string): void {
          name = name.trim();
          if (!name) { return; }
          this.productService
              .create(name)
              .then((result: ResultProduct) => {
                  this.products.push(result.results[0]);
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

