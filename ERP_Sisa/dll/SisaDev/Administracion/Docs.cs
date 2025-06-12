// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.Docs
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Administracion
{
  public class Docs : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected HtmlInputText filepath;
    protected HtmlButton browse;
    protected HtmlButton upload;
    protected HtmlButton newfolder;
    protected HtmlButton grid;
    protected HtmlButton list;
    protected HtmlGenericControl itemOptions;
    protected HtmlGenericControl a2;
    protected HtmlGenericControl a4;

    protected void Page_Load(object sender, EventArgs e)
    {
      Docs.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Docs.usuario != null)
      {
        Docs.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        if (Docs.rolesUsuarios.Tipo == "ROOT" || Docs.rolesUsuarios.Tipo == "ADMINISTRACION")
        {
          this.a2.Visible = true;
          this.a4.Visible = true;
          this.upload.Visible = true;
          this.newfolder.Visible = true;
          this.browse.Visible = true;
          this.filepath.Visible = true;
        }
        else
        {
          this.a2.Visible = false;
          this.a4.Visible = false;
          this.upload.Visible = false;
          this.newfolder.Visible = false;
          this.browse.Visible = false;
          this.filepath.Visible = false;
          this.itemOptions.Visible = false;
        }
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public string Permisos(string pid)
    {
      string empty = string.Empty;
      Docs.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Docs.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Docs.rolesUsuarios.Tipo == "ROOT" || Docs.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        this.a2.Visible = true;
        this.upload.Visible = true;
        this.newfolder.Visible = true;
        this.browse.Visible = true;
        this.filepath.Visible = true;
      }
      else
      {
        this.a2.Visible = false;
        this.upload.Visible = false;
        this.newfolder.Visible = false;
        this.browse.Visible = false;
        this.filepath.Visible = false;
      }
      return "";
    }
  }
}
