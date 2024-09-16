using FrontEnd_Proyecto_1.ConexionAPI;
using FrontEnd_Proyecto_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Controllers
{
    public class BaseController : Controller
    {
        protected ConexionBitacora bitacoraAPI = new ConexionBitacora();

        protected async void RegistroBitacora(string desc)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                // Obtener los datos del usuario logueado
                string userbitacoras = HttpContext.User.Identity.Name;
                string iduser = HttpContext.User.FindFirst("Usuario").Value;

                BitacoraModel registro = new BitacoraModel();

                registro.Id_Usuario = iduser;
                registro.nombre_usuario = userbitacoras;
                registro.descripcion = desc;
                await bitacoraAPI.RegistroBitacora(registro);
            }
        }
    }
}
