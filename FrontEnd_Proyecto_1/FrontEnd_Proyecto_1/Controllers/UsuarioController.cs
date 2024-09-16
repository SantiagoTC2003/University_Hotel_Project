using FrontEnd_Proyecto_1.ConexionAPI;
using FrontEnd_Proyecto_1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Controllers
{
    public class UsuarioController : BaseController
    {

        ConexionUsuarios APIUsuario = new ConexionUsuarios();

        
        public async Task<IActionResult> Index()
        {
            //List<UsuarioModel> lsresultados = await APIUsuario.ListarUsuario();
            string desc = "Consulta de clientes";
            RegistroBitacora(desc);
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Administrar()
        {
            List<UsuarioModel> lsresultados = await APIUsuario.ListarUsuario();
            string desc = "Consulta de clientes";
            RegistroBitacora(desc);
            return View(lsresultados);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult crearUsuario()
        {
            string desc = "Creación de clientes";
            RegistroBitacora(desc);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(UsuarioModel pUsuario)
        {
            await APIUsuario.AgregarUsuario(pUsuario);
            return RedirectToAction("Administrar");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(UsuarioModel ObjCliente)
        {
            string id = ObjCliente.Email;
            List<UsuarioModel> lstresultados = await APIUsuario.ListarUsuario();
            UsuarioModel cliente = lstresultados.Find(x => x.Email.Equals(id));
            string desc = "Eliminación de clientes";
            RegistroBitacora(desc);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarUsuario(UsuarioModel pEntidad)
        {
            await APIUsuario.EliminarUsuario(pEntidad);
            return RedirectToAction("Administrar");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditarUsuario(UsuarioModel ObjCliente)
        {
            string id = ObjCliente.Email;

            List<UsuarioModel> lstresultados = await APIUsuario.ListarUsuario();
            UsuarioModel cliente = lstresultados.Find(x => x.Email.Equals(id));
            string desc = "Edición de clientes";
            RegistroBitacora(desc);
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(UsuarioModel P_Modelo)
        {
            await APIUsuario.ModificarUsuario(P_Modelo);
            return RedirectToAction("Administrar");
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(UsuarioModel pEntidad)
         {
            List<UsuarioModel> lsresultados = await APIUsuario.ComprobarCredenciales(pEntidad);

            if (lsresultados.Count != 0)
            {
                UsuarioModel objUsuario = lsresultados.First();

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, objUsuario.Nombre),
                    new Claim("Usuario", objUsuario.Email),
                    new Claim(ClaimTypes.Role, objUsuario.Tipo)

                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Index", "Home");

            } else
            {
                TempData["MENSAJE"] = "No tienes credenciales correctas";
                return RedirectToAction("AccesoDenegado");
            }
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Usuario");
        }

    }
}
