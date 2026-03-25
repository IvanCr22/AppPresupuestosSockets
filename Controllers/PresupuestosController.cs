using AppPresupuestosSockets.Models;
using AppPresupuestosSockets.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppPresupuestosSockets.Controllers
{
    public class PresupuestosController : Controller
    {
        private readonly PresupuestosContext _db;
        private readonly IChart _chartService;

        public PresupuestosController(PresupuestosContext db, IChart chartService)
        {
            _db = db;
            _chartService = chartService;
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

        [HttpGet]
        public async Task<IActionResult> VerDetalle(string id)
        {
            Presupuestos? presupuesto = await _db.Presupuestos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            if (presupuesto == null) return NotFound();
            return View(presupuesto);
        }

        [HttpGet]
    public async Task<IActionResult> ObtenerDatosGrafica(int id)
    {
        var data = await _chartService.GetInformacionChart(id);
        if (data == null) return NotFound();
        
        return Json(data);
    }
    }
}