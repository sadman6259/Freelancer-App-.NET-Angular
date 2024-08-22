import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { freelancerService } from '../freelancers.service';
import { freelancers } from '../freelancers';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-addfreelancer',
  templateUrl: './addfreelancer.component.html',
  styleUrls: ['./addfreelancer.component.css']
})
export class AddfreelancerComponent {

  constructor(public service:freelancerService,public http:HttpClient,public router:Router) { }
  url = 'https://localhost:7116/api/Freelancer'
  public freelancers: any = [];  

  ngOnInit() {
  }

  resetForm(form?:NgForm ){
    if (form != null)
    form.form.reset();
    this.service.formData = {
    id: 0 ,
    userName: '' ,
    mail: '' ,
    phoneNumber: '',
    skillsets:'',
    hobby:''

  }
  this.getFreelancer().subscribe(data =>  this.freelancers = data);

  }
  keyPress(event: any) {
    const pattern = /[0-9\+\-\ ]/;

    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  
  generateform(freelancers: freelancers){
    
    this.service.formData = {
      Id: freelancers.Id,
      UserName: freelancers.username,
      Mail: freelancers.mail,
      Skillsets: freelancers.skillsets,
      PhoneNumber: freelancers.phonenumber,
      Hobby: freelancers.hobby

  
    }
  
    }
    
  getFreelancer():Observable<freelancers[]>{

    return this.http.get<freelancers[]>(this.url);
 
  }

  NavigateHome(){
    this.router.navigateByUrl('/freelancerinfo'); 
  }
  onSubmit(form:NgForm)
  {
    console.log("onsubmit");
  
   if(form.value.Id > 0) {
   this.service.putFreelancer(form.value).subscribe(
     res=>{
      this.resetForm();
      this.router.navigateByUrl('/freelancerinfo'); 
     },
 
     err=>{ console.log('err',err)},
     
 
 
    );
 }
 else{
   this.service.postFreelancer(form.value).subscribe(
     res=>{ 
      this.resetForm();
      this.router.navigateByUrl('/freelancerinfo');  
     },
 
     err=>{ console.log('err',err)},
     
 
 
    );
 }
   
   
 
 
  }

}
