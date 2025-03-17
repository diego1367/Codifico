using CodficoBack.Entities.Dto;
using CodficoBack.Entities.Entities;
using CodificoBack.Business.Interfaces;
using CodificoBack.Business.Mappers;
using CodificoBack.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodificoBack.Business.Implementation
{
    public class Sales : ISales
    {
        private IUnitOfWork _unit;
        public Sales(IUnitOfWork unit)
        {
            this._unit = unit;
        }

        public Respuesta<bool> AddNewOrder(OrderDto order)
        {
            try
            {
                order.CustId = this._unit.GenericRepository<Customer>().Get(x => x.CompanyName == order.CustName).FirstOrDefault().CustId;  
                var newOrder = order.ToEntity();
                this._unit.GenericRepository<Order>().Insert(newOrder);
                this._unit.Save();
                return new Respuesta<bool> { Error = false, Data = true };
            }
            catch (Exception ex)
            {
                return new Respuesta<bool> { Error = true, Data = false, DescripcionError = ex.Message };
            }
        }

        public IEnumerable<Order> GetClientOrders(string cliente)
        {
            return _unit.GenericRepository<Order>().Get(x => x.Customer.CompanyName == cliente).AsEnumerable();
        }

        public IEnumerable<EmployeeDto> GetEmployee()
        {
            return this._unit.GenericRepository<Employee>().Get().Select(emp => new EmployeeDto
            {
                Empid = emp.EmpId,
                FullName = $"{emp.FirstName} {emp.LastName}"
            }).ToList(); ;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this._unit.GenericRepository<Product>().Get();
        }

        public Respuesta<IEnumerable<SalesPrediction>> GetSalesPrediction()
        {
            try
            {
                var orders = this._unit.GenericRepository<SalesPrediction>().GetSp("GetNextOrderPrediction").ToList();
                return new Respuesta<IEnumerable<SalesPrediction>> { Error = false, Data = orders };
            }
            catch (Exception ex)
            {
                return new Respuesta<IEnumerable<SalesPrediction>> { Error = true, Data = null, DescripcionError = ex.Message };
            }
        }

        public IEnumerable<Shipper> GetShippers()
        {
            return this._unit.GenericRepository<Shipper>().Get();
        }
    }
}
