using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodficoBack.Entities.Entities
{
    public class Respuesta<T>
    {
        public bool Error { get; set; } = false;
        public T Data { get; set; }
        public string DescripcionError { get; set; } = string.Empty;
    }
}

