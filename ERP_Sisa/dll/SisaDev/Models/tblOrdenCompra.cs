// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblOrdenCompra
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblOrdenCompra
  {
    public Guid IdOrdenCompra { get; set; }

    public string Folio { get; set; }

    public Guid IdProveedor { get; set; }

    public string ReferenciaCot { get; set; }

    public Guid IdProyecto { get; set; }

    public Guid IdUsuario { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Iva { get; set; }

    public Decimal? Total { get; set; }

    public int Estatus { get; set; }

    public int Enviada { get; set; }

    public string EnviarA { get; set; }

    public Guid IdMoneda { get; set; }

    public string CondicionPago { get; set; }

    public string Comentarios { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Guid IdUsuarioCreacion { get; set; }

    public DateTime FechaModificacion { get; set; }

    public Guid IdUsuarioModificacion { get; set; }

    public DateTime? FechaCancelacion { get; set; }

    public string IdUsuarioCancelacion { get; set; }

    public string MotivoCancelacion { get; set; }

    public Decimal? Descuento { get; set; }

    public Guid? IdUsuarioAprobo { get; set; }

    public string TipoOC { get; set; }

    public Guid? idSucursal { get; set; }

    public Guid? idRequisicion { get; set; }

    public string FolioReq { get; set; }
  }
}
