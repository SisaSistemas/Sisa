// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarViaticosEnc_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarViaticosEnc_Result
  {
    public Guid ID { get; set; }

    public Guid? IdProyecto { get; set; }

    public Decimal CantEntregada { get; set; }

    public Decimal CantGastada { get; set; }

    public Decimal? Diferencia { get; set; }

    public Guid IdUsuario { get; set; }

    public int? Estatus { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaCaptura { get; set; }

    public string Concepto { get; set; }

    public string NombreProyecto { get; set; }
  }
}
