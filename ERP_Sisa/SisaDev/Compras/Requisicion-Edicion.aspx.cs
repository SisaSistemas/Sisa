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
    public partial class Requisicion_Edicion : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static tblReqEnc ReqEditable;
        public static List<tblReqDet> ReqEditableDetalles;
        public static string idRequisicion = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idRequisicion = Request.QueryString["idReq"];
                txtIdRequicion.Value = idRequisicion;
                using(var DataControl = new SisaEntitie())
                {
                    Guid id = Guid.Parse(idRequisicion);
                    ReqEditable = DataControl.tblReqEnc.FirstOrDefault(r=> r.IdReqEnc == id);
                    if(ReqEditable != null)
                    {
                        ReqEditableDetalles = DataControl.tblReqDet.Where(r => r.IdReqEnc == id).ToList();
                    }
                    else
                    {
                        FailureText.Text = "No se encontro información.";
                        ErrorMessage.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerRequisicion()
        {
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(idRequisicion);
                var requi = (from r in DataControl.tblReqEnc
                             join p in DataControl.tblProyectos on r.IdProyecto equals p.IdProyecto
                             where  r.IdReqEnc == id //r.IdUsuarioElaboro == usuario.IdUsuario &&
                             orderby r.FechaElaboracion descending
                             select new { r.IdReqEnc, r.NoReq, p.NombreProyecto, r.Fecha, FechaAutorizada = DbFunctions.TruncateTime(r.FechaAutorizada), FechaCompra = DbFunctions.TruncateTime(r.FechaCompra), r.Observaciones });

                return JsonConvert.SerializeObject(requi);
            }
                
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerRequisicionDetalle()
        {
            return JsonConvert.SerializeObject(ReqEditableDetalles);
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarRequisiciones(string pObservaciones, string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RequisicionesEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    Guid id = Guid.Parse(idRequisicion);

                    var Existe = DataControl.tblReqEnc.FirstOrDefault(r => r.IdReqEnc == id);
                    if(Existe != null)
                    {
                        Existe.Observaciones = (pObservaciones.Trim().Length > 0 ? pObservaciones : Existe.Observaciones);
                        DataControl.SaveChanges();
                        tblSolicitudesAprobacion adds = new tblSolicitudesAprobacion
                        {
                            UsuarioSolicita = usuario.Usuario,
                            idUsuarioSolicita = usuario.IdUsuario.ToString(),
                            timestamp = DateTime.Now,
                            Estatus = true,
                            CondicionEstatus = "Enviado",
                            Comentarios = Existe.NoReq + ", se modifico requisición, fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
                            idDocumento = Existe.IdReqEnc,
                            Tipo = "REQUISICION"
                        };
                        DataControl.tblSolicitudesAprobacion.Add(adds);
                        DataControl.SaveChanges();
                        var Delete = DataControl.tblReqDet.Where(d => d.IdReqEnc == id);
                        if (Delete != null)
                        {
                            foreach (var d in Delete)
                            {
                                DataControl.tblReqDet.Remove(d);
                            }
                            DataControl.SaveChanges();
                        }
                        retorno = "Requisiciones actualizadas.";
                    }
                    else
                    {
                        retorno = "No se encontro información, intenta de nuevo.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de editar Requisición.";
            }

            return retorno;
        }
        [WebMethod]
        public static string GuardarRequisicionesDetalle(string pItem, string pDescripcio, string pCantidad, string pUnidad, string pNumParte, string pMarca)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RequisicionesEditar == true || rolesUsuarios.Tipo == "ROOT")
            {

                using (var DataControl = new SisaEntitie())
                {                   
                    
                    tblReqDet add = new tblReqDet
                    {
                        IdReqDet = Guid.NewGuid(),
                        TimeStamp = DateTime.Now,
                        Item = Convert.ToInt32(pItem),
                        Descripcion = pDescripcio,
                        Cantidad = Convert.ToInt32(pCantidad),
                        Unidad = pUnidad,
                        NumeroParte = pNumParte,
                        Marca = pMarca,
                        Estatus = true,
                        IdReqEnc = Guid.Parse(idRequisicion)
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
                retorno = "No tienes permiso de editar Requisición.";
            }

            return retorno;
        }

    }
}