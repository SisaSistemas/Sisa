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
    
    public partial class sp_LoadHorasHombre_Result
    {
        public System.Guid IdHorasHombre { get; set; }
        public System.Guid IdProyecto { get; set; }
        public System.Guid IdUsuario { get; set; }
        public int Lunes { get; set; }
        public int Martes { get; set; }
        public int Miercoles { get; set; }
        public int Jueves { get; set; }
        public int Viernes { get; set; }
        public int Sabado { get; set; }
        public int Domingo { get; set; }
        public Nullable<int> Total { get; set; }
        public int Activo { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string FolioProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string Descripcion { get; set; }
        public string NombreCompleto { get; set; }
    }
}
