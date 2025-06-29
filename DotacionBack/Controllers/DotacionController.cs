using DotacionBack.Application.DTOs;
using DotacionBack.Application.Interfaces.Repositories;
using DotacionBack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DotacionBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DotacionController : ControllerBase
    {
        private readonly IDotacionRepository _repository;

        public DotacionController(IDotacionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene todas las dotaciones
        /// </summary>
        /// <returns>Lista de dotaciones</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DotacionEntity>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var dotaciones = await _repository.GetAllAsync();
            return Ok(dotaciones);
        }

        /// <summary>
        /// Crea una nueva dotación
        /// </summary>
        /// <param name="dto">Datos de la dotación</param>
        /// <returns>Dotación creada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(DotacionEntity), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] DotacionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new DotacionEntity
            {
                CantidadDotacion = dto.CantidadDotacion,
                FkIdArticulo = dto.FkIdArticulo,
                FkIdSede = dto.FkIdSede,
                FkIdTipodotacion = dto.FkIdTipodotacion
            };

            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetAll), null, entity);
        }
    }
}
