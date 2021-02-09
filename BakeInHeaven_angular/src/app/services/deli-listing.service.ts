import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { delicacy } from '../Types/delicacy';
import { delicacywrite } from '../Types/delicacywrite';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class DeliListingService {
  constructor(private http: HttpClient) {}
  getDelilistings(): Observable<delicacy[]> {
    return this.http.get<delicacy[]>('api/Bakery/delicacy');
  }
  deleteDeliListing(id: number): Observable<any> {
    return this.http.delete(`api/Bakery/delicacy/${id}`);
  }
  createListing(
    name: string,
    quantity: number,
    price: number,
    weight: number,
    nutri_engy: number,
    veg: boolean,
    spl: boolean,
    aval: boolean,
    archive: boolean
  ): Observable<delicacywrite> {
    return this.http.post<delicacywrite>(
      'api/Bakery/delicacy',
      { name, quantity, price, weight, nutri_engy, veg, spl, aval, archive },
      httpOptions
    );
  }
  getDeliById(id: number): Observable<delicacy> {
    return this.http.get<delicacy>(`api/Bakery/delicacy/${id}`);
  }
  editDeliById(
    id: number,
    name: string,
    quantity: number,
    price: number,
    weight: number,
    nutri_engy: number,
    veg: boolean,
    spl: boolean,
    aval: boolean,
    archive: boolean
  ): Observable<delicacywrite> {
    return this.http.put<delicacywrite>(
      `/api/Bakery/delicacy/${id}`,
      { name, quantity, price, weight, nutri_engy, veg, spl, aval, archive },
      httpOptions
    );
  }
}
