using AppPresupuestosSockets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPresupuestosSockets.Controllers
{
    public class PresupuestosController : Controller
    {
        private readonly PresupuestosContext _db;

        public PresupuestosController(PresupuestosContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var modelo = new CrearPresupuestoViewModel();
            modelo.ListaUsuarios = await _db.Usuarios.ToListAsync();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarPresupuesto(CrearPresupuestoViewModel viewModel)
        {
            await _db.Presupuestos.AddAsync(viewModel.NuevoPresupuesto);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}