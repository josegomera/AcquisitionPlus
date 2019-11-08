import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-purchase-order-list',
  templateUrl: './purchase-order-list.component.html',
  styleUrls: ['./purchase-order-list.component.css']
})
export class PurchaseOrderListComponent implements OnInit {
  displayedColumns: string[] = ['orderNumber', 'amount','orderDate', 'unitCost', 'total', 'accion'];
  dataSource = new MatTableDataSource([]);
  constructor(private actRoute : ActivatedRoute) { }

  ngOnInit() {
    this.actRoute.data.subscribe((data) => {
      this.dataSource = new MatTableDataSource(data.purchase);
     })
  }

}
