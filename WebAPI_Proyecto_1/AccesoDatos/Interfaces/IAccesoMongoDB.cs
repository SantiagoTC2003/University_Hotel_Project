using Entidades.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Interfaces
{
    public interface IAccesoMongoDB
    {
        /// <summary>Agregar Registro</summary>
        /// <remarks>Realiza la inserción del registro a la base de datos</remarks>
        /// <returns>Retorna un true o false para indicar el estado de la acción</returns>
        /// <param name="P_Entidad">El objeto con la información del registro</param>
        bool AgregarRegistro(Bitacora P_Entidad);

        /// <summary>Consultar Registros</summary>
        /// <remarks>Realiza la consulta de los registros a la base de datos</remarks>
        /// <returns>Retorna el listado de registros</returns>
        /// <param name="P_Entidad">Datos por el que se desea filtrar</param>
        List<Bitacora> ConsutarRegistro(Bitacora P_Entidad);
    }
}
