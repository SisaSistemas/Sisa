//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SisaDev.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblServiciosComputo
    {
        public System.Guid IdComputo { get; set; }
        public string PC { get; set; }
        public string Tipo { get; set; }
        public string Comentarios { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public System.Guid IdUsuario { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public System.Guid IdUsuarioModificacion { get; set; }
        public string Serie { get; set; }
        public Nullable<System.DateTime> FechaProximoMantenimiento { get; set; }
        public string Usuario { get; set; }
    }
}
