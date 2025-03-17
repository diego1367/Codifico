using CodficoBack.Entities.Dto;
using CodficoBack.Entities.Entities;
using CodificoBack.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodificoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodificoController : ControllerBase
    {
        private readonly ISales _sales;
        public CodificoController(ISales sales)
        {
            _sales = sales;
        }

        [HttpGet("GetEmployee")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployee()
        {
            try
            {
                var tasks = _sales.GetEmployee();
                if (tasks == null || tasks.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("GetShippers")]
        public ActionResult<IEnumerable<Shipper>> GetShippers()
        {
            try
            {
                var tasks = _sales.GetShippers();
                if (tasks == null || tasks.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var tasks = _sales.GetProducts();
                if (tasks == null || tasks.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("GetClientOrders")]
        public ActionResult<IEnumerable<Order>> GetClientOrders(string cliente)
        {
            try
            {
                var tasks = _sales.GetClientOrders(cliente);
                if (tasks == null || tasks.Count() == 0)
                {
                    return NoContent();
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("GetSalesPrediction")]
        public ActionResult<Respuesta<IEnumerable<SalesPrediction>>> GetSalesPrediction()
        {
            try
            {
                var result = _sales.GetSalesPrediction();
                if (result.Error)
                {
                    return StatusCode(500, result.DescripcionError);
                }
                if (result.Data == null)
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("PostNewOrder")]
        public ActionResult<bool> PostNewOrder(OrderDto order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }
                var inserted = _sales.AddNewOrder(order);
                if (inserted == null)
                {
                    return StatusCode(500, "No se pudo insertar");
                }
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}
