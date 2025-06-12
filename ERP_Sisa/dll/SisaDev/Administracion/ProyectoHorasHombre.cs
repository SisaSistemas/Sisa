// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.ProyectoHorasHombre
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
  public class ProyectoHorasHombre : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idProyecto = string.Empty;
    protected HtmlGenericControl lblProyectoTarea;
    protected HtmlGenericControl lblFolio;
    protected HtmlInputHidden idProyectoHH;

    protected void Page_Load(object sender, EventArgs e)
    {
      ProyectoHorasHombre.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ProyectoHorasHombre.usuario != null)
      {
        ProyectoHorasHombre.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        ProyectoHorasHombre.idProyecto = this.Request.QueryString["id"];
        this.idProyectoHH.Value = ProyectoHorasHombre.idProyecto;
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == ProyectoHorasHombre.idProyecto));
          this.lblProyectoTarea.InnerText = tblProyectos.FolioProyecto + " " + tblProyectos.NombreProyecto + " Descripción: " + tblProyectos.Descripcion;
          this.lblFolio.InnerText = tblProyectos.NombreProyecto;
        }
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarCombos(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombos(new int?(int32)));
      }
    }

    [WebMethod]
    public static string CargarHorasHombre(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblHorasHombre>) sisaEntitie.tblHorasHombre).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, (Expression<Func<tblHorasHombre, Guid>>) (tt => tt.IdUsuario), (Expression<Func<tblUsuarios, Guid>>) (u => u.IdUsuario), (tt, u) => new
        {
          tt = tt,
          u = u
        }).Where(data => data.tt.IdProyecto.ToString() == ProyectoHorasHombre.idProyecto && data.tt.Activo == 1).Select(data => new
        {
          IdHorasHombre = data.tt.IdHorasHombre,
          NombreCompleto = data.u.NombreCompleto,
          Lunes = data.tt.Lunes,
          Martes = data.tt.Martes,
          Miercoles = data.tt.Miercoles,
          Jueves = data.tt.Jueves,
          Viernes = data.tt.Viernes,
          Sabado = data.tt.Sabado,
          Domingo = data.tt.Domingo,
          Fecha = data.tt.FechaAlta,
          Total = data.tt.Total
        }).OrderByDescending(a => a.Fecha));
    }

    [WebMethod]
    public static string AgregarHorasHombre(
      string pid,
      string Usuario,
      string Lunes,
      string Martes,
      string Miercoles,
      string Jueves,
      string Viernes,
      string Sabado,
      string Domingo)
    {
      string str = string.Empty;
      ProyectoHorasHombre.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoHorasHombre.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoHorasHombre.rolesUsuarios.ProyectosEditar || ProyectoHorasHombre.rolesUsuarios.Tipo == "ROOT")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            Guid guid1 = Guid.Parse(pid);
            Guid idu = Guid.Parse(Usuario);
            tblHorasHombre add = new tblHorasHombre()
            {
              IdHorasHombre = Guid.NewGuid(),
              IdUsuario = idu,
              IdProyecto = guid1,
              Activo = 1,
              FechaAlta = new DateTime?(DateTime.Now),
              Lunes = Lunes == string.Empty ? 0 : Convert.ToInt32(Lunes),
              Martes = Martes == string.Empty ? 0 : Convert.ToInt32(Martes),
              Miercoles = Miercoles == string.Empty ? 0 : Convert.ToInt32(Miercoles),
              Jueves = Jueves == string.Empty ? 0 : Convert.ToInt32(Jueves),
              Viernes = Viernes == string.Empty ? 0 : Convert.ToInt32(Viernes),
              Sabado = Sabado == string.Empty ? 0 : Convert.ToInt32(Sabado),
              Domingo = Domingo == string.Empty ? 0 : Convert.ToInt32(Domingo)
            };
            sisaEntitie.tblHorasHombre.Add(add);
            sisaEntitie.SaveChanges();
            tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (a => a.IdUsuario == idu));
            if (tblUsuarios != null)
            {
              if (string.IsNullOrEmpty(tblUsuarios.SueldoDiario.ToString()))
                return "Se agregaron las horas pero no el dato para la eficiencia ya que la persona seleccionada, no cuenta con un sueldo diario registrado.";
              Decimal num1 = (Decimal) ((Lunes == string.Empty ? 0 : Convert.ToInt32(Lunes)) + (Martes == string.Empty ? 0 : Convert.ToInt32(Martes)) + (Miercoles == string.Empty ? 0 : Convert.ToInt32(Miercoles)) + (Jueves == string.Empty ? 0 : Convert.ToInt32(Jueves)) + (Viernes == string.Empty ? 0 : Convert.ToInt32(Viernes)) + (Sabado == string.Empty ? 0 : Convert.ToInt32(Sabado)) + (Domingo == string.Empty ? 0 : Convert.ToInt32(Domingo)));
              Decimal? nullable1 = tblUsuarios.SueldoDiario;
              Decimal num2 = (Decimal) 8;
              Decimal? nullable2 = nullable1.HasValue ? new Decimal?(nullable1.GetValueOrDefault() / num2) : new Decimal?();
              tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == add.IdHorasHombre.ToString()));
              if (eficienciasDesglose1 != null)
              {
                eficienciasDesglose1.idProyecto = pid;
                eficienciasDesglose1.idDocumento = add.IdHorasHombre.ToString();
                eficienciasDesglose1.Categoria = "MANOOBRA";
                tblEficienciasDesglose eficienciasDesglose2 = eficienciasDesglose1;
                Decimal num3 = num1;
                nullable1 = nullable2;
                Decimal? nullable3 = nullable1.HasValue ? new Decimal?(num3 * nullable1.GetValueOrDefault()) : new Decimal?();
                eficienciasDesglose2.Total = nullable3;
                eficienciasDesglose1.TipoDoc = "HH";
                eficienciasDesglose1.Folio = "";
                sisaEntitie.SaveChanges();
              }
              else
              {
                tblEficienciasDesglose eficienciasDesglose3 = new tblEficienciasDesglose();
                eficienciasDesglose3.idProyecto = pid;
                eficienciasDesglose3.Categoria = "MANOOBRA";
                Decimal num4 = num1;
                nullable1 = nullable2;
                eficienciasDesglose3.Total = nullable1.HasValue ? new Decimal?(num4 * nullable1.GetValueOrDefault()) : new Decimal?();
                eficienciasDesglose3.TipoDoc = "HH";
                eficienciasDesglose3.Folio = "";
                eficienciasDesglose3.FechaDoc = add.FechaAlta;
                Guid guid2 = ProyectoHorasHombre.usuario.IdUsuario;
                eficienciasDesglose3.idUsuarioUltimo = guid2.ToString();
                guid2 = add.IdHorasHombre;
                eficienciasDesglose3.idDocumento = guid2.ToString();
                tblEficienciasDesglose eficienciasDesglose4 = eficienciasDesglose3;
                sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose4);
                sisaEntitie.SaveChanges();
              }
              sisaEntitie.SaveChanges();
            }
            str = "Horas agregadas.";
          }
        }
        catch (Exception ex)
        {
          str = ex.Message;
        }
      }
      else
        str = "No tienes permiso de edicion de proyectos.";
      return str;
    }

    [WebMethod]
    public static string EliminarProyectosHH(string pid)
    {
      string str = string.Empty;
      ProyectoHorasHombre.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoHorasHombre.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoHorasHombre.rolesUsuarios.ProyectosEditar || ProyectoHorasHombre.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblHorasHombre tblHorasHombre = ((IQueryable<tblHorasHombre>) sisaEntitie.tblHorasHombre).FirstOrDefault<tblHorasHombre>((Expression<Func<tblHorasHombre, bool>>) (e => e.IdHorasHombre.ToString() == pid));
          if (tblHorasHombre != null)
          {
            tblHorasHombre.Activo = 0;
            sisaEntitie.SaveChanges();
            tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == pid));
            if (eficienciasDesglose != null)
            {
              sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
              sisaEntitie.SaveChanges();
            }
            str = "Horas eliminadas.";
          }
          else
            str = "Se genero un problema recarga la página.";
        }
      }
      else
        str = "No tienes permiso de editar proyectos-";
      return str;
    }
  }
}
