// Decompiled with JetBrains decompiler
// Type: SisaDev.Admin.Inventario
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

namespace SisaDev.Admin
{
  public class Inventario : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Inventario.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Inventario.usuario != null)
        Inventario.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string Cargar(string pid)
    {
      string str = string.Empty;
      Inventario.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Inventario.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Inventario.rolesUsuarios.Tipo == "ROOT" || Inventario.rolesUsuarios.Tipo == "GERENCIAL" || Inventario.rolesUsuarios.Tipo == "ADMINISTRACION" || Inventario.rolesUsuarios.Inventario)
      {
        if (pid == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblInventario>) sisaEntitie.tblInventario).Select<tblInventario, tblInventario>((Expression<Func<tblInventario, tblInventario>>) (s => s)));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblInventario>) sisaEntitie.tblInventario).Where<tblInventario>((Expression<Func<tblInventario, bool>>) (s => s.IdHerramienta.ToString() == pid)));
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string GuardarInventario(
      string Descripcion,
      string Tipo,
      string Observaciones,
      string Contenedor,
      string CantInicial)
    {
      string str = string.Empty;
      Inventario.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Inventario.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Inventario.rolesUsuarios.Tipo == "ROOT" || Inventario.rolesUsuarios.Tipo == "GERENCIAL" || Inventario.rolesUsuarios.Tipo == "ADMINISTRACION" || Inventario.rolesUsuarios.Inventario)
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblInventario tblInventario1 = ((IQueryable<tblInventario>) sisaEntitie.tblInventario).OrderByDescending<tblInventario, int>((Expression<Func<tblInventario, int>>) (u => u.IdHerramienta)).FirstOrDefault<tblInventario>();
          int num = tblInventario1 == null ? 1 : tblInventario1.IdHerramienta + 1;
          tblInventario tblInventario2 = new tblInventario()
          {
            NoCodigo = "SISA-" + num.ToString(),
            Descripcion = Descripcion,
            Tipo = Tipo,
            Observaciones = Observaciones,
            Contenedor = int.Parse(Contenedor),
            Entradas = Decimal.Parse(CantInicial),
            Salidas = 0M,
            TotalAlmacen = Decimal.Parse(CantInicial),
            Estatus = true,
            NoSerie = ""
          };
          sisaEntitie.tblInventario.Add(tblInventario2);
          sisaEntitie.SaveChanges();
          tblInventarioDet tblInventarioDet = new tblInventarioDet()
          {
            idHerramienta = new int?(tblInventario2.IdHerramienta),
            idUsuario = new Guid?(Inventario.usuario.IdUsuario),
            Entrada = new Decimal?(Decimal.Parse(CantInicial)),
            Salida = new Decimal?(0M),
            Fecha = new DateTime?(DateTime.Now)
          };
          sisaEntitie.tblInventarioDet.Add(tblInventarioDet);
          sisaEntitie.SaveChanges();
          str = "Inventario actualizado.";
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string RegistroEntradas(string pid, string Cantidad)
    {
      string str = string.Empty;
      Inventario.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Inventario.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Inventario.rolesUsuarios.Tipo == "ROOT" || Inventario.rolesUsuarios.Tipo == "GERENCIAL" || Inventario.rolesUsuarios.Tipo == "ADMINISTRACION" || Inventario.rolesUsuarios.Inventario)
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblInventario tblInventario = ((IQueryable<tblInventario>) sisaEntitie.tblInventario).FirstOrDefault<tblInventario>((Expression<Func<tblInventario, bool>>) (s => s.IdHerramienta.ToString() == pid));
          if (tblInventario != null)
          {
            tblInventario.Entradas += Decimal.Parse(Cantidad);
            tblInventario.TotalAlmacen = tblInventario.Entradas - tblInventario.Salidas;
            sisaEntitie.SaveChanges();
            tblInventarioDet tblInventarioDet = new tblInventarioDet()
            {
              idHerramienta = new int?(int.Parse(pid)),
              idUsuario = new Guid?(Inventario.usuario.IdUsuario),
              Entrada = new Decimal?(Decimal.Parse(Cantidad)),
              Salida = new Decimal?(0M),
              Fecha = new DateTime?(DateTime.Now)
            };
            sisaEntitie.tblInventarioDet.Add(tblInventarioDet);
            sisaEntitie.SaveChanges();
            str = "Informacion actualizada.";
          }
          else
            str = "Problema al obtener información, intenta de nuevo actualizando página.";
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string RegistroSalidas(string pid, string Cantidad)
    {
      string str = string.Empty;
      Inventario.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Inventario.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Inventario.rolesUsuarios.Tipo == "ROOT" || Inventario.rolesUsuarios.Tipo == "GERENCIAL" || Inventario.rolesUsuarios.Tipo == "ADMINISTRACION" || Inventario.rolesUsuarios.Inventario)
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblInventario tblInventario = ((IQueryable<tblInventario>) sisaEntitie.tblInventario).FirstOrDefault<tblInventario>((Expression<Func<tblInventario, bool>>) (s => s.IdHerramienta.ToString() == pid));
          if (tblInventario != null)
          {
            tblInventario.Salidas += Decimal.Parse(Cantidad);
            tblInventario.TotalAlmacen = tblInventario.Entradas - tblInventario.Salidas;
            sisaEntitie.SaveChanges();
            tblInventarioDet tblInventarioDet = new tblInventarioDet()
            {
              idHerramienta = new int?(int.Parse(pid)),
              idUsuario = new Guid?(Inventario.usuario.IdUsuario),
              Entrada = new Decimal?(0M),
              Salida = new Decimal?(Decimal.Parse(Cantidad)),
              Fecha = new DateTime?(DateTime.Now)
            };
            sisaEntitie.tblInventarioDet.Add(tblInventarioDet);
            sisaEntitie.SaveChanges();
            str = "Informacion actualizada.";
          }
          else
            str = "Problema al obtener información, intenta de nuevo actualizando página.";
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }
  }
}
