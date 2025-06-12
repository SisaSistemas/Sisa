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
using System.Web.UI.WebControls;

namespace SisaDev.Admin
{
    public partial class CajaChica : System.Web.UI.Page
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
        public static string ObtenerCC(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            if (pid.Trim() == "2")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    str = JsonConvert.SerializeObject((object)((IQueryable<tblCajaChica>)sisaEntitie.tblCajaChica).Select<tblCajaChica, tblCajaChica>((Expression<Func<tblCajaChica, tblCajaChica>>)(s => s)));
                }
                    
            }
            if (rolesUsuarios.CajaChica || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject((object)((IEnumerable<JT_LoadCajaChica_Result>)sisaEntitie.JT_LoadCajaChica()).Where<JT_LoadCajaChica_Result>((Func<JT_LoadCajaChica_Result, bool>)(s =>
                        {
                            int? estatus7 = s.Estatus;
                            int num7 = 0;
                            if (estatus7.GetValueOrDefault() == num7 & estatus7.HasValue)
                                return true;
                            int? estatus8 = s.Estatus;
                            int num8 = 1;
                            return estatus8.GetValueOrDefault() == num8 & estatus8.HasValue;
                        })));
                    }
                        
                }
                else
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject((object)((IQueryable<tblCajaChica>)sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>)(s => s.IdCajaChica.ToString() == pid)));
                    }
                        
                }
            }
            else
                str = "No tienes permiso,";
            return str;
        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                int op = Convert.ToInt32(Opcion);

                retorno = JsonConvert.SerializeObject(DataControl.sp_CargaCombos(op));
            }
            return retorno;

        }

        [WebMethod]
        public static string EliminarCC(string pid)
        {
            string str = string.Empty;
            CajaChica.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            CajaChica.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (CajaChica.rolesUsuarios.CajaChicaEliminar || CajaChica.rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblCajaChica tblCajaChica = ((IQueryable<tblCajaChica>)sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>)(s => s.IdCajaChica.ToString() == pid));
                    if (tblCajaChica != null)
                    {
                        sisaEntitie.tblCajaChica.Remove(tblCajaChica);
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(a => a.idDocumento == pid));
                            if (eficienciasDesglose != null)
                            {
                                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                                sisaEntitie.SaveChanges();
                            }
                            str = "Informacion eliminada.";
                        }
                        else
                            str = "Ocurrio un problema al eliminar información.";
                    }
                    else
                        str = "Ocurrio un problema al obtener información seleccionada.";
                }
            }
            else
                str = "No tienes permiso de eliminar información.";
            return str;
        }

        [WebMethod]
        public static string GuardarCC(string Responsable, string Concepto, string pidproyecto, string Proyecto, string Comprobante, string Cargo, string Abono, string Fecha, string Estatus, string Tipo, string pid, string Categoria, string CampoExtra, string OC, string nombrearchivo, string dataarchivo)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            
            if (Tipo == "1")
            {
                if (rolesUsuarios.CajaChicaAgregar || rolesUsuarios.Tipo == "ROOT")
                {
                    if (pidproyecto == "1")
                        pidproyecto = "";
                    else
                        Guid.Parse(pidproyecto);

                    int int32 = Convert.ToInt32(Estatus);
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblCajaChica add = new tblCajaChica()
                        {
                            IdCajaChica = Guid.NewGuid(),
                            FechaAlta = DateTime.Now,
                            Responsable = Responsable,
                            Concepto = Concepto,
                            Proyecto = Proyecto,
                            Comprobante = Comprobante,
                            Cargo = Decimal.Parse(Cargo),
                            Abono = Decimal.Parse(Abono),
                            Fecha = DateTime.Parse(Fecha),
                            Estatus = new int?(int32),
                            IdProyecto = pidproyecto,
                            Categoria = Categoria,
                            CampoExtra = CampoExtra,
                            FolioOrdenCompra = OC,
                            NombreArchivo = nombrearchivo,
                            Archivo = dataarchivo,
                            IdUsuarioAlta = usuario.IdUsuario,
                            IdUsuarioModifica = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now
                        };
                        sisaEntitie.tblCajaChica.Add(add);
                        //sisaEntitie.SaveChanges();
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            if (nombrearchivo != "")
                            {
                                if (!Directory.Exists(@"C:\SisaFiles\CajaChica\"))
                                {
                                    Directory.CreateDirectory(@"C:\SisaFiles\CajaChica\");
                                }

                                if (System.IO.File.Exists(@"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo))
                                {
                                    System.IO.File.Delete(@"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo);
                                }

                                string[] completo64 = dataarchivo.Split(',');
                                //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                string archivo = @"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                {
                                    Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                }
                            }
                            
                        }
                        Decimal num = Cargo == "0" ? Decimal.Parse(Abono) : Decimal.Parse(Cargo);
                        if (!(Categoria == "N/A"))
                        {
                            tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(e => e.idDocumento == add.IdCajaChica.ToString()));
                            if (eficienciasDesglose1 != null)
                            {
                                eficienciasDesglose1.idProyecto = pidproyecto;
                                eficienciasDesglose1.idDocumento = add.IdCajaChica.ToString();
                                eficienciasDesglose1.Categoria = Categoria.ToUpper();
                                eficienciasDesglose1.Total = new Decimal?(num);
                                eficienciasDesglose1.TipoDoc = "CC";
                                sisaEntitie.SaveChanges();
                            }
                            else
                            {
                                tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
                                {
                                    idProyecto = pidproyecto,
                                    idDocumento = add.IdCajaChica.ToString(),
                                    Categoria = Categoria.ToUpper(),
                                    Total = new Decimal?(num),
                                    TipoDoc = "CC",
                                    Folio = "",
                                    FechaDoc = new DateTime?(add.FechaAlta),
                                    idUsuarioUltimo = CajaChica.usuario.IdUsuario.ToString()
                                };
                                sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose2);
                                sisaEntitie.SaveChanges();
                            }
                        }
                        str = "Informacion actualizada.";
                    }
                }
                else
                    str = "No tienes permiso de agregar información.";
            }
            else if (Tipo == "2")
            {
                if (rolesUsuarios.CajaChicaEditar)
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblCajaChica Existe = ((IQueryable<tblCajaChica>)sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>)(a => a.IdCajaChica.ToString() == pid));
                        if (Existe != null)
                        {
                            int int32 = Convert.ToInt32(Estatus);
                            Existe.Responsable = Responsable;
                            Existe.Concepto = Concepto;
                            Existe.Cargo = Decimal.Parse(Cargo);
                            Existe.Abono = Decimal.Parse(Abono);
                            Existe.Estatus = new int?(int32);
                            Existe.Categoria = Categoria;
                            Existe.CampoExtra = CampoExtra;
                            Existe.Comprobante = Comprobante;
                            Decimal num = Cargo == "0.00" ? Decimal.Parse(Abono) : Decimal.Parse(Cargo);
                            Existe.IdProyecto = pidproyecto;
                            Existe.Proyecto = Proyecto;
                            Existe.FolioOrdenCompra = OC;
                            Existe.Archivo = dataarchivo;
                            Existe.NombreArchivo = nombrearchivo;
                            Existe.IdUsuarioModifica = usuario.IdUsuario;
                            Existe.FechaModificacion = DateTime.Now;
                            //sisaEntitie.SaveChanges();
                            if (sisaEntitie.SaveChanges() > 0)
                            {
                                if (!Directory.Exists(@"C:\SisaFiles\CajaChica\"))
                                {
                                    Directory.CreateDirectory(@"C:\SisaFiles\CajaChica\");
                                }

                                if (System.IO.File.Exists(@"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo))
                                {
                                    System.IO.File.Delete(@"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo);
                                }

                                string[] completo64 = dataarchivo.Split(',');
                                //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                string archivo = @"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                {
                                    Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                }
                            }
                            if (!(Categoria == "N/A"))
                            {
                                tblEficienciasDesglose eficienciasDesglose3 = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(e => e.idDocumento == Existe.IdCajaChica.ToString()));
                                if (eficienciasDesglose3 != null)
                                {
                                    eficienciasDesglose3.idProyecto = pidproyecto;
                                    eficienciasDesglose3.idDocumento = Existe.IdCajaChica.ToString();
                                    eficienciasDesglose3.Categoria = Categoria.ToUpper();
                                    eficienciasDesglose3.Total = new Decimal?(num);
                                    eficienciasDesglose3.TipoDoc = "CC";
                                    sisaEntitie.SaveChanges();
                                }
                                else
                                {
                                    tblEficienciasDesglose eficienciasDesglose4 = new tblEficienciasDesglose()
                                    {
                                        idProyecto = pidproyecto,
                                        idDocumento = Existe.IdCajaChica.ToString(),
                                        Categoria = Categoria.ToUpper(),
                                        Total = new Decimal?(num),
                                        TipoDoc = "CC",
                                        Folio = "",
                                        FechaDoc = new DateTime?(Existe.FechaAlta),
                                        idUsuarioUltimo = CajaChica.usuario.IdUsuario.ToString()
                                    };
                                    sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose4);
                                    sisaEntitie.SaveChanges();
                                }
                            }
                            str = "Informacion actualizada.";
                        }
                        else
                            str = "No se pudo obtener información, recarga página e intenta de nuevo.";
                    }
                }
                else
                    str = "No tienes permiso de editar información.";
            }
            return str;
        }

        [WebMethod]
        public static string CargarOC(string pid)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                Guid id = Guid.Parse(pid);
                return JsonConvert.SerializeObject((object)((IQueryable<tblOrdenCompra>)sisaEntitie.tblOrdenCompra).Where<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>)(a => a.IdProyecto == id)).Select(a => new
                {
                    Folio = a.Folio.ToUpper(),
                    TipoOC = a.TipoOC.ToUpper()
                }).Union(((IQueryable<tblOrdenCompraInsumos>)sisaEntitie.tblOrdenCompraInsumos).Where<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>)(b => b.IdProyecto.ToString() == id.ToString())).Select(b => new
                {
                    Folio = b.Folio.ToUpper(),
                    TipoOC = "MATERIAL"
                })));
            }

        }

        [WebMethod]
        public static string EliminarDocumentos(string IdCajaChica)
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
                        var cajaChica = DataControl.tblCajaChica.FirstOrDefault(p => p.IdCajaChica.ToString() == IdCajaChica);
                        if (cajaChica != null)
                        {
                            cajaChica.NombreArchivo = "";
                            cajaChica.Archivo = "";
                            DataControl.SaveChanges();
                            retorno = "Documento y/o Foto eliminado.";
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
        public static string GuardarImagenTarea(string IdCajaChica, string FileName, string FileSize, string FileType, string File)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {


                using (var DataControl = new SisaEntitie())
                {
                    Guid cajaChica = Guid.Parse(IdCajaChica);
                    tblCajaChicaDocumentos add = new tblCajaChicaDocumentos
                    {
                        IdDocumentoCC = Guid.NewGuid(),
                        IdCajaChica = cajaChica,
                        FileName = FileName,
                        File = File,
                        Fecha = DateTime.Now
                    };
                    DataControl.tblCajaChicaDocumentos.Add(add);
                    DataControl.SaveChanges();
                    
                }

                if (!Directory.Exists(@"C:\SisaFiles\CajaChica\"))
                {
                    Directory.CreateDirectory(@"C:\SisaFiles\CajaChica\");
                }

                if (System.IO.File.Exists(@"C:\SisaFiles\CajaChica\" + @"\" + FileName))
                {
                    System.IO.File.Delete(@"C:\SisaFiles\CajaChica\" + @"\" + FileName);
                }

                string[] completo64 = File.Split(',');
                //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                string archivo = @"C:\SisaFiles\CajaChica\" + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                {
                    Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                }

                retorno = "Archivo guardado";
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentos(string IdDocumento, string IdCajaChica, string FileName, string File, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                int a = Convert.ToInt32(Opcion);
                using (var DataControl = new SisaEntitie())
                {
                    var Filtrado = DataControl.sp_InsertDeleteDocumentosProyecto(IdDocumento, IdCajaChica, FileName, File, "", a);
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
                    var docu = DataControl.tblCajaChicaDocumentos.FirstOrDefault(a => a.IdDocumentoCC.ToString() == id);
                    if (docu != null)
                    {
                        if (!string.IsNullOrEmpty(docu.FileName) && !string.IsNullOrEmpty(docu.File))
                        {
                            string[] completo64 = docu.File.Split(',');
                            //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Administracion\\docs\\" + docu.FileName;
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
        public static string EliminarDocumento(string IdDocumento, string NombreArchivo)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {

                    tblCajaChicaDocumentos entity = DataControl.tblCajaChicaDocumentos.FirstOrDefault<tblCajaChicaDocumentos>((v => v.IdDocumentoCC.ToString() == IdDocumento));
                    if (entity != null)
                    {
                        DataControl.tblCajaChicaDocumentos.Remove(entity);
                        DataControl.SaveChanges();
                        retorno = "Documento eliminado.";

                        if (System.IO.File.Exists(@"C:\SisaFiles\CajaChica\" + @"\" + NombreArchivo))
                        {
                            System.IO.File.Delete(@"C:\SisaFiles\CajaChica\" + @"\" + NombreArchivo);
                        }

                        if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Administracion\\docs\\" + NombreArchivo))
                        {
                            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "Administracion\\docs\\" + NombreArchivo);
                        }
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
        public static string BuscarSucursalInsumo(string IdSucursal)
        {
            string str = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {

                Guid id = Guid.Parse(IdSucursal);
                return JsonConvert.SerializeObject((object)(sisaEntitie.tblProyectosInsumos).Where(d => d.IdSucursal == id && d.EsCarro == 0).OrderBy(a => a.Descripcion)); ;
            }
        }

        [WebMethod]
        public static string GuardarCCSucursal(string Concepto, string Fecha, string IdSucursal, string Sucursal, string Responsable, string Comprobante, string pidproyecto, string Proyecto, string Cargo, string Abono, string Estatus, string Tipo, string nombrearchivo, string dataarchivo)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            if (Tipo == "1")
            {
                if (rolesUsuarios.CajaChicaAgregar || rolesUsuarios.Tipo == "ROOT")
                {
                    //if (pidproyecto == "1")
                    //    pidproyecto = "";
                    //else
                    //    Guid.Parse(pidproyecto);

                    int int32 = Convert.ToInt32(Estatus);
                    var idCajaChica = Guid.NewGuid();
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblCajaChica add = new tblCajaChica()
                        {
                            IdCajaChica = idCajaChica,
                            FechaAlta = DateTime.Now,
                            Responsable = Responsable,
                            Concepto = Concepto,
                            Proyecto = Proyecto,
                            Comprobante = Comprobante,
                            Cargo = Decimal.Parse(Cargo),
                            Abono = Decimal.Parse(Abono),
                            Fecha = DateTime.Parse(Fecha),
                            Estatus = new int?(int32),
                            IdProyecto = pidproyecto,
                            Categoria = "N/A",
                            CampoExtra = "",
                            FolioOrdenCompra = "N/A",
                            NombreArchivo = nombrearchivo,
                            Archivo = dataarchivo,
                            IdUsuarioAlta = usuario.IdUsuario,
                            IdUsuarioModifica = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now
                        };
                        sisaEntitie.tblCajaChica.Add(add);
                        //sisaEntitie.SaveChanges();
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            /*CUAUTITLAN*/
                            if (IdSucursal.ToUpper() == "E8FB7D08-3E75-4DD4-9D6F-18A31886B638")
                            {
                                tblCajaChicaCuautitlan tblCajaChicaCuautitlan = new tblCajaChicaCuautitlan()
                                {
                                    IdCajaChicaCuautitlan = Guid.NewGuid(),
                                    FechaAlta = DateTime.Now,
                                    Responsable = Responsable,
                                    Concepto = Concepto,
                                    Proyecto = Proyecto,
                                    Comprobante = Comprobante,
                                    Cargo = Decimal.Parse(Abono),
                                    Abono = Decimal.Parse(Cargo),
                                    Fecha = DateTime.Parse(Fecha),
                                    Estatus = new int?(int32),
                                    IdProyecto = pidproyecto,
                                    Categoria = "N/A",
                                    CampoExtra = "",
                                    FolioOrdenCompra = "N/A",
                                    NombreArchivo = nombrearchivo,
                                    Archivo = dataarchivo,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    IdUsuarioModifica = usuario.IdUsuario,
                                    FechaModificacion = DateTime.Now
                                };
                                sisaEntitie.tblCajaChicaCuautitlan.Add(tblCajaChicaCuautitlan);
                                sisaEntitie.SaveChanges();

                                if (nombrearchivo != "")
                                {
                                    if (!Directory.Exists(@"C:\SisaFiles\CajaChicaCuautitlan\"))
                                    {
                                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaCuautitlan\");
                                    }

                                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaCuautitlan\" + @"\" + dataarchivo))
                                    {
                                        System.IO.File.Delete(@"C:\SisaFiles\CajaChicaCuautitlan\" + @"\" + dataarchivo);
                                    }

                                    string[] completo64 = dataarchivo.Split(',');
                                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    string archivo = @"C:\SisaFiles\CajaChicaCuautitlan\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }

                            /*CHIHUAHUA*/
                            if (IdSucursal.ToUpper() == "4327A1A3-B1F1-438A-9C89-081B2FB69D08")
                            {
                                tblCajaChicaChihuahua tblCajaChicaChihuahua = new tblCajaChicaChihuahua()
                                {
                                    IdCajaChicaChihuahua = Guid.NewGuid(),
                                    FechaAlta = DateTime.Now,
                                    Responsable = Responsable,
                                    Concepto = Concepto,
                                    Proyecto = Proyecto,
                                    Comprobante = Comprobante,
                                    Cargo = Decimal.Parse(Abono),
                                    Abono = Decimal.Parse(Cargo),
                                    Fecha = DateTime.Parse(Fecha),
                                    Estatus = new int?(int32),
                                    IdProyecto = pidproyecto,
                                    Categoria = "N/A",
                                    CampoExtra = "",
                                    FolioOrdenCompra = "N/A",
                                    NombreArchivo = nombrearchivo,
                                    Archivo = dataarchivo,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    IdUsuarioModifica = usuario.IdUsuario,
                                    FechaModificacion = DateTime.Now
                                };
                                sisaEntitie.tblCajaChicaChihuahua.Add(tblCajaChicaChihuahua);
                                sisaEntitie.SaveChanges();

                                if (nombrearchivo != "")
                                {
                                    if (!Directory.Exists(@"C:\SisaFiles\CajaChicaChihuahua\"))
                                    {
                                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaChihuahua\");
                                    }

                                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaChihuahua\" + @"\" + dataarchivo))
                                    {
                                        System.IO.File.Delete(@"C:\SisaFiles\CajaChicaChihuahua\" + @"\" + dataarchivo);
                                    }

                                    string[] completo64 = dataarchivo.Split(',');
                                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    string archivo = @"C:\SisaFiles\CajaChicaChihuahua\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }

                            /*USA*/
                            if (IdSucursal.ToUpper() == "56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB")
                            {
                                tblCajaChicaUSA tblCajaChicaUSA = new tblCajaChicaUSA()
                                {
                                    IdCajaChicaUsa = Guid.NewGuid(),
                                    FechaAlta = DateTime.Now,
                                    Responsable = Responsable,
                                    Concepto = Concepto,
                                    Proyecto = Proyecto,
                                    Comprobante = Comprobante,
                                    Cargo = Decimal.Parse(Abono),
                                    Abono = Decimal.Parse(Cargo),
                                    Fecha = DateTime.Parse(Fecha),
                                    Estatus = new int?(int32),
                                    IdProyecto = pidproyecto,
                                    Categoria = "N/A",
                                    CampoExtra = "",
                                    FolioOrdenCompra = "N/A",
                                    NombreArchivo = nombrearchivo,
                                    Archivo = dataarchivo,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    IdUsuarioModifica = usuario.IdUsuario,
                                    FechaModificacion = DateTime.Now
                                };
                                sisaEntitie.tblCajaChicaUSA.Add(tblCajaChicaUSA);
                                sisaEntitie.SaveChanges();

                                if (nombrearchivo != "")
                                {
                                    if (!Directory.Exists(@"C:\SisaFiles\CajaChicaUSA\"))
                                    {
                                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaUSA\");
                                    }

                                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaUSA\" + @"\" + dataarchivo))
                                    {
                                        System.IO.File.Delete(@"C:\SisaFiles\CajaChicaUSA\" + @"\" + dataarchivo);
                                    }

                                    string[] completo64 = dataarchivo.Split(',');
                                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    string archivo = @"C:\SisaFiles\CajaChicaUSA\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }

                            /*IRAPUATO*/
                            if (IdSucursal.ToUpper() == "AED5D6F1-86F9-4148-8A45-F97F4AD140A5")
                            {
                                tblCajaChicaIrapuato tblCajaChicaIrapuato = new tblCajaChicaIrapuato()
                                {
                                    IdCajaChicaIrapuato = Guid.NewGuid(),
                                    FechaAlta = DateTime.Now,
                                    Responsable = Responsable,
                                    Concepto = Concepto,
                                    Proyecto = Proyecto,
                                    Comprobante = Comprobante,
                                    Cargo = Decimal.Parse(Abono),
                                    Abono = Decimal.Parse(Cargo),
                                    Fecha = DateTime.Parse(Fecha),
                                    Estatus = new int?(int32),
                                    IdProyecto = pidproyecto,
                                    Categoria = "N/A",
                                    CampoExtra = "",
                                    FolioOrdenCompra = "N/A",
                                    NombreArchivo = nombrearchivo,
                                    Archivo = dataarchivo,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    IdUsuarioModifica = usuario.IdUsuario,
                                    FechaModificacion = DateTime.Now
                                };
                                sisaEntitie.tblCajaChicaIrapuato.Add(tblCajaChicaIrapuato);
                                sisaEntitie.SaveChanges();

                                if (nombrearchivo != "")
                                {
                                    if (!Directory.Exists(@"C:\SisaFiles\CajaChicaIrapuato\"))
                                    {
                                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaIrapuato\");
                                    }

                                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaIrapuato\" + @"\" + dataarchivo))
                                    {
                                        System.IO.File.Delete(@"C:\SisaFiles\CajaChicaIrapuato\" + @"\" + dataarchivo);
                                    }

                                    string[] completo64 = dataarchivo.Split(',');
                                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    string archivo = @"C:\SisaFiles\CajaChicaIrapuato\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }

                            /*QUERETARO*/
                            if (IdSucursal.ToUpper() == "1479126E-06FA-4F4B-BA36-380CF73A6912")
                            {
                                tblCajaChicaQueretaro tblCajaChicaQueretaro = new tblCajaChicaQueretaro()
                                {
                                    IdCajaChicaQueretaro = Guid.NewGuid(),
                                    FechaAlta = DateTime.Now,
                                    Responsable = Responsable,
                                    Concepto = Concepto,
                                    Proyecto = Proyecto,
                                    Comprobante = Comprobante,
                                    Cargo = Decimal.Parse(Abono),
                                    Abono = Decimal.Parse(Cargo),
                                    Fecha = DateTime.Parse(Fecha),
                                    Estatus = new int?(int32),
                                    IdProyecto = pidproyecto,
                                    Categoria = "N/A",
                                    CampoExtra = "",
                                    FolioOrdenCompra = "N/A",
                                    NombreArchivo = nombrearchivo,
                                    Archivo = dataarchivo,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    IdUsuarioModifica = usuario.IdUsuario,
                                    FechaModificacion = DateTime.Now
                                };
                                sisaEntitie.tblCajaChicaQueretaro.Add(tblCajaChicaQueretaro);
                                sisaEntitie.SaveChanges();

                                if (nombrearchivo != "")
                                {
                                    if (!Directory.Exists(@"C:\SisaFiles\CajaChicaQueretaro\"))
                                    {
                                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaQueretaro\");
                                    }

                                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaQueretaro\" + @"\" + dataarchivo))
                                    {
                                        System.IO.File.Delete(@"C:\SisaFiles\CajaChicaQueretaro\" + @"\" + dataarchivo);
                                    }

                                    string[] completo64 = dataarchivo.Split(',');
                                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    string archivo = @"C:\SisaFiles\CajaChicaIrapuato\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }

                            /*TECATE*/
                            if (IdSucursal.ToUpper() == "F8E5400A-E1B5-4100-A990-E73E9DA59370")
                            {
                                tblCajaChicaTecate tblCajaChicaTecate = new tblCajaChicaTecate()
                                {
                                    IdCajaChicaTecate = Guid.NewGuid(),
                                    FechaAlta = DateTime.Now,
                                    Responsable = Responsable,
                                    Concepto = Concepto,
                                    Proyecto = Proyecto,
                                    Comprobante = Comprobante,
                                    Cargo = Decimal.Parse(Abono),
                                    Abono = Decimal.Parse(Cargo),
                                    Fecha = DateTime.Parse(Fecha),
                                    Estatus = new int?(int32),
                                    IdProyecto = pidproyecto,
                                    Categoria = "N/A",
                                    CampoExtra = "",
                                    FolioOrdenCompra = "N/A",
                                    NombreArchivo = nombrearchivo,
                                    Archivo = dataarchivo,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    IdUsuarioModifica = usuario.IdUsuario,
                                    FechaModificacion = DateTime.Now
                                };
                                sisaEntitie.tblCajaChicaTecate.Add(tblCajaChicaTecate);
                                sisaEntitie.SaveChanges();

                                if (nombrearchivo != "")
                                {
                                    if (!Directory.Exists(@"C:\SisaFiles\CajaChicaTecate\"))
                                    {
                                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaTecate\");
                                    }

                                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaTecate\" + @"\" + dataarchivo))
                                    {
                                        System.IO.File.Delete(@"C:\SisaFiles\CajaChicaTecate\" + @"\" + dataarchivo);
                                    }

                                    string[] completo64 = dataarchivo.Split(',');
                                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    string archivo = @"C:\SisaFiles\CajaChicaTecate\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }

                            //tblCajaChicaSucursal tblCajaChicaSucursal = new tblCajaChicaSucursal()
                            //{
                            //    IdCajaChicaSucursal = Guid.NewGuid(),
                            //    IdCajaChica = idCajaChica,
                            //    IdSucursal = Guid.Parse(IdSucursal),
                            //    Sucursal = Sucursal,
                            //    Concepto = Concepto,
                            //    Cargo = Decimal.Parse(Abono),
                            //    Abono = Decimal.Parse(Cargo),
                            //    Fecha = DateTime.Parse(Fecha),
                            //    FechaAlta = DateTime.Now,
                            //    Estatus = int32,
                            //    NombreArchivo = nombrearchivo,
                            //    Archivo = dataarchivo,
                            //    IdUsuarioAlta = usuario.IdUsuario,
                            //    IdUsuarioModifica = usuario.IdUsuario,
                            //    FechaModificacion = DateTime.Now
                            //};
                            //sisaEntitie.tblCajaChicaSucursal.Add(tblCajaChicaSucursal);
                            //sisaEntitie.SaveChanges();



                        }
                       
                        str = "Informacion actualizada.";
                    }
                }
                else
                    str = "No tienes permiso de agregar información.";
            }
            //else if (Tipo == "2")
            //{
            //    if (rolesUsuarios.CajaChicaEditar)
            //    {
            //        using (SisaEntitie sisaEntitie = new SisaEntitie())
            //        {
            //            tblCajaChica Existe = ((IQueryable<tblCajaChica>)sisaEntitie.tblCajaChica).FirstOrDefault<tblCajaChica>((Expression<Func<tblCajaChica, bool>>)(a => a.IdCajaChica.ToString() == pid));
            //            if (Existe != null)
            //            {
            //                int int32 = Convert.ToInt32(Estatus);
            //                Existe.Responsable = Responsable;
            //                Existe.Concepto = Concepto;
            //                Existe.Cargo = Decimal.Parse(Cargo);
            //                Existe.Abono = Decimal.Parse(Abono);
            //                Existe.Estatus = new int?(int32);
            //                Existe.Categoria = "N/A";
            //                Existe.CampoExtra = "";
            //                Existe.FolioOrdenCompra = "N/A";
            //                Existe.Comprobante = Comprobante;
            //                Decimal num = Cargo == "0.00" ? Decimal.Parse(Abono) : Decimal.Parse(Cargo);
            //                Existe.IdProyecto = pidproyecto;
            //                Existe.Proyecto = Proyecto;
            //                Existe.Archivo = dataarchivo;
            //                Existe.NombreArchivo = nombrearchivo;
            //                Existe.IdUsuarioModifica = usuario.IdUsuario;
            //                Existe.FechaModificacion = DateTime.Now;
            //                //sisaEntitie.SaveChanges();
            //                if (sisaEntitie.SaveChanges() > 0)
            //                {
            //                    if (!Directory.Exists(@"C:\SisaFiles\CajaChica\"))
            //                    {
            //                        Directory.CreateDirectory(@"C:\SisaFiles\CajaChica\");
            //                    }

            //                    if (System.IO.File.Exists(@"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo))
            //                    {
            //                        System.IO.File.Delete(@"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo);
            //                    }

            //                    string[] completo64 = dataarchivo.Split(',');
            //                    //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
            //                    //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
            //                    string archivo = @"C:\SisaFiles\CajaChica\" + @"\" + dataarchivo;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
            //                    using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
            //                    {
            //                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
            //                    }
            //                }
            //                str = "Informacion actualizada.";
            //            }
            //            else
            //                str = "No se pudo obtener información, recarga página e intenta de nuevo.";
            //        }
            //    }
            //    else
            //        str = "No tienes permiso de editar información.";
            //}
            return str;
        }
    }
}