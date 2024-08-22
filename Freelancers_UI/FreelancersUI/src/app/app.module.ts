import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { FreelancerinfoComponent } from './freelancerinfo/freelancerinfo.component';
import { AppRoutingModule } from './app-routing.module';
import {NgxPaginationModule} from 'ngx-pagination';
import { AddfreelancerComponent } from './addfreelancer/addfreelancer.component';

@NgModule({
  declarations: [
    AppComponent,
    AddfreelancerComponent,
    FreelancerinfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxPaginationModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
