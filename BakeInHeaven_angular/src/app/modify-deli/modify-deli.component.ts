import { Component, OnInit } from '@angular/core';
import { delicacy } from '../Types/delicacy';
import { DeliListingService } from '../services/deli-listing.service';
import { ActivatedRoute } from '@angular/router';
import { DeliSchdlService } from '../services/deli-schdl.service';
@Component({
  selector: 'app-modify-deli',
  templateUrl: './modify-deli.component.html',
  styleUrls: ['./modify-deli.component.css'],
})
export class ModifyDeliComponent implements OnInit {
  nonspldelicacys: delicacy[] = [];
  spldelicacys: delicacy[] = [];
  deliSchdId!: number;
  constructor(
    private deliSchdleService: DeliSchdlService,
    private delilistinservice: DeliListingService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.delilistinservice.getDelilistings().subscribe((delicacys) => {
      this.nonspldelicacys = delicacys.filter(
        (delicacy) => !delicacy.spl && !delicacy.archive
      );
      this.spldelicacys = delicacys.filter(
        (delicacy) => delicacy.spl && !delicacy.archive
      );
    });
  }
  onClickDelete(deliId: number): void {
    if (confirm('WARNING: GOING TO DELETE')) {
      console.log('inside');
      this.deliSchdleService.getDeliSchdl().subscribe((deli_schd) => {
        deli_schd.forEach((deli_schd) => {
          if (deli_schd.delicacy_id === deliId) {
            this.deliSchdleService
              .deleteDeliSchdlById(deli_schd.id)
              .subscribe();
          }
        });
      });
    }
    this.delilistinservice.getDeliById(deliId).subscribe((delicacy) => {
      this.delilistinservice
        .editDeliById(
          deliId,
          delicacy.name,
          delicacy.quantity,
          delicacy.price,
          delicacy.weight,
          delicacy.nutri_engy,
          delicacy.veg,
          delicacy.spl,
          delicacy.aval,
          true
        )
        .subscribe(() => {
          this.nonspldelicacys = this.nonspldelicacys.filter(
            (deli) => deli.id !== deliId
          );
          this.spldelicacys = this.spldelicacys.filter(
            (deli) => deli.id !== deliId
          );
          console.log(this.deliSchdId);
        });
    });
  }
}
