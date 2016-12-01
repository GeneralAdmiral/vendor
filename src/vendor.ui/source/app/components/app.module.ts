import { NgModule }      from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule }   from "@angular/forms";
import { HttpModule }    from "@angular/http";
// import { MaterialModule } from "@angular/material";

import { InMemoryWebApiModule } from "angular2-in-memory-web-api";
import { InMemoryDataService }  from "../services/in-memory-data.service";

import { AppComponent }   from "./app.component";
import { ProductDetailComponent } from "./product/product-detail.component";
import { ProductService } from "../services/product.service";
import { ProductComponent } from "./product/product.component";
import { DashboardComponent } from "./panel/dashboard.component";
import { ProductSearchComponent } from "./product/product-search.component";
import { routing }       from "../router";
import "./rxjs-extensions";


@NgModule(({
    imports: [BrowserModule, FormsModule, routing, InMemoryWebApiModule.forRoot(InMemoryDataService), HttpModule /*, MaterialModule.forRoot()*/],
    declarations: [AppComponent, ProductComponent, ProductDetailComponent, DashboardComponent, ProductSearchComponent],
    providers: [ProductService],
    bootstrap: [AppComponent]
}))
export class AppModule {}