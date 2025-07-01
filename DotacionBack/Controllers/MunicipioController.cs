using DotacionBack.Application.DTOs;
using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotacionBack.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioRepository _repository;

        public MunicipioController(IMunicipioRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Obtiene todos los municipios</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MunicipioEntity>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        /// <summary>Registra un nuevo municipio</summary>
        [HttpPost]
        [ProducesResponseType(typeof(MunicipioEntity), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] MunicipioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new MunicipioEntity
            {
                NombreMunicipio = dto.NombreMunicipio,
                LatitudMunicipio = dto.LatitudMunicipio,
                LongitudMunicipio = dto.LongitudMunicipio
            };

            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetAll), null, entity);
        }
    }
}
