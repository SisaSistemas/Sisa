// Decompiled with JetBrains decompiler
// Type: SisaDev.Ventas.ReporteCotizacion
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Microsoft.Reporting.WebForms;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
  public class ReporteCotizacion : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected HtmlForm form1;
    protected ScriptManager ScriptManager1;
    protected ReportViewer ReportViewer1;
    protected SqlDataSource SqlDataSource3;
    protected SqlDataSource SqlDataSource2;
    protected SqlDataSource SqlDataSource1;
    protected TextBox txtIdCotizacion;

    protected void Page_Load(object sender, EventArgs e)
    {
      ReporteCotizacion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ReporteCotizacion.usuario != null)
      {
        this.txtIdCotizacion.Text = this.Request.QueryString["IdCotizacion"].ToString();
        string empty = string.Empty;
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          ((Report) this.ReportViewer1.LocalReport).DisplayName = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (s => s.IdCotizaciones.ToString() == this.txtIdCotizacion.Text)).NoCotizaciones;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }
  }
}
