using Inventario_Api_Entities;
using Inventario_Entities;
using Inventario_Interface;
using Inventario_Interface.Bodega;
using Inventario_Interface.Producto;
using Inventario_Repository.Bodega;
using Inventario_Repository.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private Dictionary<Type, object> _instanceHolder;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _instanceHolder = new Dictionary<Type, object>();
        }

        public IBodegaRepository BodegaRepository
        {
            get { return Get<BodegaRepository>(); }
        }

        public IProductoRepository ProductoRepository
        {
            get { return Get<ProductoRepository>(); }
        }

        private T Get<T>()
        {
            lock (_instanceHolder)
            {
                Type type = typeof(T);
                if (_instanceHolder.ContainsKey(type))
                {
                    return (T)_instanceHolder[type];
                }
                else
                {
                    T t = (T)Activator.CreateInstance(typeof(T), _repositoryContext);
                    _instanceHolder.Add(type, t);
                    return t;
                }
            }
        }


    }
}
