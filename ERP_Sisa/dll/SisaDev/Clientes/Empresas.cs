// Decompiled with JetBrains decompiler
// Type: SisaDev.Clientes.Empresas
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Clientes
{
  public class Empresas : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Empresas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Empresas.usuario != null)
        Empresas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerEmpresas(string pid)
    {
      string str = string.Empty;
      Empresas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Empresas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (Empresas.rolesUsuarios.Tipo == "ROOT" || Empresas.rolesUsuarios.Tipo == "ADMINISTRACION" || Empresas.rolesUsuarios.Tipo == "GERENCIAL" || Empresas.rolesUsuarios.Tipo == "COMPRAS")
            return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true)));
          return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true && s.idSucursalRegistro == Empresas.usuario.idSucursal)));
        }
      }
      else
      {
        if (Empresas.rolesUsuarios.ClienteEmpresa || Empresas.rolesUsuarios.Tipo == "ROOT" || Empresas.rolesUsuarios.Tipo == "ADMINISTRACION" || Empresas.rolesUsuarios.Tipo == "GERENCIAL" || Empresas.rolesUsuarios.Tipo == "COMPRAS")
        {
          if (pid.Trim() == "1")
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
              if (Empresas.rolesUsuarios.Tipo == "ROOT" || Empresas.rolesUsuarios.Tipo == "ADMINISTRACION" || Empresas.rolesUsuarios.Tipo == "GERENCIAL" || Empresas.rolesUsuarios.Tipo == "COMPRAS")
                return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true)));
              return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true && s.idSucursalRegistro == Empresas.usuario.idSucursal)));
            }
          }
          else
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).FirstOrDefault<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.idEmpresa.ToString() == pid)));
          }
        }
        else
          str = "No tienes permiso.";
        return str;
      }
    }

    [WebMethod]
    public static string GuardarEmpresa(
      string pRZ,
      string pDireccion,
      string pTelefono,
      string pRFC,
      string pCorreo,
      string pCP,
      string pCiudad,
      string pCliente)
    {
      string str = string.Empty;
      Empresas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Empresas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Empresas.rolesUsuarios.ClienteEmpresaAgregar || Empresas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblEmpresas tblEmpresas = new tblEmpresas()
          {
            idEmpresa = Guid.NewGuid(),
            RazonSocial = pRZ,
            DireccionFiscal = pDireccion,
            Telefono = pTelefono,
            TIMESTAMP = DateTime.Now,
            RFC = pRFC,
            Correo = pCorreo,
            CP = Convert.ToInt32(pCP),
            Ciudad = pCiudad,
            Estatus = new bool?(true),
            idSucursalRegistro = Empresas.usuario.idSucursal,
            Cliente = pCliente
          };
          sisaEntitie.tblEmpresas.Add(tblEmpresas);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar empresa." : "Empresa creada.";
        }
      }
      else
        str = "No tienes permiso de agregar empresas.";
      return str;
    }

    [WebMethod]
    public static string EliminarEmpresa(string pidEmpresa)
    {
      string str = string.Empty;
      Empresas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Empresas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Empresas.rolesUsuarios.ClienteEmpresaEliminar || Empresas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblEmpresas tblEmpresas = ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).FirstOrDefault<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.idEmpresa.ToString() == pidEmpresa));
          if (tblEmpresas != null)
          {
            tblEmpresas.Estatus = new bool?(false);
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar empresa, ya esta inactiva." : "Empresa eliminada.";
          }
          else
            str = "Ocurrio un problema al obtener información de empresa seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar empresas.";
      return str;
    }

    [WebMethod]
    public static string EditarEmpresa(
      string pid,
      string pRZ,
      string pDireccion,
      string pTelefono,
      string pRFC,
      string pCorreo,
      string pCP,
      string pCiudad,
      string pCliente)
    {
      string str = string.Empty;
      Empresas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Empresas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Empresas.rolesUsuarios.ClienteEmpresaEditar || Empresas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblEmpresas tblEmpresas = ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).FirstOrDefault<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.idEmpresa.ToString() == pid.Trim()));
          if (tblEmpresas != null)
          {
            tblEmpresas.RazonSocial = pRZ;
            tblEmpresas.DireccionFiscal = pDireccion;
            tblEmpresas.Telefono = pTelefono;
            tblEmpresas.RFC = pRFC;
            tblEmpresas.Correo = pCorreo;
            tblEmpresas.CP = Convert.ToInt32(pCP);
            tblEmpresas.Ciudad = pCiudad;
            tblEmpresas.Cliente = pCliente;
            str = sisaEntitie.SaveChanges() <= 0 ? "No se realizaron cambios." : "Emrpesa actualizada.";
          }
          else
            str = "No se obtuvo información de empresa seleccionada.";
        }
      }
      else
        str = "NO tienes permiso de edición de empresas.";
      return str;
    }

    [WebMethod]
    public static string ActivarEmpresa(string pidEmpresa)
    {
      string str = string.Empty;
      Empresas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Empresas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Empresas.rolesUsuarios.ClienteEmpresaEditar || Empresas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblEmpresas tblEmpresas = ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).FirstOrDefault<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.idEmpresa.ToString() == pidEmpresa));
          if (tblEmpresas != null)
          {
            tblEmpresas.Estatus = new bool?(true);
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al activar empresa, ya esta activa." : "Empresa activada.";
          }
          else
            str = "Ocurrio un problema al obtener información de empresa seleccionada.";
        }
      }
      else
        str = "No tienes permiso de editar empresas.";
      return str;
    }
  }
}
