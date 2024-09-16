using FrontEnd_Proyecto_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> VerBitacora()
        {
            List<BitacoraModel> lsresultados = await bitacoraAPI.ConsultarRegistro(new BitacoraModel { });
            string desc = "Consulta de la bitácora";
            RegistroBitacora(desc);
            return View(lsresultados);
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
