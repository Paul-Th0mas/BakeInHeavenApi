import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllCusOrdersComponent } from './all-cus-orders/all-cus-orders.component';
import { DeliDetailPageComponent } from './deli-detail-page/deli-detail-page.component';
import { DeliListingComponent } from './deli-listing/deli-listing.component';
import { HomePageComponent } from './home-page/home-page.component';
import { ModifyDeliComponent } from './modify-deli/modify-deli.component';
import { MyOrderStatComponent } from './my-order-stat/my-order-stat.component';
import { NewDelicacyPageComponent } from './new-delicacy-page/new-delicacy-page.component';
import { OrderCartComponent } from './order-cart/order-cart.component';

const routes: Routes = [
  { path: '', redirectTo: '/homepage', pathMatch: 'full' },
  { path: 'homepage', component: HomePageComponent },
  { path: 'deli-listing', component: DeliListingComponent },
  { path: 'all-cus-orders', component: AllCusOrdersComponent },
  { path: 'modify-deli', component: ModifyDeliComponent },
  { path: 'my-order-stat', component: MyOrderStatComponent },
  { path: 'order-cart', component: OrderCartComponent },
  { path: 'details-deli/:id', component: DeliDetailPageComponent },
  { path: 'new-deli', component: NewDelicacyPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
