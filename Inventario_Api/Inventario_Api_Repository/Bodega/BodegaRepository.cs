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
                Codigo = entity.Codigo
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
                Codigo= b.Codigo
            }).FirstOrDefaultAsync();

            return bodega;
        }

        public async Task Modified(BodegaDTO entity)
        {
            BodegaEntities bodega = await FindByCondition(a => a.BodegaId == entity.BodegaId).FirstOrDefaultAsync();

            bodega.Nombre = entity.Nombre;
            bodega.Codigo = entity.Codigo;

            Update(bodega);
            await SaveAsync();        
        }

    }
}
