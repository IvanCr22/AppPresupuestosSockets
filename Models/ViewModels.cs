using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppPresupuestosSockets.Models
{
    public class CrearPresupuestoViewModel
    {
        public Presupuestos NuevoPresupuesto { get; set; } = new Presupuestos();
        public List<Usuarios> ListaUsuarios { get; set; } = new List<Usuarios>();
    }


    public class CrearTransaccionViewModel
    {
        public Transacciones NuevaTransaccion { get; set; } = new Transacciones();
        public List<Presupuestos> ListaPresupuestos { get; set; } = new List<Presupuestos>();
        public List<Usuarios> ListaUsuarios { get; set; } = new List<Usuarios>();
    }

    public class ChartDataViewModel
    {
        public List<string> Labels { get; set; } = new();
        public List<decimal> Cantidades { get; set; } = new();
        public List<string> Colores { get; set; } = new();

        public List<Transacciones> Historial { get; set; } = new();

        public Presupuestos? Presupuesto { get; set; } = new Presupuestos();
    }
}