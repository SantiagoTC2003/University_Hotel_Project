using FrontEnd_Proyecto_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.ConexionAPI
{
    public class ConexionHabitaciones : ConexionBase
    {
        public ConexionHabitaciones()
        {
            GestorDeConexiones();
        }

        //MÉTODO PARA LISTAR HABITACIÓN EN DB
        public async Task<List<HabitacionModel>> ListarHabitacion()
        {

            List<HabitacionModel> lstresultados = new List<HabitacionModel>();

            string url = "Habitacion/ConsultarHabitacion";

            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<HabitacionModel>>(convertirAstring);
            }
            return lstresultados;
        }

        //MÉTODO PARA AGREGAR HABITACIÓN EN DB
        public async Task<bool> AgregarHabitacion(HabitacionModel pEntidad)
        {
            string url = "Habitacion/AgregarHabitacion";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        //MÉTODO PARA ELIMINAR HABITACIÓN EN DB
        public async Task<bool> EliminarHabitacion(HabitacionModel pEntidad)
        {
            string url = "Habitacion/EliminarHabitacion";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        //MÉTODO PARA MODIFICAR HABITACIÓN EN DB
        public async Task<bool> ModificarHabitacion(HabitacionModel pEntidad)
        {
            string url = "Habitacion/ModificarHabitacion";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }
    }
}