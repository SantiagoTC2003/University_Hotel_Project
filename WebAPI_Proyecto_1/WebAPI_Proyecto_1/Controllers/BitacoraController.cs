using Entidades.MongoDB;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Proyecto_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : Controller
    {
        #region Atributos

        private readonly ILogicaBitacora _iLogica;

        #endregion

        #region BitacoraController

        public BitacoraController(ILogicaBitacora ilogica)
        {
            _iLogica = ilogica;
        }

        #endregion
        
        [HttpPost]
        [Route(nameof(AgregarRegistro))]
        public bool AgregarRegistro(Bitacora P_Entidad)
        {
            return _iLogica.AgregarRegistro(P_Entidad);
        }

        [HttpGet]
        [Route(nameof(ConsultarRegistro))]
        public IEnumerable<Bitacora> ConsultarRegistro()
        {
            Bitacora r = new Bitacora();
            return _iLogica.ConsutarRegistro(r).ToList();
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
