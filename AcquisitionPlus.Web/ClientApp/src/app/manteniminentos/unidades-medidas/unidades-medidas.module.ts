import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UnidadesMedidasListComponent } from './list/unidades-medidas-list.component';
import { MaterialModule } from 'src/app/material/material.module';
import { UnidadesMedidasRoutingModule } from './unidades-medidas-routing.module';



@NgModule({
  declarations: [UnidadesMedidasListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    UnidadesMedidasRoutingModule
  ]
})
export class UnidadesMedidasModule { }
