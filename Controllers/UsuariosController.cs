using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppPresupuestosSockets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppPresupuestosSockets.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly PresupuestosContext _db;

       public UsuariosController(PresupuestosContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Usuarios usuario)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", usuario);
            }

            await _db.Usuarios.AddAsync(usuario);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}