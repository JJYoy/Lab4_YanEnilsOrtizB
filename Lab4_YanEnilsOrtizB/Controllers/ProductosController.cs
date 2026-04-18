using Microsoft.AspNetCore.Mvc;
using Lab4_YanEnilsOrtizB.Models; 

namespace Lab4_YanEnilsOrtizB.Controllers
{
    public class ProductosController : Controller
    {
        
        public IActionResult Index()
        {
            var productos = ProductoRepositorio.ObtenerTodos();
            return View(productos);
        }

        
        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        
        public IActionResult Crear()
        {
            
            // if (string.IsNullOrEmpty(producto.Nombre) || producto.Precio <= 0) {
            //    ViewBag.Error = "Datos invalidos";
            //    return View(producto);
            // }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            
            if (ModelState.IsValid)
            {
                ProductoRepositorio.Agregar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        
        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductoRepositorio.Actualizar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        
        public IActionResult Eliminar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}