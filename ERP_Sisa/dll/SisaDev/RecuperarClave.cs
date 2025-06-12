// Decompiled with JetBrains decompiler
// Type: SisaDev.RecuperarClave
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
  public class RecuperarClave : Page
  {
    protected TextBox txtUsuario;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;
    protected PlaceHolder CorrectMessage;
    protected Literal CorrectText;
    protected Button btnEnviar;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (u => u.Usuario == this.txtUsuario.Text.Trim()));
        if (tblUsuarios != null)
        {
          string pCodigo = Proceso.GeneraCodigoRecuperacion();
          tblRecuperaciones tblRecuperaciones = new tblRecuperaciones()
          {
            fecha = DateTime.Now,
            Usuario = this.txtUsuario.Text.Trim(),
            Estatus = true,
            Codigo = pCodigo,
            idUsuario = tblUsuarios.IdUsuario,
            Correo = tblUsuarios.Correo
          };
          sisaEntitie.tblRecuperaciones.Add(tblRecuperaciones);
          sisaEntitie.SaveChanges();
          if (Proceso.EnviarCorreo(tblUsuarios.Correo, pCodigo))
          {
            this.CorrectText.Text = "Código enviado.";
            this.CorrectMessage.Visible = true;
          }
          else
          {
            this.FailureText.Text = "Problema al enviar correo, intenta de nuevo.";
            this.ErrorMessage.Visible = true;
          }
        }
        else
        {
          this.FailureText.Text = "Usuario inexistente.";
          this.ErrorMessage.Visible = true;
        }
      }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string GuardarClaveNueva(string pCodigo, string pClaveNueva)
    {
      string str = "Se ha actualizado información.";
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        tblRecuperaciones BuscaID = ((IQueryable<tblRecuperaciones>) sisaEntitie.tblRecuperaciones).FirstOrDefault<tblRecuperaciones>((Expression<Func<tblRecuperaciones, bool>>) (r => r.Codigo == pCodigo.Trim() && r.Estatus == true));
        if (BuscaID != null)
        {
          ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (r => r.IdUsuario == BuscaID.idUsuario)).Contrasena = pClaveNueva.Trim();
          BuscaID.Estatus = false;
          sisaEntitie.SaveChanges();
        }
        else
          str = "Código inexistente o ya caduco.";
      }
      return str;
    }
  }
}
