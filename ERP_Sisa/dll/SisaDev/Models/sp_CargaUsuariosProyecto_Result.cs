// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargaUsuariosProyecto_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargaUsuariosProyecto_Result
  {
    public string IdProyecto { get; set; }

    public Guid IdUsuario { get; set; }

    public string NombreCompleto { get; set; }
  }
}
