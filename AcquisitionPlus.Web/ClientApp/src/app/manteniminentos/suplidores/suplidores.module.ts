import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SuplidoresListComponent } from './list/suplidores-list.component';
import { MaterialModule } from 'src/app/material/material.module';
import { SuplidoresRoutingModule } from './suplidores-routing.module';



@NgModule({
  declarations: [SuplidoresListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    SuplidoresRoutingModule
  ]
})
export class SuplidoresModule { }
