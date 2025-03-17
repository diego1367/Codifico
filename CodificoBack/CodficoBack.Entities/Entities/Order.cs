using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Entities.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public int EmpId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShipperId { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; } = string.Empty;
        public string ShipAddress { get; set; } = string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public string? ShipRegion { get; set; }
        public string ShipPostalCode { get; set; } = string.Empty;
        public string ShipCountry { get; set; } = string.Empty;

        public virtual Customer? Customer { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public virtual Shipper Shipper { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
