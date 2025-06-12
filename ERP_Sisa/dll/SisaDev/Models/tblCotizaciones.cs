// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblCotizaciones
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblCotizaciones
  {
    public Guid IdCotizaciones { get; set; }

    public string NoCotizaciones { get; set; }

    public Guid IdEmpresa { get; set; }

    public Guid idContacto { get; set; }

    public string Concepto { get; set; }

    public DateTime FechaCotizaciones { get; set; }

    public DateTime TIMESTAMP { get; set; }

    public int Estatus { get; set; }

    public string NombreArchivoPdf { get; set; }

    public string DocumentoPdf { get; set; }

    public string NombreArchivoXls { get; set; }

    public string DocumentoXls { get; set; }

    public Decimal? CostoCotizaciones { get; set; }

    public Guid? IdUsuarioCancela { get; set; }

    public string ComentarioCancela { get; set; }

    public DateTime? FechaCancela { get; set; }

    public DateTime? FechaEnviada { get; set; }

    public Guid? IdUsuarioEnvia { get; set; }

    public Guid? IdUsuarioCreo { get; set; }

    public Guid? idRequisicion { get; set; }

    public double? CostoMOCotizado { get; set; }

    public double? CostoMaterialCotizado { get; set; }

    public double? CostoMECotizado { get; set; }
  }
}
