using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _3F3R.Models;

namespace _3F3R.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Puestos()
        {
            return View();
        }

        public IActionResult Materiales()
        {
            return View();
        }

        public IActionResult Preguntas()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult EnviarContacto(string nombre, string mail, string consulta) {

            try
                {
                    MailMessage correo= new MailMessage();
                    correo.From=new MailAddress("contacto3f3r@gmail.com");
                    correo.IsBodyHtml= true;
                    correo.Priority= MailPriority.Normal;
                    SmtpClient smtp= new SmtpClient();
                    smtp.Host= "smtp.gmail.com";
                    smtp.Port=25;
                    smtp.EnableSsl=true;
                    smtp.UseDefaultCredentials=true;
                    string scuentaCorreo="contacto3f3r@gmail.com";
                    string sPasswordCorreo="proyectocomit2020";
                    smtp.Credentials= new System.Net.NetworkCredential(scuentaCorreo,sPasswordCorreo);
                    smtp.Send(scuentaCorreo, scuentaCorreo, $"Consulta de {nombre}", $"{consulta}");
                    smtp.Send(scuentaCorreo, mail, $"Consulta de {nombre}", $"{consulta}");
                    
                    ViewBag.Mensaje= "Mensaje enviado correctamente";

                }
                catch (Exception ex)
                {
                    
                    ViewBag.Error= ex.Message;
                }

            
            this.ViewBag.Nombre = nombre;
            this.ViewBag.Mail = mail;
            this.ViewBag.Consulta = consulta;

            return View("ConsultaEnviada");
        }
    }
}
