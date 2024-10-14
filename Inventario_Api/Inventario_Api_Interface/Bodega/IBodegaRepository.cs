using Inventario_Api_DTO;
using Inventario_Api_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Interface.Bodega
{
    public interface IBodegaRepository
    {
        Task<Guid> Save(BodegaDTO entity);
        Task<BodegaDTO> GetById(Guid Id);
        Task Modified(BodegaDTO entity);
        Task<IEnumerable<BodegaDTO>> GetBodegas();
    }
}
