using Inventario_Interface.Bodega;
using Inventario_Interface.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Interface
{
    public interface IRepositoryWrapper
    {
        IBodegaRepository BodegaRepository { get; }
        IProductoRepository ProductoRepository { get; }
    }
}
