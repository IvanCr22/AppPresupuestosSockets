using AppPresupuestosSockets.Models;
using Microsoft.EntityFrameworkCore;

namespace AppPresupuestosSockets.Service
{
    public class ChartService : IChart
    {
        private readonly PresupuestosContext _db;

        public ChartService(PresupuestosContext db)
        {
            _db = db;
        }

        public async Task<Transacciones?> EliminarTransaccion(int transaccionId)
        {
            var transaccion = await _db.Transacciones.FirstOrDefaultAsync(x => x.Id == transaccionId);

            if (transaccion != null)
            {
                _db.Transacciones.Remove(transaccion);
                await _db.SaveChangesAsync();

                return transaccion;
            }

            return null;
        }

        public async Task<ChartDataViewModel> GetInformacionChart(int presupuestoId)
        {
            var presupuesto = await _db.Presupuestos.FindAsync(presupuestoId);
            if (presupuesto == null) return null;

            var transacciones = await _db.Transacciones
                .Where(t => t.PresupuestoId == presupuestoId)
                .ToListAsync();

            var dataAgrupada = transacciones
                .GroupBy(t => new { t.Categoria, t.ColorHex })
                .Select(g => new
                {
                    Categoria = g.Key.Categoria,
                    Total = g.Sum(x => x.Monto),
                    Color = g.Key.ColorHex
                }).ToList();

            decimal totalGastado = dataAgrupada.Sum(x => x.Total);
            decimal saldoRestante = presupuesto.MontoTotal - totalGastado;

            var viewModel = new ChartDataViewModel
            {
                Labels = dataAgrupada.Select(x => x.Categoria).ToList(),
                Cantidades = dataAgrupada.Select(x => x.Total).ToList(),
                Colores = dataAgrupada.Select(x => x.Color).ToList(),
                Historial = transacciones.OrderByDescending(t => t.Fecha).ToList(),
                Presupuesto = presupuesto
            };

            if (saldoRestante > 0)
            {
                viewModel.Labels.Add("Disponible");
                viewModel.Cantidades.Add(saldoRestante);
                viewModel.Colores.Add("#2ecc71");
            }
            else if (saldoRestante < 0)
            {
                viewModel.Labels.Add("Excedido");
                viewModel.Cantidades.Add(Math.Abs(saldoRestante));
                viewModel.Colores.Add("#e74c3c");
            }

            return viewModel;
        }

        
    }
}