using Inventario_Api_DTO;
using Inventario_Api_Entities;
using Inventario_DTO;
using Inventario_Entities;
using Inventario_Interface.Producto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Repository.Producto
{
    public class ProductoRepository : RepositoryBase<ProductoEntities>, IProductoRepository
    {
        public ProductoRepository(RepositoryContext repositoryContex) : base(repositoryContex)
        {
        }

        public async Task<ProductoDTO> GetById(Guid Id)
        {
            ProductoDTO producto = new ProductoDTO();

            producto = await FindByCondition(a => a.ProductoId == Id).Select(b => new ProductoDTO()
            {
                ProductoId = b.ProductoId,
                NombreProducto = b.NombreProducto,
                Descripcion = b.Descripcion,
                FechaCreacion = b.FechaCreacion,
                CreadoPor = b.CreadoPor
            }).FirstOrDefaultAsync();

            return producto;
        }

        public async Task<IEnumerable<ProductoDTO>> GetProductos()
        {
            IEnumerable<ProductoDTO> ListaProductos = new List<ProductoDTO>();

            ListaProductos = await FindAll().Select(b => new ProductoDTO()
            {
                ProductoId = b.ProductoId,
                NombreProducto = b.NombreProducto,
                Descripcion = b.Descripcion,
                FechaCreacion = b.FechaCreacion,
                CreadoPor = b.CreadoPor
            }).ToListAsync();

            return ListaProductos;
        }

        public async Task Modified(ProductoDTO entity)
        {
            ProductoEntities producto = await FindByCondition(a => a.ProductoId == entity.ProductoId).FirstOrDefaultAsync();

            producto.NombreProducto = entity.NombreProducto;
            producto.Descripcion = entity.Descripcion;
            producto.CreadoPor = entity.CreadoPor;

            Update(producto);
            await SaveAsync();
        }

        public async Task<Guid> Save(ProductoDTO entity)
        {
            ProductoEntities producto = new ProductoEntities()
            {
                NombreProducto = entity.NombreProducto,
                Descripcion = entity.Descripcion,
                CreadoPor = entity.CreadoPor,
                FechaCreacion = DateTime.Now
            };

            Create(producto);
            await SaveAsync();
            return producto.ProductoId;
        }
    }
}
