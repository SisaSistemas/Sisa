// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadRFQ_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadRFQ_Result
  {
    public Guid IdRfq { get; set; }

    public string RFQ { get; set; }

    public string RQ { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public string Comprador { get; set; }

    public string Requisitor { get; set; }

    public string Empresa { get; set; }

    public string FolioCotizacion { get; set; }
  }
}
