import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { DepartamentosListComponent } from './list/departamentos-list/departamentos-list.component';

const routes: Routes = [
  {path: '', component: DepartamentosListComponent}
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
export class DepartamentosRoutingModule { }
