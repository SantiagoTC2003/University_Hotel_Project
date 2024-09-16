using FrontEnd_Proyecto_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.ConexionAPI
{
    public class ConexionUsuarios : ConexionBase
    {
        public ConexionUsuarios()
        {
            GestorDeConexiones();
        }

        public async Task<List<UsuarioModel>> ListarUsuario()
        {
            List<UsuarioModel> lstresultados = new List<UsuarioModel>();
            string url = "Usuarios/ConsultarUsuario";
            HttpResponseMessage resultado = await Cliente.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<UsuarioModel>>(convertirAstring);
            }

            return lstresultados;
        }

        public async Task<List<UsuarioModel>> ComprobarCredenciales(UsuarioModel pUsuario)
        {
            List<UsuarioModel> lstresultados = new List<UsuarioModel>();
            string url = "Usuarios/ComprobarCredenciales";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pUsuario);

            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lstresultados = JsonConvert.DeserializeObject<List<UsuarioModel>>(convertirAstring);
            }

            return lstresultados;
        }

        public async Task<bool> AgregarUsuario(UsuarioModel pUsuario)
        {
            string url = "Usuarios/AgregarUsuario";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pUsuario);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarUsuario(UsuarioModel pUsuario)
        {
            string url = "Usuarios/EliminarUsuario";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pUsuario);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<bool> ModificarUsuario(UsuarioModel pUsuario)
        {
            string url = "Usuarios/ModificarUsuario";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(url, pUsuario);
            return resultado.IsSuccessStatusCode;
        }
    }
}
