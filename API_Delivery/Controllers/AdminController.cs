using API_Delivery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DbDeliveryContext ct;
        public AdminController(DbDeliveryContext ct)
        {
            this.ct = ct;
        }



        [HttpGet("resumo")]
        public async Task<IActionResult> Resumo() => Ok(new
        {
            pendentes = await ct.Pedidos.CountAsync(p => p.IdStatus == 1),
            entregues = await ct.Pedidos.CountAsync(p => p.IdStatus == 2),
            emTransito = await ct.Pedidos.CountAsync(p => p.IdStatus == 3),
            cancelados = await ct.Pedidos.CountAsync(p => p.IdStatus == 4)
        });
    }
}
