"use strict";
var router_1 = require('@angular/router');
var product_component_1 = require('./components/product/product.component');
var product_detail_component_1 = require('./components/product/product-detail.component');
var dashboard_component_1 = require('./components/panel/dashboard.component');
var appRoutes = [
    {
        path: 'products',
        component: product_component_1.ProductComponent
    },
    {
        path: 'dashboard',
        component: dashboard_component_1.DashboardComponent
    },
    {
        path: '',
        redirectTo: '/dashboard',
        pathMatch: 'full'
    },
    {
        path: 'detail/:id',
        component: product_detail_component_1.ProductDetailComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=router.js.map