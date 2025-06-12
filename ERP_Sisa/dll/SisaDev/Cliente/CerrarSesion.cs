// Decompiled with JetBrains decompiler
// Type: SisaDev.Cliente.CerrarSesion
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Cliente
{
  public class CerrarSesion : Page
  {
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
      HttpContext.Current.Session["UsuarioClienteLogueado"] = (object) null;
      this.Response.Redirect("Default.aspx");
    }
  }
}
