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
    public class InstitucionController : ControllerBase
    {
        private readonly IInstitucionRepository _repository;

        public InstitucionController(IInstitucionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Obtiene todas las instituciones</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InstitucionEntity>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        /// <summary>Obtiene las instituciones por municipio</summary>
        [HttpGet("{MunicipioId}")]
        [ProducesResponseType(typeof(IEnumerable<InstitucionEntity>), 200)]
        public async Task<IActionResult> GetByMunicipioId(int municipioId)
        {
            var result = await _repository.GetAllByMunicipioId(municipioId);
            return Ok(result);
        }


        /// <summary>Registra una nueva institución</summary>
        [HttpPost]
        [ProducesResponseType(typeof(InstitucionEntity), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] InstitucionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new InstitucionEntity
            {
                NombreInstitucion = dto.NombreInstitucion,
                CalendarioInstitucion = dto.CalendarioInstitucion,
                CodigodaneInstitucion = dto.CodigodaneInstitucion,
                FkIdMunicipio = dto.FkIdMunicipio
            };

            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetAll), null, entity);
        }
    }
}
