using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPresupuestosSockets.Models;

namespace AppPresupuestosSockets.Service
{
    public interface IChart
    {
        Task<ChartDataViewModel> GetInformacionChart(int presupuestoId);
    }
}