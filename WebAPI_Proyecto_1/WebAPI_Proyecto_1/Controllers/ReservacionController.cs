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
    public class ReservacionController : Controller
    {

        private readonly IReservacionNSQL _iLogica;

        //Constructor
        public ReservacionController(IReservacionNSQL ilogica)
        {
            _iLogica = ilogica;
        }

        [HttpPost]
        [Route("AgregarReserva")]
        public bool AgregarReserva(Reservaciones P_Entidad)
        {
            return _iLogica.AgregarReserva(P_Entidad);
        }

        [HttpGet]
        [Route("ConsultarReserva")]
        public IEnumerable<Reservaciones> ConsultarReserva()
        {
            Reservaciones r = new Reservaciones();
            return _iLogica.ConsultarReserva(r).ToList();
        }

        [HttpPost]
        [Route("ModificarReserva")]
        public bool ModificarReserva(Reservaciones Entidad)
        {
            return _iLogica.ModificarReserva(Entidad);
        }

        [HttpPost]
        [Route("EliminarReserva")]
        public bool EliminarReserva(Reservaciones Entidad)
        {
            return _iLogica.EliminarReserva(Entidad);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
