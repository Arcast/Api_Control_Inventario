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
        public async Task<ActionResult> Guardar([FromBody] BodegaDTO bodega)
        {
            try
            {

                IEnumerable<BodegaDTO> listaBodegas = await _repository.BodegaRepository.GetBodegas();     
                
                int existe = (from a in listaBodegas where a.Nombre == bodega.Nombre select a).Count();

                if (existe > 0)
                {
                    return BadRequest("El Nombre de la bodega que desea guardar ya existe");
                }

                var BodegaId = await _repository.BodegaRepository.Save(bodega);
                return Ok(BodegaId);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al guardar bodega");
            }
        }

        /// <summary>
        /// Buscar bodega por Id.
        /// <returns>IdBodega</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Buscar Bodega.")]
        public async Task<ActionResult> BuscarPorId(Guid Id)
        {
            try
            {
                BodegaDTO Bodega = await _repository.BodegaRepository.GetById(Id);
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

        /// <summary>
        /// Mostrar lista de bodegas.
        /// <returns>IdBodega</returns>
        [HttpGet]
        [Route("MostrarBodegas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Mostrar Bodegas.")]
        public async Task<ActionResult> MostrarBodegas()
        {
            try
            {
                IEnumerable<BodegaDTO> listaBodegas = await _repository.BodegaRepository.GetBodegas();

                return Ok(listaBodegas);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}
