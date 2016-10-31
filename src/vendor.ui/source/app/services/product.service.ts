/// <reference path="../common/models/product.model.ts" />
import { Injectable } from "@angular/core";
import { Headers, Http, Response } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { Product } from "../common/models/product.model";

@Injectable()
export class ProductService {

    private productsUrl = "app/products";  // url to web api
    private headers = new Headers({ "Content-Type": "application/json" });

    constructor(private http: Http) { }

    private handleError(error: any): Promise<any> {
        console.error("An error occurred", error); // for demo purposes only
        return Promise.reject(error.message || error);
    }


    getProducts(): Promise<Product[]> {
        return this.http.get(this.productsUrl)
            .toPromise()
            .then((response: Response) => response.json().data as Product[])
            .catch(this.handleError);
    }

    getProductsSlowly(): Promise<Product[]> {
        return new Promise<Product[]>((resolve) =>
            setTimeout(resolve, 2000)) // delay 2 seconds
            .then(() => this.getProducts());
    }

    getProduct(id: number): Promise<Product> {
        return this.getProducts()
            .then((products: Product[]) => products.find((product: Product) => product.id === id));
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

    create(name: string): Promise<Product> {
        return this.http
            .post(this.productsUrl, JSON.stringify({ name: name }), { headers: this.headers })
            .toPromise()
            .then((res: Response)=> res.json().data)
            .catch(this.handleError);
    }
}