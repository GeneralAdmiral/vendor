import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'my-app',
    templateUrl: './app/components/app.component.html'
})
export class AppComponent {
    title = 'Tour of Products';
    id = module.id;
}