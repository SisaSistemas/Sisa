// Decompiled with JetBrains decompiler
// Type: SisaDev.Account.Salir
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Account
{
  public class Salir : Page
  {
    protected HtmlForm form1;

    protected void Page_Load(object sender, EventArgs e)
    {
      HttpContext.Current.Session["UsuarioLogueado"] = (object) null;
      HttpContext.Current.Session["RolesUsuarioLogueado"] = (object) null;
      this.Response.Redirect("~/Default.aspx");
    }
  }
}
