using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
    public partial class Requisicion_Solicitud : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static tblSolicitudesAprobacion ReqEditable;
        public static string idRequisicion = string.Empty;
        public static bool Todos = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idRequisicion = Request.QueryString["idReq"];
                if(idRequisicion != null)
                {
                    Todos = false;
                }
                else
                {
                    Todos = true;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string CargarSolicitud()
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (Todos == true)
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "COMPRAS")
                    {
                        var requi = (from r in DataControl.tblSolicitudesAprobacion
                                     where r.Tipo == "REQUISICION"
                                     orderby r.idSolicitud descending
                                     select new { r.idSolicitud, timestamp = DbFunctions.TruncateTime(r.timestamp), r.Comentarios, r.UsuarioSolicita, r.idDocumento, r.CondicionEstatus });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                    else
                    {
                        var requi = (from r in DataControl.tblSolicitudesAprobacion
                                     where r.Tipo == "REQUISICION" && r.idUsuarioSolicita == usuario.IdUsuario.ToString()
                                     orderby r.idSolicitud descending
                                     select new { r.idSolicitud, timestamp = DbFunctions.TruncateTime(r.timestamp), r.Comentarios, r.UsuarioSolicita, r.idDocumento, r.CondicionEstatus });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
            }
            else
            {
                Guid id = Guid.Parse(idRequisicion);
                using (var DataControl = new SisaEntitie())
                {
                    var requi = (from r in DataControl.tblSolicitudesAprobacion
                                 where r.idDocumento == id
                                 select new { r.idSolicitud, timestamp = DbFunctions.TruncateTime(r.timestamp), r.Comentarios, r.UsuarioSolicita, r.idDocumento, r.CondicionEstatus });

                    retorno = JsonConvert.SerializeObject(requi);
                }
            }
            return retorno;
        }
        
        [WebMethod]
        public static string AprobarRechazar(string pid, string pEstatus)
        {
            string retorno = string.Empty;
            int id = Convert.ToInt32(pid);
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS" || rolesUsuarios.Tipo == "ROOT") 
            {
                if (pEstatus == "true")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var a = DataControl.tblSolicitudesAprobacion.FirstOrDefault(s => s.idSolicitud == id);
                        if (a != null)
                        {
                            var req = DataControl.tblReqEnc.FirstOrDefault(r => r.IdReqEnc == a.idDocumento);
                            if(req != null)
                            {
                                req.FechaAutorizada = DateTime.Now;
                                var ActualizarNoti = DataControl.tblSolicitudesAprobacion.Where(r => r.idDocumento == a.idDocumento && r.Estatus == true);
                                if(ActualizarNoti != null)
                                {
                                    foreach(var n in ActualizarNoti)
                                    {
                                        n.Estatus = false;
                                    }
                                    
                                }
                                
                                DataControl.SaveChanges();
                            }
                            a.Estatus = false;
                            a.CondicionEstatus = "APROBADA";
                            DataControl.SaveChanges();
                            tblSolicitudesAprobacion add = new tblSolicitudesAprobacion
                            {
                                idUsuarioAprobo = usuario.IdUsuario,
                                idUsuarioSolicita = a.idUsuarioSolicita,
                                usuarioAprobo = usuario.Usuario,
                                UsuarioSolicita = a.UsuarioSolicita,
                                Comentarios = "APROBADA " + a.Comentarios,
                                Estatus = true,
                                CondicionEstatus = "Enviado",
                                idDocumento = a.idDocumento,
                                timestamp = DateTime.Now,
                                Tipo = "MENSAJES"
                            };
                            DataControl.tblSolicitudesAprobacion.Add(add);
                            DataControl.SaveChanges();
                            retorno = "Requisición actualizada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al obtener información.";
                        }
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var a = DataControl.tblSolicitudesAprobacion.FirstOrDefault(s => s.idSolicitud == id);
                        if (a != null)
                        {
                            a.Estatus = false;
                            a.CondicionEstatus = "RECHAZADA";
                            DataControl.SaveChanges();
                            retorno = "Requisición actualizada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al obtener información.";
                        }
                    }
                }
            }
            else
            {
                retorno = "No tienes privilegios de usuario.";
            }
            
            return retorno;
        }
    }
}