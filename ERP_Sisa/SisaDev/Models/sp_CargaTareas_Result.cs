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
    
    public partial class sp_CargaTareas_Result
    {
        public System.Guid IdTask { get; set; }
        public string Task { get; set; }
        public string NombreCompleto { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public Nullable<int> Dias { get; set; }
        public Nullable<int> DiasTranscurridos { get; set; }
        public int Estatus { get; set; }
        public string Comentarios { get; set; }
        public Nullable<decimal> Porcentaje { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public int CONT { get; set; }
        public Nullable<int> ContDaily { get; set; }
    }
}
