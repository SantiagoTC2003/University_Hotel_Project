using Entidades.SQLServer;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Proyecto_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : Controller
    {

        private readonly IHabitacionNSQL _iLogica;

        //Constructor
        public HabitacionController(IHabitacionNSQL iLogica)
        {
            _iLogica = iLogica;
        }

        [HttpPost]
        [Route("AgregarHabitacion")]
        public bool AgregarHabitacion(Habitaciones pEntidad)
        {
            return _iLogica.AgregarHabitacion(pEntidad);
        }

        [HttpGet]
        [Route("ConsultarHabitacion")]
        public IEnumerable<Habitaciones> ConsultarHabitacion()
        {
            Habitaciones h = new Habitaciones();
            return _iLogica.ConsultarHabitacion(h).ToList();
        }

        [HttpPost]
        [Route("ModificarHabitacion")]
        public bool ModificarHabitacion(Habitaciones pEntidad)
        {
            return _iLogica.ModificarHabitacion(pEntidad);
        }

        [HttpPost]
        [Route("EliminarHabitacion")]
        public bool EliminarHabitacion(Habitaciones pEntidad)
        {
            return _iLogica.EliminarHabitacion(pEntidad);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
