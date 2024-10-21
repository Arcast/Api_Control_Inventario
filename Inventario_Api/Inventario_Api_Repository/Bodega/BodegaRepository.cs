using Inventario_Api_DTO;
using Inventario_Interface.Bodega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario_Api_Entities;
using Inventario_Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Inventario_Repository.Bodega
{
    public class BodegaRepository : RepositoryBase<BodegaEntities>, IBodegaRepository
    {
        public BodegaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Guid> Save(BodegaDTO entity)
        {
            BodegaEntities bodega = new BodegaEntities()
            {
                Nombre = entity.Nombre,
                Codigo = entity.Codigo,
                Estado = entity.Estado
            };           

            Create(bodega);
            await SaveAsync();
            return bodega.BodegaId;
        }

        public async Task<BodegaDTO> GetById(Guid Id)
        {
            BodegaDTO bodega = new BodegaDTO();

            bodega = await FindByCondition(a => a.BodegaId == Id).Select(b => new BodegaDTO()
            {
                BodegaId = b.BodegaId,
                Nombre = b.Nombre,
                Codigo = b.Codigo,
                Estado = b.Estado
            }).FirstOrDefaultAsync();

            return bodega;
        }

        public async Task Modified(BodegaDTO entity)
        {
            BodegaEntities bodega = await FindByCondition(a => a.BodegaId == entity.BodegaId).FirstOrDefaultAsync();

            bodega.Nombre = entity.Nombre;
            bodega.Codigo = entity.Codigo;
            bodega.Estado = entity.Estado;

            Update(bodega);
            await SaveAsync();        
        }

        public async Task<IEnumerable<BodegaDTO>> GetBodegas()
        {
            IEnumerable<BodegaDTO> listaBodegas = new List<BodegaDTO>();

            listaBodegas = await FindAll().Select(a => new BodegaDTO
            {
                BodegaId = a.BodegaId,
                Nombre = a.Nombre,
                Codigo = a.Codigo,
                Estado = a.Estado
            }).ToListAsync();

            return listaBodegas;

        }
    }
}
