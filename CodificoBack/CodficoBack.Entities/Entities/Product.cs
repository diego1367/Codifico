using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Entities.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
