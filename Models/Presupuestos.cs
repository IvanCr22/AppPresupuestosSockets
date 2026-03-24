using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPresupuestosSockets.Models
{
    public class Presupuestos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal MontoTotal { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } = null!;
        public List<Transacciones> Transacciones { get; set; } = new();
    }
}