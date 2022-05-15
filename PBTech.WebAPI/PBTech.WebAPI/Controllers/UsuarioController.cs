using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBTech.WebAPI.Data;
using PBTech.WebAPI.Models;

namespace PBTech.WebAPI.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _contexto;

        public UsuarioController(UsuarioContext contexto) 
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("{nome}/{email}")]
        public async Task<IActionResult> Consultar([FromRoute] string nome, string email) 
        {
            var usuarioDB = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Nome == nome && u.Email == email);

            if (usuarioDB != null)
                return Ok(usuarioDB);

            return NotFound();
        }

        
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario usuario) {
            var usuarioDB = _contexto.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);

            if (usuarioDB != null)
                return BadRequest();

            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return Ok(usuario);
        }

        
        [HttpDelete]
        [Route("{email}")]
        public async Task<IActionResult> Excluir(string email) {
            var usuarioDB = _contexto.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuarioDB != null) { 
                _contexto.Usuarios.Remove(usuarioDB);
                await _contexto.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        
        [HttpPut]
        public async Task<ActionResult> Atualizar(string email, [FromBody] Usuario usuario) {
            var usuarioDB = _contexto.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuarioDB != null)
            {
                _contexto.Entry(usuario).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}
