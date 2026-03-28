using System.ComponentModel.DataAnnotations;

namespace AppPresupuestosSockets.Models
{
    public class Presupuestos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "La Descripción es requerida")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "El Presupuesto Inicial es requerido")]
        public decimal MontoTotal { get; set; }
        [Required(ErrorMessage = "La Fecha de Creación es requerida")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; } = null!;
        public List<Transacciones>? Transacciones { get; set; } = new();
    }
}