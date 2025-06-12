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
    public partial class Mensajes : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static tblSolicitudesAprobacion ReqEditable;
        public static string idRFQ = string.Empty;
        public static bool Todos = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idRFQ = Request.QueryString["idMsj"];
                if(idRFQ != null)
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
                if(rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "COMPRAS")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from r in DataControl.tblSolicitudesAprobacion
                                     where r.Tipo == "MENSAJES"

                                     orderby r.idSolicitud descending
                                     select new { r.idSolicitud, timestamp = DbFunctions.TruncateTime(r.timestamp), r.Comentarios, r.UsuarioSolicita, r.idDocumento, r.CondicionEstatus, r.Tipo });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var requi = (from r in DataControl.tblSolicitudesAprobacion
                                     where r.Tipo == "MENSAJES" && r.idUsuarioSolicita == usuario.IdUsuario.ToString()

                                     orderby r.idSolicitud descending
                                     select new { r.idSolicitud, timestamp = DbFunctions.TruncateTime(r.timestamp), r.Comentarios, r.UsuarioSolicita, r.idDocumento, r.CondicionEstatus, r.Tipo });

                        retorno = JsonConvert.SerializeObject(requi);
                    }
                }
                
            }
            else
            {
                Guid id = Guid.Parse(idRFQ);
                using (var DataControl = new SisaEntitie())
                {
                    var requi = (from r in DataControl.tblSolicitudesAprobacion
                                 where r.idDocumento == id
                                 select new { r.idSolicitud, timestamp = DbFunctions.TruncateTime(r.timestamp), r.Comentarios, r.UsuarioSolicita, r.idDocumento, r.CondicionEstatus, r.Tipo });

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
            using (var DataControl = new SisaEntitie())
            {
                var a = DataControl.tblSolicitudesAprobacion.FirstOrDefault(s => s.idSolicitud == id);
                if (a != null)
                {
                    a.Comentarios = a.Comentarios + " LEIDO";
                    a.Estatus = false;
                    DataControl.SaveChanges();
                    retorno = "Mensajes actualizada.";
                }
                else
                {
                    retorno = "Ocurrio un problema al obtener información.";
                }
            }

            return retorno;
        }
    }
}