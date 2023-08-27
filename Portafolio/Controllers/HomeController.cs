using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repo;
        private readonly ServicioTransient servicioTransient;
        private readonly ServicioScoped servicioScoped;
        private readonly ServicioSingleton servicioSingleton;
        private readonly IServicioEmailSendGrid servicioEmailSendGrid;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepositorioProyectos repo,
            ServicioTransient servicioTransient,
            ServicioScoped servicioScoped,
            ServicioSingleton servicioSingleton,
            IServicioEmailSendGrid servicioEmailSendGrid
            )
        {
            _logger = logger;
            this.repo = repo;
            this.servicioTransient = servicioTransient;
            this.servicioScoped = servicioScoped;
            this.servicioSingleton = servicioSingleton;
            this.servicioEmailSendGrid = servicioEmailSendGrid;
        }

        public IActionResult Index()
        {
            var guidDTO = new EjemploGuidDTO()
            {
                transient = servicioTransient.obtenerGuid,
                scoped = servicioScoped.obtenerGuid,
                singleton = servicioSingleton.obtenerGuid,
            };
            var repositorioProyectos = new RepositorioProyectos();
            var proyects = repositorioProyectos.obtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexDTO() { proyectos = proyects, ejemplo1 = guidDTO };
            return View(modelo);
        }

        public IActionResult Proyectos()
        {
            var proyectos = repo.obtenerProyectos();

            return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoDTO contacto)
        {
            await servicioEmailSendGrid.enviar(contacto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
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
}