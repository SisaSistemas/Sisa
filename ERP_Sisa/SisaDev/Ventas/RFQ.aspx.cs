using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
    public partial class RFQ : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idRfqNueva = string.Empty;
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
        public static string ObtenerRFQ(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Administracion == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.RFQ == true)
            {
                if (pid.Trim() == "1")
                {
                    if (rolesUsuarios.Administracion == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.RFQ == true)
                    {
                        using (var DataControl = new SisaEntitie())
                        {
                            var Rfq = (from r in DataControl.tblRFQ
                                       join cn in DataControl.tblClienteContacto on r.IdCliente equals cn.idContacto
                                       join ce in DataControl.tblEmpresas on cn.idEmpresa equals ce.idEmpresa
                                       join uv in DataControl.tblUsuarios on r.idVendedor equals uv.IdUsuario
                                       join uc in DataControl.tblUsuarios on r.idCoordinador equals uc.IdUsuario
                                       where r.Estatus > 0
                                       select new { r.IdRfq, r.Folio, r.Descripcion, FechaRFQ = r.FechaAlta, FechaCompromiso = r.FechaVencimiento, NombreContacto = ce.RazonSocial + "-" + cn.NombreContacto, cn.Telefono, r.Seguimiento, r.ArchivoRFQ, Vendedor = uv.NombreCompleto, Coordinador = uc.NombreCompleto, Estatus = SqlFunctions.DateDiff("DAY", DateTime.Now, r.FechaVencimiento), EstatusN = r.Estatus });

                            retorno = JsonConvert.SerializeObject(Rfq);
                        }
                    }
                    else
                    {
                        using (var DataControl = new SisaEntitie())
                        {
                            var Rfq = (from r in DataControl.tblRFQ
                                       join cn in DataControl.tblClienteContacto on r.IdCliente equals cn.idContacto
                                       join ce in DataControl.tblEmpresas on cn.idEmpresa equals ce.idEmpresa
                                       join uv in DataControl.tblUsuarios on r.idVendedor equals uv.IdUsuario
                                       join uc in DataControl.tblUsuarios on r.idCoordinador equals uc.IdUsuario
                                       where r.IdUsuarioAlta == usuario.IdUsuario && r.Estatus > 0
                                       select new { r.IdRfq, r.Folio, r.Descripcion, FechaRFQ = r.FechaAlta, FechaCompromiso = r.FechaVencimiento, NombreContacto = ce.RazonSocial + "-" + cn.NombreContacto, cn.Telefono, r.Seguimiento, r.ArchivoRFQ, Vendedor = uv.NombreCompleto, Coordinador = uc.NombreCompleto, Estatus = SqlFunctions.DateDiff("DAY", DateTime.Now, r.FechaVencimiento), EstatusN = r.Estatus });

                            retorno = JsonConvert.SerializeObject(Rfq);
                        }
                    }
                        
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Rfq = (from r in DataControl.tblRFQ
                                   join cn in DataControl.tblClienteContacto on r.IdCliente equals cn.idContacto
                                   join ce in DataControl.tblEmpresas on cn.idEmpresa equals ce.idEmpresa
                                   join uv in DataControl.tblUsuarios on r.idVendedor equals uv.IdUsuario
                                   join uc in DataControl.tblUsuarios on r.idCoordinador equals uc.IdUsuario
                                   where r.IdUsuarioAlta == usuario.IdUsuario && r.IdRfq.ToString() == pid && r.Estatus > 0
                                   select new { r.IdRfq, r.Folio, r.Descripcion, FechaRFQ = r.FechaAlta, FechaCompromiso = r.FechaVencimiento, NombreContacto = ce.RazonSocial + "-" + cn.NombreContacto, cn.Telefono, r.Seguimiento, r.ArchivoRFQ, Vendedor = uv.NombreCompleto, Coordinador = uc.NombreCompleto, Estatus = SqlFunctions.DateDiff("DAY", DateTime.Now, r.FechaVencimiento), EstatusN = r.Estatus });

                        retorno = JsonConvert.SerializeObject(Rfq);

                    }
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }
            
            return retorno;
        }

        public static string ObtenerRFQsDetalles(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var requi = (from p in DataControl.tblRFQDet
                                 where p.IdRfq.ToString() == pid
                                 orderby p.Item ascending
                                 select new { p.IdRfq, p.Descripcion, p.Cantidad, p.NumeroParte, p.Marca, p.Unidad, p.Item });

                    retorno = JsonConvert.SerializeObject(requi);
                }
            }
            if (rolesUsuarios.RFQ == true)
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from p in DataControl.tblRFQDet
                                     join a in DataControl.tblRFQ on p.IdRfq equals a.IdRfq
                                     where a.IdUsuarioAlta == usuario.IdUsuario
                                     orderby p.Item ascending
                                     select new { p.IdRfq, p.Descripcion, p.Cantidad, p.NumeroParte, p.Marca, p.Unidad, p.Item });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from p in DataControl.tblRFQDet
                                     where p.IdRfq.ToString() == pid
                                     orderby p.Item ascending
                                     select new { p.IdRfq, p.Descripcion, p.Cantidad, p.NumeroParte, p.Marca, p.Unidad, p.Item });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
            }

            return retorno;
        }

        

        [WebMethod]
        public static string EliminarRFQ(string pidRFQ)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RFQEliminar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var RExiste = DataControl.tblRFQ.FirstOrDefault(s => s.IdRfq.ToString() == pidRFQ);
                    if (RExiste != null)
                    {
                        RExiste.Estatus = 0;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "RFQ eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar RFQ.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de RFQ seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar RFQ.";
            }

            return retorno;
        }

       
        [WebMethod]
        public static string ObtenerEmpresas(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {

                using (var DataControl = new SisaEntitie())
                {
                    if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
                    {
                        //var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                        var Empresas = (from r in DataControl.tblEmpresas
                                        join cn in DataControl.tblClienteContacto on r.idEmpresa equals cn.idEmpresa
                                        where r.Estatus == true && cn.Estatus == true
                                        select new { cn.idContacto, r.RazonSocial, cn.NombreContacto });
                        retorno = JsonConvert.SerializeObject(Empresas);
                    }
                    else
                    {
                        //var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true && s.idSucursalRegistro == usuario.idSucursal);

                        var Empresas = (from r in DataControl.tblEmpresas
                                        join cn in DataControl.tblClienteContacto on r.idEmpresa equals cn.idEmpresa
                                        where r.idSucursalRegistro == usuario.idSucursal && r.Estatus == true && cn.Estatus == true
                                        select new { cn.idContacto, r.RazonSocial, cn.NombreContacto });
                        retorno = JsonConvert.SerializeObject(Empresas);
                    }


                }
            }


            return retorno;
        }

        [WebMethod]
        public static string ObtenerUsuarios(string pid)
        {
            string retorno = string.Empty;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Vendedores = (from r in DataControl.tblUsuarios
                                          join cn in DataControl.tblRolesUsuarios on r.IdUsuario equals cn.idUsuarios
                                      where r.Activo == 1
                                          select new { r.IdUsuario, r.NombreCompleto, cn.Tipo });

                    return JsonConvert.SerializeObject(Vendedores);
                }
            }


            return retorno;
        }

        [WebMethod]
        public static string EnviarRFQ(string pidRFQ)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RFQEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var RExiste = DataControl.tblRFQ.FirstOrDefault(s => s.IdRfq.ToString() == pidRFQ);
                    if (RExiste != null)
                    {
                        RExiste.Estatus = 2;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "RFQ terminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al terminada RFQ.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de RFQ seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de terminada RFQ.";
            }

            return retorno;
        }
    }
}