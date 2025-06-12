// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblRFQ
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblRFQ
  {
    public Guid IdRfq { get; set; }

    public string Folio { get; set; }

    public string Round { get; set; }

    public string Fecha { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public Guid IdCliente { get; set; }

    public string FolioRQ { get; set; }

    public Guid IdComprador { get; set; }

    public Guid? IdCotizacion { get; set; }

    public string ArchivoRFQ { get; set; }

    public int Estatus { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioModificar { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string Descripcion { get; set; }

    public Guid? idVendedor { get; set; }

    public Guid? idCoordinador { get; set; }

    public string Seguimiento { get; set; }
  }
}
