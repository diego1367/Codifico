using CodficoBack.Entities.Dto;
using CodficoBack.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodificoBack.Business.Mappers
{
    public static class OrderMapper
    {
        public static Order ToEntity(this OrderDto dto)
        {
            return new Order
            {
                EmpId = dto.EmpId,
                CustId= dto.CustId,
                ShipperId = dto.ShipperId,
                ShipName = dto.ShipName,
                ShipAddress = dto.ShipAddress,
                ShipCity = dto.ShipCity,
                OrderDate = dto.OrderDate,
                RequiredDate = dto.RequiredDate,
                ShippedDate = dto.ShippedDate,
                Freight = dto.Freight,
                ShipCountry = dto.ShipCountry,
                OrderDetails =  new List<OrderDetail> { new OrderDetail
                {
                    ProductId = dto.OrderDetail.ProductId,
                    UnitPrice = dto.OrderDetail.UnitPrice,
                    Qty = dto.OrderDetail.Quantity,
                    Discount = dto.OrderDetail.Discount
                } }
            };
        }
    }
}
