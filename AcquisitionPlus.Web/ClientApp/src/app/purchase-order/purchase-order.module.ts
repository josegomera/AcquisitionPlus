import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PurchaseOrderListComponent } from './list/purchase-order-list.component';
import { MaterialModule } from '../material/material.module';
import { PurchaseOrderRoutingModule } from './purchase-order-routing.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [PurchaseOrderListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    PurchaseOrderRoutingModule,
    FormsModule
  ]
})
export class PurchaseOrderModule { }
