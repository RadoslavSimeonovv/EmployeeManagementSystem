import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { IRole } from '../../models/IRole';
import { IShift } from '../../models/IShift';
import { DataService } from '../../services/data.service';
import { NgFor } from '@angular/common';
import {MatTimepickerModule} from '@angular/material/timepicker';
import { IEmployee } from '../../models/IEmployee';

@Component({
  selector: 'app-edit-shift',
  imports: [MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    FormsModule, NgFor,
    MatTimepickerModule],
  templateUrl: './edit-shift.component.html',
  styleUrl: './edit-shift.component.css'
})
export class EditShiftComponent {
  dropdownRoles: IRole[] = [];
  shiftModel = {} as IShift;
  selectedRole: string = '';
  employee = {} as IEmployee;
  overlap: boolean = false;
  dayName: string = '';

  constructor(private router: Router,
    private route: ActivatedRoute, 
    private dataService: DataService
  ) {}

  ngOnInit(): void {
    const state = window.history.state;
    this.dropdownRoles = state.employee.roles;
    this.shiftModel = state.shift;
    this.shiftModel.employeeId = state.employeeId;
    this.employee = state.employee;
    this.dayName = state.dayName;
  }

  editShift() {
    if (this.checkForOverlap(this.shiftModel, this.employee.shifts)) {
      this.overlap = true;
      return;
    }
    this.dataService.updateShift(this.shiftModel.id, this.shiftModel).subscribe((response) => {
      this.router.navigate(['']);
    });
  }

  deleteShift() {
    this.dataService.deteleShift(this.shiftModel.id).subscribe((response) => {
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
