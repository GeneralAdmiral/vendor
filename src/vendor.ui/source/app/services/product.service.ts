/// <reference path="../common/models/product.model.ts" />
import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { Product } from '../common/models/product.model';
import { ProductLanguage } from '../common/models/many_to_many/product.language.model';
import { ResultProduct } from '../common/models/result/product.result';


@Injectable()
export class ProductService {

    private productsUrl = 'product';  // url to web api
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }


    getProducts(): Promise<Product[]> {
        const url: string = `${this.productsUrl}/list`;
        return this.http.get(url)
            .toPromise()
            .then((response: Response) => response.json().data as Product[])
            .catch(this.handleError);
    }

    // getProductsSlowly(): Promise<Product[]> {
    //     return new Promise<Product[]>((resolve) =>
    //         setTimeout(resolve, 2000)) // delay 2 seconds
    //         .then(() => this.getProducts());
    // }

    getProduct(id: number): Promise<Product> {
        let prs: Product[] = [];
        const url: string = `${this.productsUrl}/list`;
        let pr = this.http.get(url)
            .toPromise()
            .then((response: Response) => response.json().data as Product)
            .catch(this.handleError);
        return pr;
        // return this.getProducts()
        //    .then((products: Product[]) => products.find((product: Product) => product.id === id));
    }

    delete(id: number): Promise<void> {
        const url: string = `${this.productsUrl}/${id}`;
        return this.http
            .delete(url, { headers: this.headers })
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    update(product: Product): Promise<Product> {
        const url: string = `${this.productsUrl}/${product.id}`;
        return this.http
            .put(url, JSON.stringify(product), { headers: this.headers })
            .toPromise()
            .then(() => product)
            .catch(this.handleError);
    }

    create(name: string): Promise<ResultProduct> {
        return this.http
            .post(this.productsUrl, JSON.stringify(this.set())
            , { headers: this.headers })
            .toPromise()
            .then((response: Response) => {
                let pr = response.json() as ResultProduct;
                return pr;
            })
            .catch(this.handleError);
    }

    private set(): Product {
        let product = new Product();
        product.image = [];
        let lang: ProductLanguage = new ProductLanguage();
        lang.description = 'Test Prodct';
        lang.name = 'Tester';
        lang.languageId = 0;
        lang.parentId = lang.userUpdateId = 0;
        // lang.update = Date.now.toString();
        product.productLanguages.push(lang);
        return product;
    }

    setTime(d: Date) {
        let currentTime = d;
    }
}