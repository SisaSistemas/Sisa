using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Compras
{
    public partial class OrdenCompra : System.Web.UI.Page
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
        public static string ObtieneRolUsuarioLogueado()
        {
            return usuario.Puesto;
        }

        [WebMethod]
        public static string ObtenerOC(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.OC || rolesUsuarios.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    if (usuario.Usuario == "ycalderon" || usuario.Usuario == "avargas")
                    {

                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>)(s =>
                            {
                                Guid? idCuautitlan = Guid.Parse("E8FB7D08-3E75-4DD4-9D6F-18A31886B638");
                                Guid? idSucursal = s.IdSucursal;
                                Guid? idQueretaro = Guid.Parse("1479126E-06FA-4F4B-BA36-380CF73A6912");
                                string usuario = s.UsuarioCreo;
                                string usuarioCreo = "Yolanda Estefania Calderon Martinez";
                                string usuarioCreo2 = "ADRIANA VARGAS CASTELAN ";
                                //string usuarioCreo = "Yolanda Estefanía Calderon Martinez";

                                return false || idCuautitlan.GetValueOrDefault().ToString() == idSucursal.GetValueOrDefault().ToString().ToUpper() || idQueretaro.GetValueOrDefault().ToString() == idSucursal.GetValueOrDefault().ToString().ToUpper() || usuarioCreo == usuario || usuarioCreo2 == usuario;
                            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion)));
                        }
                    }
                    else if (usuario.Usuario == "mpacheco")
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>)(s =>
                            {
                                Guid? idCuautitlan = Guid.Parse("E8FB7D08-3E75-4DD4-9D6F-18A31886B638");
                                Guid? idSucursal = s.IdSucursal;
                                Guid? idIrapuato = Guid.Parse("AED5D6F1-86F9-4148-8A45-F97f4AD140A5");
                                string usuario = s.UsuarioCreo;
                                string usuarioCreo = "Martha Patricia Pacheco Zarco";

                                return false || idCuautitlan.GetValueOrDefault() == idSucursal.GetValueOrDefault() || idIrapuato.GetValueOrDefault() == idSucursal.GetValueOrDefault() || usuarioCreo == usuario;
                            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion)));
                        }
                    }
                    else if (usuario.Usuario == "aromero" || usuario.Usuario == "aroman")
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>)(s =>
                            {
                                Guid? idHermosillo = Guid.Parse("E9D0B53B-D8B7-493A-B26D-FAF66D906157");
                                Guid? idSucursal = s.IdSucursal;
                                string usuario = s.UsuarioCreo;
                                string usuarioCreo = "Abigail Roman Cota";
                                string usuarioCreo2 = "Valeria Judith Guevara Martinez";
                                Guid? idChihuahua = Guid.Parse("4327A1A3-B1F1-438A-9C89-081B2FB69D08");

                                return false || idHermosillo.GetValueOrDefault() == idSucursal.GetValueOrDefault() || usuarioCreo == usuario || usuarioCreo2 == usuario;
                            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion)));
                        }
                    }
                    else if (usuario.Usuario == "cpinon")
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>)(s =>
                            {
                                Guid? idChihuahua = Guid.Parse("4327A1A3-B1F1-438A-9C89-081B2FB69D08");
                                Guid? idSucursal = s.IdSucursal;
                                string usuario = s.UsuarioCreo;
                                string usuarioCreo = "Cecilia Piñon Villarreal";

                                return false || idChihuahua.GetValueOrDefault() == idSucursal.GetValueOrDefault() || usuarioCreo == usuario;
                            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion)));
                        }
                    }
                    else if (usuario.Usuario == "gbarrios" || usuario.Usuario == "vguevara" || usuario.Usuario == "mamavizca")
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>)(s =>
                            {

                                Guid? idTecate = Guid.Parse("F8E5400A-E1B5-4100-A990-E73E9DA59370");
                                Guid? idSucursal = s.IdSucursal;
                                Guid? idEstadosUnidos = Guid.Parse("56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB");
                                Guid? idHermosillo = usuario.idSucursal;
                                Guid? idChihuahua = Guid.Parse("4327A1A3-B1F1-438A-9C89-081B2FB69D08");
                                Guid? idCuautitlan = Guid.Parse("E8FB7D08-3E75-4DD4-9D6F-18A31886B638");
                                Guid? idIrapuato = Guid.Parse("AED5D6F1-86F9-4148-8A45-F97f4AD140A5");
                                Guid? idQueretaro = Guid.Parse("1479126E-06FA-4F4B-BA36-380CF73A6912");

                                string usuarioCreo = s.UsuarioCreo;
                                //string usuarioCreo = "Yolanda Estefanía Calderon Martinez";

                                return false 
                                            || idHermosillo.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper() 
                                            || idTecate.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper() 
                                            || idEstadosUnidos.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper()
                                            || idChihuahua.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper()
                                            || idCuautitlan.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper()
                                            || idIrapuato.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper()
                                            || idQueretaro.GetValueOrDefault().ToString().ToUpper() == idSucursal.GetValueOrDefault().ToString().ToUpper();
                            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion)));
                        }
                    }
                    else
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS" || rolesUsuarios.Tipo == "ROOT" ? JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion))) : JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadOrdenCompra_Result>)sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>)(s =>
                            {
                                Guid? idSucursal7 = s.IdSucursal;
                                Guid? idSucursal8 = usuario.idSucursal;
                                if (idSucursal7.HasValue != idSucursal8.HasValue)
                                    return false;
                                return !idSucursal7.HasValue || idSucursal7.GetValueOrDefault() == idSucursal8.GetValueOrDefault();
                            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>)(a => a.FechaCreacion)));
                        }
                    }
                    
                        
                }
                else
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject((object)((IQueryable<tblOrdenCompra>)sisaEntitie.tblOrdenCompra).Join((IEnumerable<tblProveedores>)sisaEntitie.tblProveedores, (Expression<Func<tblOrdenCompra, Guid>>)(r => r.IdProveedor), (Expression<Func<tblProveedores, Guid>>)(p => p.IdProveedor), (r, p) => new
                        {
                            r = r,
                            p = p
                        }).Where(data => data.r.idSucursal == usuario.idSucursal && data.r.IdOrdenCompra.ToString() == pid).Select(data => new
                        {
                            IdOrdenCompra = data.r.IdOrdenCompra,
                            Folio = data.r.Folio,
                            Proveedor = data.p.Proveedor,
                            Email = data.p.Email,
                            Correo = usuario.Correo
                        }));
                    }
                        
                }
            }
            else
            {
                str = "No tienes permiso de lectura.";
            }

            return str;
        }

        [WebMethod]
        public static string CargarResumen(string valor)
        {

            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.OC || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    str = JsonConvert.SerializeObject((object)sisaEntitie.sp_TotalesOC(valor));
                }
                    
            }
            else
            {
                str = "No tienes permiso de lectura.";
            }
                
            return str;
        }

        [WebMethod]
        public static string EliminarOC(string pidOC)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.OCEliminar || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>)sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>)(s => s.IdOrdenCompra.ToString() == pidOC));
                    if (tblOrdenCompra != null)
                    {
                        tblOrdenCompra.Estatus = 3;
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            str = "OC eliminado.";
                            tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(a => a.idDocumento == pidOC));
                            if (eficienciasDesglose != null)
                            {
                                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                                sisaEntitie.SaveChanges();
                            }
                        }
                        else
                            str = "Ocurrio un problema al eliminar OC.";
                    }
                    else
                    {
                        tblOrdenCompraInsumos ordenCompraInsumos = ((IQueryable<tblOrdenCompraInsumos>)sisaEntitie.tblOrdenCompraInsumos).FirstOrDefault<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>)(s => s.IdOrdenCompra.ToString() == pidOC));
                        if (ordenCompraInsumos != null)
                        {
                            ordenCompraInsumos.Estatus = 0;
                            if (sisaEntitie.SaveChanges() > 0)
                            {
                                str = "OC eliminado.";
                                tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(a => a.idDocumento == pidOC));
                                if (eficienciasDesglose != null)
                                {
                                    sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                                    sisaEntitie.SaveChanges();
                                }
                            }
                            else
                                str = "Ocurrio un problema al eliminar OC.";
                        }
                        else
                            str = "Ocurrio un problema al obtener información de OC seleccionada.";
                    }
                }
            }
            else
            {
                str = "No tienes permiso de eliminar OC.";
            }
                
            return str;
        }

        [WebMethod]
        public static string CancelarOC(string pidOC, string Comentarios)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (OrdenCompra.rolesUsuarios.OCEditar || OrdenCompra.rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>)sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>)(s => s.IdOrdenCompra.ToString() == pidOC));
                    if (tblOrdenCompra != null)
                    {
                        tblOrdenCompra.Estatus = 2;
                        tblOrdenCompra.MotivoCancelacion = Comentarios;
                        tblOrdenCompra.IdUsuarioCancelacion = usuario.IdUsuario.ToString();
                        tblOrdenCompra.FechaCancelacion = DateTime.Now;
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            str = "OC cancelado.";
                            tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(a => a.idDocumento == pidOC));
                            if (eficienciasDesglose != null)
                            {
                                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                                sisaEntitie.SaveChanges();
                            }
                        }
                        else
                            str = "Ocurrio un problema al cancelar OC, es posible que ya haya sido cancelada con anterioridad.";
                    }
                    else
                    {
                        tblOrdenCompraInsumos ordenCompraInsumos = ((IQueryable<tblOrdenCompraInsumos>)sisaEntitie.tblOrdenCompraInsumos).FirstOrDefault<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>)(s => s.IdOrdenCompra.ToString() == pidOC));
                        if (ordenCompraInsumos != null)
                        {
                            ordenCompraInsumos.Estatus = 2;
                            ordenCompraInsumos.MotivoCancelacion = Comentarios;
                            ordenCompraInsumos.IdUsuarioCancelacion = usuario.IdUsuario.ToString();
                            ordenCompraInsumos.FechaCancelacion = DateTime.Now;
                            if (sisaEntitie.SaveChanges() > 0)
                            {
                                str = "OC cancelado.";
                                tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(a => a.idDocumento == pidOC));
                                if (eficienciasDesglose != null)
                                {
                                    sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                                    sisaEntitie.SaveChanges();
                                }
                            }
                            else
                            {
                                str = "Ocurrio un problema al cancelar OC, es posible que ya haya sido cancelada con anterioridad.";
                            }
                                
                        }
                        else
                        {
                            str = "Ocurrio un problema al obtener información de OC seleccionada.";
                        }
                            
                    }
                }
            }
            else
            {
                str = "No tienes permiso de cancelar OC.";
            }

            return str;

        }

        [WebMethod]
        public static string CargarComentarios(string IdOrdenCompra)
        {
            
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaComentariosOrdenCompra(IdOrdenCompra));
            }
        }

        [WebMethod]
        public static string GuardarComentarios(string IdOrdenCompra, string Comentario)
        {
            
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_InsertaComentariosOrdenCompra(IdOrdenCompra, Comentario, usuario.IdUsuario.ToString()));
            }
                
        }
        
        [WebMethod]
        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GuardarDocumentos(string IdOrdenCompra, string FileName, string fileSize, string filetype, string fileExtension, string Archivo)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {

                using (var DataControl = new SisaEntitie())
                {
                    //int a = Convert.ToInt32(Opcion);
                    Guid idOrden = Guid.Parse(IdOrdenCompra);
                    tblOrdenCompraArchivos add = new tblOrdenCompraArchivos
                    {
                        IdArchivoCotOC = Guid.NewGuid(),
                        IdOrdenCompra = idOrden,
                        NombreArchivo = FileName,
                        FileExtension = fileExtension,
                        FileSize = fileSize,
                        FileContentType = filetype,
                        Archivo = Archivo,
                        Fecha = DateTime.Now,
                        IdUsuario = usuario.IdUsuario

                    };
                    DataControl.tblOrdenCompraArchivos.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Archivo guardado";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentos(string IdOrdenCompra, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                int a = Convert.ToInt32(Opcion);
                using (var DataControl = new SisaEntitie())
                {
                    var Filtrado = DataControl.sp_SelectDocumentosOrdenCompra(IdOrdenCompra);
                    retorno = JsonConvert.SerializeObject(Filtrado);
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string VerPdf(string id)
        {
            string retorno = string.Empty;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    var docu = DataControl.tblOrdenCompraArchivos.FirstOrDefault(a => a.IdArchivoCotOC.ToString() == id);
                    if (docu != null)
                    {
                        if (!string.IsNullOrEmpty(docu.NombreArchivo) && !string.IsNullOrEmpty(docu.Archivo))
                        {
                            string[] completo64 = docu.Archivo.Split(',');
                            //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Compras\\docs\\" + docu.NombreArchivo;
                            using (FileStream Writer = new System.IO.FileStream(a, FileMode.Create, FileAccess.Write))
                            {
                                Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                            }
                            //File.WriteAllBytes(a + p.Nombre, Convert.FromBase64String(p.Archivo));
                        }
                        retorno = JsonConvert.SerializeObject(docu);
                    }
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            retorno = retorno.Replace("FileName", "NombreArchivo");
            return retorno;
        }

        [WebMethod]
        public static string EliminarDocumento(string IdDocumento)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.OCEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {

                    tblOrdenCompraArchivos entity = DataControl.tblOrdenCompraArchivos.FirstOrDefault<tblOrdenCompraArchivos>((v => v.IdArchivoCotOC.ToString() == IdDocumento));
                    if (entity != null)
                    {
                        DataControl.tblOrdenCompraArchivos.Remove(entity);
                        DataControl.SaveChanges();
                        retorno = "Documento eliminado.";
                    }
                    else
                    {
                        retorno = "Error";
                    }



                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar documento.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarPagosOrdenes(string IdOrden)
        {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                var result = from pagos in
                             sisaEntitie.sp_SelectPagosFacturasOrdenes(IdOrden)
                             select new clsPagosFacturasOrdenes
                             {
                                 IdPago = pagos.IdPago,
                                 IdOrdenCompra = pagos.IdOrdenCompra,
                                 FechaPago = pagos.FechaPago,
                                 Pago = pagos.Pago,
                                 FechaAlta = pagos.FechaAlta,
                                 IdUsuarioAlta = pagos.IdUsuarioAlta,
                                 Banco = pagos.Banco,
                                 FolioFactura = pagos.FolioFactura,
                                 esRoot = rolesUsuarios.Tipo == "ROOT" ? true : false
                             };
                return JsonConvert.SerializeObject((object)result);
                //return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectPagosFacturasOrdenes(IdOrden));
            }
        }

        [WebMethod]
        public static string GuardarPagos(string IdOrdenCompra, string FechaPago, string Monto, string Banco, string FolioFactura)
        {

            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.spInsertPagosFacturasOrdenes(IdOrdenCompra, FechaPago, Convert.ToDecimal(Monto), Banco, usuario.IdUsuario.ToString(), FolioFactura));
            }

        }

        [WebMethod]
        public static string EliminarPago(string IdPago)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {

                    tblPagosFacturasOrdenes entity = DataControl.tblPagosFacturasOrdenes.FirstOrDefault<tblPagosFacturasOrdenes>((v => v.IdPago.ToString() == IdPago));
                    if (entity != null)
                    {
                        DataControl.tblPagosFacturasOrdenes.Remove(entity);
                        DataControl.SaveChanges();
                        retorno = "Pago eliminado.";
                    }
                    else
                    {
                        retorno = "Error";
                    }



                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar Pagos.";
            }

            return retorno;
        }

        [WebMethod]
        public static string AgregaOrdenParaPagoMultiple(string IdOrdenCompra, string Folio, string NombreProyecto, string Total)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                var idOrden = sisaEntitie.tblPagosMultiples.Where(p => p.IdOrdenCompra.ToString().Equals(IdOrdenCompra) && p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList().Count;
                if (idOrden <= 0)
                {
                    //generamos el objeto nuevo con la info necesaria para insertarlo en la tabla
                    var nuevoPago = new tblPagosMultiples()
                    {
                        IdOrdenCompra = new Guid(IdOrdenCompra),
                        Folio = Folio,
                        IdUsuario = usuario.IdUsuario,
                        NombreProyecto = NombreProyecto,
                        Total = decimal.Parse(Total),
                        FechaAlta = DateTime.Now
                    };
                    //agregamos el objeto creado a la tabla del modelo
                    sisaEntitie.tblPagosMultiples.Add(nuevoPago);
                    //con esete codigo se guarda en la base de datos
                    sisaEntitie.SaveChanges();
                    retorno = "pago agregado a la lista";
                }
            }
            return retorno;  
        }

        [WebMethod]
        public static string EliminaOrdenParaPagoMultiple(string IdOrdenCompra, string Folio, string NombreProyecto, string Total)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                //verificamos que la orden existe en la tabla 
                var pago = sisaEntitie.tblPagosMultiples.Where(p => p.IdOrdenCompra.ToString().Equals(IdOrdenCompra) && p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).FirstOrDefault();
                if (pago != null)
                {
                    //el pago existe
                    sisaEntitie.tblPagosMultiples.Remove(pago);
                    //guardamos los cambios en la base de datos
                    sisaEntitie.SaveChanges();
                    retorno = "Pago eliminado";
                }
            }
            return retorno;
        }

        [WebMethod]
        public static string CuantosParaPagoMultiple(string id)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.tblPagosMultiples.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList().Count.ToString());            
            }
        }

        [WebMethod]
        public static string obtienePagosMultiplesPendientes(string id)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            string retorno = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                retorno = JsonConvert.SerializeObject((object)sisaEntitie.tblPagosMultiples.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList());
            }
            return retorno;
        }

        [WebMethod]
        public static string guardaPagosMultiples(string _fecha, string _Banco)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                var ordenes = sisaEntitie.tblPagosMultiples.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList();
                foreach (var orden in ordenes)
                {
                    sisaEntitie.spInsertPagosFacturasOrdenes(orden.IdOrdenCompra.ToString(), _fecha, Convert.ToDecimal(orden.Total), _Banco, usuario.IdUsuario.ToString(), "");
                    sisaEntitie.tblPagosMultiples.Remove(orden);
                }
                sisaEntitie.SaveChanges();
                //verificamos que no haya pagoa pendientes en la tabla para el usuario en curso
                if (sisaEntitie.tblPagosMultiples.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList().Count > 0)
                {
                    retorno = "Ocurrio un error al intentar guardar los pagos!!!";
                }
                else
                {
                    retorno = "Ordenes pagadas."; 
                }
            }   
            return retorno;
        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int num = int.Parse(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombos(new int?(num)));
            }
           
        }

        [WebMethod]
        public static string CargarCotizacionesComparativa(string IdOrden)
        {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                var result = sisaEntitie.sp_SelCotizaciones_comparativa(IdOrden);
                return JsonConvert.SerializeObject(result);
                //return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectPagosFacturasOrdenes(IdOrden));
            }
        }

        [WebMethod]
        public static string GuardaCotizacionComparativa(string IdOrdenCompra, int NumCotizacion, string NombreCot, string ArchivoCot, string IdProveedor, string Monto)
        {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                sisaEntitie.sp_Ins_Cot_Comparativa(IdOrdenCompra, NumCotizacion, NombreCot, ArchivoCot, IdProveedor, decimal.Parse(Monto), usuario.IdUsuario.ToString());
            }
            return "";
        }

        [WebMethod]
        public static string EliminaCotizacionComparativa(string IdOrdenCompra, int NumCotizacion)
        {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                sisaEntitie.sp_Del_Cot_Comparativa(IdOrdenCompra, NumCotizacion);
            }
            return "";
        }

        [WebMethod]
        public static string CargarCombos2(string Opcion)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)((IQueryable<tblProveedores>)sisaEntitie.tblProveedores).Where<tblProveedores>((Expression<Func<tblProveedores, bool>>)(p => p.Activo == 1)).Select(p => new
                {
                    Id = p.IdProveedor,
                    Nombre = p.Proveedor
                }));
            }

        }
    }
}