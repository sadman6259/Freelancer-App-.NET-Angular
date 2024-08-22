import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddfreelancerComponent } from './addfreelancer/addfreelancer.component';
import { FreelancerinfoComponent } from './freelancerinfo/freelancerinfo.component';
 
const routes: Routes = [
  {path: 'addfreelancer', component:AddfreelancerComponent},
  {path: 'freelancerinfo',component: FreelancerinfoComponent},
  {path: '', component:FreelancerinfoComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
