export interface Order {
    empId: number;
    shipperId: number;
    shipName: string;
    shipAddress: string;
    shipCity: string;
    shipCountry: string;
    orderDate: string;
    requiredDate: string;
    shippedDate?: string;
    freight: number;
    orderDetail: OrderDetail;
  }
  
  export interface OrderDetail {
    productId: number;
    unitPrice: number;
    quantity: number;
    discount: number;
  }