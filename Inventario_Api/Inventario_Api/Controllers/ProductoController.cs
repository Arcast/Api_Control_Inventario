using Inventario_Api_DTO;
using Inventario_DTO;
using Inventario_Interface;
using Inventario_Interface.Bodega;
using Inventario_Interface.Producto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api_Inventario.Controllers
{
    [Route("Producto")]
    public class ProductoController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        private readonly IProductoRepository _productoRepository;

        public ProductoController(
            IRepositoryWrapper repository,
            IProductoRepository productoRepository,
            IConfiguration configuration
        )
        {
            _repository = repository;
            _productoRepository = productoRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Guardar nuevo producto.
        /// <returns>IdProducto</returns>
        [HttpPost]
        [Route("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Éxito al guardar Producto.")]
        public async Task<ActionResult> Guardar([FromBody] ProductoDTO producto)
        {
            try
            {

                IEnumerable<ProductoDTO> ListaProductos = await _repository.ProductoRepository.GetProductos();

                int existe = (from a in ListaProductos where a.NombreProducto == producto.NombreProducto select a).Count();

                if (existe > 0)
                {
                    return BadRequest("El Nombre del producto que desea guardar ya existe");
                }

                var ProductoId = await _repository.ProductoRepository.Save(producto);
                return Ok(ProductoId);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al guardar Producto");
            }
        }

        /// <summary>
        /// Buscar producto por Id.
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarPorId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Buscar Producto.")]
        public async Task<ActionResult> BuscarPorId(Guid Id)
        {
            try
            {
                ProductoDTO productoDTO = await _repository.ProductoRepository.GetById(Id);
                return Ok(productoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Modificar producto.
        /// <returns></returns>
        [HttpPost]
        [Route("Modificar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Modificar Producto.")]
        public async Task<ActionResult> Modificar([FromBody] ProductoDTO producto)
        {
            try
            {
                ProductoDTO productoDTO = await _repository.ProductoRepository.GetById(producto.ProductoId);

                if (productoDTO is null)
                {
                    return BadRequest("Id de producto no encontrada");
                }

                await _repository.ProductoRepository.Modified(producto);
                return Ok("Modificado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Mostrar lista de productos.
        /// <returns>IdBodega</returns>
        [HttpGet]
        [Route("MostrarProductos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, "Mostrar Productos.")]
        public async Task<ActionResult> MostrarProductos()
        {
            try
            {
                IEnumerable<ProductoDTO> ListaProductos = await _repository.ProductoRepository.GetProductos();

                return Ok(ListaProductos);

            }
            catch (Exception ex)
            {
                return BadRequest("Error al consultar Productos");
            }
        }

    }
}
