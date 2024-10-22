using Inventario_Api_DTO;
using Inventario_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Interface.MovimientoInventario
{
    public interface IMovimientoInventarioRepository
    {
        Task<Guid> Save(MovimientoInventarioDTO entity);
        Task<MovimientoInventarioDTO> GetById(Guid Id);
        Task Modified(MovimientoInventarioDTO entity);
        Task<IEnumerable<MovimientoInventarioDTO>> GetMovimientos();
    }
}

