import { Injectable } from "@angular/core";


@Injectable({
  providedIn: 'root'
})
export class EmployeeGlobalConstants {

  hourlySalaryType = 'HourlySalaryEmployee';
  monthlySalaryType = 'MonthlySalaryEmployee';

  hourlySalaryLabel = 'Hourly Salary Employee';
  monthlySalaryLabel = 'Monthly Salary Employee';

  employeeNotFoundMessage = 'Employee not found';
}