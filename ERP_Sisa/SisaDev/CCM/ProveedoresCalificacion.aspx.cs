using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.CCM
{
    public partial class ProveedoresCalificacion : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtenerProveedores(string pid, string pIdProveedor)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.Proveedores == true || rolesUsuario.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var proveedores = (from p in DataControl.tblProveedores
                                           where p.Activo == 1 && p.Usuario != null
                                           select new { p.IdProveedor, p.Proveedor, p.Email, p.Telefono1, p.NombreComercial, p.Usuario, p.CapFinanciera }).OrderBy(a => a.Proveedor);
                        retorno = JsonConvert.SerializeObject(proveedores);
                    }
                }
                else
                {

                    using (var DataControl = new SisaEntitie())
                    {
                        Guid id = Guid.Parse(pIdProveedor);

                        var calProveedores = DataControl.tblCalProveedor.Where(s => s.IdProveedor == id);
                        retorno = JsonConvert.SerializeObject(calProveedores);
                        //List<tblCotizaciones> cotizaciones = (from a in DataControl.tblCotizaciones
                        //                    where id.Equals(a.idRequisicion)
                        //                    select a).ToList();
                        //retorno = JsonConvert.SerializeObject(cotizaciones);
                    }
                    return retorno;
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }


            return retorno;
        }

        [WebMethod]
        public static string GuardarCalificacion(string pIdProveedor, string pCalCalidad, string pCalSeguridad, string pCalTEntrega, string pCalCostos, string pCapFinanciera)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.ProveedoresAgregar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    Guid id = Guid.Parse(pIdProveedor);

                    var existeProveedor = DataControl.tblProveedores.Where(p => p.IdProveedor == id).FirstOrDefault();
                    if (existeProveedor != null)
                    {
                        existeProveedor.CapFinanciera = decimal.Parse(pCapFinanciera);

                        if (DataControl.SaveChanges() > 0)
                        {
                            var existeCalProveedor = DataControl.tblCalProveedor.Where(cp => cp.IdProveedor == id).FirstOrDefault();

                            if (existeCalProveedor != null)
                            {
                                existeCalProveedor.Calidad = decimal.Parse(pCalCalidad);
                                existeCalProveedor.Seguridad = decimal.Parse(pCalSeguridad);
                                existeCalProveedor.TiempoEntrega = decimal.Parse(pCalTEntrega);
                                existeCalProveedor.Costos = decimal.Parse(pCalCostos);

                                DataControl.SaveChanges();
                                retorno = "Calificación Modificada";
                            }
                            else
                            {
                                tblCalProveedor add = new tblCalProveedor
                                {
                                    IdCalProveedor = Guid.NewGuid(),
                                    IdProveedor = id,
                                    Calidad = decimal.Parse(pCalCalidad),
                                    Seguridad = decimal.Parse(pCalSeguridad),
                                    TiempoEntrega = decimal.Parse(pCalTEntrega),
                                    Costos = decimal.Parse(pCalCostos)
                                };
                                DataControl.tblCalProveedor.Add(add);
                                DataControl.SaveChanges();
                                retorno = "Calificación Guardada.";
                            }
                            
                        }
                        else
                        {
                            retorno = "No se guardo Calificación.";
                        }
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