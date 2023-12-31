import { Component, ViewChild } from '@angular/core';
import { StudentService } from './student.service';
import { Student } from '../models/ui-models/student.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent {

  students:Student[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'dateOfBirth', 'email', 'mobile', 'gender', 'edit'];
  dataSource:MatTableDataSource<Student> = new MatTableDataSource<Student>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  filterString='';

  constructor(private studentService:StudentService) {}

  ngOnInit():void {
    // debugger;
    this.studentService.getStudents().subscribe(
      (success) => {
        this.students = success;
        this.dataSource = new MatTableDataSource<Student>(this.students);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      (err) => {

      }
    )
  }

  filterStudents() {
    this.dataSource.filter = this.filterString.trim().toLocaleLowerCase();
  }
}


// cors hatasında backende bunu yazdık:
// builder.Services.AddCors(o => o.AddPolicy("MyPolicy",builder =>
// {
//   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
// }));

// app.UseCors("MyPolicy");