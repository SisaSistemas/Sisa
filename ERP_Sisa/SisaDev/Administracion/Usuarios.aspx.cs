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
    public partial class Usuarios : System.Web.UI.Page
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
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerUsuarios(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.Usuarios == true || rolesUsuario.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        //tblUsuarioSucursal
                        var Usuario = (from cl in DataControl.tblUsuarios
                                       join rl in DataControl.tblRolesUsuarios on cl.IdUsuario equals rl.idUsuarios
                                       join clSuc in DataControl.tblUsuarioSucursal on cl.IdUsuario equals clSuc.IdUsuario
                                       join suc in DataControl.tblSucursales on clSuc.IdSucursal equals suc.idSucursa
                                       where cl.Activo == 1
                                       select new { cl.IdUsuario, cl.NombreCompleto, cl.Usuario, cl.Telefono, cl.Correo, rl.Tipo, suc.CiudadSucursal }).OrderBy(a => a.NombreCompleto);

                        //var Usuario = (from cl in DataControl.tblUsuarios
                        //               join rl in DataControl.tblRolesUsuarios on cl.IdUsuario equals rl.idUsuarios
                        //               join suc in DataControl.tblSucursales on cl.idSucursal equals suc.idSucursa
                        //               where cl.Activo == 1
                        //               select new { cl.IdUsuario, cl.NombreCompleto, cl.Usuario, cl.Telefono, cl.Correo, rl.Tipo, suc.CiudadSucursal }).OrderBy(a=>a.NombreCompleto);
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(Usuario);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Usuario = (from cl in DataControl.tblUsuarios
                                       join rl in DataControl.tblRolesUsuarios on cl.IdUsuario equals rl.idUsuarios
                                       join suc in DataControl.tblSucursales on cl.idSucursal equals suc.idSucursa
                                       where cl.IdUsuario.ToString() == pid
                                       select new
                                       {
                                           cl.IdUsuario,
                                           cl.Activo,
                                           cl.NombreCompleto,
                                           cl.Usuario,
                                           cl.Telefono,
                                           cl.Correo,
                                           cl.Contrasena,
                                           rl.Tipo,
                                           cl.idSucursal,
                                           cl.SueldoDiario,
                                           EsCCM = cl.EsCCM == 1 ? "true" : "false",
                                           cl.PuestoCCM,
                                           cl.AreaCCM,
                                           ClienteEmpresa = rl.ClienteEmpresa,
                                           ClienteEmpresaAgregar = rl.ClienteEmpresaAgregar,
                                           ClienteEmpresaEditar = rl.ClienteEmpresaEditar,
                                           ClienteEmpresaEliminar = rl.ClienteEmpresaEliminar,
                                           ClienteContacto = rl.ClienteContacto,
                                           ClienteContactoAgrear = rl.ClienteContactoAgrear,
                                           ClienteContactoEditar = rl.ClienteContactoEditar,
                                           ClienteContactoEliminar = rl.ClienteContactoEliminar,
                                           RFQ = rl.RFQ,
                                           RFQAgregar = rl.RFQAgregar,
                                           RFQEditar = rl.RFQEditar,
                                           RFQEliminar = rl.RFQEliminar,
                                           Cotizaciones = rl.Cotizaciones,
                                           CotizacionesAgregar = rl.CotizacionesAgregar,
                                           CotizacionesEditar = rl.CotizacionesEditar,
                                           CotizacionesEliminar = rl.CotizacionesEliminar,
                                           Materiales = rl.Materiales,
                                           MaterialesAgregar = rl.MaterialesAgregar,
                                           MaterialesEditar = rl.MaterialesEditar,
                                           MaterialesEliminar = rl.MaterialesEliminar,
                                           Proveedores = rl.Proveedores, 
                                           ProveedoresAgregar = rl.ProveedoresAgregar,
                                           ProveedoresEditar = rl.ProveedoresEditar,
                                           ProveedoresEliminar = rl.ProveedoresEliminar,
                                           Requisiciones = rl.Requisiciones,
                                           RequisicionesAgregar = rl.RequisicionesAgregar,
                                           RequisicionesEditar = rl.RequisicionesEditar,
                                           RequisicionesEliminar = rl.RequisicionesEliminar,
                                           OC = rl.OC,
                                           OCAgregar = rl.OCAgregar,
                                           OCEditar = rl.OCEditar,
                                           OCEliminar = rl.OCEliminar,
                                           Viaticos = rl.Viaticos,
                                           ViaticosAgregar = rl.ViaticosAgregar,
                                           ViaticosEditar = rl.ViaticosEditar,
                                           ViaticosEliminar = rl.ViaticosEliminar,
                                           Proyectos = rl.Proyectos,
                                           ProyectosAgregar = rl.ProyectosAgregar,
                                           ProyectosEditar = rl.ProyectosEditar,
                                           ProyectosEliminar = rl.ProyectosEliminar,
                                           CajaChica = rl.CajaChica,
                                           CajaChicaAgregar = rl.CajaChicaAgregar,
                                           CajaChicaEditar = rl.CajaChicaEditar,
                                           CajaChicaEliminar = rl.CajaChicaEliminar,
                                           CajaChicaCuautitlan = rl.CajaChicaCuautitlan,
                                           CajaChicaChihuahua = rl.CajaChicaChihuahua,
                                           CajaChicaUSA = rl.CajaChicaUSA,
                                           CajaChicaIrapuato = rl.CajaChicaIrapuato,
                                           CajaChicaQueretaro = rl.CajaChicaQueretaro,
                                           CajaChicaTecate = rl.CajaChicaTecate,
                                           Usuarios = rl.Usuarios,
                                           UsuariosAgregar = rl.UsuariosAgregar,
                                           UsuariosEditar = rl.UsuariosEditar,
                                           UsuariosEliminar = rl.UsuariosEliminar,
                                           Sucursales = rl.Sucursales,
                                           SucursalesAgregar = rl.SucursalesAgregar,
                                           SucursalesEditar = rl.SucursalesEditar,
                                           SucursalesEliminar = rl.SucursalesEliminar,
                                           ControlFacturas = rl.ControlFacturas,
                                           FacRecibidas = rl.FacRecibidas,
                                           FacRecibidasAgregar = rl.FacRecibidasAgregar,
                                           FacRecibidasEditar = rl.FacRecibidasEditar,
                                           FacRecibidasEliminar = rl.FacRecibidasEliminar,
                                           FacEmitidas = rl.FacEmitidas ,
                                           FacEmitidasAgregar = rl.FacEmitidasAgregar,
                                           FacEmitidasEditar = rl.FacEmitidasEditar,
                                           FacEmitidasEliminar = rl.FacEmitidasEliminar,
                                           ControlDocumentos = rl.ControlDocumentos,
                                           Administracion = rl.Administracion,
                                           Inventario = rl.Inventario,
                                           Timming = rl.Timming,
                                           Boletines = rl.Boletines,
                                           ServiciosCarro = rl.ServiciosCarro,                                           
                                           ServiciosComputo = rl.ServiciosComputo ,
                                           FacturasEmitidas = rl.FacturasEmitidas,
                                           Reportes = rl.Reportes ,
                                           rptOrdenCompra = rl.rptOrdenCompra,
                                           rptFacturasRecibidas = rl.rptFacturasRecibidas ,
                                           chkRptFacturasEmitidas = rl.rptFacturasEmitidas,
                                           rptProyectos = rl.rptProyectos,
                                           rptCotizaciones = rl.rptCotizaciones,
                                           rptProyectosGastos = rl.rptProyectosGastos,
                                           rptProveedoresPagar = rl.rptProveedoresPagar,
                                           rptEficiencias = rl.rptEficiencias,
                                           rptMonitor = rl.rptMonitor,
                                           ModuloPO = rl.ModuloPO,
                                           CostoIndirecto = rl.CostoIndirecto
                                       }) ;
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(Usuario);
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
        public static string GuardarUsuarios(string pNombreCompleto, string pCorreoUsuario, string pTelefonoUsuario, string pClaveUsuario
            , string pUsuario, string pTipo, bool pchkCuautitlan, bool pchkChihuahua, bool pchkUsa, bool pchkHermosillo, bool pchkIrapuato, bool pchkQueretaro, bool pchkTecate
            , bool pchkCliEmpVer, bool pchkCliEmpAdd, bool pchkCliEmpEdit
            , bool pchkCliEmpDel, bool pchkCliConVer, bool pchkCliConAdd, bool pchkCliConEdit, bool pchkCliConDel, bool pchkRFQVer
            , bool pchkRFQAdd, bool pchkRFQEdit, bool pchkRFQDel, bool pchkCotVer, bool pchkCotAdd, bool pchkCotEdit, bool pchkCotDel
            , bool pchkMatVer, bool pchkMatAdd, bool pchkMatEdit, bool pchkMatDel, bool pchkProvVer, bool pchkProvAdd, bool pchkProvEdit
            , bool pchkProvDel, bool pchkRequiVer, bool pchkRequiAdd, bool pchkRequiEdit, bool pchkRequiDel, bool pchkOCVer
            , bool pchkOCAdd, bool pchkOCEdit, bool pchkOCDel, bool pchkViaVer, bool pchkViaAdd, bool pchkViaEdit, bool pchkViaDel
            , bool pchkProyVer, bool pchkProyAdd, bool pchkProyEdit, bool pchkProyDel, bool pchkCajaVer, bool pchkCajaAdd
            , bool pchkCajaEdit, bool pchkCajaDel, bool pchkCajaCuautitlan, bool pchkCajaChihuahua, bool pchkCajaUSA, bool pchkCajaIrapuato, bool pchkCajaQueretaro, bool pchkCajaTecate
            , bool pchkUserVer, bool pchkUserAdd, bool pchkUserEdit, bool pchkUserDel
            , bool pchkSucVer, bool pchkSucAdd, bool pchkSucEdit, bool pchkSucDel, bool pchkFacVer, bool pchkDocsAdd, bool pchkAdminVer
            , bool pchkInventaAdd, bool pchkTimmEdit, bool pchkBoletines, bool pchkCarroVer, bool pchkPCAdd, string pSalario, bool pchkFacVerEmitidas
            , bool pReportes, bool pRptOrdenCompra, bool pRptFacturasRecibidas, bool pRptFacturasEmitidas, bool pRptProyectos
            , bool pRptCotizaciones, bool pRptProyectosGastos, bool pRptProveedoresPagar
            , bool pchkFRVer, bool pchkFRAdd, bool pchkFREdit, bool pchkFRDel
            , bool pchkFEVer, bool pchkFEAdd, bool pchkFEEdit, bool pchkFEDel, bool pRptEficiencias, bool pRptMonitor
            , bool pchkModuloPO, bool pchkCostoIndirecto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.UsuariosAgregar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Usuario = DataControl.tblUsuarios.FirstOrDefault(u => u.Usuario.ToString() == pUsuario);
                    if (Usuario == null)
                    {
                        tblUsuarios user = new tblUsuarios
                        {
                            IdUsuario = Guid.NewGuid(),
                            NombreCompleto = pNombreCompleto,
                            Correo = pCorreoUsuario,
                            Telefono = pTelefonoUsuario,
                            Contrasena = pClaveUsuario,
                            Usuario = pUsuario,
                            //idSucursal = Guid.Parse(pSucursal),
                            Permisos = 1,
                            Puesto = pTipo,
                            Foto = "",
                            FechaAlta = DateTime.Now,
                            IdUsuarioModificacion = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            Activo = 1,
                            SueldoDiario = pSalario == "" ? 0 : decimal.Parse(pSalario)

                        };
                        DataControl.tblUsuarios.Add(user);
                        if (DataControl.SaveChanges() > 0)
                        {
                            tblRolesUsuarios rol = new tblRolesUsuarios
                            {
                                idRol = Guid.NewGuid(),
                                idUsuarios = user.IdUsuario,
                                Tipo = pTipo,
                                ClienteEmpresa = pchkCliEmpVer,
                                ClienteEmpresaAgregar = pchkCliEmpAdd,
                                ClienteEmpresaEditar = pchkCliEmpEdit,
                                ClienteEmpresaEliminar = pchkCliEmpDel,
                                ClienteContacto = pchkCliConVer,
                                ClienteContactoAgrear = pchkCliConAdd,
                                ClienteContactoEditar = pchkCliConEdit,
                                ClienteContactoEliminar = pchkCliConDel,
                                RFQ = pchkRFQVer,
                                RFQAgregar = pchkRFQAdd,
                                RFQEditar = pchkRFQEdit,
                                RFQEliminar = pchkRFQDel,
                                Cotizaciones = pchkCotVer,
                                CotizacionesAgregar = pchkCotAdd,
                                CotizacionesEditar = pchkCotEdit,
                                CotizacionesEliminar = pchkCotDel,
                                Materiales = pchkMatVer,
                                MaterialesAgregar = pchkMatAdd,
                                MaterialesEditar = pchkMatEdit,
                                MaterialesEliminar = pchkMatDel,
                                Proveedores = pchkProvVer,
                                ProveedoresAgregar = pchkProvAdd,
                                ProveedoresEditar = pchkProvEdit,
                                ProveedoresEliminar = pchkProvDel,
                                Requisiciones = pchkRequiVer,
                                RequisicionesAgregar = pchkRequiAdd,
                                RequisicionesEditar = pchkRequiEdit,
                                RequisicionesEliminar = pchkRequiDel,
                                OC = pchkOCVer,
                                OCAgregar = pchkOCAdd,
                                OCEditar = pchkOCEdit,
                                OCEliminar = pchkOCDel,
                                Viaticos = pchkViaVer,
                                ViaticosAgregar = pchkViaAdd,
                                ViaticosEditar = pchkViaEdit,
                                ViaticosEliminar = pchkViaDel,
                                Proyectos = pchkProyVer,
                                ProyectosAgregar = pchkProyAdd,
                                ProyectosEditar = pchkProyEdit,
                                ProyectosEliminar = pchkProyDel,
                                CajaChica = pchkCajaVer,
                                CajaChicaAgregar = pchkCajaAdd,
                                CajaChicaEditar = pchkCajaEdit,
                                CajaChicaEliminar = pchkCajaDel,
                                CajaChicaCuautitlan = pchkCajaCuautitlan,
                                CajaChicaChihuahua = pchkCajaChihuahua,
                                CajaChicaUSA = pchkCajaUSA,
                                CajaChicaIrapuato = pchkCajaIrapuato,
                                CajaChicaQueretaro = pchkCajaQueretaro,
                                CajaChicaTecate = pchkCajaTecate,
                                Usuarios = pchkUserVer,
                                UsuariosAgregar = pchkUserAdd,
                                UsuariosEditar = pchkUserEdit,
                                UsuariosEliminar = pchkUserDel,
                                Sucursales = pchkSucVer,
                                SucursalesAgregar = pchkSucAdd,
                                SucursalesEditar = pchkSucEdit,
                                SucursalesEliminar = pchkSucDel,
                                ControlFacturas = pchkFacVer,
                                ControlDocumentos = pchkDocsAdd,
                                Administracion = pchkAdminVer,
                                Timming = pchkTimmEdit,
                                Boletines = pchkBoletines,
                                ServiciosCarro = pchkCarroVer,
                                Inventario = pchkInventaAdd,
                                ServiciosComputo = pchkPCAdd,
                                FacturasEmitidas = pchkFacVerEmitidas,
                                Reportes = pReportes,
                                rptOrdenCompra = pRptOrdenCompra,
                                rptFacturasRecibidas = pRptFacturasRecibidas,
                                rptFacturasEmitidas = pRptFacturasEmitidas,
                                rptProyectos = pRptProyectos,
                                rptCotizaciones = pRptCotizaciones,
                                rptProyectosGastos = pRptProyectosGastos,
                                rptProveedoresPagar = pRptProveedoresPagar,
                                FacRecibidas = pchkFRVer,
                                FacRecibidasAgregar = pchkFRAdd,
                                FacRecibidasEditar = pchkFREdit,
                                FacRecibidasEliminar = pchkFRDel,
                                FacEmitidas = pchkFEVer,
                                FacEmitidasAgregar = pchkFEAdd,
                                FacEmitidasEditar = pchkFEEdit,
                                FacEmitidasEliminar = pchkFEDel,
                                rptEficiencias = pRptEficiencias,
                                ModuloPO = pchkModuloPO,
                                CostoIndirecto = pchkCostoIndirecto,
                                rptMonitor = pRptMonitor
                            };
                            DataControl.tblRolesUsuarios.Add(rol);
                            if (DataControl.SaveChanges() > 0)
                            {
                                Guid cuautitlan = Guid.Parse("E8FB7D08-3E75-4DD4-9D6F-18A31886B638");
                                Guid chihuahua = Guid.Parse("4327A1A3-B1F1-438A-9C89-081B2FB69D08");
                                Guid usa = Guid.Parse("56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB");
                                Guid hermosillo = Guid.Parse("E9D0B53B-D8B7-493A-B26D-FAF66D906157");
                                Guid irapuato = Guid.Parse("AED5D6F1-86F9-4148-8A45-F97F4AD140A5");
                                Guid queretaro = Guid.Parse("1479126E-06FA-4F4B-BA36-380CF73A6912");
                                Guid tecate = Guid.Parse("F8E5400A-E1B5-4100-A990-E73E9DA59370");

                                if (pchkCuautitlan)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = cuautitlan,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                if (pchkChihuahua)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = chihuahua,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                if (pchkUsa)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = usa,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                if (pchkHermosillo)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = hermosillo,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                if (pchkIrapuato)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = irapuato,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                if (pchkQueretaro)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = queretaro,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                if (pchkTecate)
                                {
                                    tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                    {
                                        IdUsuarioSucursal = Guid.NewGuid(),
                                        IdUsuario = user.IdUsuario,
                                        IdSucursal = tecate,
                                        FechaAlta = DateTime.Now
                                    };
                                    DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                }
                                DataControl.SaveChanges();
                                retorno = "Usuario creado.";
                            }
                            else
                            {
                                retorno = "Error al agregar los roles de usuario, contácta el administrador del sistema.";
                            }

                        }
                        else
                        {
                            retorno = "Error al agregar usuario.";
                        }
                    }
                    else
                    {
                        retorno = "Usuario Repetido. Favor de Verificar!";
                    }
                    
                }
            }
            else
            {
                retorno = "No tienes permiso para agregar usuarios.";
            }           

            return retorno;
        }

        [WebMethod]
        public static string EditarUsuarios(string pidUsuario, string pNombreCompleto, string pCorreoUsuario, string pTelefonoUsuario, string pClaveUsuario
            , string pUsuario, string pTipo, bool pchkCuautitlan, bool pchkChihuahua, bool pchkUsa, bool pchkHermosillo, bool pchkIrapuato, bool pchkQueretaro, bool pchkTecate
            , bool pchkCliEmpVer, bool pchkCliEmpAdd, bool pchkCliEmpEdit
            , bool pchkCliEmpDel, bool pchkCliConVer, bool pchkCliConAdd, bool pchkCliConEdit, bool pchkCliConDel, bool pchkRFQVer
            , bool pchkRFQAdd, bool pchkRFQEdit, bool pchkRFQDel, bool pchkCotVer, bool pchkCotAdd, bool pchkCotEdit, bool pchkCotDel
            , bool pchkMatVer, bool pchkMatAdd, bool pchkMatEdit, bool pchkMatDel, bool pchkProvVer, bool pchkProvAdd, bool pchkProvEdit
            , bool pchkProvDel, bool pchkRequiVer, bool pchkRequiAdd, bool pchkRequiEdit, bool pchkRequiDel, bool pchkOCVer
            , bool pchkOCAdd, bool pchkOCEdit, bool pchkOCDel, bool pchkViaVer, bool pchkViaAdd, bool pchkViaEdit, bool pchkViaDel
            , bool pchkProyVer, bool pchkProyAdd, bool pchkProyEdit, bool pchkProyDel, bool pchkCajaVer, bool pchkCajaAdd
            , bool pchkCajaEdit, bool pchkCajaDel, bool pchkCajaCuautitlan, bool pchkCajaChihuahua, bool pchkCajaUSA, bool pchkCajaIrapuato, bool pchkCajaQueretaro, bool pchkCajaTecate
            , bool pchkUserVer, bool pchkUserAdd, bool pchkUserEdit, bool pchkUserDel
            , bool pchkSucVer, bool pchkSucAdd, bool pchkSucEdit, bool pchkSucDel, bool pchkFacVer, bool pchkDocsAdd, bool pchkAdminVer
            , bool pchkInventaAdd, bool pchkTimmEdit, bool pchkBoletines, bool pchkCarroVer, bool pchkPCAdd, string pSalario, bool pchkFacVerEmitidas
            , bool pReportes, bool pRptOrdenCompra, bool pRptFacturasRecibidas, bool pRptFacturasEmitidas, bool pRptProyectos
            , bool pRptCotizaciones, bool pRptProyectosGastos, bool pRptProveedoresPagar
            , bool pchkFRVer, bool pchkFRAdd, bool pchkFREdit, bool pchkFRDel
            , bool pchkFEVer, bool pchkFEAdd, bool pchkFEEdit, bool pchkFEDel, bool pRptEficiencias, bool pRptMonitor, string pActivo, string pEsCCM, string pslctPuestoCCM, string pslctAreaCCM
            , bool pchkModuloPO, bool pchkCostoIndirecto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.UsuariosEditar == true || rolesUsuario.Tipo == "ROOT")
            {

                using (var DataControl = new SisaEntitie())
                {
                    var Usuario = DataControl.tblUsuarios.FirstOrDefault(u => u.IdUsuario.ToString() == pidUsuario);
                    if (Usuario != null)
                    {
                        Usuario.NombreCompleto = pNombreCompleto;
                        Usuario.Correo = pCorreoUsuario;
                        Usuario.Telefono = pTelefonoUsuario;
                        Usuario.Contrasena = pClaveUsuario;
                        Usuario.Usuario = pUsuario;
                        //Usuario.idSucursal = Guid.Parse(pSucursal);
                        Usuario.Puesto = pTipo;
                        Usuario.IdUsuarioModificacion = usuario.IdUsuario;
                        Usuario.FechaModificacion = DateTime.Now;
                        Usuario.Activo = Convert.ToInt32(pActivo);// == "ACTIVO" ? 1 : 0;
                        //Usuario.idSucursal = Guid.Parse(pSucursal);
                        
                        Usuario.SueldoDiario = pSalario == "" ? 0 :  decimal.Parse(pSalario);
                        Usuario.EsCCM = pEsCCM == "true" ? 1 : 0;

                        if (pEsCCM == "true")
                        {
                            Usuario.PuestoCCM = pslctPuestoCCM;
                        }
                        else
                        {
                            Usuario.PuestoCCM = "";
                        }

                        if (pslctPuestoCCM == "PM")
                        {
                            Usuario.AreaCCM = pslctAreaCCM;
                        }
                        else
                        {
                            Usuario.AreaCCM = "";
                        }

                        DataControl.SaveChanges();
                        var Roles = DataControl.tblRolesUsuarios.FirstOrDefault(r => r.idUsuarios.ToString() == pidUsuario);
                        if (Roles != null)
                        {
                            Roles.Tipo = pTipo;
                            Roles.ClienteEmpresa = pchkCliEmpVer;
                            Roles.ClienteEmpresaAgregar = pchkCliEmpAdd;
                            Roles.ClienteEmpresaEditar = pchkCliEmpEdit;
                            Roles.ClienteEmpresaEliminar = pchkCliEmpDel;
                            Roles.ClienteContacto = pchkCliConVer;
                            Roles.ClienteContactoAgrear = pchkCliConAdd;
                            Roles.ClienteContactoEditar = pchkCliConEdit;
                            Roles.ClienteContactoEliminar = pchkCliConDel;
                            Roles.RFQ = pchkRFQVer;
                            Roles.RFQAgregar = pchkRFQAdd;
                            Roles.RFQEditar = pchkRFQEdit;
                            Roles.RFQEliminar = pchkRFQDel;
                            Roles.Cotizaciones = pchkCotVer;
                            Roles.CotizacionesAgregar = pchkCotAdd;
                            Roles.CotizacionesEditar = pchkCotEdit;
                            Roles.CotizacionesEliminar = pchkCotDel;
                            Roles.Materiales = pchkMatVer;
                            Roles.MaterialesAgregar = pchkMatAdd;
                            Roles.MaterialesEditar = pchkMatEdit;
                            Roles.MaterialesEliminar = pchkMatDel;
                            Roles.Proveedores = pchkProvVer;
                            Roles.ProveedoresAgregar = pchkProvAdd;
                            Roles.ProveedoresEditar = pchkProvEdit;
                            Roles.ProveedoresEliminar = pchkProvDel;
                            Roles.Requisiciones = pchkRequiVer;
                            Roles.RequisicionesAgregar = pchkRequiAdd;
                            Roles.RequisicionesEditar = pchkRequiEdit;
                            Roles.RequisicionesEliminar = pchkRequiDel;
                            Roles.OC = pchkOCVer;
                            Roles.OCAgregar = pchkOCAdd;
                            Roles.OCEditar = pchkOCEdit;
                            Roles.OCEliminar = pchkOCDel;
                            Roles.Viaticos = pchkViaVer;
                            Roles.ViaticosAgregar = pchkViaAdd;
                            Roles.ViaticosEditar = pchkViaEdit;
                            Roles.ViaticosEliminar = pchkViaDel;
                            Roles.Proyectos = pchkProyVer;
                            Roles.ProyectosAgregar = pchkProyAdd;
                            Roles.ProyectosEditar = pchkProyEdit;
                            Roles.ProyectosEliminar = pchkProyDel;
                            Roles.CajaChica = pchkCajaVer;
                            Roles.CajaChicaAgregar = pchkCajaAdd;
                            Roles.CajaChicaEditar = pchkCajaEdit;
                            Roles.CajaChicaEliminar = pchkCajaDel;
                            Roles.CajaChicaCuautitlan = pchkCajaCuautitlan;
                            Roles.CajaChicaChihuahua = pchkCajaChihuahua;
                            Roles.CajaChicaUSA = pchkCajaUSA;
                            Roles.CajaChicaIrapuato = pchkCajaIrapuato;
                            Roles.CajaChicaQueretaro = pchkCajaQueretaro;
                            Roles.CajaChicaTecate = pchkCajaTecate;
                            Roles.Usuarios = pchkUserVer;
                            Roles.UsuariosAgregar = pchkUserAdd;
                            Roles.UsuariosEditar = pchkUserEdit;
                            Roles.UsuariosEliminar = pchkUserDel;
                            Roles.Sucursales = pchkSucVer;
                            Roles.SucursalesAgregar = pchkSucAdd;
                            Roles.SucursalesEditar = pchkSucEdit;
                            Roles.SucursalesEliminar = pchkSucDel;
                            Roles.ControlFacturas = pchkFacVer;
                            Roles.ControlDocumentos = pchkDocsAdd;
                            Roles.Administracion = pchkAdminVer;
                            Roles.Timming = pchkTimmEdit;
                            Roles.Boletines = pchkBoletines;
                            Roles.ServiciosCarro = pchkCarroVer;
                            Roles.Inventario = pchkInventaAdd;
                            Roles.ServiciosComputo = pchkPCAdd;
                            Roles.FacturasEmitidas = pchkFacVerEmitidas;
                            Roles.Reportes = pReportes;
                            Roles.rptOrdenCompra = pRptOrdenCompra;
                            Roles.rptFacturasRecibidas = pRptFacturasRecibidas;
                            Roles.rptFacturasEmitidas = pRptFacturasEmitidas;
                            Roles.rptProyectos = pRptProyectos;
                            Roles.rptCotizaciones = pRptCotizaciones;
                            Roles.rptProyectosGastos = pRptProyectosGastos;
                            Roles.rptProveedoresPagar = pRptProveedoresPagar;
                            Roles.FacRecibidas = pchkFRVer;
                            Roles.FacRecibidasAgregar = pchkFRAdd;
                            Roles.FacRecibidasEditar = pchkFREdit;
                            Roles.FacRecibidasEliminar = pchkFRDel;
                            Roles.FacEmitidas = pchkFEVer;
                            Roles.FacEmitidasAgregar = pchkFEAdd;
                            Roles.FacEmitidasEditar = pchkFEEdit;
                            Roles.FacEmitidasEliminar = pchkFEDel;
                            Roles.rptEficiencias = pRptEficiencias;
                            Roles.rptMonitor = pRptMonitor;
                            Roles.ModuloPO = pchkModuloPO;
                            Roles.CostoIndirecto = pchkCostoIndirecto;

                            DataControl.SaveChanges();
                            var Sucursales = DataControl.tblUsuarioSucursal.Where(r => r.IdUsuario.ToString() == pidUsuario);
                            if (Sucursales != null)
                            {
                                foreach (var d in Sucursales)
                                {
                                    DataControl.tblUsuarioSucursal.Remove(d);
                                }
                                
                                //DataControl.SaveChanges();
                                if (DataControl.SaveChanges() > 0)
                                {
                                    Guid cuautitlan = Guid.Parse("E8FB7D08-3E75-4DD4-9D6F-18A31886B638");
                                    Guid chihuahua = Guid.Parse("4327A1A3-B1F1-438A-9C89-081B2FB69D08");
                                    Guid usa = Guid.Parse("56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB");
                                    Guid hermosillo = Guid.Parse("E9D0B53B-D8B7-493A-B26D-FAF66D906157");
                                    Guid irapuato = Guid.Parse("AED5D6F1-86F9-4148-8A45-F97F4AD140A5");
                                    Guid queretaro = Guid.Parse("1479126E-06FA-4F4B-BA36-380CF73A6912");
                                    Guid tecate = Guid.Parse("F8E5400A-E1B5-4100-A990-E73E9DA59370");

                                    if (pchkCuautitlan)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = cuautitlan,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    if (pchkChihuahua)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = chihuahua,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    if (pchkUsa)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = usa,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    if (pchkHermosillo)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = hermosillo,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    if (pchkIrapuato)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = irapuato,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    if (pchkQueretaro)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = queretaro,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    if (pchkTecate)
                                    {
                                        tblUsuarioSucursal tblUsuarioSucursal = new tblUsuarioSucursal
                                        {
                                            IdUsuarioSucursal = Guid.NewGuid(),
                                            IdUsuario = Guid.Parse(pidUsuario),
                                            IdSucursal = tecate,
                                            FechaAlta = DateTime.Now
                                        };
                                        DataControl.tblUsuarioSucursal.Add(tblUsuarioSucursal);
                                    }
                                    DataControl.SaveChanges();
                                    retorno = "Usuario actualizado.";
                                }
                            }
                           
                        }
                        else
                        {
                            retorno = "No se pudo obtener información de permisos usuario seleccionado, recarga la página e intenta de nuevo.";
                        }
                        
                    }
                    else
                    {
                        retorno = "No se pudo obtener información de usuario seleccionado, recarga la página e intenta de nuevo.";
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de edición de usuarios.";
            }
            
            return retorno;
        }

        [WebMethod]
        public static string EliminarUsuarios(string pidUsuarios)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.UsuariosEliminar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Usuario = DataControl.tblUsuarios.FirstOrDefault(u => u.IdUsuario.ToString() == pidUsuarios);
                    if (Usuario != null)
                    {
                        Usuario.Activo = 0;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Usuario actualizado.";
                        }
                        else
                        {
                            retorno = "No se pudo dar de baja información de usuario seleccionado, recarga la página e intenta de nuevo.";

                        }
                    }
                    else
                    {
                        retorno = "No se pudo obtener información de usuario seleccionado, recarga la página e intenta de nuevo.";
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de dar de baja usuarios.";
            }
            
            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerUsuariosFoto(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Usuario = (from cl in DataControl.tblUsuarios
                               where cl.IdUsuario.ToString() == pid
                               select new
                               {
                                   cl.IdUsuario, cl.Foto

                               });
                retorno = JsonConvert.SerializeObject(Usuario);
            }


            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ActualizarUsuariosFoto(string pid, string pFoto)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var BuscaID = DataControl.tblUsuarios.FirstOrDefault(r => r.IdUsuario.ToString().Trim() == pid.Trim());
                if (BuscaID != null)
                {
                    BuscaID.Foto = pFoto;
                    int Cambios = DataControl.SaveChanges();
                    if (Cambios > 0)
                    {                       
                        retorno = "Datos guardados.";
                    }
                    else
                    {
                        retorno = "No se hicieron cambios, es la misma foto.";

                    }
                }
                else
                {
                    retorno = "Problema al guardar información, recarga la página.";

                }
            }


            return retorno;
        }


        [WebMethod]
        public static string ObtieneAreas()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var areas = (from a in DataControl.tblArea
                             where a.Activo == true
                             orderby a.Nombre ascending
                             select a);
                retorno = JsonConvert.SerializeObject(areas);
            }
            return retorno;
        }

        [WebMethod]
        public static string ObtieneSucursales(string IdUsuario)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var sucursales = (from a in DataControl.tblUsuarioSucursal
                             where a.IdUsuario.ToString() == IdUsuario
                             select a);
                retorno = JsonConvert.SerializeObject(sucursales);
            }
            return retorno;
        }
    }
}