using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppPresupuestosSockets.Models;
using Microsoft.EntityFrameworkCore;

namespace AppPresupuestosSockets.Controllers;

public class HomeController : Controller
{
    private readonly PresupuestosContext _db;

    public HomeController(PresupuestosContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var presupuestos = await _db.Presupuestos.ToListAsync();
        return View(presupuestos);
    }

    /* [HttpGet]
    public async Task<IActionResult> VerDetalle(string id)
    {
        Presupuestos? presupuesto = await _db.Presupuestos.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
        if (presupuesto == null ) return NotFound();
        return View(presupuesto);
    } */

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
