// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblRequisicion
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblRequisicion
  {
    public Guid IdRequisicion { get; set; }

    public string NoRequisicion { get; set; }

    public Guid IdEmpresa { get; set; }

    public Guid idContacto { get; set; }

    public string Concepto { get; set; }

    public DateTime FechaRequisicion { get; set; }

    public DateTime TIMESTAMP { get; set; }

    public int Estatus { get; set; }

    public string NombreArchivoPdf { get; set; }

    public string DocumentoPdf { get; set; }

    public string NombreArchivoXls { get; set; }

    public string DocumentoXls { get; set; }

    public Decimal? CostoRequisicion { get; set; }

    public Guid? IdUsuarioCancela { get; set; }

    public string ComentarioCancela { get; set; }

    public DateTime? FechaCancela { get; set; }

    public DateTime? FechaEnviada { get; set; }

    public Guid? IdUsuarioEnvia { get; set; }

    public Guid? IdUsuarioCreo { get; set; }
  }
}
