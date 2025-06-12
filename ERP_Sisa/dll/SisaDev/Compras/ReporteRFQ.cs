// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.ReporteRFQ
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
  public class ReporteRFQ : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected HtmlForm form1;
    protected ScriptManager ScriptManager1;
    protected ReportViewer ReportViewer1;
    protected TextBox txtNombreRFQ;
    protected TextBox txtIdRFQ;

    protected void Page_Load(object sender, EventArgs e)
    {
      ReporteRFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ReporteRFQ.usuario != null)
      {
        this.txtIdRFQ.Text = this.Request.QueryString["IdRFQ"].ToString();
        ((Report) this.ReportViewer1.LocalReport).DisplayName = this.txtNombreRFQ.Text;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }
  }
}
