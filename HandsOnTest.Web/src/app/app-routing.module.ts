import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'employees',
    loadChildren: () => import('./feature/employees/employees.module')
      .then(mod => mod.EmployeesModule),
    data: { preload: true }
  },
  {
    path: '',
    loadChildren: () => import('./feature/employees/employees.module')
      .then(mod => mod.EmployeesModule),
    data: { preload: true }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true, onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
