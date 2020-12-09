using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using _3F3R.Models;
using System.Data.Common;

namespace AltaPuestos.Controllers
{
    public class AltaPuestosController : Controller
    {
        private readonly ILogger<AltaPuestosController> logger;
        private readonly _3F3RContext db;

        public AltaPuestosController(ILogger<AltaPuestosController> logger,
            _3F3RContext contexto)
        {
            this.logger = logger;
            this.db = contexto;
        }

         public IActionResult Editar()
        {
            ViewBag.verPuestos = db.Puestos.ToList();            
            return View();
        }

        public JsonResult ConsultarPuestos()
        {
            return Json(db.Puestos.ToList());
        }       

        public IActionResult Eliminar(int CP)
        {
            Puesto puesto = db.Puestos.FirstOrDefault(n => n.CP == CP);
            
            db.Puestos.Remove(puesto);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }   
}   