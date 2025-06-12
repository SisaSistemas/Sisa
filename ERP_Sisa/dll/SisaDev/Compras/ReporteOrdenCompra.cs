// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.ReporteOrdenCompra
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

namespace SisaDev.Compras
{
  public class ReporteOrdenCompra : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected HtmlForm form1;
    protected ScriptManager ScriptManager1;
    protected ReportViewer ReportViewer1;
    protected ObjectDataSource ObDs1;
    protected ObjectDataSource ObDs2;
    protected TextBox txtNombreOrden;
    protected TextBox txtIdOrdenCompra;

    protected void Page_Load(object sender, EventArgs e)
    {
      ReporteOrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ReporteOrdenCompra.usuario != null)
      {
        this.txtNombreOrden.Text = this.Request.QueryString["NombreOrden"].ToString();
        this.txtIdOrdenCompra.Text = this.Request.QueryString["IdOrdenCompra"].ToString();
        ((Report) this.ReportViewer1.LocalReport).DisplayName = this.txtNombreOrden.Text;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }
  }
}
