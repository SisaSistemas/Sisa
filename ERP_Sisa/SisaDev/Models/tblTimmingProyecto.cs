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
    
    public partial class tblTimmingProyecto
    {
        public System.Guid IdTimming { get; set; }
        public string NombreProyecto { get; set; }
        public string Actividad { get; set; }
        public string Tarea { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Persona { get; set; }
        public string DiasTrans { get; set; }
        public Nullable<decimal> Avance { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<System.Guid> IdUsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.Guid> IdUsuarioModificacion { get; set; }
    }
}
