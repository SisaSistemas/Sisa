// Decompiled with JetBrains decompiler
// Type: SisaDev.Clientes.ClientesContacto
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

namespace SisaDev.Clientes
{
  public class ClientesContacto : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ClientesContacto.usuario != null)
        ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string GuardarImagenContacto(string idContacto, string FileName, string File)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (a => a.idContacto.ToString() == idContacto));
          tblClienteContacto.Imagen = File;
          tblClienteContacto.NombreImagen = FileName;
          sisaEntitie.SaveChanges();
          return "Archivo guardado";
        }
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    [WebMethod]
    public static string ObtenerContactos(string pid)
    {
      string str = string.Empty;
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ClientesContacto.rolesUsuarios.ClienteContacto || ClientesContacto.rolesUsuarios.Tipo == "GERENCIAL" || ClientesContacto.rolesUsuarios.Tipo == "ROOT" || ClientesContacto.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        if (pid.Trim() == "1")
        {
          if (ClientesContacto.rolesUsuarios.Tipo == "GERENCIAL" || ClientesContacto.rolesUsuarios.Tipo == "ROOT" || ClientesContacto.rolesUsuarios.Tipo == "ADMINISTRACION")
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, (Expression<Func<tblClienteContacto, Guid>>) (cl => cl.idEmpresa), (Expression<Func<tblEmpresas, Guid>>) (em => em.idEmpresa), (cl, em) => new
              {
                idContacto = cl.idContacto,
                NombreContacto = cl.NombreContacto,
                Telefono = cl.Telefono,
                Correo = cl.Correo,
                Cliente = em.Cliente,
                idEmpresa = em.idEmpresa,
                Usuario = cl.Usuario,
                Clave = cl.Clave,
                Estatus = cl.Estatus
              }).OrderBy(a => a.NombreContacto));
          }
          else
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, (Expression<Func<tblClienteContacto, Guid>>) (cl => cl.idEmpresa), (Expression<Func<tblEmpresas, Guid>>) (em => em.idEmpresa), (cl, em) => new
              {
                cl = cl,
                em = em
              }).Where(data => data.em.idSucursalRegistro == ClientesContacto.usuario.idSucursal).Select(data => new
              {
                idContacto = data.cl.idContacto,
                NombreContacto = data.cl.NombreContacto,
                Telefono = data.cl.Telefono,
                Correo = data.cl.Correo,
                Cliente = data.em.Cliente,
                idEmpresa = data.em.idEmpresa,
                Usuario = data.cl.Usuario,
                Clave = data.cl.Clave,
                Estatus = data.cl.Estatus
              }).OrderBy(a => a.NombreContacto));
          }
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, (Expression<Func<tblClienteContacto, Guid>>) (cl => cl.idEmpresa), (Expression<Func<tblEmpresas, Guid>>) (em => em.idEmpresa), (cl, em) => new
            {
              cl = cl,
              em = em
            }).Where(data => data.cl.idContacto.ToString() == pid).Select(data => new
            {
              idContacto = data.cl.idContacto,
              NombreContacto = data.cl.NombreContacto,
              Telefono = data.cl.Telefono,
              Correo = data.cl.Correo,
              RazonSocial = data.em.RazonSocial,
              idEmpresa = data.em.idEmpresa,
              Usuario = data.cl.Usuario,
              Clave = data.cl.Clave,
              Estatus = data.cl.Estatus
            }));
        }
      }
      else
        str = "No tienes permiso de ver los contactos de clientes";
      return str;
    }

    [WebMethod]
    public static string GuardarContacto(
      string pNombre,
      string pTelefono,
      string pCorreo,
      string pEmpresa,
      string pUsuario,
      string pClave)
    {
      string str = string.Empty;
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ClientesContacto.rolesUsuarios.ClienteContactoAgrear || ClientesContacto.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = new tblClienteContacto()
          {
            idContacto = Guid.NewGuid(),
            NombreContacto = pNombre,
            Telefono = pTelefono,
            Correo = pCorreo,
            TIMESTAMP = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Estatus = true,
            Usuario = pUsuario,
            Clave = pClave,
            idEmpresa = Guid.Parse(pEmpresa)
          };
          sisaEntitie.tblClienteContacto.Add(tblClienteContacto);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar contacto." : "Contacto creado.";
        }
      }
      else
        str = "No tienes permiso de agregar contactos.";
      return str;
    }

    [WebMethod]
    public static string EliminarContacto(string pidContacto)
    {
      string str = string.Empty;
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ClientesContacto.rolesUsuarios.ClienteContactoEliminar || ClientesContacto.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (s => s.idContacto.ToString() == pidContacto));
          if (tblClienteContacto != null)
          {
            tblClienteContacto.Estatus = false;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar Contacto, ya esta inactivo." : "Contacto eliminado.";
          }
          else
            str = "Ocurrio un problema al obtener información de Contacto seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar Contacto.";
      return str;
    }

    [WebMethod]
    public static string ActivarContacto(string pidContacto)
    {
      string str = string.Empty;
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ClientesContacto.rolesUsuarios.ClienteContactoEditar || ClientesContacto.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (s => s.idContacto.ToString() == pidContacto));
          if (tblClienteContacto != null)
          {
            tblClienteContacto.Estatus = true;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al activar Contacto, ya esta activo." : "Contacto activada.";
          }
          else
            str = "Ocurrio un problema al obtener información de Contacto seleccionada.";
        }
      }
      else
        str = "No tienes permiso de activar Contacto.";
      return str;
    }

    [WebMethod]
    public static string EditarContacto(
      string pid,
      string pNombre,
      string pTelefono,
      string pCorreo,
      string pUsuario,
      string pClave,
      string idEmpresa)
    {
      string str = string.Empty;
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ClientesContacto.rolesUsuarios.ClienteContactoEditar || ClientesContacto.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (s => s.idContacto.ToString() == pid.Trim()));
          if (tblClienteContacto != null)
          {
            Guid guid = Guid.Parse(idEmpresa);
            tblClienteContacto.NombreContacto = pNombre;
            tblClienteContacto.Telefono = pTelefono;
            tblClienteContacto.Correo = pCorreo;
            tblClienteContacto.Usuario = pUsuario;
            tblClienteContacto.Clave = pClave;
            tblClienteContacto.idEmpresa = guid;
            str = sisaEntitie.SaveChanges() <= 0 ? "No se realizaron cambios." : "Contacto actualizada.";
          }
          else
            str = "No se obtuvo información de Contacto seleccionado.";
        }
      }
      else
        str = "NO tienes permiso de edición de Contacto.";
      return str;
    }

    [WebMethod]
    public static string ObtenerEmpresas(string pid)
    {
      string empty = string.Empty;
      ClientesContacto.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ClientesContacto.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        if (ClientesContacto.rolesUsuarios.Tipo == "ROOT" || ClientesContacto.rolesUsuarios.Tipo == "ADMINISTRACION" || ClientesContacto.rolesUsuarios.Tipo == "GERENCIAL" || ClientesContacto.rolesUsuarios.Tipo == "COMPRAS")
          return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true)));
        return JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Where<tblEmpresas>((Expression<Func<tblEmpresas, bool>>) (s => s.Estatus == (bool?) true && s.idSucursalRegistro == ClientesContacto.usuario.idSucursal)));
      }
    }
  }
}
