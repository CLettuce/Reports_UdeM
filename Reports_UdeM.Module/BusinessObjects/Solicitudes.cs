using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Reports_UdeM.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class Solicitudes : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Solicitudes(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            FechaRegistro = DateTime.Now;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        public enum EstadoSolicitud
        {
            Creado = 0,
            [XafDisplayName("Publicado")]
            Publicado = 1,
            EnRevision = 2,
            Entregado = 3,
            Rechazado = 4
        }

        CatalogoUbicacion ubicacionDePeticion;
        CatalogoProfesores profesor;
        CatalogoCarrera carrera;
        SolicitudesAuditoria propertyName;
        DateTime fechaRegistro;
        Persona persona;
        EstadoSolicitud estado;
        string descripcion;

        public Persona Persona { get => persona; set => SetPropertyValue(nameof(Persona), ref persona, value); }

        public DateTime FechaRegistro { get => fechaRegistro; set => SetPropertyValue(nameof(FechaRegistro), ref fechaRegistro, value); }

        public EstadoSolicitud Estado { get => estado; set => SetPropertyValue(nameof(Estado), ref estado, value); }
        [Size(200)]
        public string Descripcion { get => descripcion; set => SetPropertyValue(nameof(Descripcion), ref descripcion, value); }

        public string NombreCompletoPersona => Persona is null ? "N/A" : Persona.NombreCompleto;

        public CatalogoCarrera Carrera { get => carrera; set => SetPropertyValue(nameof(Carrera), ref carrera, value); }

        public CatalogoProfesores Profesor { get => profesor; set => SetPropertyValue(nameof(Profesor), ref profesor, value); }

        public CatalogoUbicacion UbicacionDePeticion { get => ubicacionDePeticion; set => SetPropertyValue(nameof(UbicacionDePeticion), ref ubicacionDePeticion, value); }

    }
}