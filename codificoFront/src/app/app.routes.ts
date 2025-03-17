import { Routes } from '@angular/router';
import { NewOrderComponent } from './new-order/new-order.component';
import { OrdersViewComponent } from './orders-view/orders-view.component';
import { SalesPredictionComponent } from './sales-prediction/sales-prediction.component';
import { VanillaViewComponent } from './vanilla-view/vanilla-view.component';

export const routes: Routes = [
    { path: 'newapp', component: NewOrderComponent },
    { path: 'orderview', component: OrdersViewComponent },
    { path: 'prediction', component: SalesPredictionComponent },
    { path: 'vanilla', component: VanillaViewComponent },
    { path: '', redirectTo: '/prediction', pathMatch: 'full' },
    { path: '**', redirectTo: '/prediction' }
];
