using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Entities.Dto
{
    public class OrderDto
    {
        public int EmpId { get; set; } 
        public int ShipperId { get; set; }
        public int? CustId { get; set; } = 0;
        public string CustName { get; set; }
        public string ShipName { get; set; } = string.Empty;
        public string ShipAddress { get; set; } = string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipCountry { get; set; } = string.Empty;
        public OrderDetailDto OrderDetail { get; set; } 


    }

    public class OrderDetailDto
    {
        public int OrderId { get; set; } 
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
