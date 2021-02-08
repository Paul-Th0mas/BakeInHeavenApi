import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { authread } from "../Types/authRead";
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  login(Username:string,Password:string):Observable<any>{
    return this.http.post<authread>("/api/Bakery/auth",{Username,Password},httpOptions);
  }
}
