using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.MongoDB
{
    public class Bitacora
    {
        #region Propiedades

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Id_Usuario")]
        public string Id_Usuario { get; set; }
        [BsonElement("Nombre_Usuario")]
        public string nombre_usuario { get; set; }
        [BsonElement("Descripcion")]
        public string descripcion { get; set; }

        #endregion

        #region Constructor

        public Bitacora()
        {
            Id = string.Empty;
            Id_Usuario = string.Empty;
            nombre_usuario = string.Empty;
            descripcion = string.Empty;
        }

        #endregion
    }
}
