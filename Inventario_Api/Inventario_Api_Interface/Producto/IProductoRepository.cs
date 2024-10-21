using Inventario_Api_DTO;
using Inventario_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Interface.Producto
{
    public interface IProductoRepository
    {
        Task<Guid> Save(ProductoDTO entity);
        Task<ProductoDTO> GetById(Guid Id);
        Task Modified(ProductoDTO entity);
        Task<IEnumerable<ProductoDTO>> GetProductos();
    }
}
