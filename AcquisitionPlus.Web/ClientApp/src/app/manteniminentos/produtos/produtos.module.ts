import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from 'src/app/material/material.module';
import { ProdutosListComponent } from './list/produtos-list.component';
import { ProdutosRoutigModule } from './produtos-routig.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [ProdutosListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ProdutosRoutigModule,
    FormsModule
  ]
})
export class ProdutosModule { }
