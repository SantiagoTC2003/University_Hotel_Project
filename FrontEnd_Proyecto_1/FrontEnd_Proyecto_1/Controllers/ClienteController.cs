using FrontEnd_Proyecto_1.ConexionAPI;
using FrontEnd_Proyecto_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Controllers
{
    public class ClienteController : BaseController
    {
        ConexionClientes conexionAPI = new ConexionClientes();

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> Index()
        {
            List<ClienteModel> lsresultados = await conexionAPI.ListarCliente();
            string desc = "Consulta de clientes";
            RegistroBitacora(desc);
            return View(lsresultados);
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public IActionResult crearCliente()
        {
            string desc = "Creación de clientes";
            RegistroBitacora(desc);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ClienteModel pEntidad)
        {
            await conexionAPI.AgregarCliente(pEntidad);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> Eliminar(ClienteModel ObjCliente)
        {
            string id = ObjCliente.CedulaCliente;
            List<ClienteModel> lstresultados = await conexionAPI.ListarCliente();
            ClienteModel cliente = lstresultados.Find(x => x.CedulaCliente.Equals(id));
            string desc = "Eliminación de clientes";
            RegistroBitacora(desc);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCliente(ClienteModel pEntidad)
        {
            await conexionAPI.EliminarCliente(pEntidad);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> EditarCliente(ClienteModel ObjCliente)
        {
            string id = ObjCliente.CedulaCliente;

            List<ClienteModel> lstresultados = await conexionAPI.ListarCliente();
            ClienteModel cliente = lstresultados.Find(x => x.CedulaCliente.Equals(id));
            string desc = "Edición de clientes";
            RegistroBitacora(desc);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(ClienteModel P_Modelo)
        {
            await conexionAPI.ModificarCliente(P_Modelo);
            return RedirectToAction("Index");
        }
    }
}
