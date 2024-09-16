using AccesoDatos.Interfaces;
using Entidades.SQLServer;
using Negocio.Interfaces.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Metodos.SQLServer
{
    public class ClienteNSQL : IClienteNSQL
    {

        private readonly IClientesADSQL _ICLienteAD;

        public ClienteNSQL(IClientesADSQL _iaccesoSQL)
        {
            _ICLienteAD = _iaccesoSQL;
        }

        public bool AgregarCliente(Clientes pEntidad)
        {
            return _ICLienteAD.AgregarCliente(pEntidad);
        }

        public List<Clientes> ConsultarCliente(Clientes pEntidad)
        {
            return _ICLienteAD.ConsultarCliente(pEntidad);
        }

        public bool EliminarCliente(Clientes pEntidad)
        {
            return _ICLienteAD.EliminarCliente(pEntidad);
        }

        public bool ModificarCliente(Clientes pEntidad)
        {
            return _ICLienteAD.ModificarCliente(pEntidad);
        }
    }
}