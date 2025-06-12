// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.ProyectoDetallesAdmin
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Administracion
{
  public class ProyectoDetallesAdmin : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idProyecto = string.Empty;
    protected HtmlGenericControl lblProyectoTarea;
    protected HtmlGenericControl lblFolio;
    protected HtmlInputHidden idProyectoDetalle;

    protected void Page_Load(object sender, EventArgs e)
    {
      ProyectoDetallesAdmin.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ProyectoDetallesAdmin.usuario != null)
      {
        ProyectoDetallesAdmin.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        ProyectoDetallesAdmin.idProyecto = this.Request.QueryString["id"];
        this.idProyectoDetalle.Value = ProyectoDetallesAdmin.idProyecto;
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == ProyectoDetallesAdmin.idProyecto));
          this.lblProyectoTarea.InnerText = tblProyectos.FolioProyecto + " " + tblProyectos.NombreProyecto + " Descripción: " + tblProyectos.Descripcion;
          this.lblFolio.InnerText = tblProyectos.NombreProyecto;
        }
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarDatos(string IdProyecto, string Opcion)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarDetalleProyecto(IdProyecto, new int?(Convert.ToInt32(Opcion))));
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarComentarios(string IdProyecto, string Opcion)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarDetalleProyecto(IdProyecto, new int?(Convert.ToInt32(Opcion))));
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarGrafica(string IdProyecto)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) sisaEntitie.sp_GraficaUtilidad(IdProyecto));
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarGraficaPastel(string IdProyecto)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) sisaEntitie.sp_GraficaPastelUtilidad(IdProyecto));
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarDetalleGrafica(string Nombre, string IdProyecto, string Gastado)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) sisaEntitie.sp_GraficaPastelDetalle(IdProyecto, Nombre, new Decimal?(Decimal.Parse(Gastado))));
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarDetalle(string Punto, string IdProyecto)
    {
      string str = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = !(Punto == "Mano de Obra") ? (!(Punto == "Viaticos") ? (!(Punto == "Caja Chica") ? JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarDetalleGrafica_Result>) sisaEntitie.sp_CargarDetalleGrafica(Punto, IdProyecto)).Distinct<sp_CargarDetalleGrafica_Result>()) : JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarDetalleGraficaCajaChica(Punto, IdProyecto))) : JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarDetalleGraficaViaticos(Punto, IdProyecto))) : JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarDetalleGraficaMO(Punto, IdProyecto));
      }
      catch (Exception ex)
      {
        str = ex.ToString();
      }
      return str;
    }

    [WebMethod]
    public static string CargarGraficaPastelEficiencia(string IdProyecto)
    {
      string str = string.Empty;
      ProyectoDetallesAdmin.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoDetallesAdmin.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoDetallesAdmin.rolesUsuarios.Administracion || ProyectoDetallesAdmin.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) sisaEntitie.CargarEficiencias(IdProyecto));
      }
      else
        str = "No tienes permiso de actualizar proyecto.";
      return str;
    }

    [WebMethod]
    public static string Proyecciones(string IdProyecto)
    {
      string str = string.Empty;
      ProyectoDetallesAdmin.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoDetallesAdmin.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoDetallesAdmin.rolesUsuarios.Administracion || ProyectoDetallesAdmin.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarProyecciones(IdProyecto));
      }
      else
        str = "No tienes permiso de actualizar proyecto.";
      return str;
    }
  }
}
