using API_Delivery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadorController : ControllerBase
    {
        private readonly DbDeliveryContext ct;
        public EntregadorController(DbDeliveryContext ct)
        {
            this.ct = ct;
        }

        [HttpGet]
        public IActionResult ListarPedidos() 
        {
            try
            {
                var p = ct.Pedidos.Where(o => o.IdStatus == 2).ToList();
                return Ok(p);
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
