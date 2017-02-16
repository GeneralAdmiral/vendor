import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductComponent } from './components/product/product.component';
import { ProductDetailComponent } from './components/product/product-detail.component';
import { DashboardComponent } from './components/panel/dashboard.component';

const appRoutes: Routes = [
    {
        path: 'products',
        component: ProductComponent
    },
    {
        path: 'dashboard',
        component: DashboardComponent
    },
    {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
    },
    {
        path: 'detail/:id',
        component: ProductDetailComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);