import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { MantenimientosListComponent } from './list/mantenimientos-list.component';
import { EmpleadosModule } from './empleados/empleados.module';
import { DepartamentosModule } from './departamentos/departamentos.module';

@NgModule({
  declarations: [MantenimientosListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    MantenimientoRoutingModule,
    EmpleadosModule,
    DepartamentosModule
  ]
})
export class MantenimientoModule { }
