import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UnidadesMedidasListComponent } from './list/unidades-medidas-list.component';
import { MaterialModule } from 'src/app/material/material.module';
import { UnidadesMedidasRoutingModule } from './unidades-medidas-routing.module';
import { UnidadesMedidasAddComponent } from './add/unidades-medidas-add.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [UnidadesMedidasListComponent, UnidadesMedidasAddComponent],
  imports: [
    CommonModule,
    MaterialModule,
    UnidadesMedidasRoutingModule,
    ReactiveFormsModule
  ]
})
export class UnidadesMedidasModule { }
