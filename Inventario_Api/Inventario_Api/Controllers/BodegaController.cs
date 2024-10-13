using AutoMapper;
using Inventario_Api_DTO;
using Inventario_Interface;
using Inventario_Interface.Bodega;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api_Inventario.Controllers
{

    /// <summary>
    /// Api para la gestión y consulta de bodegas
    /// </summary>
    //[Authorize]
    [Route("Bodega")]
    [ApiController]
    public class BodegaController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        private readonly IBodegaRepository _bodegaRepository;

        public BodegaController(
            IRepositoryWrapper repository,
            IBodegaRepository bodegaRepository,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _bodegaRepository = bodegaRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Guardar la nueva bodega.
        /// <returns>IdBodega</returns>
        [HttpPost]
        [Route("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Éxito al guardar Bodega.")]
        public async Task<ActionResult> Guardar([FromQuery] BodegaDTO bodega)
        {
            try
            {
                var BodegaId = await _repository.BodegaRepository.Save(bodega);
                return Ok(BodegaId);
            }
            catch (Exception ex)
            {
                return BadRequest(bodega);
            }
        }

        /// <summary>
        /// Buscar bodega por Id.
        /// <returns>IdBodega</returns>
        [HttpPost]
        [Route("BuscarPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Buscar Bodega.")]
        public async Task<ActionResult> BuscarPorId(Guid Id)
        {
            try
            {
                var Bodega = await _repository.BodegaRepository.GetById(Id);
                return Ok(Bodega);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modificar bodega.
        /// <returns>IdBodega</returns>
        [HttpPost]
        [Route("Modificar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificar Bodega.")]
        public async Task<ActionResult> Modificar([FromBody] BodegaDTO bodega)
        {
            try
            {
                BodegaDTO bodegaDTO = await _repository.BodegaRepository.GetById(bodega.BodegaId);

                if (bodegaDTO is null)
                {
                    return BadRequest("Id de bodega no encontrada");
                }

                await _repository.BodegaRepository.Modified(bodega);
                return Ok("Modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
