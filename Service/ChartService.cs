using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Colores = dataAgrupada.Select(x => x.Color).ToList()
            };

            if (saldoRestante > 0)
            {
                viewModel.Labels.Add("Disponible");
                viewModel.Cantidades.Add(saldoRestante);
                viewModel.Colores.Add("#2ecc71"); // Verde
            }
            else if (saldoRestante < 0)
            {
                viewModel.Labels.Add("Excedido");
                viewModel.Cantidades.Add(Math.Abs(saldoRestante));
                viewModel.Colores.Add("#e74c3c"); // Rojo
            }

            return viewModel;
        }
    }
}