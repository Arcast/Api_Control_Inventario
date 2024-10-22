using Inventario_Interface.Bodega;
using Inventario_Interface;
using Microsoft.AspNetCore.Mvc;
using Inventario_Interface.MovimientoInventario;
using Inventario_Api_DTO;
using Swashbuckle.AspNetCore.Annotations;
using Inventario_DTO;

namespace Api_Inventario.Controllers
{
    /// <summary>
    /// Api para la gestión y consulta de Movimientos de inventario
    /// </summary>
    //[Authorize]
    [Route("Movimientos")]
    [ApiController]
    public class MovimientoInventarioController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        private readonly IMovimientoInventarioRepository _movimientoInventarioRepository;

        public MovimientoInventarioController(
            IRepositoryWrapper repository,
            IMovimientoInventarioRepository movimientoInventarioRepository,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _movimientoInventarioRepository = movimientoInventarioRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Guardar la nuevo movimiento.
        /// <returns>IdBodega</returns>
        [HttpPost]
        [Route("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Éxito al guardar Movimiento.")]
        public async Task<ActionResult> Guardar([FromBody] MovimientoInventarioDTO movimiento)
        {
            try
            {
                BodegaDTO bodegaDTO = await _repository.BodegaRepository.GetById(movimiento.BodegaId);
                if (bodegaDTO is null) return BadRequest("Id de bodega no encontrada");

                ProductoDTO productoDTO = await _repository.ProductoRepository.GetById(movimiento.ProductoId);
                if (productoDTO is null) return BadRequest("Id de producto no encontrado");

                var MovimientoId = await _repository.movimientoInventarioRepository.Save(movimiento);
                return Ok(MovimientoId);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al guardar Movimiento");
            }
        }

        /// <summary>
        /// Buscar Movimiento por Id.
        /// <returns>IdBodega</returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Buscar Movimiento.")]
        public async Task<ActionResult> BuscarPorId(Guid Id)
        {
            try
            {
                MovimientoInventarioDTO movimiento = await _repository.movimientoInventarioRepository.GetById(Id);
                return Ok(movimiento);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al buscar movimiento");
            }
        }

        /// <summary>
        /// Modificar Movimiento.
        /// <returns>IdBodega</returns>
        [HttpPost]
        [Route("Modificar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificar Bodega.")]
        public async Task<ActionResult> Modificar([FromBody] MovimientoInventarioDTO movimiento)
        {
            try
            {
                MovimientoInventarioDTO movimientoInventario = await _repository.movimientoInventarioRepository.GetById(movimiento.MovimientoId);

                if (movimientoInventario is null) return BadRequest("Id de Movimiento no encontrado");

                await _repository.movimientoInventarioRepository.Modified(movimiento);
                return Ok("Modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Mostrar lista de movimientos.
        /// <returns>IdBodega</returns>
        [HttpGet]
        [Route("MostrarMovimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Mostrar Movimientos.")]
        public async Task<ActionResult> MostrarMovimientos()
        {
            try
            {
                return Ok("No disponible");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
