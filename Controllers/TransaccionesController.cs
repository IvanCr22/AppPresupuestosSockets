using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppPresupuestosSockets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppPresupuestosSockets.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly PresupuestosContext _db;
        private readonly IHubContext<PresupuestoHub> _hubContext;

        public TransaccionesController(PresupuestosContext db, IHubContext<PresupuestoHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelo = new CrearTransaccionViewModel();
            modelo.ListaPresupuestos = await _db.Presupuestos.ToListAsync();
            modelo.ListaUsuarios = await _db.Usuarios.ToListAsync();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarTransaccion(CrearTransaccionViewModel viewModel)
        {
            await _db.Transacciones.AddAsync(viewModel.NuevaTransaccion);
            await _db.SaveChangesAsync();
            //await _hubContext.Clients.All.SendAsync("ActualizarGrafica", viewModel);
            string nombreGrupo = viewModel.NuevaTransaccion.PresupuestoId.ToString();
            await _hubContext.Clients.Group(nombreGrupo).SendAsync("ActualizarGrafica", viewModel);
            return RedirectToAction("Index");
        }
        
    }
}