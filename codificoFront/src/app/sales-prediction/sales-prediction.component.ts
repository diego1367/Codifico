import { Component } from '@angular/core';
import { GeneralService } from '../../services/general.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sales-prediction',
  imports: [FormsModule, CommonModule],
  templateUrl: './sales-prediction.component.html',
  styleUrl: './sales-prediction.component.css'
})
export class SalesPredictionComponent {
  customers: any[] = [];
  displayedCustomers: any[] = []; 
  searchQuery: string = '';
  currentPage: number = 1;
  pageSize: number = 10;
  totalCustomers: number = 0;
  Math = Math;
  sortColumn: string = '';
  sortDirection: 'asc' | 'desc' = 'asc';


  constructor(private generalService: GeneralService, private router: Router) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.generalService.get("GetSalesPrediction").subscribe({
      next: (response: any) => {
        console.log(response.data);
        this.customers = response.data;
        this.totalCustomers = this.customers.length;
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
    this.displayedCustomers = this.customers.slice(startIndex, endIndex);
  }

  changePage(page: number): void {
    if (page < 1 || page > Math.ceil(this.totalCustomers / this.pageSize)) return;
    this.currentPage = page;
    this.updatePagination();
  }

  searchCustomers(): void {
    if (!this.searchQuery.trim()) {
      this.loadCustomers(); 
      return;
    }
    this.displayedCustomers = this.customers
      .filter(c => c.customerName.toLowerCase().includes(this.searchQuery.toLowerCase()))
      .slice(0, this.pageSize);
  }

  openViewOrders(customer: any): void {
    this.router.navigate(['/orderview'], {
      state: { customerData: customer } 
    });
  }

  openNewOrder(customer: any): void {
    this.router.navigate(['/newapp'], {
      state: { customerData: customer } 
    });

  }
  sortBy(column: string) {
    if (this.sortColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortColumn = column;
      this.sortDirection = 'asc';
    }

    this.customers.sort((a: any, b: any) => {
      const valueA = a[column];
      const valueB = b[column];

      if (valueA < valueB) return this.sortDirection === 'asc' ? -1 : 1;
      if (valueA > valueB) return this.sortDirection === 'asc' ? 1 : -1;
      return 0;
    });

    this.updatePagination();
  }
}
