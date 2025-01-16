import { Component } from '@angular/core';
import { IEmployee } from '../../models/IEmployee';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { IShift } from '../../models/IShift';
import { ITableModel } from '../../models/ITableModel';

@Component({
  selector: 'app-view-employees',
  imports: [MatTableModule, CommonModule ],
  templateUrl: './view-employees.component.html',
  styleUrl: './view-employees.component.css'
})
export class ViewEmployeesComponent {
    schedule: ITableModel[] = [
      { dayName: 'Monday', date: new Date("2025-01-13") }, 
      { dayName: 'Tuesday', date: new Date("2025-01-14") }, 
      { dayName: 'Wednesday', date: new Date("2025-01-15") },
      { dayName: 'Thursday', date: new Date("2025-01-16") }, 
      { dayName: 'Friday', date: new Date("2025-01-17") }, 
      { dayName: 'Saturday', date: new Date("2025-01-18") },
      { dayName: 'Sunday', date: new Date("2025-01-19") }, 
    ]

    daysOfWeek: string[] = [];

    employees: IEmployee[] = [];
  
    constructor(private dataService: DataService, private router: Router) {}
  
    ngOnInit(): void {
      this.daysOfWeek = this.schedule.map(x => x.dayName);
      this.loadData();
    }
  
    loadData(): void {
      this.dataService.getEmployees().subscribe((response) => {
        this.employees = response.items;

        this.employees.forEach(employee => {
          employee.shifts.forEach(shift => {
            const day = this.schedule[new Date(shift.startTime).getDay()];
            shift.dayName = day.dayName;
          });
        });
      });
    }

    getFormattedDate(date: Date)  {
      const hours = new Date(date).getHours(); // Hour (0-23)
      const minutes = new Date(date).getMinutes(); // Minute (0-59)
      const formattedTime = `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}`;
      return formattedTime;
    }
  
    addShift(employee: IEmployee, dayName: string) {
     let dayDate = this.schedule.find(x => x.dayName == dayName)?.date;
     const route = `/add/${employee.id}/shifts`;
     this.router.navigate([route], { state: { employee: employee, date: dayDate, dayName: dayName } } );
    }

    editShift(shift: IShift, employee: IEmployee, dayName: string) {
      const route = `edit/${shift.id}`;
      this.router.navigate([route], { state: { shift: shift, employee: employee, dayName: dayName } });
    }
}
