// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargaComentariosOrdenCompra_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargaComentariosOrdenCompra_Result
  {
    public Guid IdOrdenCompra { get; set; }

    public string NombreCompleto { get; set; }

    public string Comentario { get; set; }

    public string Dia { get; set; }

    public string Mes { get; set; }

    public long? ID { get; set; }

    public string Fecha { get; set; }
  }
}
