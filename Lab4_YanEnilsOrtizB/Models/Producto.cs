using System.ComponentModel.DataAnnotations;

namespace Lab4_YanEnilsOrtizB.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999, ErrorMessage = "El precio debe estar entre 0.01 y 999,999")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        public string Categoria { get; set; } = string.Empty;
    }
}