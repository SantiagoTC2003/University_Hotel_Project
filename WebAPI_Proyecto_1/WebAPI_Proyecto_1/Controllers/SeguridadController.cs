using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Proyecto_1.Controllers
{
    [Route("api/Seguridad")]
    [ApiController]
    public class SeguridadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
