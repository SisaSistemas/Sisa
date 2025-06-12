// Decompiled with JetBrains decompiler
// Type: SisaDev.SitioCliente
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
  public class SitioCliente : MasterPage
  {
    public static tblClienteContacto usuario;
    protected ContentPlaceHolder head;
    protected HyperLink home;
    protected Image LogoI;
    protected HyperLink LinkCerrar;
    protected HyperLink LinkInicio;
    protected ContentPlaceHolder MainContent;
    protected ContentPlaceHolder jsxpage;

    protected void Page_Load(object sender, EventArgs e) => SitioCliente.usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
  }
}
