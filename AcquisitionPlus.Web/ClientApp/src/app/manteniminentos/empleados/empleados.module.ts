import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { EmpleadosListComponent } from './list/empleados-list.component';
import { EmpleadoRoutingModule } from './empleado-routing.module';



@NgModule({
  declarations: [EmpleadosListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    EmpleadoRoutingModule
  ]
})
export class EmpleadosModule { }
