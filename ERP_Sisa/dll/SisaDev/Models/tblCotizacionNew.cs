// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblCotizacionNew
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblCotizacionNew
  {
    public Guid IdCotizacion { get; set; }

    public string NoCotizacion { get; set; }

    public Guid IdCliente { get; set; }

    public string Empresa { get; set; }

    public string Direccion { get; set; }

    public string Ciudad { get; set; }

    public string Concepto { get; set; }

    public string FechaCotizacion { get; set; }

    public Guid IdUsuarioElaboro { get; set; }

    public DateTime FechaAlta { get; set; }

    public string Estatus { get; set; }

    public string NombreArchivoPdf { get; set; }

    public string DocumentoPdf { get; set; }

    public string NombreArchivoXls { get; set; }

    public string DocumentoXls { get; set; }

    public Decimal? CostoCotizacion { get; set; }

    public Guid? IdUsuarioCancela { get; set; }

    public string ComentarioCancela { get; set; }

    public DateTime? FechaCancela { get; set; }

    public DateTime? FechaEnviada { get; set; }

    public Guid? IdUsuarioEnvia { get; set; }

    public Guid? IdUsuarioCreo { get; set; }
  }
}
