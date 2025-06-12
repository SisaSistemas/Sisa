// Decompiled with JetBrains decompiler
// Type: SisaDev.Account.Perfil
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Account
{
  public class Perfil : Page
  {
    public static tblUsuarios usuario;
    public static string id;
    protected Image ImgPrv;
    protected FileUpload FlupImage;
    protected HtmlInputText txtNombre;
    protected HtmlInputHidden txtId;
    protected HtmlInputText txtUsuario;
    protected HtmlInputText txtCorreo;
    protected HtmlInputGenericControl txtTelefono;

    protected void Page_Load(object sender, EventArgs e)
    {
      Perfil.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Perfil.usuario != null)
      {
        Perfil.id = Perfil.usuario.IdUsuario.ToString();
        this.txtId.Value = Perfil.usuario.IdUsuario.ToString();
        this.txtNombre.Value = Perfil.usuario.NombreCompleto;
        this.txtTelefono.Value = Perfil.usuario.Telefono;
        this.txtUsuario.Value = Perfil.usuario.Usuario;
        this.txtCorreo.Value = Perfil.usuario.Correo;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GuardarClaveNueva(string pClaveActual, string pClaveNueva)
    {
      string str = "";
      Perfil.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Perfil.usuario.Contrasena.Trim() == pClaveActual.Trim())
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (r => r.IdUsuario.ToString().Trim() == Perfil.id.Trim()));
          if (tblUsuarios != null)
          {
            tblUsuarios.Contrasena = pClaveNueva.Trim();
            if (sisaEntitie.SaveChanges() > 0)
            {
              HttpContext.Current.Session["UsuarioLogueado"] = (object) tblUsuarios;
              str = "Se ha actualizado información.";
            }
            else
              str = "Se perdio comunicación con el servidor.";
          }
          else
            str = "Ocurrio un problema al actualizar información.";
        }
      }
      else
        str = "Clave actual erronéa.";
      return str;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GuardarDatosGenerales(string pFoto, string pTelefono, string pCorreo)
    {
      string str = "";
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (r => r.IdUsuario.ToString().Trim() == Perfil.id.Trim()));
          if (tblUsuarios != null)
          {
            if (pFoto != "")
              tblUsuarios.Foto = pFoto;
            tblUsuarios.Telefono = pTelefono;
            tblUsuarios.Correo = pCorreo;
            if (sisaEntitie.SaveChanges() > 0)
            {
              HttpContext.Current.Session["UsuarioLogueado"] = (object) tblUsuarios;
              Sitio.usuario = tblUsuarios;
              str = "Datos guardados.";
            }
            else
              str = "No se hicieron cambios.";
          }
          else
            str = "Problema al guardar información, recarga la página.";
        }
      }
      catch (Exception ex)
      {
        str = "Problema de comunicación con servidor, intenta de nuevo.";
      }
      return str;
    }
  }
}
