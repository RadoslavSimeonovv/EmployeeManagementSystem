import { RouterModule, Routes } from '@angular/router';
import { EditShiftComponent } from './components/edit-shift/edit-shift.component';
import { CreateShiftComponent } from './components/create-shift/create-shift.component';
import { NgModule } from '@angular/core';
import { ViewEmployeesComponent } from './components/view-employees/view-employees.component';

// export const routes: Routes = [];
export const routes: Routes = [
    { path: '', component: ViewEmployeesComponent },
    { path: 'add/:employeeId/shifts', component: CreateShiftComponent },
    { path: 'edit/:shiftId', component: EditShiftComponent },
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
  })

  export class AppRoutingModule {}