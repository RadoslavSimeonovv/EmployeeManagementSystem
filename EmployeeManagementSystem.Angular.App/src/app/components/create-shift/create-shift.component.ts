import { Component, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { IShift } from '../../models/IShift';
import { NgFor } from '@angular/common';
import { IRole } from '../../models/IRole';
import { DataService } from '../../services/data.service';
import {MatTimepickerModule} from '@angular/material/timepicker';
import { IEmployee } from '../../models/IEmployee';

@Component({
  selector: 'app-create-shift',
  imports: [MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatOptionModule,
    FormsModule, NgFor, 
    MatTimepickerModule],
  templateUrl: './create-shift.component.html',
  styleUrl: './create-shift.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class CreateShiftComponent {
  dropdownRoles: IRole[] = [];
  dropdownRolesString: string[] = [];
  shiftModel = {} as IShift;
  selectedRole: string = '';
  employee = {} as IEmployee;
  overlap: boolean = false;
  dayName: string = '';

  constructor(private router: Router, 
    private route: ActivatedRoute, 
    private dataService: DataService) {}

  ngOnInit(): void {
    this.shiftModel.employeeId = this.route.snapshot.paramMap.get('employeeId') || '';
    const employee = window.history.state.employee;
    const date = window.history.state.date;
    this.dayName = window.history.state.dayName;
    this.employee = employee;
    this.dropdownRoles = employee.roles;
    this.dropdownRolesString = this.dropdownRoles.map(x => x.name);
    this.shiftModel.startTime = date;
    this.shiftModel.endTime = date;
  }

  saveShift() {
    if (this.checkForOverlap(this.shiftModel, this.employee.shifts)) {
      this.overlap = true;
      return;
    }
    this.overlap = false;
    this.dataService.createShift(this.shiftModel).subscribe((response) => {
      this.router.navigate(['']);
    });
  }

  checkForOverlap(newShift: IShift, existingShifts: IShift[]): boolean {
    return existingShifts.filter(x => x.dayName === this.dayName)
      .some(existingShift =>
        new Date(newShift.startTime) <= new Date(existingShift.endTime) &&
        new Date(newShift.endTime) >= new Date(existingShift.startTime)
    );
 }
}
