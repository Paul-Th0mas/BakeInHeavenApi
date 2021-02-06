import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModifyDeliComponent } from './modify-deli/modify-deli.component';
import { DeliListingComponent } from './deli-listing/deli-listing.component';

import { OrderCartComponent } from './order-cart/order-cart.component';
import { MyOrderStatComponent } from './my-order-stat/my-order-stat.component';
import { HomePageComponent } from './home-page/home-page.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CommonModule } from '@angular/common';
import { DeliDetailPageComponent } from './deli-detail-page/deli-detail-page.component';  
import {HttpClientModule} from '@angular/common/http';
import { NewDelicacyPageComponent } from './new-delicacy-page/new-delicacy-page.component';




//import { AppBootstrapModule } from './app-bootstrap/app-bootstrap.module';


@NgModule({
  declarations: [AppComponent, ModifyDeliComponent, DeliListingComponent, OrderCartComponent, MyOrderStatComponent, HomePageComponent, DeliDetailPageComponent, NewDelicacyPageComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
  CommonModule,
HttpClientModule,],
  exports:[BsDropdownModule, TooltipModule, ModalModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  

  
}
