using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Entities.Entities
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
