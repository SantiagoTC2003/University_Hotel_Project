using AccesoDatos.Interfaces;
using Entidades.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AccesoDatos
{
    public class AccesoMongoDB : IAccesoMongoDB
    {
        #region Atributos

        // String de conexión
        private readonly string CadenaConexion = @"mongodb+srv://nanosama95:Akaimune95.@cluster0.ilhoxwf.mongodb.net/BitacoraHotel?retryWrites=true&w=majority";

        // Crear instancia de la base de datos
        private MongoClient InstanciaBD;
        private IMongoDatabase BaseDatos;

        private const string NombreBD = "BitacoraHotel";
        #endregion

        #region Constructor

        public AccesoMongoDB()
        {

        }

        #endregion

        #region Métodos

        #region Privados

        private void EstablecerConexion()
        {
            try
            {
                InstanciaBD = new MongoClient(CadenaConexion);
                BaseDatos = InstanciaBD.GetDatabase(NombreBD);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        public bool AgregarRegistro(Bitacora pEntidad)
        {
            EstablecerConexion();

            var Coleccion = BaseDatos.GetCollection<Bitacora>("Bitacora");
            Coleccion.InsertOne(pEntidad);
            return true;
        }

        public List<Bitacora> ConsutarRegistro(Bitacora pEntidad)
        {
            EstablecerConexion();


            var Coleccion = BaseDatos.GetCollection<Bitacora>("Bitacora");
            if (pEntidad != null)
            {
                if (!string.IsNullOrEmpty(pEntidad.Id))
                {
                    return Coleccion.Find(d => d.Id == pEntidad.Id).ToList();
                }
                else {
                    return Coleccion.Find(d => true).ToList();
                }
            }
            else {
                return Coleccion.Find(d => true).ToList();
            }
        }
        #endregion
    }
}