import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { delicacy } from '../Types/delicacy';
import { DeliListingService } from '../services/deli-listing.service';
import { DeliSchdlService } from '../services/deli-schdl.service';

@Component({
  selector: 'app-deli-detail-page',
  templateUrl: './deli-detail-page.component.html',
  styleUrls: ['./deli-detail-page.component.css'],
})
export class DeliDetailPageComponent implements OnInit {
  @Input() buttonText: string = '';
  @Input() currentname!: string;
  @Input() currentquantity!: number;
  @Input() currentprice!: number;
  @Input() currentweight!: number;
  @Input() currentnutri_engy!: number;
  @Input() currentveg!: boolean;
  @Input() currentspl!: boolean;
  name: string = '';
  quantity!: number;
  price!: number;
  weight!: number;
  nutri_engy!: number;
  veg!: boolean;
  spl!: boolean;
  Id!: number;
  date: string = '';
  dateId!: number;
  isloading:boolean=false;
  CreateItem:boolean=false;
  @Output() onSubmit = new EventEmitter<delicacy>();
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private deliListingService: DeliListingService,
    private deliSchdlService: DeliSchdlService
  ) {}

  ngOnInit(): void {
    this.Id = Number(this.route.snapshot.paramMap.get('id'))!;
    
    
    this.deliListingService
      .getDeliById(Number(this.Id))
      .subscribe((delicacy) => {
        this.name = delicacy.name;
        this.quantity = delicacy.quantity;
        this.price = delicacy.price;
        this.weight = delicacy.weight;
        this.nutri_engy = delicacy.nutri_engy;
        this.veg = delicacy.veg;
        this.spl = delicacy.spl;
      });
      this.deliSchdlService.getDeliSchdl().subscribe((deli_schds) => {
        console.log(deli_schds);
        
        deli_schds.forEach((deli_schd) => {
          console.log("outside")
          console.log(deli_schd.delicacy_id)
          if (deli_schd.delicacy_id === Number(this.Id)) {
            console.log(deli_schd.delicacy_id);
            
            this.date = deli_schd.date;
            this.dateId = deli_schd.id;
          }
        });
      });
  }
  onClicksubmit() {
    this.deliListingService
      .editDeliById(
        this.Id,
        this.name,
        this.quantity,
        this.price,
        this.weight,
        this.nutri_engy,
        this.veg,
        this.spl
      ) 
      .subscribe(() => { 
        this.deliSchdlService
          .editDeliSchdlById(this.dateId, this.Id, this.date)
          .subscribe(() => {console.log(this.Id);
            this.router.navigateByUrl('/modify-deli');
          });
      });
  }
}
