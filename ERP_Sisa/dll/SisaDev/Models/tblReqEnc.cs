// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblReqEnc
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblReqEnc
  {
    public Guid IdReqEnc { get; set; }

    public string NoReq { get; set; }

    public Guid IdProyecto { get; set; }

    public int Estatus { get; set; }

    public int SolicitarCotizacion { get; set; }

    public int? RealizarCompra { get; set; }

    public string Observaciones { get; set; }

    public string Fecha { get; set; }

    public Guid IdUsuarioElaboro { get; set; }

    public DateTime FechaElaboracion { get; set; }

    public Guid? IdUsuarioAutorizo { get; set; }

    public DateTime? FechaAutorizada { get; set; }

    public Guid? IdUsuarioCompra { get; set; }

    public DateTime? FechaCompra { get; set; }
  }
}
