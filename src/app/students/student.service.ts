import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  // normalde services diye ayrı bir klasör açılır ama tek bu olduğu için yapmadık

  private baseApiUrl = 'https://localhost:44359';

  constructor(private hhtpClient:HttpClient) { }
    
  
  getStudents(): Observable<any> {
    return this.hhtpClient.get<any>(this.baseApiUrl+'/Students');
  }

  
}
