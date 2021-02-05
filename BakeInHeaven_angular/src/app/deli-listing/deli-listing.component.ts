import { Component, OnInit } from '@angular/core';
import { delicacy } from '../Types/delicacy';
import { DeliListingService } from '../services/deli-listing.service';
import { DeliSchdlService } from '../services/deli-schdl.service';

import { OrderListingService } from '../services/order-listing.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-deli-listing',
  templateUrl: './deli-listing.component.html',
  styleUrls: ['./deli-listing.component.css'],
})
export class DeliListingComponent implements OnInit {
  nonspldelicacys: delicacy[] = [];
  spldelicacys: delicacy[] = [];
  splQtyItems: number[] = [];
  qtyItems: number[] = [];
  constructor(
    private delilistinservice: DeliListingService,
    private delischdlservice: DeliSchdlService,
    private OrderListingService: OrderListingService,
    private router:Router
  ) {}

  ngOnInit(): void {
    const todaysdate = new Date().toLocaleDateString('en-GB');
    console.log(todaysdate);
    this.delilistinservice.getDelilistings().subscribe((delicacys) => {
      this.nonspldelicacys = delicacys.filter((delicacy) => !delicacy.spl);
      this.spldelicacys = delicacys.filter((delicacy) => delicacy.spl);
      this.delischdlservice.getDeliSchdl().subscribe((deli_scheduleList) => {
        deli_scheduleList.forEach((deli_schedule) => {
          if (deli_schedule.date != todaysdate) {
            this.spldelicacys = this.spldelicacys.filter(
              (spldelicacy) => spldelicacy.id !== deli_schedule.delicacy_id
            );
            console.log(this.spldelicacys);
            this.nonspldelicacys = this.nonspldelicacys.filter(
              (nondelicacy) => nondelicacy.id !== deli_schedule.delicacy_id
            );
          }
        });
      });
    });
  }
  onClickAdditems(qty: number, id: number): void {
    // alert(`qty:${qty}  id:${id}`)
    this.delilistinservice.getDeliById(id).subscribe((delicacy) => {
      if (delicacy.quantity < qty) {
        alert('Requested order contains quantity more than required');
      } else {
        // alert('will delete the item as there is nothing left');
        this.OrderListingService.getAllorder().subscribe((orders) => {
          this.OrderListingService.CreateOrders(
            orders[orders.length - 1].orderId + 1,
            id,
            'Paul',
            qty,
            delicacy.price * qty
          ).subscribe(() => {
            this.delischdlservice.getDeliSchdl().subscribe(() => {
                      this.delilistinservice
                        .editDeliById(
                          id,
                          delicacy.name,
                          delicacy.quantity - qty,
                          delicacy.price,
                          delicacy.weight,
                          delicacy.nutri_engy,
                          delicacy.veg,
                          delicacy.spl
                        )
                        .subscribe(() => {location.reload();
                         
                        });
                    });
              
          });
        });
      }
    });
  }
}