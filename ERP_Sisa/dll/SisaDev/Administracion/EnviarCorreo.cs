// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.EnviarCorreo
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Administracion
{
  public class EnviarCorreo : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static tblReqEnc ReqEditable;
    public static List<tblReqDet> ReqEditableDetalles;
    public static string id = string.Empty;
    public static string Tipo = string.Empty;
    private string OCcode = string.Empty;
    protected HtmlGenericControl TipoEnviar;
    protected HtmlGenericControl idEnviar;
    protected HtmlInputText txtPara;
    protected HtmlInputText txtConCopia;
    protected HtmlInputText txtSubject;
    protected FileUpload files;
    protected HtmlTextArea editor1;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;
    protected PlaceHolder SuccesMessage;
    protected Literal SuccessText;
    protected Button btnEnviar;
    protected HtmlInputHidden txtCorreo;

    protected void Page_Load(object sender, EventArgs e)
    {
      EnviarCorreo.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (EnviarCorreo.usuario != null)
      {
        EnviarCorreo.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        EnviarCorreo.id = this.Request.QueryString["id"];
        EnviarCorreo.Tipo = this.Request.QueryString["Tipo"];
        this.idEnviar.InnerText = EnviarCorreo.id;
        this.TipoEnviar.InnerText = EnviarCorreo.Tipo;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerOC(string pid)
    {
      string str = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid.Parse(EnviarCorreo.id);
        if (EnviarCorreo.Tipo == "1")
        {
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).Join((IEnumerable<tblProveedores>) sisaEntitie.tblProveedores, (Expression<Func<tblOrdenCompra, Guid>>) (r => r.IdProveedor), (Expression<Func<tblProveedores, Guid>>) (p => p.IdProveedor), (r, p) => new
          {
            r = r,
            p = p
          }).Where(data => data.r.IdOrdenCompra.ToString() == pid).Select(data => new
          {
            ID = data.r.IdOrdenCompra,
            FOLIO = data.r.Folio,
            DIRIGIDO = data.p.Proveedor,
            CORREO = data.p.Email,
            ENVIADOR = EnviarCorreo.usuario.Correo
          }));
          if (str == "[]")
          {
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblOrdenCompraInsumos>) sisaEntitie.tblOrdenCompraInsumos).Join((IEnumerable<tblProveedores>) sisaEntitie.tblProveedores, (Expression<Func<tblOrdenCompraInsumos, Guid>>) (r => r.IdProveedor), (Expression<Func<tblProveedores, Guid>>) (p => p.IdProveedor), (r, p) => new
            {
              r = r,
              p = p
            }).Where(data => data.r.IdOrdenCompra.ToString() == pid).Select(data => new
            {
              ID = data.r.IdOrdenCompra,
              FOLIO = data.r.Folio,
              DIRIGIDO = data.p.Proveedor,
              CORREO = data.p.Email,
              ENVIADOR = EnviarCorreo.usuario.Correo
            }));
            if (str == "[]")
              str = "Error, no se encontro información de correo.";
          }
        }
        else if (EnviarCorreo.Tipo == "2")
        {
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblCotizaciones, Guid>>) (r => r.idContacto), (Expression<Func<tblClienteContacto, Guid>>) (p => p.idContacto), (r, p) => new
          {
            r = r,
            p = p
          }).Where(data => data.r.IdCotizaciones.ToString() == pid).Select(data => new
          {
            ID = data.r.IdCotizaciones,
            FOLIO = data.r.NoCotizaciones,
            DIRIGIDO = data.p.NombreContacto,
            CORREO = data.p.Correo,
            ENVIADOR = EnviarCorreo.usuario.Correo
          }));
          if (str == "[]")
            str = "Error, no se encontro información de correo.";
        }
      }
      return str;
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
      string to = this.txtPara.Value;
      string from = this.txtCorreo.Value;
      string asunto = this.txtSubject.Value;
      string cc = this.txtConCopia.Value;
      string innerText = this.editor1.InnerText;
      string attch = string.Empty;
      string empty = string.Empty;
      string appSetting = ConfigurationManager.AppSettings["PathFiles"];
      if (this.files.PostedFile.FileName != "")
      {
        string fileName = Path.GetFileName(this.files.PostedFile.FileName);
        this.files.PostedFile.SaveAs(appSetting + fileName);
        attch = appSetting + fileName;
      }
      if (EnviarCorreo.Tipo == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (o => o.IdCotizaciones.ToString() == EnviarCorreo.id));
          if (tblCotizaciones != null)
          {
            if (!string.IsNullOrEmpty(tblCotizaciones.DocumentoPdf))
            {
              if (!string.IsNullOrEmpty(tblCotizaciones.NombreArchivoPdf))
              {
                string[] strArray = tblCotizaciones.DocumentoPdf.Split(',');
                using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + tblCotizaciones.NombreArchivoPdf, FileMode.Create, FileAccess.Write))
                  fileStream.Write(Convert.FromBase64String(strArray[1]), 0, Convert.FromBase64String(strArray[1]).Length);
                attch = AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + tblCotizaciones.NombreArchivoPdf;
              }
            }
          }
        }
      }
      if (Proceso.EnviarCorreoDocs(to, innerText, from, asunto, attch, cc))
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Guid i = Guid.Parse(EnviarCorreo.id);
          if (EnviarCorreo.Tipo == "1")
          {
            tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (o => o.IdOrdenCompra == i));
            if (tblOrdenCompra != null)
            {
              tblOrdenCompra.Enviada = 1;
              sisaEntitie.SaveChanges();
            }
          }
          else if (EnviarCorreo.Tipo == "2")
          {
            tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (o => o.IdCotizaciones == i));
            if (tblCotizaciones != null)
            {
              tblCotizaciones.Estatus = 4;
              tblCotizaciones.IdUsuarioEnvia = new Guid?(EnviarCorreo.usuario.IdUsuario);
              sisaEntitie.SaveChanges();
            }
          }
        }
        this.SuccessText.Text = "Correo enviado.";
        this.SuccesMessage.Visible = true;
      }
      else
      {
        this.FailureText.Text = "Ocurrio un error al enviar correo.";
        this.ErrorMessage.Visible = true;
      }
    }
  }
}
