using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppPresupuestosSockets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AppPresupuestosSockets.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly PresupuestosContext _db;

        public TransaccionesController(PresupuestosContext db)
        {
            _db = db;
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
            return RedirectToAction("Index");
        }
        
    }
}