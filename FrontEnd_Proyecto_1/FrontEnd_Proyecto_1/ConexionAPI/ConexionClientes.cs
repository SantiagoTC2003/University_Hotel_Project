using FrontEnd_Proyecto_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.ConexionAPI
{
    public class ConexionClientes : ConexionBase
    {

        public ConexionClientes()
        {
            GestorDeConexiones();
        }

        public async Task<List<ClienteModel>> ListarCliente()
        {
            List<ClienteModel> lstresultados = new List<ClienteModel>();
            string url = "Clientes/ConsultarCliente";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<ClienteModel>>(convertirAstring);
            }

            return lstresultados;
        }

        public async Task<bool> AgregarCliente(ClienteModel pEntidad)
        {
            string url = "Clientes/AgregarCliente";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarCliente(ClienteModel pEntidad)
        {
            string url = "Clientes/EliminarCliente";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarCliente(ClienteModel pEntidad)
        {
            string url = "Clientes/ModificarCliente";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pEntidad);
            return resultado.IsSuccessStatusCode;
        }
    }
}
