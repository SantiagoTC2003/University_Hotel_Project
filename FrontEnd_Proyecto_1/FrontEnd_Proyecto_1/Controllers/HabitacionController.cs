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
    public class HabitacionController : BaseController
    {
        ConexionHabitaciones habitacionAPI = new ConexionHabitaciones();

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> Index()
        {
            List<HabitacionModel> lstresultados = await habitacionAPI.ListarHabitacion();
            string desc = "Consulta de habitaciones";
            RegistroBitacora(desc);
            return View(lstresultados);
        }

        public async Task<IActionResult> IndexDiferente()
        {
            List<HabitacionModel> lstresultados = await habitacionAPI.ListarHabitacion();
            string desc = "Consulta de habitaciones";
            RegistroBitacora(desc);
            return View(lstresultados);
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public IActionResult CrearHabitacion()
        {
            string desc = "Creación de habitaciones";
            RegistroBitacora(desc);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(HabitacionModel pEntidad)
        {
            await habitacionAPI.AgregarHabitacion(pEntidad);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> EditarHabitacion(HabitacionModel ObjHabitacion)
        {
            short id = ObjHabitacion.CodHabitacion;

            List<HabitacionModel> lstresultados = await habitacionAPI.ListarHabitacion();
            HabitacionModel habitacion = lstresultados.Find(x => x.CodHabitacion.Equals(id));

            string desc = "Edición de habitaciones";
            RegistroBitacora(desc);

            return View(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(HabitacionModel pEntidad)
        {
            await habitacionAPI.ModificarHabitacion(pEntidad);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> Eliminar(HabitacionModel ObjHabitacion)
        {
            short id = ObjHabitacion.CodHabitacion;

            List<HabitacionModel> lstresultados = await habitacionAPI.ListarHabitacion();
            HabitacionModel habitacion = lstresultados.Find(x => x.CodHabitacion.Equals(id));

            string desc = "Eliminación de habitaciones";
            RegistroBitacora(desc);


            return View(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarHabitacion(HabitacionModel pEntidad)
        {
            await habitacionAPI.EliminarHabitacion(pEntidad);
            return RedirectToAction("Index");
        }
    }
}
