import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { DepartamentosRoutingModule } from './departamentos-routing.module';
import { DepartamentosListComponent } from './list/departamentos-list/departamentos-list.component';



@NgModule({
  declarations: [DepartamentosListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    DepartamentosRoutingModule
  ]
})
export class DepartamentosModule { }
