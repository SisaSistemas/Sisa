// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblProyectos
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblProyectos
  {
    public Guid IdProyecto { get; set; }

    public string FolioProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string Descripcion { get; set; }

    public string IdLider { get; set; }

    public string IdCliente { get; set; }

    public string Estatus { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public Guid? IdUsuarioAlta { get; set; }

    public DateTime? FechaAlta { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? Activo { get; set; }

    public string UserProject1 { get; set; }

    public string UserProject2 { get; set; }

    public string UserProject3 { get; set; }

    public string UserProject4 { get; set; }

    public string IdCotizacion { get; set; }

    public Decimal? CostoCotizacion { get; set; }

    public DateTime? FechaTermino { get; set; }

    public string EstatusDesc { get; set; }

    public string NombreOC { get; set; }

    public string ArchivoOC { get; set; }

    public string NombreCL { get; set; }

    public string ArchivoCL { get; set; }

    public string NombreFC { get; set; }

    public string ArchivoFC { get; set; }

    public double? CostoMOCotizado { get; set; }

    public double? CostoMaterialCotizado { get; set; }

    public double? CostoMECotizado { get; set; }

    public double? CostoMOProyectado { get; set; }

    public double? CostoMaterialProyectado { get; set; }

    public double? CostoMEProyectado { get; set; }
  }
}
