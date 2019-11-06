import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PurchaseOrderListComponent } from './list/purchase-order-list.component';


const routes : Routes = [
  {path: '', component: PurchaseOrderListComponent}
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
export class PurchaseOrderRoutingModule { }
