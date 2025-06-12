// Decompiled with JetBrains decompiler
// Type: SisaDev.Reportes.WebForm1
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Microsoft.Reporting.WebForms;
using SisaDev.Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Reportes
{
  public class WebForm1 : Page
  {
    private static tblUsuarios usuario;
    private static tblRolesUsuarios rolesUsuario;
    protected HtmlForm form1;
    protected ScriptManager ScriptManager1;
    protected ReportViewer ReportViewer1;
    protected SqlDataSource SqlDataSource1;

    protected void Page_Load(object sender, EventArgs e)
    {
      WebForm1.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (WebForm1.usuario != null)
      {
        WebForm1.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        bool? reportes = WebForm1.rolesUsuario.Reportes;
        bool flag = true;
        if (reportes.GetValueOrDefault() == flag & reportes.HasValue || WebForm1.rolesUsuario.Tipo == "ROOT" || WebForm1.rolesUsuario.Tipo == "ADMINISTRACION" || WebForm1.rolesUsuario.Tipo == "GERENCIAL")
          return;
        this.Response.Redirect("~/Default.aspx");
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }
  }
}
