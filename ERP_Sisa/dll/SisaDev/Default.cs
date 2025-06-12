// Decompiled with JetBrains decompiler
// Type: SisaDev.Default
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
  public class Default : Page
  {
    protected TextBox UserName;
    protected TextBox Password;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;
    protected Button btnLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblUsuarios Usuario = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (u => u.Usuario == this.UserName.Text && u.Contrasena == this.Password.Text.Trim()));
          if (Usuario != null)
          {
            int? activo = Usuario.Activo;
            int num = 0;
            if (activo.GetValueOrDefault() == num & activo.HasValue)
            {
              this.FailureText.Text = "Usuario inactivo, contácta administrador.";
              this.ErrorMessage.Visible = true;
            }
            else
            {
              HttpContext.Current.Session["RolesUsuarioLogueado"] = (object) ((IQueryable<tblRolesUsuarios>) sisaEntitie.tblRolesUsuarios).FirstOrDefault<tblRolesUsuarios>((Expression<Func<tblRolesUsuarios, bool>>) (r => r.idUsuarios == Usuario.IdUsuario));
              HttpContext.Current.Session["UsuarioLogueado"] = (object) Usuario;
              HttpContext.Current.Session.Timeout = 360;
              this.Response.Redirect("Inicio.aspx", false);
            }
          }
          else
          {
            this.FailureText.Text = "Usuario o clave incorrectas.";
            this.ErrorMessage.Visible = true;
          }
        }
      }
      catch (Exception ex)
      {
        this.FailureText.Text = "Error al conectar con servidor servidor.\n" + ex.Message + ".\nContácta el administrador de sistema.";
        this.ErrorMessage.Visible = true;
      }
    }
  }
}
