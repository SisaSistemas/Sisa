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
    public partial class CajaChicaSucursal : System.Web.UI.Page
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
                    str = JsonConvert.SerializeObject((object)(sisaEntitie.tblCajaChicaSucursal).Select((s => s)));
                }

            }
            if (rolesUsuarios.CajaChicaSucursal == true || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject((sisaEntitie.JT_LoadCajaChicaSucursal()).Where((s => s.IdSucursal == usuario.idSucursal)));
                    }

                }
            }
            else if (rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    str = JsonConvert.SerializeObject((object)(sisaEntitie.JT_LoadCajaChicaSucursal()).Where((s =>
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
        public static string CargarInfoGeneral(string id)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                retorno = JsonConvert.SerializeObject(DataControl.sp_CargaInfoCCSucursal(id));
            }
            return retorno;

        }

        [WebMethod]
        public static string GuardarDetalle(string IdProyecto, string Concepto, string Cantidad, string TipoGasto, string FechaGasto, string IdCajaChicaSucursal, string Tick)
        {
            string str1 = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ViaticosAgregar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblCajaChicaSucursalDetalle add = new tblCajaChicaSucursalDetalle()
                    {
                        IdCajaChicaSucursalDetalle = Guid.NewGuid(),
                        IdCajaChicaSucursal = Guid.Parse(IdCajaChicaSucursal),
                        IdProyecto = Guid.Parse(IdProyecto),
                        Concepto = Concepto,
                        CantidadGastada = Decimal.Parse(Cantidad),
                        TipoGasto = TipoGasto,
                        FechaGasto = DateTime.Parse(FechaGasto),
                        Ticket = Tick,
                        Estatus = 0,
                        IdUsuarioAlta = usuario.IdUsuario,
                        FechaAlta = DateTime.Now,
                        IdUsuarioModifica = usuario.IdUsuario,
                        FechaModifica = DateTime.Now
                    };
                    sisaEntitie.tblCajaChicaSucursalDetalle.Add(add);
                    if (sisaEntitie.SaveChanges() > 0)
                    {
                        tblCajaChicaSucursal tblCajaChicaSucursal = (sisaEntitie.tblCajaChicaSucursal).FirstOrDefault((v => v.IdCajaChicaSucursal.ToString().Trim() == IdCajaChicaSucursal));
                        tblCajaChicaSucursal.Abono += Decimal.Parse(Cantidad);
                        sisaEntitie.SaveChanges();
                        
                    label_27:
                        str1 = "Detalle creado.";
                    }
                    else
                        str1 = "Ocurrio un problema al guardar gasto.";
                }
            }
            else
                str1 = "No tienes permiso de agregar gasto viatico.";
            return str1;
        }

        [WebMethod]
        public static string Cargar(string IdCajaChicaSucursal)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject(sisaEntitie.sp_CargaCajaChicaDetalle(IdCajaChicaSucursal).OrderBy(s => s.FechaGasto));
            }

        }

        [WebMethod]
        public static string CargarDocumentos(string Id, string Opcion)
        {
            string empty = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    return JsonConvert.SerializeObject(sisaEntitie.tblCajaChicaSucursalDetalle.Where(p => p.IdCajaChicaSucursalDetalle.ToString() == Id).Select(p => new
                    {
                        Ticket = p.Ticket != default(string) ? p.Ticket : "",
                        IdCajaChicaSucursalDetalle = p.IdCajaChicaSucursalDetalle
                    }));
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [WebMethod]
        public static string GuardarDocumentos(string TipoDoc, string Id, string FileName, string File)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CajaChicaSucursalEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        Guid id = Guid.Parse(Id);
                        tblCajaChicaSucursalDetalle tblCajaChicaSucursalDetalle = sisaEntitie.tblCajaChicaSucursalDetalle.FirstOrDefault(p => p.IdCajaChicaSucursalDetalle == id);
                        if (tblCajaChicaSucursalDetalle != null)
                        {
                            tblCajaChicaSucursalDetalle.Ticket = File;
                            sisaEntitie.SaveChanges();
                            str = "Archivo guardado";
                        }
                        else
                            str = "Ocurrio un error al obtener información de viatico, recarga la página e intenta de nuevo.";
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de edición.";
            return str;
        }

        [WebMethod]
        public static string EliminarDocumento(string Id, string Opcion)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CajaChicaSucursalEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblCajaChicaSucursalDetalle tblCajaChicaSucursalDetalle = sisaEntitie.tblCajaChicaSucursalDetalle.FirstOrDefault(p => p.IdCajaChicaSucursalDetalle.ToString() == Id);
                        if (tblCajaChicaSucursalDetalle != null)
                        {
                            tblCajaChicaSucursalDetalle.Ticket = "";
                            sisaEntitie.SaveChanges();
                            str = "Documento eliminado.";
                        }
                        else
                            str = "No se encontro información de documento, intenta de nuevo recargando página";
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de edición.";
            return str;
        }

        [WebMethod]
        public static string EliminarCajaChicaDet(string Id, string Gastada, string Entregada, string Diferencia)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CajaChicaSucursalEliminar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblCajaChicaSucursalDetalle det = sisaEntitie.tblCajaChicaSucursalDetalle.FirstOrDefault(p => p.IdCajaChicaSucursalDetalle.ToString() == Id);
                        if (det != null)
                        {
                            tblCajaChicaSucursal tblCajaChicaSucursal = sisaEntitie.tblCajaChicaSucursal.FirstOrDefault(v => v.IdCajaChicaSucursal == det.IdCajaChicaSucursal);

                            tblCajaChicaSucursal.Abono = tblCajaChicaSucursal.Abono > 0M ? tblCajaChicaSucursal.Abono - det.CantidadGastada : tblCajaChicaSucursal.Abono;
                            sisaEntitie.tblCajaChicaSucursalDetalle.Remove(det);
                            sisaEntitie.SaveChanges();
                           
                            str = "Registro eliminado.";
                        }
                        else
                            str = "No se encontro información de documento, intenta de nuevo recargando página";
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de eliminación.";
            return str;
        }
    }
}