import { Component } from '@angular/core';
import { freelancerService } from '../freelancers.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { freelancers } from '../freelancers';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {NgxPaginationModule} from 'ngx-pagination';

@Component({
  selector: 'app-freelancerinfo',
  templateUrl: './freelancerinfo.component.html',
  styleUrls: ['./freelancerinfo.component.css']
})
export class FreelancerinfoComponent {
  
  constructor(public service:freelancerService,public http:HttpClient,public router:Router) { }
  url = 'https://localhost:7116/api/Freelancer';
  freelancer :any = [];  
  p = 1;
  ngOnInit() {
    this.getFreelancers().subscribe(data => this.freelancer = data);

  }
  populateForm(e: freelancers) 
  {
   this.service.formData = Object.assign({}, e);
   this.router.navigate(['addfreelancer']);

 }

  getFreelancers():Observable<freelancers[]>{
    return this.http.get<freelancers[]>(this.url);
}
   
    onDelete(id: number) {
      if (confirm('Are you sure to delete this record?')) {
        this.service.deleteFreelancer(id).subscribe(res => {
          this.getFreelancers().subscribe(data =>  this.freelancer = data);
    
        });
      }
    }

    
}
