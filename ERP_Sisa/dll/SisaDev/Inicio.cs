// Decompiled with JetBrains decompiler
// Type: SisaDev.Inicio
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev
{
  public class Inicio : Page
  {
    private static tblUsuarios usuario;
    private static tblRolesUsuarios rolesUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {
      Inicio.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Inicio.usuario != null)
        Inicio.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("Default.aspx");
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string ObtenerFoto(int a) => Inicio.usuario.Foto;

    [WebMethod]
    public static string ObtenerBoletin(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblBoletin>) sisaEntitie.tblBoletin).Select<tblBoletin, tblBoletin>((Expression<Func<tblBoletin, tblBoletin>>) (s => s)));
    }
  }
}
