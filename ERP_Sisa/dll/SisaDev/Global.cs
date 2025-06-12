// Decompiled with JetBrains decompiler
// Type: SisaDev.Global
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.Web;

namespace SisaDev
{
  public class Global : HttpApplication
  {
    protected void Application_Start(object sender, EventArgs e)
    {
    }

    public void Session_Start(object sender, EventArgs e) => this.Session["init"] = (object) 0;
  }
}
