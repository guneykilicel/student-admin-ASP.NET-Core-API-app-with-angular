import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Gender } from 'src/app/models/api-models/gender.model';

@Injectable({
  providedIn: 'root'
})
export class GenderService {

  private baseApiUrl = 'https://localhost:44359';

  constructor(private hhtpClient:HttpClient) { }
    
  
  getGenderList(): Observable<Gender[]> {
    return this.hhtpClient.get<Gender[]>(this.baseApiUrl+'/genders');
  }
}
