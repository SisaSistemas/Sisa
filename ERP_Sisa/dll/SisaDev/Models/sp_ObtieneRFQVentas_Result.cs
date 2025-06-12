// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_ObtieneRFQVentas_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_ObtieneRFQVentas_Result
  {
    public Guid IdRfqVentas { get; set; }

    public string FolioRfq { get; set; }

    public string Descripcion { get; set; }

    public Guid IdUsuarioVendedor { get; set; }

    public Guid IdUsuarioCoordinador { get; set; }

    public string Empresa { get; set; }

    public string Contacto { get; set; }

    public DateTime? FechaRfq { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public int? Enviado { get; set; }

    public int? Estatus { get; set; }

    public string Seguimiento { get; set; }

    public DateTime? FechaAlta { get; set; }

    public Guid? IdUsuarioAlta { get; set; }

    public string Vendedor { get; set; }

    public string Coordinador { get; set; }
  }
}
