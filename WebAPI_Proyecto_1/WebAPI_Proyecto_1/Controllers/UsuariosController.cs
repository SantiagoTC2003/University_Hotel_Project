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
    public class UsuariosController : Controller
    {
        private readonly IUsuarioNSQL _ilogica;

        //Constructor
        public UsuariosController(IUsuarioNSQL ilogica)
        {
            _ilogica = ilogica;
        }

        [HttpPost]
        [Route("AgregarUsuario")]
        public bool AgregarUsuario(Usuarios pEntidad)
        {
            return _ilogica.AgregarUsuario(pEntidad);
        }

        [HttpPost]
        [Route("AgregarUsuarioSP")]
        public bool AgregarUsuarioSP(Usuarios pEntidad)
        {
            return _ilogica.AgregarUsuarioSP(pEntidad);
        }

        [HttpGet]
        [Route("ConsultarUsuario")]
        public IEnumerable<Usuarios> ConsultarUsuarios([FromHeader] string pCorreo)
        {
            return _ilogica.ConsultarUsuarios(new Usuarios {Email = pCorreo}).ToList();
        }

        [HttpPost]
        [Route("ComprobarCredenciales")]
        public IEnumerable<Usuarios> ComprobarCredenciales(Usuarios pEntidad)
        {
            return _ilogica.ComprobarLogin(pEntidad).ToList();
        }

        [HttpPost]
        [Route("ModificarUsuario")]
        public bool ModificarUsuario(Usuarios pEntidad)
        {
            return _ilogica.ModificarUsuario(pEntidad);
        }

        [HttpPost]
        [Route("EliminarUsuario")]
        public bool EliminarUsuario(Usuarios pEntidad)
        {
            return _ilogica.EliminarUsuario(pEntidad);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
