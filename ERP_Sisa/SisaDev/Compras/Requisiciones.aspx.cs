using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
    public partial class Requisiciones : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idReqNueva = string.Empty;
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
        public static string ProyectosCombos(string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                int op = int.Parse(Opcion);
                retorno = JsonConvert.SerializeObject(DataControl.sp_CargaCombos(op));
            }
            return retorno;
        }       

        [WebMethod]
        public static string ObtenerRequisiciones(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var requi = (from r in DataControl.tblReqEnc
                                 join p in DataControl.tblProyectos on r.IdProyecto equals p.IdProyecto
                                 where  r.Estatus > 0 orderby r.FechaElaboracion descending
                                 select new { r.IdReqEnc, r.NoReq, p.NombreProyecto, r.Fecha, FechaAutorizada = DbFunctions.TruncateTime(r.FechaAutorizada), FechaCompra = DbFunctions.TruncateTime(r.FechaCompra), r.Observaciones });

                    return JsonConvert.SerializeObject(requi);
                }
            }
            if (rolesUsuarios.Requisiciones == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from r in DataControl.tblReqEnc
                                     join p in DataControl.tblProyectos on r.IdProyecto equals p.IdProyecto
                                     where  r.Estatus > 0 && r.IdUsuarioElaboro == usuario.IdUsuario 
                                     orderby r.FechaElaboracion descending
                                     select new { r.IdReqEnc, r.NoReq, p.NombreProyecto, r.Fecha, FechaAutorizada = DbFunctions.TruncateTime(r.FechaAutorizada), FechaCompra = DbFunctions.TruncateTime(r.FechaCompra), r.Observaciones });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from r in DataControl.tblReqEnc
                                     join p in DataControl.tblProyectos on r.IdProyecto equals p.IdProyecto
                                     where r.Estatus > 0 && r.IdUsuarioElaboro == usuario.IdUsuario 
                                     orderby r.FechaElaboracion descending
                                     select new { r.IdReqEnc, r.NoReq, p.NombreProyecto, r.Fecha, FechaAutorizada = DbFunctions.TruncateTime(r.FechaAutorizada), FechaCompra = DbFunctions.TruncateTime(r.FechaCompra), r.Observaciones });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
            }            
            return retorno;
        }

        [WebMethod]
        public static string ObtenerRequisicionesDetalles(string pid)
        {
            string retorno = string.Empty;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var requi = (from p in DataControl.tblReqDet
                                 where p.IdReqEnc.ToString() == pid
                                 orderby p.Item ascending
                                 select new { p.IdReqEnc, p.Descripcion, p.Cantidad, p.NumeroParte, p.Marca, p.Unidad, p.Item });

                    retorno = JsonConvert.SerializeObject(requi);
                }
            }
            if (rolesUsuarios.Requisiciones == true || rolesUsuarios.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from r in DataControl.tblReqEnc
                                     join p in DataControl.tblProyectos on r.IdProyecto equals p.IdProyecto
                                     where r.IdUsuarioElaboro == usuario.IdUsuario
                                     select new { r.IdReqEnc, r.NoReq, p.NombreProyecto, r.Fecha, r.FechaAutorizada, r.FechaCompra, r.Observaciones });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from p in DataControl.tblReqDet                                     
                                     where p.IdReqEnc.ToString() == pid
                                     orderby p.Item ascending
                                     select new { p.IdReqEnc, p.Descripcion, p.Cantidad, p.NumeroParte, p.Marca, p.Unidad, p.Item });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
            }

            return retorno;
        }

        [WebMethod]
        public static string GuardarRequisiciones(string pObservaciones, string pidProyecto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RequisicionesAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var parametro = new ObjectParameter("Folio", typeof(string));
                    DataControl.sp_ObtieneFolioReq(parametro).ToString();
                    tblReqEnc add = new tblReqEnc
                    {
                        IdProyecto = Guid.Parse(pidProyecto),
                        IdReqEnc = Guid.NewGuid(),
                        Observaciones = pObservaciones,
                        Estatus = 1,
                        FechaElaboracion = DateTime.Now,
                        Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
                        IdUsuarioElaboro = usuario.IdUsuario,
                        NoReq = parametro.Value.ToString()

                    };
                    DataControl.tblReqEnc.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        idReqNueva = add.IdReqEnc.ToString();
                        tblSolicitudesAprobacion adds = new tblSolicitudesAprobacion
                        {
                            UsuarioSolicita = usuario.Usuario,
                            idUsuarioSolicita = usuario.IdUsuario.ToString(),
                            timestamp = DateTime.Now,
                            Estatus = true,
                            CondicionEstatus = "Enviado",
                            Comentarios = add.NoReq + " Requisicion fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
                            idDocumento = add.IdReqEnc,
                            Tipo = "REQUISICION"
                        };
                        DataControl.tblSolicitudesAprobacion.Add(adds);
                        DataControl.SaveChanges();
                        retorno = "Requisiciones creada.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar Requisición.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar Requisición.";
            }

            return retorno;
        }
        [WebMethod]
        public static string GuardarRequisicionesDetalle(string pItem, string pDescripcio, string pCantidad, string pUnidad, string pNumParte, string pMarca)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RequisicionesAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var parametro = new ObjectParameter("Folio", typeof(string));
                    DataControl.sp_ObtieneFolioReq(parametro).ToString();
                    tblReqDet add = new tblReqDet
                    {
                        IdReqDet=Guid.NewGuid(),
                        TimeStamp = DateTime.Now,
                        Item = Convert.ToInt32(pItem),
                        Descripcion = pDescripcio,
                        Cantidad = Convert.ToInt32(pCantidad),
                        Unidad = pUnidad,
                        NumeroParte = pNumParte,
                        Marca = pMarca,
                        Estatus = true,
                        IdReqEnc = Guid.Parse(idReqNueva)
                    };
                    DataControl.tblReqDet.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Detalle Requisición guardado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar detalle Requisición.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar Requisición.";
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarRequisicion(string pidRequisicion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RequisicionesEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var RExiste = DataControl.tblReqEnc.FirstOrDefault(s => s.IdReqEnc.ToString() == pidRequisicion);
                    if (RExiste != null)
                    {
                        RExiste.Estatus = 0;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Requisiciones eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar requisición.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de requisición seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar requisición.";
            }

            return retorno;
        }
        [WebMethod]
        public static string EditarRequisicion(string pid, string pNombre, string pTelefono, string pCorreo, string pUsuario, string pClave)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteContactoEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Empresas = DataControl.tblClienteContacto.FirstOrDefault(s => s.idEmpresa.ToString() == pid.Trim());
                    if (Empresas != null)
                    {
                        Empresas.NombreContacto = pNombre;
                        Empresas.Telefono = pTelefono;
                        Empresas.Correo = pCorreo;
                        Empresas.Usuario = pUsuario;
                        Empresas.Clave = pClave;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Contacto actualizada.";
                        }
                        else
                        {
                            retorno = "No se realizaron cambios.";
                        }
                    }
                    else
                    {
                        retorno = "No se obtuvo información de Contacto seleccionado.";
                    }
                }
            }
            else
            {
                retorno = "NO tienes permiso de edición de Contacto.";
            }
            return retorno;
        }
    }
}