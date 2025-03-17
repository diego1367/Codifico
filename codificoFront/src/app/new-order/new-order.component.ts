import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-new-order',
  imports: [CommonModule,FormsModule, ReactiveFormsModule],
  standalone: true,
  templateUrl: './new-order.component.html',
  styleUrl: './new-order.component.css'
})
export class NewOrderComponent implements OnInit {
  
  employees: any[] = [];
  shippers: any[] = [];
  products: any[] = [];
  customer: any;
  orderForm: FormGroup;

  constructor(private generalService: GeneralService, private router: Router, private fb: FormBuilder,) {
    this.orderForm = this.fb.group({
      empId: [0, Validators.required],
      custId: [0],
      custName: [null],
      shipperId: [null, Validators.required],
      shipName: ['', [Validators.required, Validators.maxLength(50)]],
      shipAddress: ['', [Validators.required, Validators.maxLength(100)]],
      shipCity: ['', Validators.required],
      shipCountry: ['', Validators.required],
      orderDate: ['', Validators.required],
      requiredDate: ['', Validators.required],
      shippedDate: [''],
      freight: [0, [Validators.required, Validators.min(0)]],
      orderDetail: this.fb.group({
        productId: ['', Validators.required],
        unitPrice: [0, [Validators.required, Validators.min(0)]],
        quantity: [0, [Validators.required, Validators.min(1)]],
        discount: [0, [Validators.required, Validators.min(0), Validators.max(1)]]
      })
    });
  }

  ngOnInit():void {

    const navigation = window.history.state;
    this.customer = navigation.customerData || { customerName: ''};

    if (this.customer.customerName) {
      this.loadDropdownData();
    }
    
  }

  loadDropdownData() {
    this.generalService.get("GetEmployee").subscribe({
      next: (response: any) => {
        this.employees = response;
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('Se completo con exito');
      },
    });
    this.generalService.get("GetShippers").subscribe({
      next: (response: any) => {
        this.shippers = response;

      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('Se completo con exito');
      },
    });
    this.generalService.get("GetProducts").subscribe({
      next: (response: any) => {
        this.products = response;

      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('Se completo con exito');
      },
    });
  }

  saveOrder() {
    if (this.orderForm.invalid) {
      this.orderForm.markAllAsTouched(); // Muestra errores en los campos vacíos
      return;
    }

    this.orderForm.patchValue({
      custName: this.customer.customerName
  });
  console.log(this.orderForm.value)
    this.generalService.post("PostNewOrder",this.orderForm.value).subscribe({
      next: (response: any) => {
        console.log(response);
        alert('Order created successfully!');
        this.router.navigate(['/prediction']);
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('Se completo con exito');
      },
    });
  }

  close() {
    this.router.navigate(['/prediction']);
  }
}
