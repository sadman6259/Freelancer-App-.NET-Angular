import { Injectable, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { freelancers } from '../app/freelancers';

@Injectable({
  providedIn: 'root'
})
export class freelancerService {
  formData : any = {};
  Url='https://localhost:7116/api/Freelancer';

  list : freelancers[];
  
  constructor(private http:HttpClient) { }
    
   
  postFreelancer(formData:freelancers){
  
  return this.http.post(this.Url,formData);
  }
  getFreelancersList(){
    return this.http.get(this.Url).toPromise();
   }
  putFreelancer(formData : freelancers){
    console.log(formData);
    return this.http.put(this.Url+'/'+formData.Id,formData);
     
   }
  deleteFreelancer(id : number){
    return this.http.delete(this.Url+'/'+id);
   }
   
  
}
