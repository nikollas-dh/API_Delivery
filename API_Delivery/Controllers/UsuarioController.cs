using API_Delivery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DbDeliveryContext ct;
        public UsuarioController(DbDeliveryContext ct)
        {
            this.ct = ct;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            try
            {
                var us = ct.Usuarios.FirstOrDefault(u =>
             u.Email == usuario.Email &&
             u.Senha == usuario.Senha);

                if (us == null)
                {
                    return Unauthorized("Usuário ou senha incorretos!");
                }

                string tipoUsuario;

                if (ct.Administradors.Any(a => a.IdUsuario == us.IdUsuario))
                {
                    tipoUsuario = "Administrador";
                }
                else if (ct.Clientes.Any(c => c.IdUsuario == us.IdUsuario))
                {
                    tipoUsuario = "Cliente";
                }
                else if (ct.Entregadors.Any(e => e.IdUsuario == us.IdUsuario))
                {
                    tipoUsuario = "Entregador";
                }
                else
                {
                    return BadRequest("Usuário sem perfil cadastrado.");
                }

                return Ok(new
                {
                    us.IdUsuario,
                    us.Nome,
                    us.Email,
                    TipoUsuario = tipoUsuario
                });
            }
            catch (Exception)
            {

                return StatusCode(500,"Erro interno no servidor!");
            }
         
        }

    }
}
