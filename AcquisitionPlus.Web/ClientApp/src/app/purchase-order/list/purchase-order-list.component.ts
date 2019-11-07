import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-order-list',
  templateUrl: './purchase-order-list.component.html',
  styleUrls: ['./purchase-order-list.component.css']
})
export class PurchaseOrderListComponent implements OnInit {
  displayedColumns: string[] = ['orderNumber', 'amount','orderDate', 'unitCost', 'total', 'accion'];
  dataSource = [
    {orderNumber: 1, amount: 12, orderDate: new Date() , unitCost: 5000, total : 60000},
    {orderNumber: 2, amount: 10, orderDate: new Date('09/05/2019') , unitCost: 1000, total: 10000},
    {orderNumber: 3, amount: 3, orderDate: new Date('09/03/2014') , unitCost: 2000, total : 6000},
    {orderNumber: 4, amount: 5, orderDate: new Date('02/05/2010') , unitCost: 3000, total: 15000}
  ];
  constructor() { }

  ngOnInit() {

  }

}
