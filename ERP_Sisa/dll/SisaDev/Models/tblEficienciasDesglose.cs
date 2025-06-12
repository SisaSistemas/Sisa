// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblEficienciasDesglose
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblEficienciasDesglose
  {
    public int idEficiencia { get; set; }

    public string idProyecto { get; set; }

    public string idDocumento { get; set; }

    public string Categoria { get; set; }

    public string TipoDoc { get; set; }

    public Decimal? Total { get; set; }

    public string Folio { get; set; }

    public DateTime? FechaDoc { get; set; }

    public string idUsuarioUltimo { get; set; }
  }
}
