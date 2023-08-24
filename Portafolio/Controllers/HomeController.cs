using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
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
            var proyects = obtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexDTO() { proyectos = proyects };
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private List<ProyectoDTO> obtenerProyectos()
        {
            return new List<ProyectoDTO> {
                new ProyectoDTO { title = "Exela", description = "software developer", imageUrl = "/exela.jpg", link = "https://www.exelatech.com/" },
                new ProyectoDTO { title = "Exela", description = "configuration analyst", imageUrl = "/exela.jpg", link = "https://www.exelatech.com/" },
                new ProyectoDTO { title = "Cantera", description = "software developer", imageUrl = "/cantera.png", link = "https://canteradigital.io/" },
                new ProyectoDTO { title = "Google", description = "software developer", imageUrl = "/google.png", link = "https://www.google.com/?hl=es" },
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}