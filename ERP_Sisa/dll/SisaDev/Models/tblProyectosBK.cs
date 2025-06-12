// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblProyectosBK
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblProyectosBK
  {
    public int IdProyecto { get; set; }

    public Guid ID { get; set; }

    public string NombreProyecto { get; set; }

    public string Descripcion { get; set; }

    public Guid IdLider { get; set; }

    public Guid? IdCliente { get; set; }

    public string Estatus { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioModificacion { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int Activo { get; set; }

    public Guid? UserProject1 { get; set; }

    public Guid? UserProject2 { get; set; }

    public Guid? UserProject3 { get; set; }

    public Guid? UserProject4 { get; set; }

    public Guid? IdCotizacion { get; set; }

    public Decimal? CostoCotizacion { get; set; }
  }
}
