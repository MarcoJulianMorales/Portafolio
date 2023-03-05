using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectsRepository projectsRepository;
        private readonly IEmailService emailService;

        public IEmailService EmailService { get; }

        public HomeController(
            ILogger<HomeController> logger, 
            IProjectsRepository projectsRepository,
            IEmailService emailService
            )
        {
            _logger = logger;
            this.projectsRepository = projectsRepository;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            var projects = projectsRepository.getProjects().Take(2).ToList();
            var homeIndexDTO = new HomeIndexDTO () { projects= projects };
            return View(homeIndexDTO);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Projects()
        {
            var projects = projectsRepository.getProjects();
            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactDTO contactInfo) {
            await emailService.send(contactInfo);
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
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