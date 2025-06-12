// Decompiled with JetBrains decompiler
// Type: SisaDev.Admin.CajaChica
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

namespace SisaDev.Admin
{
  public class CajaChica : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      CajaChica.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (CajaChica.usuario != null)
        CajaChica.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerCC(string pid)
    {
      string str = string.Empty;
      CajaChica.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CajaChica.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblCajaChica>) sisaEntitie.tblCajaChica).Select<tblCajaChica, tblCajaChica>((Expression<Func<tblCajaChica, tblCajaChica>>) (s => s)));
      }
      if (CajaChica.rolesUsuarios.CajaChica || CajaChica.rolesUsuarios.Tipo == "ROOT" || CajaChica.rolesUsuarios.Tipo == "GERENCIAL" || CajaChica.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IEnumerable<JT_LoadCajaChica_Result>) sisaEntitie.JT_LoadCajaChica()).Where<JT_LoadCajaChica_Result>((Func<JT_LoadCajaChica_Result, bool>) (s =>
            {
              int? estatus7 = s.Estatus;
              int num7 = 0;
              if (estatus7.GetValueOrDefault() == num7 & estatus7.HasValue)
                return true;
              int? estatus8 = s.Estatus;
              int num8 = 1;
              return estatus8.GetValueOrDefault() == num8 & estatus8.HasValue;
            })));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblCajaChica>) sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>) (s => s.IdCajaChica.ToString() == pid)));
        }
      }
      else
        str = "No tienes permiso,";
      return str;
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
    public static string EliminarCC(string pid)
    {
      string str = string.Empty;
      CajaChica.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CajaChica.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (CajaChica.rolesUsuarios.CajaChicaEliminar || CajaChica.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblCajaChica tblCajaChica = ((IQueryable<tblCajaChica>) sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>) (s => s.IdCajaChica.ToString() == pid));
          if (tblCajaChica != null)
          {
            sisaEntitie.tblCajaChica.Remove(tblCajaChica);
            if (sisaEntitie.SaveChanges() > 0)
            {
              tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == pid));
              if (eficienciasDesglose != null)
              {
                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                sisaEntitie.SaveChanges();
              }
              str = "Informacion eliminada.";
            }
            else
              str = "Ocurrio un problema al eliminar información.";
          }
          else
            str = "Ocurrio un problema al obtener información seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar información.";
      return str;
    }

    [WebMethod]
    public static string GuardarCC(
      string Responsable,
      string Concepto,
      string pidproyecto,
      string Proyecto,
      string Comprobante,
      string Cargo,
      string Abono,
      string Fecha,
      string Estatus,
      string Tipo,
      string pid,
      string Categoria,
      string CampoExtra)
    {
      string str = string.Empty;
      CajaChica.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CajaChica.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Tipo == "1")
      {
        if (CajaChica.rolesUsuarios.CajaChicaAgregar || CajaChica.rolesUsuarios.Tipo == "ROOT")
        {
          if (pidproyecto == "1")
            pidproyecto = "";
          else
            Guid.Parse(pidproyecto);
          int int32 = Convert.ToInt32(Estatus);
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            tblCajaChica add = new tblCajaChica()
            {
              IdCajaChica = Guid.NewGuid(),
              FechaAlta = DateTime.Now,
              Responsable = Responsable,
              Concepto = Concepto,
              Proyecto = Proyecto,
              Comprobante = Comprobante,
              Cargo = Decimal.Parse(Cargo),
              Abono = Decimal.Parse(Abono),
              Fecha = DateTime.Parse(Fecha),
              Estatus = new int?(int32),
              IdProyecto = pidproyecto,
              Categoria = Categoria,
              CampoExtra = CampoExtra
            };
            sisaEntitie.tblCajaChica.Add(add);
            sisaEntitie.SaveChanges();
            Decimal num = Cargo == "0" ? Decimal.Parse(Abono) : Decimal.Parse(Cargo);
            if (!(Categoria == "N/A"))
            {
              tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (e => e.idDocumento == add.IdCajaChica.ToString()));
              if (eficienciasDesglose1 != null)
              {
                eficienciasDesglose1.idProyecto = pidproyecto;
                eficienciasDesglose1.idDocumento = add.IdCajaChica.ToString();
                eficienciasDesglose1.Categoria = Categoria.ToUpper();
                eficienciasDesglose1.Total = new Decimal?(num);
                eficienciasDesglose1.TipoDoc = "CC";
                sisaEntitie.SaveChanges();
              }
              else
              {
                tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
                {
                  idProyecto = pidproyecto,
                  idDocumento = add.IdCajaChica.ToString(),
                  Categoria = Categoria.ToUpper(),
                  Total = new Decimal?(num),
                  TipoDoc = "CC",
                  Folio = "",
                  FechaDoc = new DateTime?(add.FechaAlta),
                  idUsuarioUltimo = CajaChica.usuario.IdUsuario.ToString()
                };
                sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose2);
                sisaEntitie.SaveChanges();
              }
            }
            str = "Informacion actualizada.";
          }
        }
        else
          str = "No tienes permiso de agregar información.";
      }
      else if (Tipo == "2")
      {
        if (CajaChica.rolesUsuarios.CajaChicaEditar)
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            tblCajaChica Existe = ((IQueryable<tblCajaChica>) sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>) (a => a.IdCajaChica.ToString() == pid));
            if (Existe != null)
            {
              int int32 = Convert.ToInt32(Estatus);
              Existe.Responsable = Responsable;
              Existe.Concepto = Concepto;
              Existe.Cargo = Decimal.Parse(Cargo);
              Existe.Abono = Decimal.Parse(Abono);
              Existe.Estatus = new int?(int32);
              Existe.Categoria = Categoria;
              Existe.CampoExtra = CampoExtra;
              Existe.Comprobante = Comprobante;
              Decimal num = Cargo == "0.00" ? Decimal.Parse(Abono) : Decimal.Parse(Cargo);
              Existe.IdProyecto = pidproyecto;
              Existe.Proyecto = Proyecto;
              sisaEntitie.SaveChanges();
              if (!(Categoria == "N/A"))
              {
                tblEficienciasDesglose eficienciasDesglose3 = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (e => e.idDocumento == Existe.IdCajaChica.ToString()));
                if (eficienciasDesglose3 != null)
                {
                  eficienciasDesglose3.idProyecto = pidproyecto;
                  eficienciasDesglose3.idDocumento = Existe.IdCajaChica.ToString();
                  eficienciasDesglose3.Categoria = Categoria.ToUpper();
                  eficienciasDesglose3.Total = new Decimal?(num);
                  eficienciasDesglose3.TipoDoc = "CC";
                  sisaEntitie.SaveChanges();
                }
                else
                {
                  tblEficienciasDesglose eficienciasDesglose4 = new tblEficienciasDesglose()
                  {
                    idProyecto = pidproyecto,
                    idDocumento = Existe.IdCajaChica.ToString(),
                    Categoria = Categoria.ToUpper(),
                    Total = new Decimal?(num),
                    TipoDoc = "CC",
                    Folio = "",
                    FechaDoc = new DateTime?(Existe.FechaAlta),
                    idUsuarioUltimo = CajaChica.usuario.IdUsuario.ToString()
                  };
                  sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose4);
                  sisaEntitie.SaveChanges();
                }
              }
              str = "Informacion actualizada.";
            }
            else
              str = "No se pudo obtener información, recarga página e intenta de nuevo.";
          }
        }
        else
          str = "No tienes permiso de editar información.";
      }
      return str;
    }
  }
}
