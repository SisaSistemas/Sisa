// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadProyectosAdmin_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadProyectosAdmin_Result
  {
    public long? ID { get; set; }

    public string FolioProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string ContactoCliente { get; set; }

    public string Cliente { get; set; }

    public string LiderProyecto { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string OC { get; set; }

    public string ArchivoOC { get; set; }

    public string CL { get; set; }

    public string ArchivoCL { get; set; }

    public string FC { get; set; }

    public string ArchivoFC { get; set; }

    public Guid IdProyecto { get; set; }

    public string Estatus { get; set; }

    public Decimal Facturado { get; set; }

    public Decimal? Porcentaje { get; set; }

    public Decimal Pagado { get; set; }

    public Decimal? PorcentajePagado { get; set; }

    public string EstatusDesc { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid? IdUsuarioAlta { get; set; }

    public double? CostoMaterialProyectado { get; set; }

    public double? CostoMOProyectado { get; set; }

    public double? CostoMEProyectado { get; set; }

    public DateTime? FechaAlta { get; set; }
  }
}
