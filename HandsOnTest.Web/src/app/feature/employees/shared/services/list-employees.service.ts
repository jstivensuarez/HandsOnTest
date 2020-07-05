import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/internal/operators/map';

const ENDPOINT = environment.employeesUrl;

@Injectable({
  providedIn: 'root'
})
export class ListEmployeesService {

  constructor(private http: HttpClient) { }

  public getEmployees(): Observable<Employee[]> {
    return this.http.get(ENDPOINT).pipe(
      map(result => result as Employee[])
    );
  }

  public getEmployeeById(id: number): Observable<Employee> {
    return this.http.get(ENDPOINT+"/"+id).pipe(
      map((result) => result as Employee)
    );
  }
}
