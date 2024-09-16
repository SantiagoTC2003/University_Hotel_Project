using FrontEnd_Proyecto_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.ConexionAPI
{
    public class ConexionBitacora : ConexionBase
    {
        public ConexionBitacora()
        {
            GestorDeConexiones();
        }

        public async Task<bool> RegistroBitacora(BitacoraModel pRegistro)
        {
            string urlAgregarRegistro = "Bitacora/AgregarRegistro";
            HttpResponseMessage resultado = await Cliente.PostAsJsonAsync(urlAgregarRegistro, pRegistro);
            return resultado.IsSuccessStatusCode;
        }

        public async Task<List<BitacoraModel>> ConsultarRegistro(BitacoraModel pRegistro)
        {
            List<BitacoraModel> lista = new List<BitacoraModel>();
            string urlConsultarRegistro = "Bitacora/ConsultarRegistro";
            HttpResponseMessage resultado = await Cliente.GetAsync(urlConsultarRegistro);
            if (resultado.IsSuccessStatusCode)
            {
                var convertirAstring = await resultado.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<BitacoraModel>>(convertirAstring);
            }
            return lista;
        }
    }
}
