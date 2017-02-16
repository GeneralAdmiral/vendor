import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { ProductSearchService } from '../../services/product-search.service';
import { Product } from '../../common/models/product.model';

@Component({
    moduleId: module.id,
    selector: 'product-search',
    templateUrl: './app/components/product/product-search.component.html',
    styleUrls: ['./app/components/product/product-search.component.css'],
    providers: [ProductSearchService]
})
export class ProductSearchComponent implements OnInit {

    products: Observable<Product[]>;
    private searchTerms = new Subject<string>();

    constructor(
        private productSearchService: ProductSearchService,
        private router: Router) { }

    // Push a search term into the observable stream.
    public search(term: string): void {
        this.searchTerms.next(term);
    }

    ngOnInit(): void {
        this.products = this.searchTerms
            .debounceTime(300)        // wait for 300ms pause in events
            .distinctUntilChanged()   // ignore if next search term is same as previous
            .switchMap(term => term   // switch to new observable each time
                // return the http search observable
                ? this.productSearchService.search(term)
                // or the observable of empty products if no search term
                : Observable.of<Product[]>([]))
            .catch(error => {
                // TODO: real error handling
                console.log(error);
                return Observable.of<Product[]>([]);
            });
    }

    gotoDetail(product: Product): void {
        let link = ['/detail', product.id];
        this.router.navigate(link);
    }
}
