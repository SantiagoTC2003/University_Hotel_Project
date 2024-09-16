using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd_Proyecto_1.Models
{
    public class BitacoraModel
    {
        #region Propiedades
        public string Id_Registro { get; set; }
        public string Id_Usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string descripcion { get; set; }

        #endregion

        #region Constructor

        public BitacoraModel()
        {
            Id_Registro = string.Empty;
            Id_Usuario = string.Empty;
            descripcion = string.Empty;

        }

        #endregion
    }
}
