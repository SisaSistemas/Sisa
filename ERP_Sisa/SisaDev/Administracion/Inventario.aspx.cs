using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Admin
{
    public partial class Inventario : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string Cargar(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Inventario == true)
            {
                if(pid == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        retorno = JsonConvert.SerializeObject(DataControl.tblInventario.Select(s => s));
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        retorno = JsonConvert.SerializeObject(DataControl.tblInventario.Where(s => s.IdHerramienta.ToString() == pid));
                    }
                }
                
            }
            else
            {
                retorno = "No tienes permiso.";
            }
            
            return retorno;

        }

        [WebMethod]
        public static string GuardarInventario(string Descripcion, string Tipo, string Observaciones, string Contenedor, string CantInicial)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Inventario == true)
            {
                using (var DataControl = new SisaEntitie())
                {
                    int max = 0;
                    var maxstr = DataControl.tblInventario.OrderByDescending(u => u.IdHerramienta).FirstOrDefault();                   
                    if (maxstr != null)
                    {
                        max = maxstr.IdHerramienta + 1;
                    }
                    else
                    {
                        max = 1;
                    }
                    tblInventario add = new tblInventario
                    {
                        NoCodigo = "SISA-" + max.ToString(),
                        Descripcion = Descripcion, 
                        Tipo = Tipo,
                        Observaciones = Observaciones,
                        Contenedor = int.Parse(Contenedor),
                        Entradas = decimal.Parse(CantInicial),
                        Salidas =0,
                        TotalAlmacen = decimal.Parse(CantInicial),
                        Estatus = true,
                        NoSerie = ""
                    };
                    DataControl.tblInventario.Add(add);
                    DataControl.SaveChanges();
                    tblInventarioDet ad = new tblInventarioDet
                    {
                        idHerramienta = add.IdHerramienta,
                        idUsuario = usuario.IdUsuario,
                        Entrada = decimal.Parse(CantInicial),
                        Salida = 0,
                        Fecha = DateTime.Now
                    };
                    DataControl.tblInventarioDet.Add(ad);
                    DataControl.SaveChanges();
                    retorno = "Inventario actualizado.";
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }

            return retorno;

        }


        [WebMethod]
        public static string RegistroEntradas(string pid, string Cantidad)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Inventario == true)
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Existe = DataControl.tblInventario.FirstOrDefault(s => s.IdHerramienta.ToString() == pid);
                    if(Existe != null)
                    {
                        Existe.Entradas = Existe.Entradas + decimal.Parse(Cantidad);
                        Existe.TotalAlmacen = Existe.Entradas - Existe.Salidas;
                        DataControl.SaveChanges();
                        tblInventarioDet ad = new tblInventarioDet
                        {
                            idHerramienta = int.Parse(pid),
                            idUsuario = usuario.IdUsuario,
                            Entrada = decimal.Parse(Cantidad),
                            Salida = 0,
                            Fecha = DateTime.Now
                        };
                        DataControl.tblInventarioDet.Add(ad);
                        DataControl.SaveChanges();
                        retorno = "Informacion actualizada.";
                    }
                    else
                    {
                        retorno = "Problema al obtener información, intenta de nuevo actualizando página.";
                    }
                    
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }

            return retorno;

        }

        [WebMethod]
        public static string RegistroSalidas(string pid, string Cantidad)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Inventario == true)
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Existe = DataControl.tblInventario.FirstOrDefault(s => s.IdHerramienta.ToString() == pid);
                    if (Existe != null)
                    {
                        Existe.Salidas = Existe.Salidas + decimal.Parse(Cantidad);
                        Existe.TotalAlmacen = Existe.Entradas - Existe.Salidas;
                        DataControl.SaveChanges();
                        tblInventarioDet ad = new tblInventarioDet
                        {
                            idHerramienta = int.Parse(pid),
                            idUsuario = usuario.IdUsuario,
                            Entrada = 0,
                            Salida = decimal.Parse(Cantidad),
                            Fecha = DateTime.Now
                        };
                        DataControl.tblInventarioDet.Add(ad);
                        DataControl.SaveChanges();
                        retorno = "Informacion actualizada.";
                    }
                    else
                    {
                        retorno = "Problema al obtener información, intenta de nuevo actualizando página.";
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }

            return retorno;

        }
    }
}