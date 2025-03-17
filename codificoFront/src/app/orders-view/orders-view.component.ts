import { Component } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-orders-view',
  imports: [CommonModule,FormsModule],
  templateUrl: './orders-view.component.html',
  styleUrl: './orders-view.component.css'
})

export class OrdersViewComponent {
  customer: any;
  orders: any[] = [];
  displayedOrders: any[] = []; 
  searchQuery: string = '';
  currentPage: number = 1;
  pageSize: number = 10;
  totalOrders: number = 0;
  Math = Math;
    constructor(private generalService: GeneralService, private router: Router) {}
  ngOnInit(): void {
    const navigation = window.history.state;
    this.customer = navigation.customerData || { customerName: ''};
    if (this.customer.customerName) {
      this.loadOrders(this.customer.customerName);
    }
  }

  loadOrders(customerId: number): void {
    this.generalService.getById("GetClientOrders",customerId).subscribe({
      next: (response: any) => {
        console.log(response.data);
        this.orders = response;
        this.totalOrders = this.orders.length;
        this.updatePagination();
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        console.log('Se completo con exito');
      },
    });
  }
  updatePagination(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    this.displayedOrders = this.orders.slice(startIndex, endIndex);
  }

  changePage(page: number): void {
    if (page < 1 || page > Math.ceil(this.totalOrders / this.pageSize)) return;
    this.currentPage = page;
    this.updatePagination();
  }
  regresar(){
    this.router.navigate(['/prediction']);
  }

}
