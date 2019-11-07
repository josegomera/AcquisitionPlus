import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
const routes: Routes = [
  {path: 'ordenes', loadChildren: () => import('./purchase-order/purchase-order.module').then(p => p.PurchaseOrderModule)},
  {path: 'mantenimientos', loadChildren: () => import('./manteniminentos/mantenimiento.module').then(p => p.MantenimientoModule)}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(
     routes
    )
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
