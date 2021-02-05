import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { orders } from '../Types/orders';
import { ordersRead } from '../Types/ordersread';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};
@Injectable({
  providedIn: 'root',
})
export class OrderListingService {
  constructor(private http: HttpClient) {}
  getAllorder(): Observable<ordersRead[]> {
    return this.http.get<ordersRead[]>('/api/Bakery/order');
  }
  getOrdersById(id: number): Observable<ordersRead> {
    return this.http.get<ordersRead>(`/api/Bakery/order/${id}`);
  }
  CreateOrders(
    orderId: Number,
    delicacyid: number,
    customer: String,
    quantity: number,
    price: number
  ): Observable<orders> {
    return this.http.post<orders>(
      '/api/Bakery/order',
      { orderId, delicacyid, customer, quantity, price },
      httpOptions
    );
  }
  editorder(
    id:number,
    orderId: Number,
    delicacyid: number,
    customer: String,
    quantity: number,
    price: number):Observable<orders>{
      return this.http.put<orders>(
        `/api/Bakery/order/${id}`,
        { orderId, delicacyid, customer, quantity, price },
        httpOptions
      );
    }
}
