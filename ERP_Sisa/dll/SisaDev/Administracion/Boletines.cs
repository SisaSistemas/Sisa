// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.Boletines
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Administracion
{
  public class Boletines : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Boletines.usuario != null)
        Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerBoletin(string pid)
    {
      string str = string.Empty;
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Boletines.rolesUsuarios.Tipo == "ROOT" || Boletines.rolesUsuarios.Tipo == "GERENCIAL" || Boletines.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).Select<tblBoletin, tblBoletin>((Expression<Func<tblBoletin, tblBoletin>>) (s => s)));
      }
      else
        str = "No tienes permiso,";
      return str;
    }

    [WebMethod]
    public static string CargarDocumentos(string idBoletin, string Opcion)
    {
      string empty = string.Empty;
      if (Opcion == "PDF")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            return JsonConvert.SerializeObject((object) ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).Where<tblBoletin>((Expression<Func<tblBoletin, bool>>) (a => a.idBoletin.ToString() == idBoletin)).Select(a => new
            {
              idBoletin = a.idBoletin,
              PDF = a.PDF
            }));
        }
        catch (Exception ex)
        {
          return ex.ToString();
        }
      }
      else
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            return JsonConvert.SerializeObject((object) ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).Where<tblBoletin>((Expression<Func<tblBoletin, bool>>) (a => a.idBoletin.ToString() == idBoletin)).Select(a => new
            {
              idBoletin = a.idBoletin,
              Imagen = a.Imagen
            }));
        }
        catch (Exception ex)
        {
          return ex.ToString();
        }
      }
    }

    [WebMethod]
    public static string GuardarDocumentos(
      string TipoDoc,
      string idBoletin,
      string FileName,
      string File)
    {
      string str = string.Empty;
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Boletines.rolesUsuarios.Tipo == "ROOT" || Boletines.rolesUsuarios.Tipo == "GERENCIAL" || Boletines.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            int id = int.Parse(idBoletin);
            tblBoletin tblBoletin = ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).FirstOrDefault<tblBoletin>((Expression<Func<tblBoletin, bool>>) (p => p.idBoletin == id));
            if (tblBoletin != null)
            {
              if (TipoDoc.Trim() == "IMAGEN")
              {
                tblBoletin.Imagen = File;
                tblBoletin.NombreImagen = FileName;
              }
              else if (TipoDoc.Trim() == "PDF")
              {
                tblBoletin.PDF = File;
                tblBoletin.NombrePDF = FileName;
                if (!string.IsNullOrEmpty(File) && !string.IsNullOrEmpty(FileName))
                {
                  string[] strArray = File.Split(',');
                  using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "docsboletines\\" + FileName, FileMode.Create, FileAccess.Write))
                    fileStream.Write(Convert.FromBase64String(strArray[1]), 0, Convert.FromBase64String(strArray[1]).Length);
                }
              }
              sisaEntitie.SaveChanges();
              str = "Archivo guardado";
            }
            else
              str = "Ocurrio un error al obtener información de proyecto, recarga la página e intenta de nuevo.";
          }
        }
        catch (Exception ex)
        {
          str = ex.ToString();
        }
      }
      else
        str = "No tienes permiso de edición.";
      return str;
    }

    [WebMethod]
    public static string NuevoBoletin(string texto)
    {
      string str = string.Empty;
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Boletines.rolesUsuarios.Tipo == "ROOT" || Boletines.rolesUsuarios.Tipo == "GERENCIAL" || Boletines.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            tblBoletin tblBoletin = new tblBoletin()
            {
              Texto = texto,
              Usuario = Boletines.usuario.NombreCompleto,
              Fecha = new DateTime?(DateTime.Now),
              Imagen = "",
              NombreImagen = "",
              PDF = "",
              NombrePDF = ""
            };
            sisaEntitie.tblBoletin.Add(tblBoletin);
            sisaEntitie.SaveChanges();
            str = "Boletin creado, favor de agregar archivos.";
          }
        }
        catch (Exception ex)
        {
          str = ex.ToString();
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string EliminarBoletin(string pid)
    {
      string str = string.Empty;
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Boletines.rolesUsuarios.Tipo == "ROOT" || Boletines.rolesUsuarios.Tipo == "GERENCIAL" || Boletines.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblBoletin tblBoletin = ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).FirstOrDefault<tblBoletin>((Expression<Func<tblBoletin, bool>>) (s => s.idBoletin.ToString() == pid));
          if (tblBoletin != null)
          {
            sisaEntitie.tblBoletin.Remove(tblBoletin);
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar información." : "Informacion eliminada.";
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
    public static string EliminarImagenBoletin(string idBoletin)
    {
      string str = string.Empty;
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Boletines.rolesUsuarios.Tipo == "ROOT" || Boletines.rolesUsuarios.Tipo == "GERENCIAL" || Boletines.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblBoletin tblBoletin = ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).FirstOrDefault<tblBoletin>((Expression<Func<tblBoletin, bool>>) (s => s.idBoletin.ToString() == idBoletin));
          if (tblBoletin != null)
          {
            tblBoletin.NombreImagen = "";
            tblBoletin.Imagen = "";
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar información." : "Informacion eliminada.";
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
    public static string EliminarDocumentoBoletin(string idBoletin)
    {
      string str = string.Empty;
      Boletines.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Boletines.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Boletines.rolesUsuarios.Tipo == "ROOT" || Boletines.rolesUsuarios.Tipo == "GERENCIAL" || Boletines.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblBoletin tblBoletin = ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).FirstOrDefault<tblBoletin>((Expression<Func<tblBoletin, bool>>) (s => s.idBoletin.ToString() == idBoletin));
          if (tblBoletin != null)
          {
            tblBoletin.NombrePDF = "";
            tblBoletin.PDF = "";
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar información." : "Informacion eliminada.";
          }
          else
            str = "Ocurrio un problema al obtener información seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar información.";
      return str;
    }
  }
}
