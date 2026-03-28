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
