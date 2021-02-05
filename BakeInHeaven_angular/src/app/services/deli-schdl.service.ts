import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { delicacy_schedulesRead } from '../Types/delicacy_scheduleRead';
import { delicacy_Schedules } from '../Types/delicy_schedule';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class DeliSchdlService {
  constructor(private http: HttpClient) {}
  getDeliSchdl(): Observable<delicacy_schedulesRead[]> {
    return this.http.get<delicacy_schedulesRead[]>(
      'api/Bakery/delicacy_schedule'
    );
  }
  getDeliSchdlById(id: string): Observable<delicacy_schedulesRead> {
    return this.http.get<delicacy_schedulesRead>(
      `api/Bakery/delicacy_schedule/${id}`
    );
  }
  createDeliSchd(
    delicacy_id: number,
    date: string
  ): Observable<delicacy_Schedules> {
    return this.http.post<delicacy_Schedules>(
      'api/Bakery/delicacy_schedule',
      { delicacy_id, date },
      httpOptions
    );
  }
  editDeliSchdlById(
    id: number,
    delicacy_id: number,
    date: string
  ): Observable<delicacy_Schedules> {
    console.log(`inside ${delicacy_id}`);
    return this.http.put<delicacy_Schedules>(
      `api/Bakery/delicacy_schedule/${id}`,
      { delicacy_id, date },
      httpOptions
    );
  }
  deleteDeliSchdlById(id: number): Observable<any> {
    return this.http.delete(`api/Bakery/delicacy_schedule/${id}`);
  }
}
