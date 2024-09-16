using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using Negocio.Interfaces.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Metodos.SQLServer
{
    public class UsuarioNSQL : IUsuarioNSQL
    {

        private readonly IUsuariosADSQL _IUsuarioAD;

        public UsuarioNSQL(IUsuariosADSQL iAccesoSQL)
        {
            _IUsuarioAD = iAccesoSQL;
        }

        public bool AgregarUsuario(Usuarios pEntidad)
        {
            return _IUsuarioAD.AgregarUsuario(pEntidad);
        }

        public bool AgregarUsuarioSP(Usuarios pEntidad)
        {
            return _IUsuarioAD.AgregarUsuarioSP(pEntidad);
        }

        public List<Usuarios> ComprobarLogin(Usuarios pEntidad)
        {
            return _IUsuarioAD.ComprobarLogin(pEntidad);
        }

        public List<Usuarios> ConsultarUsuarios(Usuarios pEntidad)
        {
            return _IUsuarioAD.ConsultarUsuarios(pEntidad);
        }

        public bool EliminarUsuario(Usuarios pEntidad)
        {
            return _IUsuarioAD.EliminarUsuario(pEntidad);
        }

        public bool ModificarUsuario(Usuarios pEntidad)
        {
            return _IUsuarioAD.ModificarUsuario(pEntidad);
        }
    }
}
