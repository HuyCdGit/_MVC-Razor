using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(ILogger<PlanetController> logger,PlanetService planetService)
        {
            _planetService = planetService;
            _logger = logger; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet = true, Name = "Action")]
        public string _Name{get; set;}

        public IActionResult Mercury()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Mars()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Neptune()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Saturn()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Uranus()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(r => r.Name.Contains(_Name)).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult PlanetInfo(int? id)
        {
            var planet = _planetService.Where(r => r.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }
        
    }
}