using Newtonsoft.Json;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.ConexionAPI
{
    public class ConexionReservas : ConexionBase
    {
        public ConexionReservas()
        {
            GestorDeConexiones();
        }

        //MÉTODO PARA LISTAR RESERVA EN DB
        public async Task<List<ReservaModel>> ListarReserva()
        {
            List<ReservaModel> lstresultados = new List<ReservaModel>();
            string url = "Reservacion/ConsultarReserva";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<ReservaModel>>(convertirAstring);
            }
            return lstresultados;
        }

        public async Task<bool> AgregarReserva(ReservaModel pEntidad)
        {
            string url = "Reservacion/AgregarReserva";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarReserva(ReservaModel pEntidad)
        {
            string url = "Reservacion/EliminarReserva";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarReserva(ReservaModel pEntidad)
        {
            string url = "Reservacion/ModificarReserva";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<List<ReservaModel>> ListarFecha(ReservaModel pEntidad)
        {
            List<ReservaModel> lstresultados = new List<ReservaModel>();
            string url = "Reservacion/ConsultarReserva";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<ReservaModel>>(convertirAstring);
            }

            if (pEntidad.FechaInicioRango != DateTime.MinValue && pEntidad.FechaFinRango != DateTime.MinValue)
            {
                lstresultados = lstresultados.Where(x => x.FechaEntrada >= pEntidad.FechaInicioRango &&
                                                         x.FechaSalida <= pEntidad.FechaFinRango).ToList();
            }

            return lstresultados;
        }
    }
}
