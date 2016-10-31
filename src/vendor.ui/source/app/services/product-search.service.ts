import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs";

import { Product } from "../common/models/product.model";

@Injectable()
export class ProductSearchService {

    constructor(private http: Http) { }

    search(term: string): Observable<Product[]> {
        let result = this.http
            .get(`app/products/?name=${term}`)
            .map((r: Response) => r.json().data as Product[]);
        return result;
    }
}