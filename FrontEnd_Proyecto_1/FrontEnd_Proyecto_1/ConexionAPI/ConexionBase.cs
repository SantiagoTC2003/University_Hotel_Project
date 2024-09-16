using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.ConexionAPI
{
    public class ConexionBase
    {
        #region Propiedad
        protected HttpClient Cliente;
        #endregion

        #region Constructor
        protected void GestorDeConexiones()
        {
            Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri("http://localhost:26382/api/");
            Cliente.DefaultRequestHeaders.Accept.Clear();
            Cliente.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
    }
}
