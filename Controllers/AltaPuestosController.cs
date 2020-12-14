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

        public JsonResult ConsultarPuestos()
        {
            return Json(db.Puestos.ToList());
        }

        public IActionResult Editar()
        {
            ViewBag.verPuestos = db.Puestos.ToList();            
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(int cp, double latitud, double longitud, string plaza, 
        string calle, string horarios)
        {
            Puesto nuevoPuesto = new Puesto{
                CP = cp,
                Latitud = latitud,
                Longitud = longitud,
                Plaza = plaza,
                Calle = calle,
                Horarios = horarios,              
            };

            db.Puestos.Add(nuevoPuesto);
            db.SaveChanges();
            return RedirectToAction("Editar", "AltaPuestos");
        }    

        public IActionResult Actualizar(int CP)
        {
            Puesto puesto = db.Puestos.FirstOrDefault(n => n.CP == CP);
            return View(puesto);
        }

        [HttpPost]
        public IActionResult DoEdit(int CP, double latitud, double longitud)
        {
            Puesto puesto = db.Puestos.FirstOrDefault(n => n.CP == CP);
            puesto.Latitud = latitud;
            puesto.Longitud = longitud;

            db.Puestos.Update(puesto);
            db.SaveChanges();

            return RedirectToAction("Editar", "AltaPuestos");
        }

        public IActionResult Eliminar(int CP)
        {
            Puesto puesto = db.Puestos.FirstOrDefault(n => n.CP == CP);
            
            db.Puestos.Remove(puesto);
            db.SaveChanges();

            return RedirectToAction("Editar", "AltaPuestos");
        }
    }   
}   