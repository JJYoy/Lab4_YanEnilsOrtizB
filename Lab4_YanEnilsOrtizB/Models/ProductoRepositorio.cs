using System.Collections.Generic;
using System.Linq;

namespace Lab4_YanEnilsOrtizB.Models
{
    public static class ProductoRepositorio
    {
        private static List<Producto> _productos = new List<Producto>();

        public static List<Producto> ObtenerTodos() => _productos;

        public static Producto? ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public static void Agregar(Producto p)
        {
            p.Id = _productos.Count > 0 ? _productos.Max(x => x.Id) + 1 : 1;
            _productos.Add(p);
        }

        public static void Actualizar(Producto p)
        {
            var existente = ObtenerPorId(p.Id);
            if (existente != null)
            {
                existente.Nombre = p.Nombre;
                existente.Precio = p.Precio;
                existente.Categoria = p.Categoria;
            }
        }

        public static void Eliminar(int id)
        {
            var p = ObtenerPorId(id);
            if (p != null) _productos.Remove(p);
        }
    }
}
