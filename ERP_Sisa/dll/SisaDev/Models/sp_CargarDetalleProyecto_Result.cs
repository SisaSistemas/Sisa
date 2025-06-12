// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarDetalleProyecto_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarDetalleProyecto_Result
  {
    public Guid IdProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string NombreCompleto { get; set; }

    public string RazonSocial { get; set; }

    public string Descripcion { get; set; }

    public int? Dia { get; set; }

    public Decimal? Total { get; set; }

    public Decimal? Gastos { get; set; }

    public string NombreContacto { get; set; }

    public string Folio { get; set; }

    public string Fecha { get; set; }

    public Decimal? GastosPend { get; set; }

    public string Comentario { get; set; }

    public string Foto { get; set; }
  }
}
