// Decompiled with JetBrains decompiler
// Type: SisaDev.Ventas.CotizacionesDetalles
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
  public class CotizacionesDetalles : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idCotizaciones = string.Empty;
    private static Guid idCotizacionNueva;
    protected HiddenField idUsuarioLog;
    protected HtmlInputHidden idCotiza;

    protected void Page_Load(object sender, EventArgs e)
    {
      CotizacionesDetalles.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (CotizacionesDetalles.usuario != null)
      {
        CotizacionesDetalles.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        CotizacionesDetalles.idCotizaciones = this.Request.QueryString["idCotizacion"];
        this.idCotiza.Value = CotizacionesDetalles.idCotizaciones;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string BuscarContactos(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(pid);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).Where<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (d => d.idEmpresa == id && d.Estatus == true)));
      }
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
    public static string CrearCotizacion(
      string idContacto,
      string idEmpresa,
      string RFQ,
      string txtDescripcionCotizaCompleta,
      string CostoCotizacion,
      string MO,
      string CM,
      string CE,
      string CreadoPor)
    {
      string str = string.Empty;
      CotizacionesDetalles.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CotizacionesDetalles.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (CotizacionesDetalles.rolesUsuarios.CotizacionesAgregar || CotizacionesDetalles.rolesUsuarios.Tipo == "ROOT")
          {
            if (!string.IsNullOrEmpty(RFQ))
            {
              ObjectParameter folio = new ObjectParameter("Folio", typeof (string));
              sisaEntitie.sp_ObtieneFolioCotizacion(folio).ToString();
              tblRFQ tblRfq = ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).FirstOrDefault<tblRFQ>((Expression<Func<tblRFQ, bool>>) (r => r.Folio == RFQ));
              if (tblRfq != null)
              {
                tblCotizaciones tblCotizaciones = new tblCotizaciones()
                {
                  IdCotizaciones = Guid.NewGuid(),
                  idContacto = Guid.Parse(idContacto),
                  IdEmpresa = Guid.Parse(idEmpresa),
                  idRequisicion = new Guid?(tblRfq.IdRfq),
                  NoCotizaciones = folio.Value.ToString(),
                  Concepto = txtDescripcionCotizaCompleta,
                  CostoCotizaciones = new Decimal?(Decimal.Parse(CostoCotizacion)),
                  IdUsuarioCreo = new Guid?(Guid.Parse(CreadoPor)),
                  IdUsuarioEnvia = new Guid?(CotizacionesDetalles.usuario.IdUsuario),
                  TIMESTAMP = DateTime.Now,
                  FechaCotizaciones = DateTime.Now,
                  Estatus = 1,
                  CostoMOCotizado = new double?(double.Parse(MO)),
                  CostoMaterialCotizado = new double?(double.Parse(CM)),
                  CostoMECotizado = new double?(double.Parse(CE))
                };
                sisaEntitie.tblCotizaciones.Add(tblCotizaciones);
                sisaEntitie.SaveChanges();
                CotizacionesDetalles.idCotizacionNueva = tblCotizaciones.IdCotizaciones;
                str = "Cotizacion creada." + CotizacionesDetalles.idCotizacionNueva.ToString();
              }
              else
                str = "No se encontro RFQ, verifica el folio.";
            }
            else
            {
              ObjectParameter folio = new ObjectParameter("Folio", typeof (string));
              sisaEntitie.sp_ObtieneFolioCotizacion(folio).ToString();
              tblCotizaciones tblCotizaciones = new tblCotizaciones()
              {
                IdCotizaciones = Guid.NewGuid(),
                idContacto = Guid.Parse(idContacto),
                IdEmpresa = Guid.Parse(idEmpresa),
                idRequisicion = new Guid?(),
                NoCotizaciones = folio.Value.ToString(),
                Concepto = txtDescripcionCotizaCompleta,
                CostoCotizaciones = new Decimal?(Decimal.Parse(CostoCotizacion)),
                IdUsuarioCreo = new Guid?(Guid.Parse(CreadoPor)),
                IdUsuarioEnvia = new Guid?(CotizacionesDetalles.usuario.IdUsuario),
                TIMESTAMP = DateTime.Now,
                FechaCotizaciones = DateTime.Now,
                Estatus = 1,
                CostoMOCotizado = new double?(double.Parse(MO)),
                CostoMaterialCotizado = new double?(double.Parse(CM)),
                CostoMECotizado = new double?(double.Parse(CE))
              };
              sisaEntitie.tblCotizaciones.Add(tblCotizaciones);
              sisaEntitie.SaveChanges();
              CotizacionesDetalles.idCotizacionNueva = tblCotizaciones.IdCotizaciones;
              str = "Cotizacion creada." + CotizacionesDetalles.idCotizacionNueva.ToString();
            }
          }
          else
            str = "No tienes permiso.";
        }
      }
      catch (Exception ex)
      {
        str = ex.Message;
      }
      return str;
    }

    [WebMethod]
    public static string CrearCotizacionItem(
      string item,
      string Descripcion,
      string Cantidad,
      string Unidad,
      string Precio,
      string Importe)
    {
      string str = string.Empty;
      CotizacionesDetalles.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CotizacionesDetalles.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (CotizacionesDetalles.rolesUsuarios.CotizacionesAgregar || CotizacionesDetalles.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblCotizacionesDet tblCotizacionesDet = new tblCotizacionesDet()
          {
            idCotDetalle = Guid.NewGuid(),
            idCotizacion = new Guid?(CotizacionesDetalles.idCotizacionNueva),
            TimeStamp = new DateTime?(DateTime.Now),
            Descripcion = Descripcion,
            Cantidad = new Decimal?(Decimal.Parse(Cantidad)),
            Unidad = Unidad,
            Precio = new Decimal?(Decimal.Parse(Precio)),
            Importe = new Decimal?(Decimal.Parse(Importe)),
            idUsuarioAlta = new Guid?(CotizacionesDetalles.usuario.IdUsuario),
            Estatus = new int?(1)
          };
          sisaEntitie.tblCotizacionesDet.Add(tblCotizacionesDet);
          sisaEntitie.SaveChanges();
          str = "Cotizacion creada.";
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string CargarDatosEncabezado(string idCotiza)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(idCotiza);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).Where<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (d => d.IdCotizaciones == id)));
      }
    }

    [WebMethod]
    public static string CargarDatosDetalle(string IdCotiza)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(IdCotiza);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblCotizacionesDet>) sisaEntitie.tblCotizacionesDet).Where<tblCotizacionesDet>((Expression<Func<tblCotizacionesDet, bool>>) (d => d.idCotizacion == (Guid?) id)));
      }
    }

    [WebMethod]
    public static string CargarNotas(string IdCotiza)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(IdCotiza);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblNotaAclaratoria>) sisaEntitie.tblNotaAclaratoria).Where<tblNotaAclaratoria>((Expression<Func<tblNotaAclaratoria, bool>>) (d => d.IdCotizacion == id)));
      }
    }

    [WebMethod]
    public static string CargarFolioRFQ(string pid)
    {
      string empty = string.Empty;
      if (string.IsNullOrEmpty(pid) || pid == "null")
        return "SIN RFQ";
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(pid);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).Where<tblRFQ>((Expression<Func<tblRFQ, bool>>) (d => d.IdRfq == id)));
      }
    }

    [WebMethod]
    public static string ActualizarCotizacion(
      string idContacto,
      string idEmpresa,
      string RFQ,
      string txtDescripcionCotizaCompleta,
      string CostoCotizacion,
      string idCotiza,
      string MO,
      string CM,
      string CE,
      string CreadoPor)
    {
      string str = string.Empty;
      CotizacionesDetalles.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CotizacionesDetalles.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (CotizacionesDetalles.rolesUsuarios.CotizacionesEditar || CotizacionesDetalles.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (!string.IsNullOrEmpty(RFQ))
          {
            tblRFQ tblRfq = ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).FirstOrDefault<tblRFQ>((Expression<Func<tblRFQ, bool>>) (r => r.Folio == RFQ));
            if (tblRfq != null)
            {
              CotizacionesDetalles.idCotizacionNueva = Guid.Parse(idCotiza);
              tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (c => c.IdCotizaciones == CotizacionesDetalles.idCotizacionNueva));
              if (tblCotizaciones != null)
              {
                tblCotizaciones.idRequisicion = new Guid?(tblRfq.IdRfq);
                tblCotizaciones.Concepto = txtDescripcionCotizaCompleta;
                tblCotizaciones.CostoCotizaciones = new Decimal?(Decimal.Parse(CostoCotizacion));
                tblCotizaciones.CostoMOCotizado = new double?(double.Parse(MO));
                tblCotizaciones.CostoMaterialCotizado = new double?(double.Parse(CM));
                tblCotizaciones.CostoMECotizado = new double?(double.Parse(CE));
                tblCotizaciones.IdUsuarioCreo = new Guid?(Guid.Parse(CreadoPor));
                tblCotizaciones.idContacto = Guid.Parse(idContacto);
                tblCotizaciones.IdEmpresa = Guid.Parse(idEmpresa);
                sisaEntitie.SaveChanges();
                str = "Cotizacion actualizada.";
                IQueryable<tblCotizacionesDet> queryable1 = ((IQueryable<tblCotizacionesDet>) sisaEntitie.tblCotizacionesDet).Where<tblCotizacionesDet>((Expression<Func<tblCotizacionesDet, bool>>) (d => d.idCotizacion == (Guid?) CotizacionesDetalles.idCotizacionNueva));
                if (queryable1 != null)
                {
                  foreach (tblCotizacionesDet tblCotizacionesDet in (IEnumerable<tblCotizacionesDet>) queryable1)
                    sisaEntitie.tblCotizacionesDet.Remove(tblCotizacionesDet);
                  sisaEntitie.SaveChanges();
                }
                IQueryable<tblNotaAclaratoria> queryable2 = ((IQueryable<tblNotaAclaratoria>) sisaEntitie.tblNotaAclaratoria).Where<tblNotaAclaratoria>((Expression<Func<tblNotaAclaratoria, bool>>) (d => d.IdCotizacion == CotizacionesDetalles.idCotizacionNueva));
                if (queryable2 != null)
                {
                  foreach (tblNotaAclaratoria tblNotaAclaratoria in (IEnumerable<tblNotaAclaratoria>) queryable2)
                    sisaEntitie.tblNotaAclaratoria.Remove(tblNotaAclaratoria);
                  sisaEntitie.SaveChanges();
                }
              }
              else
                str = "No se encontro información de cotización, intenta de nuevo refrescando página.";
            }
            else
              str = "No se encontro RFQ, verifica el folio.";
          }
          else
          {
            CotizacionesDetalles.idCotizacionNueva = Guid.Parse(idCotiza);
            tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (c => c.IdCotizaciones == CotizacionesDetalles.idCotizacionNueva));
            if (tblCotizaciones != null)
            {
              tblCotizaciones.Concepto = txtDescripcionCotizaCompleta;
              tblCotizaciones.CostoCotizaciones = new Decimal?(Decimal.Parse(CostoCotizacion));
              tblCotizaciones.CostoMOCotizado = new double?(double.Parse(MO));
              tblCotizaciones.CostoMaterialCotizado = new double?(double.Parse(CM));
              tblCotizaciones.CostoMECotizado = new double?(double.Parse(CE));
              tblCotizaciones.IdUsuarioCreo = new Guid?(Guid.Parse(CreadoPor));
              tblCotizaciones.idContacto = Guid.Parse(idContacto);
              tblCotizaciones.IdEmpresa = Guid.Parse(idEmpresa);
              sisaEntitie.SaveChanges();
              str = "Cotizacion actualizada.";
              IQueryable<tblCotizacionesDet> queryable3 = ((IQueryable<tblCotizacionesDet>) sisaEntitie.tblCotizacionesDet).Where<tblCotizacionesDet>((Expression<Func<tblCotizacionesDet, bool>>) (d => d.idCotizacion == (Guid?) CotizacionesDetalles.idCotizacionNueva));
              if (queryable3 != null)
              {
                foreach (tblCotizacionesDet tblCotizacionesDet in (IEnumerable<tblCotizacionesDet>) queryable3)
                  sisaEntitie.tblCotizacionesDet.Remove(tblCotizacionesDet);
                sisaEntitie.SaveChanges();
              }
              IQueryable<tblNotaAclaratoria> queryable4 = ((IQueryable<tblNotaAclaratoria>) sisaEntitie.tblNotaAclaratoria).Where<tblNotaAclaratoria>((Expression<Func<tblNotaAclaratoria, bool>>) (d => d.IdCotizacion == CotizacionesDetalles.idCotizacionNueva));
              if (queryable4 != null)
              {
                foreach (tblNotaAclaratoria tblNotaAclaratoria in (IEnumerable<tblNotaAclaratoria>) queryable4)
                  sisaEntitie.tblNotaAclaratoria.Remove(tblNotaAclaratoria);
                sisaEntitie.SaveChanges();
              }
            }
            else
              str = "No se encontro información de cotización, intenta de nuevo refrescando página.";
          }
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string ObtenerEmpresas(string pid)
    {
      string empty = string.Empty;
      CotizacionesDetalles.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      CotizacionesDetalles.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        if (CotizacionesDetalles.rolesUsuarios.Tipo == "ROOT" || CotizacionesDetalles.rolesUsuarios.Tipo == "ADMINISTRACION" || CotizacionesDetalles.rolesUsuarios.Tipo == "GERENCIAL" || CotizacionesDetalles.rolesUsuarios.Tipo == "COMPRAS")
          return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true)));
        return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true && s.idSucursalRegistro == CotizacionesDetalles.usuario.idSucursal)));
      }
    }

    [WebMethod]
    public static string CrearNotasAclaratorias(string Nota)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        sisaEntitie.sp_InsertaNotaAclaratoria(CotizacionesDetalles.idCotizacionNueva.ToString(), Nota);
        sisaEntitie.SaveChanges();
        return "Nota creada.";
      }
    }
  }
}
