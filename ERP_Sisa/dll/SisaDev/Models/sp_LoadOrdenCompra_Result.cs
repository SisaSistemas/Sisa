// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadOrdenCompra_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadOrdenCompra_Result
  {
    public Guid IdOrdenCompra { get; set; }

    public string Folio { get; set; }

    public string Proveedor { get; set; }

    public string NombreComercial { get; set; }

    public string ReferenciaCot { get; set; }

    public string NombreProyecto { get; set; }

    public string PedidoPor { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Iva { get; set; }

    public Decimal? Total { get; set; }

    public int Enviada { get; set; }

    public int Estatus { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string UsuarioModifico { get; set; }

    public string Moneda { get; set; }

    public string Email { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string NoFactura { get; set; }

    public int? EstatusFactura { get; set; }

    public Guid? idSucursal { get; set; }

    public string CiudadSucursal { get; set; }
  }
}
