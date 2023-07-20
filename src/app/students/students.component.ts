import { Component } from '@angular/core';
import { StudentService } from './student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent {

  constructor(private studentService:StudentService) {}

  ngOnInit():void {
    debugger;
    this.studentService.getStudents().subscribe(
      (success) => {
        var guney = success[0].firstName
      },
      (err) => {

      }
    )
  }
}


// cors hatasında backende bunu yazdık:
// builder.Services.AddCors(o => o.AddPolicy("MyPolicy",builder =>
// {
//   builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
// }));

// app.UseCors("MyPolicy");