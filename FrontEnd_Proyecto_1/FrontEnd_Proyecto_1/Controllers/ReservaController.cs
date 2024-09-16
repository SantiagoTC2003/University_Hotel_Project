using FrontEnd_Proyecto_1;
using FrontEnd_Proyecto_1.ConexionAPI;
using FrontEnd_Proyecto_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Controllers
{
    public class ReservaController : BaseController
    {
        ConexionReservas reservacionAPI = new ConexionReservas();
        ConexionHabitaciones habitacionAPI = new ConexionHabitaciones();
        ConexionClientes clientesAPI = new ConexionClientes();



        #region Crear las reservaciones

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> CrearReserva()
        {
            List<HabitacionModel> lstHabitaciones = await habitacionAPI.ListarHabitacion();
            List<ClienteModel> lstClientes = await clientesAPI.ListarCliente();
            string delimiter = ",";

            for (int i = 0; i < lstHabitaciones.Count; i++)
            {
                if (lstHabitaciones[i].EstadoHabitacion.Equals("Reservada"))
                {
                    lstHabitaciones.RemoveAt(i); //Eliminar habitaciones que han sido reservadas
                    i = -1;
                }
            }

            List<SelectListItem> habList = lstHabitaciones.ConvertAll(a =>
            {
                return new SelectListItem()
                {

                    Text = "Hab: " + a.CodHabitacion.ToString() + " | Tip: " + a.TipoHabitacion.ToString() + " | Cap: " + a.CapacidadHabitacion.ToString(),
                    Value = a.CodHabitacion.ToString() + delimiter + a.TipoHabitacion.ToString() + delimiter + a.CapacidadHabitacion.ToString(),

                    Selected = false
                };
            });

            List<SelectListItem> clientList = lstClientes.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.CedulaCliente.ToString() + " | " + a.NombreCliente.ToString() + " " + a.Apellido1Cliente.ToString(),
                    Value = a.CedulaCliente.ToString(),
                    Selected = false
                };
            });

            ViewBag.Clientes = clientList;
            ViewBag.Habitaciones = habList;

            string desc = "Creación de reservas";
            RegistroBitacora(desc);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(ReservaModel P_Modelo)
        {

            string Text = Request.Form["Habitacion"].ToString();
            string CedCliente = Request.Form["Cliente"].ToString();
            string CodeHabitacion = string.Empty;
            string TypeHabitacion = string.Empty;
            string CapacityHabitacion = string.Empty;

            char delimiterChar = ',';

            string[] words = Text.Split(delimiterChar);

            CodeHabitacion = words[0];
            TypeHabitacion = words[1];
            CapacityHabitacion = words[2];

            List<HabitacionModel> lstHabitaciones = await habitacionAPI.ListarHabitacion();
            HabitacionModel ObjHabitacion = new HabitacionModel();


            ObjHabitacion.Equals(lstHabitaciones.Find(x => x.CodHabitacion.Equals(CodeHabitacion)));

            ObjHabitacion.TipoHabitacion = TypeHabitacion;
            ObjHabitacion.CapacidadHabitacion = Convert.ToInt16(CapacityHabitacion);
            ObjHabitacion.CodHabitacion = Convert.ToInt16(CodeHabitacion);
            ObjHabitacion.EstadoHabitacion = "Reservada";


            await habitacionAPI.ModificarHabitacion(ObjHabitacion);

            List<ClienteModel> lstClientes = await clientesAPI.ListarCliente();
            ClienteModel ObjCliente = lstClientes.Find(x => x.CedulaCliente.Equals(CedCliente));

            P_Modelo.CedulaCliente = CedCliente;
            P_Modelo.CodHabitacion = Convert.ToInt16(CodeHabitacion);

            await reservacionAPI.ModificarReserva(P_Modelo);

            await reservacionAPI.AgregarReserva(P_Modelo);

            return RedirectToAction("Index");
        }

        #endregion


        #region Modificar las reservaciones
        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> EditaReserva(ReservaModel ObjReserva)
        {
            short id = ObjReserva.IdReserva;

            List<ReservaModel> lstresultados = await reservacionAPI.ListarReserva();
            ReservaModel Reserva = lstresultados.Find(x => x.IdReserva.Equals(id));

            List<HabitacionModel> lstHabitaciones = await habitacionAPI.ListarHabitacion();
            List<ClienteModel> lstClientes = await clientesAPI.ListarCliente();

            string delimiter = ",";

            for (int i = 0; i < lstHabitaciones.Count; i++)
            {
                if (lstHabitaciones[i].EstadoHabitacion.Equals("Reservada"))
                {
                    if (!Reserva.CodHabitacion.Equals(lstHabitaciones[i].CodHabitacion))
                    {
                        lstHabitaciones.RemoveAt(i); //Eliminar habitaciones que han sido reservadas
                        i = -1;
                    }
                }
            }

            List<SelectListItem> habList = lstHabitaciones.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = "Hab: " + a.CodHabitacion.ToString() + " | Tip: " + a.TipoHabitacion.ToString() + " | Cap: " + a.CapacidadHabitacion.ToString(),
                    Value = a.CodHabitacion.ToString() + delimiter + a.TipoHabitacion.ToString() + delimiter + a.CapacidadHabitacion.ToString(),
                    Selected = (Reserva.CodHabitacion == a.CodHabitacion)
                };
            });

            List<SelectListItem> clientList = lstClientes.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.CedulaCliente.ToString() + " | " + a.NombreCliente.ToString() + " " + a.Apellido1Cliente.ToString(),
                    Value = a.CedulaCliente.ToString(),
                    Selected = (Reserva.CedulaCliente == a.CedulaCliente)
                };
            });


            ViewBag.Clientes = clientList;
            ViewBag.Habitaciones = habList;

            string desc = "Edición de reservas";
            RegistroBitacora(desc);

            return View(Reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(ReservaModel P_Modelo)
        {

            string Text = Request.Form["Habitacion"].ToString();
            string CedCli = Request.Form["Cliente"].ToString();

            string CodeHabitacion = string.Empty;
            string TypeHabitacion = string.Empty;
            string CapacityHabitacion = string.Empty;

            char delimiterChar = ',';

            string[] words = Text.Split(delimiterChar);

            CodeHabitacion = words[0];
            TypeHabitacion = words[1];
            CapacityHabitacion = words[2];

            List<ReservaModel> lstresultados = await reservacionAPI.ListarReserva();
            ReservaModel ReservaActual = lstresultados.Find(x => x.IdReserva.Equals(P_Modelo.IdReserva)); //Todo bien

            try
            {
                if (!CodeHabitacion.Equals(ReservaActual.CodHabitacion))
                {
                    List<HabitacionModel> lstHabitaciones = await habitacionAPI.ListarHabitacion();
                    HabitacionModel antiguaHabitacion = lstHabitaciones.Find(x => x.CodHabitacion.Equals(ReservaActual.CodHabitacion));
                    antiguaHabitacion.EstadoHabitacion = "No reservada";
                    await habitacionAPI.ModificarHabitacion(antiguaHabitacion); //TODO BIEN

                    HabitacionModel nuevaHabitacion = lstHabitaciones.Find(x => x.CodHabitacion.Equals(ReservaActual.CodHabitacion));

                    nuevaHabitacion.CodHabitacion = Convert.ToInt16(CodeHabitacion);
                    nuevaHabitacion.TipoHabitacion = TypeHabitacion;
                    nuevaHabitacion.CapacidadHabitacion = Convert.ToInt16(CapacityHabitacion);
                    nuevaHabitacion.EstadoHabitacion = "Reservada";

                    await habitacionAPI.ModificarHabitacion(nuevaHabitacion);

                    P_Modelo.CodHabitacion = Convert.ToInt16(CodeHabitacion);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            if (!CedCli.Equals(ReservaActual.CedulaCliente))
            {
                P_Modelo.CedulaCliente = CedCli;
            }

            P_Modelo.CodHabitacion = Convert.ToInt16(CodeHabitacion);
            P_Modelo.CedulaCliente = CedCli;

            await reservacionAPI.ModificarReserva(P_Modelo);
            return RedirectToAction("Index");
        }

        #endregion

        #region Eliminar las reservaciones
        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> Eliminar(ReservaModel ObjReserva)
        {
            short id = ObjReserva.IdReserva;

            List<ReservaModel> lstresultados = await reservacionAPI.ListarReserva();
            ReservaModel reserva = lstresultados.Find(x => x.IdReserva.Equals(id));

            string desc = "Eliminación de reservas";
            RegistroBitacora(desc);

            return View(reserva);
        }

        //ELIMINAR RESERVA
        [HttpPost]
        public async Task<IActionResult> EliminarReserva(ReservaModel P_Modelo)
        {
            await reservacionAPI.EliminarReserva(P_Modelo);
            return RedirectToAction("Index");
        }

        

        #endregion

        private List<SelectListItem> ObtenerOpciones()
        {
            return new List<SelectListItem> {
                new SelectListItem{
                    Text = "Cédula del huésped",
                    Value = "A"
                },
                new SelectListItem{
                    Text = "Código de la reserva",
                    Value = "B"
                }
            };
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public IActionResult Consultar()
        {
            string desc = "Consulta de reservas";
            RegistroBitacora(desc);
            ViewBag.Listado = ObtenerOpciones();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ValorSeleccionado()
        {
            string opcionSeleccionada = Request.Form["ddlFiltro"].ToString();
            string textBoxDato = Request.Form["TextBoxInfo"].ToString();

            List<ReservaModel> lstresultados = await reservacionAPI.ListarReserva();

            if (opcionSeleccionada.Equals("A")) //Filtración por cédula del huésped
            {
                lstresultados = lstresultados.FindAll(x => x.CedulaCliente.Equals(textBoxDato));
            }
            else
            {
                lstresultados = lstresultados.FindAll(x => x.CodReserva.Equals(textBoxDato));
            }
            ViewBag.Lista = lstresultados;

            return View(lstresultados);
        }

        [Authorize(Roles = "Admin, Reservaciones")]
        public async Task<IActionResult> Index()
        {

            List<ReservaModel> lstresultados = await reservacionAPI.ListarReserva();

            return View(lstresultados);
        }

        public async Task<IActionResult> Fechas(DateTime BuscarFechaInicio, DateTime BuscarFechaFin)
        {

            ReservaModel ObjReserva = new ReservaModel();

            if (BuscarFechaInicio != DateTime.MinValue)
                ObjReserva.FechaInicioRango = BuscarFechaInicio;

            if (BuscarFechaFin != DateTime.MinValue)
                ObjReserva.FechaFinRango = BuscarFechaFin;

            List<ReservaModel> lstresultados = await reservacionAPI.ListarFecha(ObjReserva);

            return View(lstresultados);
        }

    }
}
