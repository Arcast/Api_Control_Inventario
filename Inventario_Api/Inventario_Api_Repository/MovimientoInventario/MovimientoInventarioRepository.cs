using Inventario_Api_DTO;
using Inventario_Api_Entities;
using Inventario_DTO;
using Inventario_Entities;
using Inventario_Interface.Bodega;
using Inventario_Interface.MovimientoInventario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Repository.MovimientoInventario
{
    public class MovimientoInventarioRepository : RepositoryBase<MovimientoInventarioEntities>, IMovimientoInventarioRepository
    {
        public MovimientoInventarioRepository(RepositoryContext repositoryContex) : base(repositoryContex)
        {
        }

        public async Task<MovimientoInventarioDTO> GetById(Guid Id)
        {
            MovimientoInventarioDTO movimiento = new MovimientoInventarioDTO();

            movimiento = await FindByCondition(a => a.MovimientoId == Id).Select(b => new MovimientoInventarioDTO()
            {
                MovimientoId = b.MovimientoId,
                ProductoId = b.ProductoId,
                BodegaId = b.BodegaId,
                TipoMovimiento = b.TipoMovimiento,
                Cantidad = b.Cantidad,
                Observaciones = b.Observaciones,
                FechaMovimiento = b.FechaMovimiento,
                CreadoPor = b.CreadoPor
            }).FirstOrDefaultAsync();

            return movimiento;
        }

        public Task<IEnumerable<MovimientoInventarioDTO>> GetMovimientos()
        {
            throw new NotImplementedException();
        }

        public async Task Modified(MovimientoInventarioDTO entity)
        {
            MovimientoInventarioEntities movimiento = await FindByCondition(a => a.MovimientoId == entity.MovimientoId).FirstOrDefaultAsync();

            movimiento.MovimientoId = entity.MovimientoId;
            movimiento.ProductoId = entity.ProductoId;
            movimiento.BodegaId = entity.BodegaId;
            movimiento.TipoMovimiento = entity.TipoMovimiento;
            movimiento.Cantidad = entity.Cantidad;
            movimiento.Observaciones = entity.Observaciones;
            movimiento.FechaMovimiento = DateTime.Now;
            movimiento.CreadoPor = entity.CreadoPor;

            Update(movimiento);
            await SaveAsync();
        }

        public async Task<Guid> Save(MovimientoInventarioDTO entity)
        {
            try
            {
                MovimientoInventarioEntities movimiento = new MovimientoInventarioEntities()
                {
                    MovimientoId = entity.MovimientoId,
                    ProductoId = entity.ProductoId,
                    BodegaId = entity.BodegaId,
                    TipoMovimiento = entity.TipoMovimiento,
                    Cantidad = entity.Cantidad,
                    Observaciones = entity.Observaciones,
                    FechaMovimiento = DateTime.Now,
                    CreadoPor = entity.CreadoPor
                };

                Create(movimiento);
                await SaveAsync();
                return movimiento.MovimientoId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
