using DotacionBack.Application.DTOs;
using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Domain.Entities;
using DotacionBack.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotacionBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SedeController : ControllerBase
    {
        private readonly ISedeRepository _repository;

        public SedeController(ISedeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>Obtiene todas las sedes</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SedeEntity>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        /// <summary>Obtiene las sedes por institución</summary>
        [HttpGet("{institucionId}")]
        [ProducesResponseType(typeof(IEnumerable<SedeEntity>), 200)]
        public async Task<IActionResult> GetByInstitucionId(int institucionId)
        {
            var result = await _repository.GetResumenDotacionBySedeId(institucionId);
            return Ok(result);
        }

        [HttpGet("{sedeId}/dotacion")]
        [ProducesResponseType(typeof(IEnumerable<DotacionPorSedeDto>), 200)]
        public async Task<IActionResult> GetDotacionBySedeId(int sedeId)
        {
            var result = await _repository.GetDotacionBySedeId(sedeId);
            return Ok(result);
        }


        /// <summary>Registra una nueva sede</summary>
        [HttpPost]
        [ProducesResponseType(typeof(SedeEntity), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] SedeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SedeEntity
            {
                NombreSede = dto.NombreSede,
                CodigodaneSede = dto.CodigodaneSede,
                DireccionSede = dto.DireccionSede,
                LatitudSede = dto.LatitudSede,
                LongitudSede = dto.LongitudSede,
                ZonaSede = dto.ZonaSede,
                FkIdInstitucion = dto.FkIdInstitucion
            };

            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetAll), null, entity);
        }
    }
}
