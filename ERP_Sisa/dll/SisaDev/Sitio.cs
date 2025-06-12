// Decompiled with JetBrains decompiler
// Type: SisaDev.Sitio
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
  public class Sitio : MasterPage
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuario;
    protected ContentPlaceHolder head;
    protected HyperLink home;
    protected Image LogoI;
    protected HyperLink TodoMsg;
    protected HyperLink HyperLink6;
    protected HyperLink TodoSol;
    protected HyperLink HyperLink7;
    protected HyperLink LinkPerfil;
    protected HyperLink LinkCerrar;
    protected HyperLink LinkInicio;
    protected HyperLink LinkEmpresaCliente;
    protected HyperLink LinkContactosCliente;
    protected HyperLink LinkRFQ;
    protected HyperLink LinkCotizaciones;
    protected HyperLink LinkMateriales;
    protected HyperLink LinkProveedores;
    protected HyperLink LinkRequisiciones;
    protected HyperLink LinkOrdenCompra;
    protected HyperLink LinkViaticos;
    protected HyperLink LinkProyectos;
    protected HyperLink LinkAdmin;
    protected HyperLink LinkServicioCarros;
    protected HyperLink LinkServicioPC;
    protected HyperLink LinkInventario;
    protected HyperLink LinkControlDocumentos;
    protected HyperLink LinkCajaChica;
    protected HyperLink LinkUsuarios;
    protected HyperLink LinkFacturas;
    protected HyperLink LinkSucursales;
    protected HyperLink LinkBoletines;
    protected HyperLink HyperLink1;
    protected HyperLink HyperLink2;
    protected HyperLink HyperLink3;
    protected HyperLink HyperLink4;
    protected HyperLink HyperLink5;
    protected HyperLink HyperLink8;
    protected HyperLink HyperLink9;
    protected ContentPlaceHolder MainContent;
    protected ContentPlaceHolder jsxpage;

    protected void Page_Load(object sender, EventArgs e)
    {
      Sitio.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Sitio.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      Proceso.usuarioGlobal = Sitio.usuario;
      Proceso.rolesUsuariosGlobal = Sitio.rolesUsuario;
    }
  }
}
