import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/api-models/student.model';
import { UpdateStudentRequest } from '../models/api-models/updateStudentRequest.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  // normalde services diye ayrı bir klasör açılır ama tek bu olduğu için yapmadık

  private baseApiUrl = 'https://localhost:44359';

  constructor(private hhtpClient:HttpClient) { }
    
  
  getStudents(): Observable<Student[]> {
    return this.hhtpClient.get<Student[]>(this.baseApiUrl+'/Students');
  }

  getStudent(studentId:string | null): Observable<Student> {
    return this.hhtpClient.get<Student>(this.baseApiUrl+'/students/'+studentId);
  }

  updateStudent(studentId:string,studentRequest:Student): Observable<Student> {
    const updateStudentRequest: UpdateStudentRequest = {
      firstName: studentRequest.firstName,
      lastName: studentRequest.lastName,
      dateOfBirth: studentRequest.dateOfBirth,
      email: studentRequest.email,
      mobile: studentRequest.mobile,
      genderId: studentRequest.genderId,
      physicalAddress: studentRequest.address.physicalAddress,
      postalAddress: studentRequest.address.postalAddress,
    }
    return this.hhtpClient.put<Student>(this.baseApiUrl+'/students/'+studentId,updateStudentRequest);
  }

  deleteStudent(studentId:string): Observable<Student> {
    return this.hhtpClient.delete<Student>(this.baseApiUrl+'/students/'+studentId);
  }

  
}
