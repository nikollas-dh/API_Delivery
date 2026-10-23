using API_Delivery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly DbDeliveryContext ct;
        public ClienteController(DbDeliveryContext ct)
        {
            this.ct = ct;
        }

        [HttpGet("{IdUsuario:int}")]
        public IActionResult ListarPedidos([FromRoute] int IdUsuario) 
        {
            try
            {
                var pedidos = ct.Pedidos.Where(o => o.IdCliente == IdUsuario).ToList();
                return Ok(pedidos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
