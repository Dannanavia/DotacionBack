using DotacionBack.Application.DTOs;
using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotacionBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtService _jwtService;

        public AuthController(IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _usuarioRepository.GetByCredentialsAsync(dto.CorreoUsuario, dto.ContraseniaUsuario);
            if (user is null)
                return Unauthorized("Credenciales inválidas");

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                usuario = new
                {
                    user.IdUsuario,
                    user.CorreoUsuario
                }
            });
        }

    }
}
