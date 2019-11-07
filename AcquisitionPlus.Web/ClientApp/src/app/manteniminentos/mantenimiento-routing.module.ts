import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MantenimientosListComponent } from './list/mantenimientos-list.component';



const routes: Routes = [
  {path: '', component: MantenimientosListComponent}
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
export class MantenimientoRoutingModule { }
