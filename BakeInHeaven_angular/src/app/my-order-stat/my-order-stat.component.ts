import { Component, OnInit } from '@angular/core';
import { OrderListingService } from "../services/order-listing.service";
import { ordersRead  } from "../Types/ordersread";

@Component({
  selector: 'app-my-order-stat',
  templateUrl: './my-order-stat.component.html',
  styleUrls: ['./my-order-stat.component.css']
})
export class MyOrderStatComponent implements OnInit {
  order:ordersRead[]=[];
  constructor(private orderListingService:OrderListingService) { }

  ngOnInit(): void {
    this.orderListingService.getAllorder().subscribe(orders=>this.order=orders)
  }
  onClickDelete(orderId:number):void{
    if(confirm("do You want to delete?")){
      this.orderListingService.deleteOrderById(orderId).subscribe(()=>location.reload())
    }
    
  }

}
