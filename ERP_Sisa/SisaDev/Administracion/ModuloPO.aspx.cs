using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SisaDev.Models;
using System.Xml.Linq;
using System.Web.Services;
using System.Security;
using System.IO;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SisaDev.Administracion
{
    public partial class ModuloPO : System.Web.UI.Page
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
        public static string CargarModuloPO(string Opcion)
        {
            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectCostosIndirectos(Convert.ToInt32(Opcion), Convert.ToInt32(Sucursal)));
            //}

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {

                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaModuloPO());
            }
        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {
            string retorno = string.Empty;
            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectCostosIndirectos(Convert.ToInt32(Opcion), Convert.ToInt32(Sucursal)));
            //}

            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombos(Convert.ToInt32(Opcion)));
            //}

            if (Opcion == "1")
            {
                using (var DataControl = new SisaEntitie())
                {
                    //Guid id = Guid.Parse(Opcion);
                    var OCD = DataControl.tblMonedas.ToList();
                    retorno = JsonConvert.SerializeObject(OCD);
                }
            }

            if (Opcion == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    //Guid id = Guid.Parse(Opcion);
                    var estatus = new string[]{ "0", "1", "2", "3" };

                    var OCD = DataControl.tblProyectos.Where(d => d.Activo == 1).Select(d => new
                    {
                        Id = d.IdProyecto,
                        Nombre = d.FolioProyecto + "-" + d.NombreProyecto
                    }).OrderBy(a => a.Nombre);
                    retorno = JsonConvert.SerializeObject(OCD);
                }
            }

            if (Opcion == "3")
            {
                using (var DataControl = new SisaEntitie())
                {
                    //Guid id = Guid.Parse(Opcion);
                    var OCD = DataControl.tblEmpresas.Where(d => d.Estatus == true);
                    retorno = JsonConvert.SerializeObject(OCD);
                }
            }

            if (Opcion == "4")
            {
                using (var DataControl = new SisaEntitie())
                {
                    //Guid id = Guid.Parse(Opcion);
                    var OCD = DataControl.tblSucursales.Where(d => d.Estatus == true);
                    retorno = JsonConvert.SerializeObject(OCD);
                }
            }

            return retorno;
        }

        [WebMethod]
        public static string BuscarContactos(string IdCliente)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdCliente);
                var OCD = DataControl.tblClienteContacto.Where(d => d.idEmpresa == id);
                retorno = JsonConvert.SerializeObject(OCD);
            }
            return retorno;

        }

        [WebMethod]
        public static string BuscarCotizaciones(string IdCliente)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdCliente);
                var OCD = DataControl.tblCotizaciones.Where(d => d.IdEmpresa == id && d.Estatus != 2).Select(d => new
                {
                    Id = d.IdCotizaciones,
                    Folio = d.NoCotizaciones
                }).OrderBy(a => a.Folio);
                retorno = JsonConvert.SerializeObject(OCD);
            }
            return retorno;

        }

        [WebMethod]
        public static string VerModuloPO(string pIdModuloPO)
        {
            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectCostosIndirectos(Convert.ToInt32(Opcion), Convert.ToInt32(Sucursal)));
            //}

            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCostosIndirectos(FechaIni, FechaFin));
            //}

            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(pIdModuloPO);
                if (rolesUsuarios.Tipo == "ROOT")
                {
                    var moduloPO = DataControl.tblModuloPO.Where(s => s.IdModuloPO == id);
                    retorno = JsonConvert.SerializeObject(moduloPO);
                }

            }

            return retorno;
        }

        [WebMethod]
        public static string GuardarPO(string pIdModuloPO, string pFecha, string pOrdenCompra, string pIdCliente
            , string pIdRequisitor, string pComprador, string pMonto
            , string pIdMoneda, string pMarkUp, string pIdCotizacion, string pEstatus, string pIdSucursal)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.Tipo == "ROOT")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if (pIdModuloPO == "0")
                        {
                            tblModuloPO add = new tblModuloPO
                            {
                                IdModuloPO = Guid.NewGuid(),
                                Fecha = DateTime.Parse(pFecha),
                                FolioPO = pOrdenCompra,
                                IdCliente = Guid.Parse(pIdCliente),
                                Contacto = pIdRequisitor,
                                Comprador = pComprador,
                                Monto = pMonto != "" ? Decimal.Parse(pMonto) : Decimal.Parse("0"),
                                IdMoneda = Guid.Parse(pIdMoneda),
                                Estatus = pEstatus,
                                MarkUP = Int32.Parse(pMarkUp),
                                FechaAlta = DateTime.Now,
                                IdUsuarioAlta = usuario.IdUsuario,
                                FechaModificacion = DateTime.Now,
                                IdUsuarioModificacion = usuario.IdUsuario,
                                IdSucursal = Guid.Parse(pIdSucursal),
                                Activo = true
                                
                            };
                            DataControl.tblModuloPO.Add(add);
                            if (DataControl.SaveChanges() > 0)
                            {
                                var existePO = DataControl.tblModuloPO.FirstOrDefault(p => p.IdModuloPO == add.IdModuloPO);
                                if (existePO != null)
                                {
                                    if (pIdCotizacion != "-1")
                                    {
                                        existePO.NoCotizacion = pIdCotizacion;
                                    }
                                    DataControl.SaveChanges();
                                    
                                }
                            }
                            
                        }
                        else
                        {
                            var existePO = DataControl.tblModuloPO.FirstOrDefault(p => p.IdModuloPO.ToString() == pIdModuloPO);
                            if (existePO != null)
                            {
                                existePO.Fecha = DateTime.Parse(pFecha);
                                existePO.FolioPO = pOrdenCompra;
                                existePO.MarkUP = Int32.Parse(pMarkUp);
                                existePO.IdCliente = Guid.Parse(pIdCliente);
                                existePO.Contacto = pIdRequisitor;
                                existePO.Comprador = pComprador;
                                existePO.NoCotizacion = pIdCotizacion;
                                existePO.Monto = pMonto != "" ? Decimal.Parse(pMonto) : Decimal.Parse("0");
                                existePO.IdMoneda = Guid.Parse(pIdMoneda);
                                existePO.Estatus = pEstatus;
                                existePO.FechaModificacion = DateTime.Now;
                                existePO.IdUsuarioModificacion = usuario.IdUsuario;
                                existePO.IdSucursal = Guid.Parse(pIdSucursal);
                                DataControl.SaveChanges();
                            }
                        }
                        


                        retorno = "Datos Guardados.";
                    }
                }
                else
                {
                    retorno = "No tienes permiso.";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarDocumentos(string IdModuloPO, string FileName, string fileSize, string filetype, string fileExtension, string Archivo)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {

                using (var DataControl = new SisaEntitie())
                {
                    //int a = Convert.ToInt32(Opcion);
                    Guid idModuloPO = Guid.Parse(IdModuloPO);
                    tblModuloPOArchivos add = new tblModuloPOArchivos
                    {
                        IdArchivoPO = Guid.NewGuid(),
                        IdModuloPO = idModuloPO,
                        NombreArchivo = FileName,
                        FileExtension = fileExtension,
                        FileSize = fileSize,
                        FileContentType = filetype,
                        Archivo = Archivo,
                        Fecha = DateTime.Now,
                        IdUsuario = usuario.IdUsuario

                    };
                    DataControl.tblModuloPOArchivos.Add(add);
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
        public static string CargarDocumentos(string IdModuloPO, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                int a = Convert.ToInt32(Opcion);
                using (var DataControl = new SisaEntitie())
                {
                    Guid id = Guid.Parse(IdModuloPO);
                    var OCD = DataControl.tblModuloPOArchivos.Where(d => d.IdModuloPO == id);
                    retorno = JsonConvert.SerializeObject(OCD);
                    //var Filtrado = DataControl.sp_SelectDocumentosOrdenCompra(IdModuloPO);
                    //retorno = JsonConvert.SerializeObject(Filtrado);
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string EliminarDocumento(string IdArchivoPO)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var archivoPO = DataControl.tblModuloPOArchivos.FirstOrDefault(p => p.IdArchivoPO.ToString() == IdArchivoPO);
                        if (archivoPO != null)
                        {
                            DataControl.tblModuloPOArchivos.Remove(archivoPO);
                            DataControl.SaveChanges();
                            retorno = "Documento eliminado.";
                        }
                        else
                        {
                            retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                        }

                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                retorno = "No tienes permiso de edición.";
            }
            return retorno;
        }

        [WebMethod]
        public static string EliminarModuloPO(string IdModuloPO)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ModuloPO == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var moduloPO = DataControl.tblModuloPO.FirstOrDefault(p => p.IdModuloPO.ToString() == IdModuloPO);
                        if (moduloPO != null)
                        {
                            moduloPO.Activo = false;
                            moduloPO.FechaEliminado = DateTime.Now;
                            moduloPO.IdUsuarioEliminado = usuario.IdUsuario;
                            DataControl.SaveChanges();
                            retorno = "ModuloPO eliminado.";
                        }
                        else
                        {
                            retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                        }

                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                retorno = "No tienes permiso de edición.";
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarFiltrosBuscar(string Opcion)
        {
            string str = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                if (Opcion == "7")
                {
                    //str = JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombosFacturasEmitidas(new int?(int32)));

                    str = JsonConvert.SerializeObject((object)((IQueryable<tblMonedas>)sisaEntitie.tblMonedas).OrderBy<tblMonedas, string>((Expression<Func<tblMonedas, string>>)(d => d.Moneda)).Select(d => new
                    {
                        Id = d.Abreviatura,
                        Nombre = d.Moneda
                    }).Distinct());
                }

                else if (Opcion == "26")
                    str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(d => d.Activo == (int?)1)).Select(d => new
                    {
                        Id = d.IdProyecto,
                        Nombre = d.FolioProyecto + "-" + d.NombreProyecto
                    }).OrderBy(a => a.Nombre));
                else if (Opcion == "12")
                    str = JsonConvert.SerializeObject((object)((IQueryable<DateDimension>)sisaEntitie.DateDimension).Where<DateDimension>((Expression<Func<DateDimension, bool>>)(d => d.Year <= DateTime.Now.Year)).Select(d => new
                    {
                        Id = d.Year,
                        Nombre = d.Year
                    }).Distinct().OrderByDescending(a => a.Nombre));
                else if (Opcion == "13")
                {

                    str = JsonConvert.SerializeObject((from m in sisaEntitie.tblModuloPO
                           join em in sisaEntitie.tblEmpresas on m.IdCliente equals em.idEmpresa
                           select new { m.IdCliente, em.Cliente }).Distinct().OrderBy(a => a.Cliente));
                }
                else if (Opcion == "1")
                {

                    str = JsonConvert.SerializeObject(sisaEntitie.tblModuloPO.Where(d => d.Activo == true).Select(d => new 
                    {
                        Id = d.Comprador,
                        Nombre = d.Comprador
                    }).Distinct().OrderBy(d => d.Id));
                }
                else if (Opcion == "2")
                {

                    str = JsonConvert.SerializeObject(sisaEntitie.tblModuloPO.Where(d => d.Activo == true).Select(d => new
                    {
                        Id = d.Contacto,
                        Nombre = d.Contacto
                    }).Distinct().OrderBy(d => d.Id));
                }

                else if (Opcion == "3")
                {

                    str = JsonConvert.SerializeObject((object)((IQueryable<DateDimension>)sisaEntitie.DateDimension).Where<DateDimension>((Expression<Func<DateDimension, bool>>)(d => d.Year <= DateTime.Now.Year)).Select(d => new
                    {
                        Id = d.Month,
                        Nombre = d.MonthName
                    }).Distinct().OrderBy(a => a.Id));
                }

            }
            return str;
        }

        [WebMethod]
        public static string CargarModuloPOBuscar(string pid, string AnioBuscar, string ClienteBuscar, string ProyectoEmitidaBuscar, string MonedaEmitidaBuscar
                , string Requisitor, string Comprador, string Estatus, string Mes, string MarkUp)
        {
            string empty = string.Empty;
            if (AnioBuscar == "null")
            {
                AnioBuscar = "-1";
            }

            if (ClienteBuscar == "null")
            {
                ClienteBuscar = "-1";
            }

            if (ProyectoEmitidaBuscar == "null")
            {
                ProyectoEmitidaBuscar = "-1";
            }

            if (MonedaEmitidaBuscar == "null")
            {
                MonedaEmitidaBuscar = "-1";
            }

            if (Requisitor == "null")
            {
                Requisitor = "-1";
            }

            if (Comprador == "null")
            {
                Comprador = "-1";
            }

            if (Estatus == "null")
            {
                Estatus = "-1";
            }

            if (MarkUp == "null")
            {
                MarkUp = "-1";
            }

            if (Mes == "null")
            {
                Mes = "-1";
            }

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("JT_LoadModuloPO", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Anio", (object)AnioBuscar);
            sqlCommand.Parameters.AddWithValue("@Cliente", (object)ClienteBuscar);
            sqlCommand.Parameters.AddWithValue("@IdProyecto", (object)ProyectoEmitidaBuscar);
            sqlCommand.Parameters.AddWithValue("@Moneda", (object)MonedaEmitidaBuscar);
            sqlCommand.Parameters.AddWithValue("@Requisitor", (object)Requisitor);
            sqlCommand.Parameters.AddWithValue("@Comprador", (object)Comprador);
            sqlCommand.Parameters.AddWithValue("@Estatus", (object)Estatus);
            sqlCommand.Parameters.AddWithValue("@MarkUP", (object)MarkUp);
            sqlCommand.Parameters.AddWithValue("@Mes", (object)Mes);
            DataTable dataTable = new DataTable();
            dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
            return JsonConvert.SerializeObject((object)dataTable);
        }

        [WebMethod]
        public static string CargarResumenPO(string anio, string cliente, string proyecto, string moneda
                , string requisitor, string comprador, string estatus, string mes, string markup)
        {
            string retorno = string.Empty;

            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (anio == "null")
                    {
                        anio = "-1";
                    }

                    if (cliente == "null")
                    {
                        cliente = "-1";
                    }

                    if (proyecto == "null")
                    {
                        proyecto = "-1";
                    }

                    if (moneda == "null")
                    {
                        moneda = "-1";
                    }

                    if (requisitor == "null")
                    {
                        requisitor = "-1";
                    }

                    if (comprador == "null")
                    {
                        comprador = "-1";
                    }

                    if (estatus == "null")
                    {
                        estatus = "-1";
                    }

                    if (markup == "null")
                    {
                        markup = "-1";
                    }

                    if (mes == "null")
                    {
                        mes = "-1";
                    }

                    //int e = Convert.ToInt32(estatus);
                    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ResumenTotalesMofuloPO", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", (object)anio);
                    command.Parameters.AddWithValue("@Cliente", (object)cliente);
                    command.Parameters.AddWithValue("@IdProyecto", (object)proyecto);
                    command.Parameters.AddWithValue("@Moneda", (object)moneda);
                    command.Parameters.AddWithValue("@Requisitor", (object)requisitor);
                    command.Parameters.AddWithValue("@Comprador", (object)comprador);
                    command.Parameters.AddWithValue("@Estatus", (object)estatus);
                    command.Parameters.AddWithValue("@MarkUP", (object)markup);
                    command.Parameters.AddWithValue("@Mes", (object)mes);


                    DataTable dt = new DataTable();

                    dt.Load(command.ExecuteReader());

                    return JsonConvert.SerializeObject(dt);
                    //retorno = JsonConvert.SerializeObject(DataControl.sp_ResumenTotalesFacturasEmitidas(anio,cliente,proyecto,moneda,e));
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

    }
}