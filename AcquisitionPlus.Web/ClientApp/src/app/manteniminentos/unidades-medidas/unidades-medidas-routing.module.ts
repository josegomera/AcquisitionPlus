import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UnidadesMedidasListComponent } from './list/unidades-medidas-list.component';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  {path: '', component: UnidadesMedidasListComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(
     routes
    )
  ],
  exports: [RouterModule]
})

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class UnidadesMedidasRoutingModule { }
