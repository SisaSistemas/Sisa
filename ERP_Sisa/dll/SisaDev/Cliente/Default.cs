// Decompiled with JetBrains decompiler
// Type: SisaDev.Cliente.Default
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

namespace SisaDev.Cliente
{
  public class Default : Page
  {
    protected TextBox UserName;
    protected TextBox Password;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;
    protected Button btnLoginCliente;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLoginCliente_Click(object sender, EventArgs e)
    {
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (u => u.Usuario == this.UserName.Text && u.Clave == this.Password.Text.Trim()));
          if (tblClienteContacto != null)
          {
            if (!tblClienteContacto.Estatus)
            {
              this.FailureText.Text = "Usuario inactivo, contácta administrador.";
              this.ErrorMessage.Visible = true;
            }
            else
            {
              HttpContext.Current.Session["UsuarioClienteLogueado"] = (object) tblClienteContacto;
              this.Response.Redirect("ProyectosClientes.aspx", false);
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
