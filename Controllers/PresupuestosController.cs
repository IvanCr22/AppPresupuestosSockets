using AppPresupuestosSockets.Models;
using AppPresupuestosSockets.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AppPresupuestosSockets.Controllers
{
    public class PresupuestosController : Controller
    {
        private readonly PresupuestosContext _db;
        private readonly IChart _chartService;

        private readonly IHubContext<PresupuestoHub> _hubContext;

        public PresupuestosController(PresupuestosContext db, IChart chartService, IHubContext<PresupuestoHub> hubContext)
        {
            _db = db;
            _chartService = chartService;
            _hubContext = hubContext;
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
            var datosGrafica = await _chartService.GetInformacionChart(int.Parse(id));
            return View(datosGrafica);
        }

        [HttpPost]
        [Route("Transacciones/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var transaccion = await _chartService.EliminarTransaccion(id);

            if (transaccion == null) return NotFound();

            await _hubContext.Clients.Group(transaccion.PresupuestoId.ToString())
                .SendAsync("EliminarGrafica", new { id = id, monto = transaccion.Monto, categoria = transaccion.Categoria });

            return Ok();
        }
    }
}