using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AppPresupuestosSockets.Models
{
    public class Transacciones
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Monto es requerido")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "La Descripción es requerida")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "La Categoria es requerida")]
        public string Categoria { get; set; } = "General";
        [Required(ErrorMessage = "El Color es requerido")]
        public string ColorHex { get; set; } = "#36A2EB";
        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        
        public int PresupuestoId { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public Presupuestos? Presupuesto { get; set; } = null!;

        public int UsuarioId { get; set; }
        public Usuarios? Usuario { get; set; } = null!;
    }
}