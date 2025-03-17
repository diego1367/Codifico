using CodficoBack.Entities.Dto;
using CodficoBack.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodificoBack.Business.Interfaces
{
    public interface ISales
    {
        //bool Insert(TaskToDo todo);
        IEnumerable<EmployeeDto> GetEmployee();
        IEnumerable<Shipper> GetShippers();
        IEnumerable<Product> GetProducts();
        Respuesta<IEnumerable<SalesPrediction>> GetSalesPrediction();
        IEnumerable<Order> GetClientOrders(string cliente);
        Respuesta<bool> AddNewOrder(OrderDto order);


    }
}
