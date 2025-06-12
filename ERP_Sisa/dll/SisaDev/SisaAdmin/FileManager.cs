// Decompiled with JetBrains decompiler
// Type: SisaAdmin.FileManager
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaAdmin
{
  public class FileManager : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected HtmlGenericControl a1;
    protected HtmlGenericControl a2;
    protected HtmlGenericControl a3;
    protected HtmlGenericControl a4;

    protected void Page_Load(object sender, EventArgs e)
    {
      FileManager.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (FileManager.usuario != null)
      {
        FileManager.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        if (!(FileManager.rolesUsuarios.Tipo != "ROOT") && !(FileManager.rolesUsuarios.Tipo != "ADMINISTRACION"))
          return;
        this.a1.Visible = false;
        this.a2.Visible = false;
        this.a3.Visible = false;
        this.a4.Visible = false;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }
  }
}
