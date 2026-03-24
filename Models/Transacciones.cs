using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPresupuestosSockets.Models
{
    public class Transacciones
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Categoria { get; set; } = "General";
        public string ColorHex { get; set; } = "#36A2EB";
        public DateTime Fecha { get; set; } = DateTime.Now;

        public int PresupuestoId { get; set; }
        public Presupuestos Presupuesto { get; set; } = null!;

        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } = null!;
    }
}