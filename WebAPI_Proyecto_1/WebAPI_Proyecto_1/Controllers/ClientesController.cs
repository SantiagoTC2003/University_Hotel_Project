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
    public class ClientesController : Controller
    {
        private readonly IClienteNSQL _iLogica;

        //Constructor
        public ClientesController(IClienteNSQL iLogica)
        {
            _iLogica = iLogica;
        }

        [HttpPost]
        [Route("AgregarCliente")]
        public bool AgregarCliente(Clientes pEntidad)
        {
            return _iLogica.AgregarCliente(pEntidad);
        }

        [HttpGet]
        [Route("ConsultarCliente")]
        public IEnumerable<Clientes> ConsultarCliente()
        {
            Clientes c = new Clientes();
            return _iLogica.ConsultarCliente(c).ToList();
        }

        [HttpPost]
        [Route("ModificarCliente")]
        public bool ModificarCliente(Clientes pEntidad)
        {
            return _iLogica.ModificarCliente(pEntidad);
        }

        [HttpPost]
        [Route("EliminarCliente")]
        public bool EliminarCliente(Clientes pEntidad)
        {
            return _iLogica.EliminarCliente(pEntidad);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
