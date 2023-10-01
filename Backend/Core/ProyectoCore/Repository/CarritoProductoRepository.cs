﻿using ProyectoCore.Models;
using ProyectoCore.Interface;

namespace ProyectoCore.Repository
{
    public class CarritoProductoRepository : ICarritoProductoRepository
    {

        private readonly TiendaPruebaContext _context;
        public CarritoProductoRepository(TiendaPruebaContext context)
        {
            _context = context;
        }
        public ICollection<CarritoProducto> GetCarritoProducto()
        {
            return _context.CarritoProductos.OrderBy(H => H.IdCarrito).ToList();
        }

        public CarritoProducto GetCarritoProducto(int id)
        {
            return _context.CarritoProductos.Where(e => e.IdCarrito == id).FirstOrDefault();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        Producto ICarritoProductoRepository.GetCarritoProducto(int id) // esto se agrego solo
        {
            throw new NotImplementedException();
        }
    }
}
