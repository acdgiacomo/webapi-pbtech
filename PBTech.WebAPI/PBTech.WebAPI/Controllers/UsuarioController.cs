using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBTech.WebAPI.Data;
using PBTech.WebAPI.Models;

namespace PBTech.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _contexto;

        public UsuarioController(UsuarioContext contexto) 
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarTodos() {
            List<Usuario> usuarios = await _contexto.Usuarios.ToListAsync();

            return Ok(usuarios);   
        }

        [HttpGet]
        [Route("consultar/{nome}/{email}")]
        public async Task<IActionResult> Consultar([FromRoute] string nome, string email) 
        {
            var usuarioDB = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Nome == nome && u.Email == email);

            if (usuarioDB != null)
                return Ok(usuarioDB);

            return NotFound();
        }

        
        [HttpPost]
        [Route("incluir")]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario usuario) {
            var usuarioDB = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (usuarioDB != null)
                return BadRequest();

            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();

            return Ok(usuario);
        }

        
        [HttpDelete]
        [Route("excluir/{email}")]
        public async Task<IActionResult> Excluir(string email) {
            var usuarioDB = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuarioDB != null) { 
                _contexto.Usuarios.Remove(usuarioDB);
                await _contexto.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        
        [HttpPut]
        [Route("atualizar/{email}")]
        public async Task<ActionResult> Atualizar(string email, [FromBody] Usuario usuario) {
            var usuarioDB = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (usuarioDB != null)
                return BadRequest();

            var usuarioAtt = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuarioAtt != null)
            {
                usuarioAtt.Nome = usuario.Nome;
                usuarioAtt.Email = usuario.Email;
            
                await _contexto.SaveChangesAsync();

                return Ok(usuarioAtt);
                
            }

            return NotFound();
        }
    }
}
