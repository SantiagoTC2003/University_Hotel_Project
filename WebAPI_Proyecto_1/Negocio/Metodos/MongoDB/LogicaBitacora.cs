using AccesoDatos.Interfaces;
using Entidades.MongoDB;
using Negocio.Interfaces.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Metodos.MongoDB
{
    public class LogicaBitacora : ILogicaBitacora
    {
        private readonly IAccesoMongoDB _iaccesomongo;
        public LogicaBitacora(IAccesoMongoDB pAccesoMongoDB)
        {
            _iaccesomongo = pAccesoMongoDB;
        }

        public bool AgregarRegistro(Bitacora pRegistro)
        {
            return _iaccesomongo.AgregarRegistro(pRegistro);
        }

        public List<Bitacora> ConsutarRegistro(Bitacora pRegistro)
        {
            return _iaccesomongo.ConsutarRegistro(pRegistro);
        }
    }
}
