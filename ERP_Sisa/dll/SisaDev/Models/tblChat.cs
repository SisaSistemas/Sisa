// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblChat
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblChat
  {
    public int IdChat { get; set; }

    public string IdFrom { get; set; }

    public string From { get; set; }

    public string IdTo { get; set; }

    public string To { get; set; }

    public string Message { get; set; }

    public DateTime MessageDate { get; set; }

    public int Leido { get; set; }
  }
}
