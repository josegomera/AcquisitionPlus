import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { MantenimientosListComponent } from './list/mantenimientos-list.component';

@NgModule({
  declarations: [MantenimientosListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    MantenimientoRoutingModule
  ]
})
export class MantenimientoModule { }
