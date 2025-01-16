import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmployee } from '../models/IEmployee';
import { IEmployeeResponse } from '../models/IEmployeeResponse';
import { IShift } from '../models/IShift';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'https://localhost:44304/api';

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<IEmployeeResponse> {
    return this.http.get<IEmployeeResponse>(`${this.apiUrl}/employees`);
  }

  createShift(data: IShift): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/shift/create`, data);
  }

  updateShift(id: string, data: IShift): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/shift/update/${id}`, data);
  }

  deteleShift(id: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/shift/delete/${id}`);
  }
}
