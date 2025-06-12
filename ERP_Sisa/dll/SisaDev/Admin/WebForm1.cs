// Decompiled with JetBrains decompiler
// Type: SisaDev.Admin.WebForm1
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Admin
{
  public class WebForm1 : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected HtmlIframe doc;

    protected void Page_Load(object sender, EventArgs e)
    {
      WebForm1.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (WebForm1.usuario != null)
      {
        WebForm1.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        this.doc.Attributes["src"] = "Docs.aspx";
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }
  }
}
