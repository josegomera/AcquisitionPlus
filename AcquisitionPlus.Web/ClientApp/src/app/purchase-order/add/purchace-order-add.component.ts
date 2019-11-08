import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { PurchaseOrderService } from 'src/app/core/services/purchase-order.service';

@Component({
  selector: 'app-purchace-order-add',
  templateUrl: './purchace-order-add.component.html',
  styleUrls: ['./purchace-order-add.component.css']
})
export class PurchaceOrderAddComponent implements OnInit {
  puchaseOrderForm: FormGroup;
  listEmployee;
  listProduct;
  constructor(private fb: FormBuilder, private purchase: PurchaseOrderService,
    private router: Router, private actRoute: ActivatedRoute) { }

  ngOnInit() {
    this.puchaseOrderForm = this.fb.group({
      'Amount': [null, [Validators.required]],
      'UnitCost': [null, [Validators.required]],
      'Product': [null, [Validators.required]],
      'Employee': [null, [Validators.required]]
    });
    this.actRoute.data.subscribe((data) => {
      this.listEmployee = data.listEmployee;
      this.listProduct = data.listProduct;
    })

  }

  save() {
    this.purchase.addPurchaseOrders(this.puchaseOrderForm.value).subscribe((data) => {
      this.router.navigate(['../'], { relativeTo: this.actRoute });
    });

    console.log(this.puchaseOrderForm.value);
  }
}

