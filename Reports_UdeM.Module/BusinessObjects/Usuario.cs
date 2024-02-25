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

    public class Usuario : BaseObject
    {
        public Usuario(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            FechaRegistro = DateTime.Now;
        }


        EstadoUsuario estado;
        string passwordAgain;
        bool usuarioExiste;
        string username;
        string password;
        DateTime fechaRegistro;

        public DateTime FechaRegistro { get => fechaRegistro; set => SetPropertyValue(nameof(FechaRegistro), ref fechaRegistro, value); }

        public enum EstadoUsuario
        {
            Activo = 1,
            Inactivo = 0
        }

        [Size(50)]
        public string Username { get => username; set => SetPropertyValue(nameof(Username), ref username, value); }

        [NonPersistent]
        public bool UsuarioExiste { get; set; }

        [Size(100)]
        public string Password { get => password; set => SetPropertyValue(nameof(Password), ref password, value); }

        [NonPersistent]
        [Size(100)]
        public string PasswordAgain { get => passwordAgain; set => SetPropertyValue(nameof(PasswordAgain), ref passwordAgain, value); }

        public EstadoUsuario Estado { get => estado; set => SetPropertyValue(nameof(Estado), ref estado, value); }

        [Association("Usuario-Persona")]
        public XPCollection<Persona> Persona => GetCollection<Persona>(nameof(Persona));
    }
}