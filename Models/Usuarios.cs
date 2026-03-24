using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPresupuestosSockets.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}