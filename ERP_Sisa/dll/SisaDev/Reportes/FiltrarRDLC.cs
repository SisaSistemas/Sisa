// Decompiled with JetBrains decompiler
// Type: SisaDev.Reportes.FiltrarRDLC
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Reportes
{
  public class FiltrarRDLC : Page
  {
    protected HtmlForm form1;
    protected TextBox txtFiltro;
    protected Button Button1;
    protected ScriptManager ScriptManager1;
    protected ReportViewer ReportViewer1;
    protected SqlDataSource SqlDataSource1;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e) => ((Report) this.ReportViewer1.LocalReport).SetParameters((IEnumerable<ReportParameter>) new ReportParameter[1]
    {
      new ReportParameter("Cliente", this.txtFiltro.Text)
    });
  }
}
