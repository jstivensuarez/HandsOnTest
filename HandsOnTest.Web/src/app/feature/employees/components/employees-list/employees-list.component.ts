import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Employee } from '../../shared/models/employee';
import { MatDialog } from '@angular/material/dialog';
import { ListEmployeesService } from '../../shared/services/list-employees.service';
import { FormBuilder, FormControl } from '@angular/forms';
import { EmployeeGlobalConstants } from '../../shared/constants/employee-global-constants';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employees: Employee[];
  employeeId = new FormControl('');
  displayedColumns: string[];
  dataSource: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fb: FormBuilder,
    private listCountriesService: ListEmployeesService,
    private employeeConstants: EmployeeGlobalConstants,
    public dialog: MatDialog,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.employees = [];
    this.displayedColumns = ['name', 'contractTypeName', 'roleName','roleDescription', 'hourlySalary', 'monthlySalary', 'annualSalary'];
  }

  search() {
    if (this.employeeId.value) {
      this.getEmployeeById()
    } else {
      this.getEmployees();
    }
  }

  getEmployees() {
    this.employees = [];
    this.listCountriesService.getEmployees().subscribe(
      employees => {
        this.employees = employees;
        this.initDataSource();
      }
    );
  }

  getEmployeeById() {
    this.employees = [];
    this.listCountriesService.getEmployeeById(this.employeeId.value).subscribe(
      employee => {
        if (employee) {
          this.employees.push(employee);
        }else{
          this.snackBar.open(this.employeeConstants.employeeNotFoundMessage,'OK', {duration:3000});
        }
        this.initDataSource();
      }
    );
  }

  initDataSource() {
    this.dataSource = new MatTableDataSource(this.employees);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  getContractType(contractType: string) {
    let contract = null;
    if (contractType == this.employeeConstants.hourlySalaryType) {
      contract =  this.employeeConstants.hourlySalaryLabel;
    } else if (contractType ==  this.employeeConstants.monthlySalaryType) {
      contract =  this.employeeConstants.monthlySalaryLabel;
    }
    return contract;
  }

  get showTable() {
    return this.employees.length > 0
  }
}
