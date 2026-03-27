using System.ComponentModel.DataAnnotations;

namespace AppPresupuestosSockets.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El Email es requerido")]
        public string Email { get; set; } = string.Empty;
    }
}