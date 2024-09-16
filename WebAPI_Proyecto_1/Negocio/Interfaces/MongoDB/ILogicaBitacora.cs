using Entidades.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Interfaces.MongoDB
{
    public interface ILogicaBitacora
    {
        /// <summary>Agregar Registro</summary>
        /// <remarks>Realiza la inserción del registro a la base de datos</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="pEntidad">El objeto con la información del registro</param>
        bool AgregarRegistro(Bitacora pEntidad);

        /// <summary>Consultar Registros</summary>
        /// <remarks>Realiza la consulta de los registros a la base de datos</remarks>
        /// <returns>Retorna el listado de registros</returns>
        /// <param name="pEntidad">Datos por el que se desea filtrar</param>
        List<Bitacora> ConsutarRegistro(Bitacora pEntidad);
    }
}
