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
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SolicitudesAuditoria : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public SolicitudesAuditoria(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Fecha = DateTime.Now;
            UsuarioAud = SecuritySystem.CurrentUserName;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string nota;
        Solicitudes.EstadoSolicitud estadoAnterior;
        Solicitudes.EstadoSolicitud estadoNuevo;
        string usuarioAud;
        DateTime fecha;

        public DateTime Fecha { get => fecha; set => SetPropertyValue(nameof(Fecha), ref fecha, value); }


        [Size(50)]
        public string UsuarioAud { get => usuarioAud; set => SetPropertyValue(nameof(UsuarioAud), ref usuarioAud, value); }


        public Solicitudes.EstadoSolicitud EstadoAnterior { get => estadoAnterior; set => SetPropertyValue(nameof(EstadoAnterior), ref estadoAnterior, value); }

        public Solicitudes.EstadoSolicitud EstadoNuevo { get => estadoNuevo; set => SetPropertyValue(nameof(EstadoNuevo), ref estadoNuevo, value); }


        [Size(SizeAttribute.Unlimited)]
        public string Nota { get => nota; set => SetPropertyValue(nameof(Nota), ref nota, value); }


       
    }
}