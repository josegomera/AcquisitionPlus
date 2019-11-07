import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { MantenimientoRoutingModule } from './mantenimiento-routing.module';
import { MantenimientosListComponent } from './list/mantenimientos-list.component';
import { EmpleadosModule } from './empleados/empleados.module';
import { DepartamentosModule } from './departamentos/departamentos.module';
import { ProdutosModule } from './produtos/produtos.module';

@NgModule({
  declarations: [MantenimientosListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    MantenimientoRoutingModule,
    EmpleadosModule,
    DepartamentosModule,
    ProdutosModule
  ]
})
export class MantenimientoModule { }
