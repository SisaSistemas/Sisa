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

namespace SisaDev.Administracion
{
    public partial class CajaChicaUSA : System.Web.UI.Page
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
                    str = JsonConvert.SerializeObject(sisaEntitie.tblCajaChicaUSA.Select((s => s)));
                }

            }
            if (rolesUsuarios.CajaChicaUSA == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject(sisaEntitie.JT_LoadCajaChicaUSA().Where((s =>
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
                        str = JsonConvert.SerializeObject(sisaEntitie.tblCajaChicaUSA.FirstOrDefault((s => s.IdCajaChicaUsa.ToString() == pid)));
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
        public static string GuardarCC(string Responsable, string Concepto, string pidproyecto, string Proyecto, string Comprobante, string Abono, string Fecha, string Estatus, string Tipo, string pid, string Categoria, string CampoExtra, string OC, string nombrearchivo, string dataarchivo)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            if (Tipo == "1")
            {
                if (rolesUsuarios.CajaChicaUSA == true || rolesUsuarios.Tipo == "ROOT")
                {
                    if (pidproyecto == "1")
                        pidproyecto = "";
                    else
                        Guid.Parse(pidproyecto);

                    int int32 = Convert.ToInt32(Estatus);
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblCajaChicaUSA add = new tblCajaChicaUSA()
                        {
                            IdCajaChicaUsa = Guid.NewGuid(),
                            FechaAlta = DateTime.Now,
                            Responsable = Responsable,
                            Concepto = Concepto,
                            Proyecto = Proyecto,
                            Comprobante = Comprobante,
                            Cargo = Decimal.Parse("0"),
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
                        sisaEntitie.tblCajaChicaUSA.Add(add);
                        //sisaEntitie.SaveChanges();
                        if (sisaEntitie.SaveChanges() > 0)
                        {
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
                        Decimal num = Decimal.Parse(Abono);
                        if (!(Categoria == "N/A"))
                        {
                            tblEficienciasDesglose eficienciasDesglose1 = (sisaEntitie.tblEficienciasDesglose.FirstOrDefault((e => e.idDocumento == add.IdCajaChicaUsa.ToString())));
                            if (eficienciasDesglose1 != null)
                            {
                                eficienciasDesglose1.idProyecto = pidproyecto;
                                eficienciasDesglose1.idDocumento = add.IdCajaChicaUsa.ToString();
                                eficienciasDesglose1.Categoria = Categoria.ToUpper();
                                eficienciasDesglose1.Total = new Decimal?(num);
                                eficienciasDesglose1.TipoDoc = "CCU";
                                sisaEntitie.SaveChanges();
                            }
                            else
                            {
                                tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
                                {
                                    idProyecto = pidproyecto,
                                    idDocumento = add.IdCajaChicaUsa.ToString(),
                                    Categoria = Categoria.ToUpper(),
                                    Total = new Decimal?(num),
                                    TipoDoc = "CCU",
                                    Folio = "",
                                    FechaDoc = new DateTime?(add.FechaAlta),
                                    idUsuarioUltimo = CajaChicaUSA.usuario.IdUsuario.ToString()
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
                        tblCajaChicaUSA Existe = (sisaEntitie.tblCajaChicaUSA.FirstOrDefault((a => a.IdCajaChicaUsa.ToString() == pid)));
                        if (Existe != null)
                        {
                            int int32 = Convert.ToInt32(Estatus);
                            Existe.Responsable = Responsable;
                            Existe.Concepto = Concepto;
                            Existe.Abono = Decimal.Parse(Abono);
                            Existe.Estatus = new int?(int32);
                            Existe.Categoria = Categoria;
                            Existe.CampoExtra = CampoExtra;
                            Existe.Comprobante = Comprobante;
                            Decimal num = Decimal.Parse(Abono);
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
                            if (!(Categoria == "N/A"))
                            {
                                tblEficienciasDesglose eficienciasDesglose3 = (sisaEntitie.tblEficienciasDesglose.FirstOrDefault((e => e.idDocumento == Existe.IdCajaChicaUsa.ToString())));
                                if (eficienciasDesglose3 != null)
                                {
                                    eficienciasDesglose3.idProyecto = pidproyecto;
                                    eficienciasDesglose3.idDocumento = Existe.IdCajaChicaUsa.ToString();
                                    eficienciasDesglose3.Categoria = Categoria.ToUpper();
                                    eficienciasDesglose3.Total = new Decimal?(num);
                                    eficienciasDesglose3.TipoDoc = "CCU";
                                    sisaEntitie.SaveChanges();
                                }
                                else
                                {
                                    tblEficienciasDesglose eficienciasDesglose4 = new tblEficienciasDesglose()
                                    {
                                        idProyecto = pidproyecto,
                                        idDocumento = Existe.IdCajaChicaUsa.ToString(),
                                        Categoria = Categoria.ToUpper(),
                                        Total = new Decimal?(num),
                                        TipoDoc = "CCU",
                                        Folio = "",
                                        FechaDoc = new DateTime?(Existe.FechaAlta),
                                        idUsuarioUltimo = CajaChicaCuautitlan.usuario.IdUsuario.ToString()
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
        public static string EliminarCC(string pid)
        {
            string str = string.Empty;
            CajaChicaCuautitlan.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            CajaChicaCuautitlan.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (CajaChicaCuautitlan.rolesUsuarios.CajaChicaUSA == true || CajaChicaCuautitlan.rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblCajaChicaUSA tblCajaChica = (sisaEntitie.tblCajaChicaUSA.FirstOrDefault((s => s.IdCajaChicaUsa.ToString() == pid)));
                    if (tblCajaChica != null)
                    {
                        sisaEntitie.tblCajaChicaUSA.Remove(tblCajaChica);
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            tblEficienciasDesglose eficienciasDesglose = (sisaEntitie.tblEficienciasDesglose.FirstOrDefault(a => a.idDocumento == pid));
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

                if (!Directory.Exists(@"C:\SisaFiles\CajaChicaUSA\"))
                {
                    Directory.CreateDirectory(@"C:\SisaFiles\CajaChicaUSA\");
                }

                if (System.IO.File.Exists(@"C:\SisaFiles\CajaChicaUSA\" + @"\" + FileName))
                {
                    System.IO.File.Delete(@"C:\SisaFiles\CajaChicaUSA\" + @"\" + FileName);
                }

                string[] completo64 = File.Split(',');
                //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                string archivo = @"C:\SisaFiles\CajaChicaUSA\" + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
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
    }
}