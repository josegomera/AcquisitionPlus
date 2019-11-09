import { Component, OnInit, AfterViewInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { PurchaseOrderService } from "src/app/core/services/purchase-order.service";

@Component({
  selector: "app-purchace-order-add",
  templateUrl: "./purchace-order-add.component.html",
  styleUrls: ["./purchace-order-add.component.css"]
})
export class PurchaceOrderAddComponent implements OnInit, AfterViewInit {
  puchaseOrderForm: FormGroup;
  listEmployee;
  listProduct;
  constructor(
    private fb: FormBuilder,
    private purchase: PurchaseOrderService,
    private router: Router,
    private actRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.puchaseOrderForm = this.fb.group({
      amount: [null, [Validators.required]],
      unitCost: [null, [Validators.required]],
      idEmployee: [null, [Validators.required]],
      idProduct: [null, [Validators.required]]
    });
    this.actRoute.data.subscribe(data => {
      this.listEmployee = data.listEmployee;
      this.listProduct = data.listProduct;
    });
  }

  ngAfterViewInit(): void {
    // this.checkInvalid();
  }

  checkInvalid() {
    const invalid = [];
    console.log(this.puchaseOrderForm);
    // const controls = this.puchaseOrderForm.controls;
    // for (const name in controls) {
    //   if (controls[name].invalid) {
    //     invalid.push(name);
    //   }
    // }
    return invalid;
  }

  save() {
    let unitCostControl = this.puchaseOrderForm.get('unitCost');
    unitCostControl.setValue(+unitCostControl.value);

    unitCostControl.updateValueAndValidity();

    console.log(this.puchaseOrderForm.value);
    this.purchase.addPurchaseOrders(this.puchaseOrderForm.value).subscribe(
      data => {
        this.router.navigate(["../"], { relativeTo: this.actRoute });
      },
      error => console.log(error)
    );
  }
}
