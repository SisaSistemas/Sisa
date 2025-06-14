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
    
    public partial class tblProyectos
    {
        public System.Guid IdProyecto { get; set; }
        public string FolioProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string Descripcion { get; set; }
        public string IdLider { get; set; }
        public string IdCliente { get; set; }
        public string Estatus { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<System.Guid> IdUsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<System.Guid> IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> Activo { get; set; }
        public string UserProject1 { get; set; }
        public string UserProject2 { get; set; }
        public string UserProject3 { get; set; }
        public string UserProject4 { get; set; }
        public string IdCotizacion { get; set; }
        public Nullable<decimal> CostoCotizacion { get; set; }
        public Nullable<System.DateTime> FechaTermino { get; set; }
        public string EstatusDesc { get; set; }
        public string NombreOC { get; set; }
        public string ArchivoOC { get; set; }
        public string NombreCL { get; set; }
        public string ArchivoCL { get; set; }
        public string NombreFC { get; set; }
        public string ArchivoFC { get; set; }
        public Nullable<double> CostoMOCotizado { get; set; }
        public Nullable<double> CostoMaterialCotizado { get; set; }
        public Nullable<double> CostoMECotizado { get; set; }
        public Nullable<double> CostoMOProyectado { get; set; }
        public Nullable<double> CostoMaterialProyectado { get; set; }
        public Nullable<double> CostoMEProyectado { get; set; }
        public string LinkSharepoint { get; set; }
        public Nullable<System.Guid> IdSucursal { get; set; }
        public string FolioPO { get; set; }
        public Nullable<int> Avance { get; set; }
        public Nullable<System.Guid> IdUsuarioFinaliza { get; set; }
        public Nullable<System.Guid> IdUsuarioAvance { get; set; }
        public Nullable<int> EsCCM { get; set; }
        public Nullable<System.Guid> IdModuloPO { get; set; }
        public Nullable<System.Guid> IdUsuarioEstatus { get; set; }
        public Nullable<System.DateTime> FechaEstatus { get; set; }
    }
}
