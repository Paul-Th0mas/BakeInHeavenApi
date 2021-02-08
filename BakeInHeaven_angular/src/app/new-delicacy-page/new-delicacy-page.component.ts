import { Component, OnInit } from '@angular/core';
import { DeliListingService } from '../services/deli-listing.service';
import { delicacywrite } from '../Types/delicacywrite';
import { Router } from '@angular/router';
import { DeliSchdlService } from '../services/deli-schdl.service';
@Component({
  selector: 'app-new-delicacy-page',
  templateUrl: './new-delicacy-page.component.html',
  styleUrls: ['./new-delicacy-page.component.css'],
})
export class NewDelicacyPageComponent implements OnInit {
  delicacy!: delicacywrite;
  name: string = '';
  quantity!: number;
  price!: number;
  weight!: number;
  nutri_engy!: number;
  veg: boolean = false;
  spl: boolean = false;
  date!: string;
  deliSchId!: number;
  createDate:boolean=false;
  constructor(
    private delilisting: DeliListingService,
    private router: Router,
    private deliSchdlService: DeliSchdlService
  ) {}

  ngOnInit(): void {}
  onClickCreate(): void {
    this.delilisting
      .createListing(
        this.name,
        this.quantity,
        this.price,
        this.weight,
        this.nutri_engy,
        this.veg,
        this.spl
      )
      .subscribe(()=> {
        this.createDate=true;
      });
  }
  onClickDate(): void {
    this.delilisting.getDelilistings().subscribe((delilistings) => {
      delilistings.forEach((deliListing) => {
        if (deliListing.name === this.name) {
          this.deliSchdlService
            .createDeliSchd(deliListing.id, this.date)
            .subscribe(() => {
              this.router.navigateByUrl('/modify-deli');
            });
        }
      });
    });
  }
}
