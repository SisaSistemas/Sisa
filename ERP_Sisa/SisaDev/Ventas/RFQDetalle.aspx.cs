using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
    public partial class RFQDetalle : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idRfqNueva = string.Empty;
        public static string idRFQ = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idRFQ = Request.QueryString["idRFQ"];
                //lblRFQ = Request.QueryString["Folio"];
                txtIdRFQ.Value = idRFQ;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        [WebMethod]
        public static string ObtenerEmpresas(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {

                using (var DataControl = new SisaEntitie())
                {
                    if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
                    {
                        //var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                        var Empresas = (from r in DataControl.tblEmpresas
                                        join cn in DataControl.tblClienteContacto on r.idEmpresa equals cn.idEmpresa
                                        where r.Estatus == true && cn.Estatus == true
                                        select new { cn.idContacto, r.RazonSocial, cn.NombreContacto });
                        retorno = JsonConvert.SerializeObject(Empresas);
                    }
                    else
                    {
                        //var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true && s.idSucursalRegistro == usuario.idSucursal);

                        var Empresas = (from r in DataControl.tblEmpresas
                                        join cn in DataControl.tblClienteContacto on r.idEmpresa equals cn.idEmpresa
                                        where r.idSucursalRegistro == usuario.idSucursal && r.Estatus == true && cn.Estatus == true
                                        select new { cn.idContacto, r.RazonSocial, cn.NombreContacto });
                        retorno = JsonConvert.SerializeObject(Empresas);
                    }


                }
            }


            return retorno;
        }

        [WebMethod]
        public static string GuardarRFQes(string pO, string dtCaduca, string idContacto, string idVendedor, string idCoordinador, string Seguimiento, string Descripcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RFQAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var parametro = new ObjectParameter("Folio", typeof(string));
                    DataControl.sp_ObtieneFolioRFQ(parametro).ToString();
                    tblRFQ add = new tblRFQ
                    {
                        IdRfq = Guid.NewGuid(),
                        Estatus = 1,
                        FechaAlta = DateTime.Now,
                        Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
                        IdUsuarioAlta = usuario.IdUsuario,
                        IdUsuarioModificar = usuario.IdUsuario,
                        Folio = parametro.Value.ToString(),
                        FechaVencimiento = DateTime.Parse(dtCaduca),
                        FechaModificacion = DateTime.Now,
                        Round = "",
                        FolioRQ = parametro.Value.ToString(),
                        IdCliente = Guid.Parse(idContacto),
                        idVendedor = Guid.Parse(idVendedor),
                        idCoordinador = Guid.Parse(idCoordinador),
                        Seguimiento = Seguimiento,
                        Descripcion = Descripcion

                    };
                    DataControl.tblRFQ.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        idRfqNueva = add.IdRfq.ToString();
                        
                        tblSolicitudesAprobacion adds = new tblSolicitudesAprobacion
                        {
                            UsuarioSolicita = usuario.Usuario,
                            idUsuarioSolicita = add.idVendedor.ToString(),
                            timestamp = DateTime.Now,
                            Estatus = true,
                            CondicionEstatus = "Enviado",
                            Comentarios = add.Folio + " RFQ fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
                            idDocumento = Guid.Parse(idRfqNueva),
                            Tipo = "MENSAJES"
                        };
                        DataControl.tblSolicitudesAprobacion.Add(adds);
                        DataControl.SaveChanges();
                        retorno = "RFQ creada." + idRfqNueva;
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar RFQ.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar RFQ.";
            }

            return retorno;
        }
        [WebMethod]
        public static string GuardarRFQesDetalle(string pItem, string pDescripcio, string pCantidad, string pUnidad)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RFQAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblRFQDet add = new tblRFQDet
                    {
                        IdRFQDet = Guid.NewGuid(),
                        TimeStamp = DateTime.Now,
                        Item = Convert.ToInt32(pItem),
                        Descripcion = pDescripcio,
                        Cantidad = Convert.ToInt32(pCantidad),
                        Unidad = pUnidad,
                        NumeroParte = "",
                        Marca = "",
                        Estatus = true,
                        IdRfq = Guid.Parse(idRfqNueva)
                    };
                    DataControl.tblRFQDet.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Comentario RFQ guardado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar Comentario RFQ.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar Comentario de RFQ.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarDatosDetalle(string IdRFQ, string Opcion)
        {

            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdRFQ);
                var RFQ = DataControl.tblRFQDet.Where(d => d.IdRfq == id);
                
                retorno = JsonConvert.SerializeObject(RFQ);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarDatosEncabezado(string IdRFQ, string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdRFQ);
                var Rfq = (from r in DataControl.tblRFQ
                           join cn in DataControl.tblClienteContacto on r.IdCliente equals cn.idContacto
                           join ce in DataControl.tblEmpresas on cn.idEmpresa equals ce.idEmpresa
                           join uv in DataControl.tblUsuarios on r.idVendedor equals uv.IdUsuario
                           join uc in DataControl.tblUsuarios on r.idCoordinador equals uc.IdUsuario
                           where r.IdRfq.ToString() == IdRFQ && r.Estatus > 0
                           select new { r.IdRfq, r.IdCliente, r.idVendedor, r.idCoordinador, r.Folio, r.Descripcion, FechaRFQ = r.FechaAlta.Day + "/" + r.FechaAlta.Month + "/" + r.FechaAlta.Year, r.FechaVencimiento, NombreContacto = ce.RazonSocial + "-" + cn.NombreContacto, cn.Telefono, r.Seguimiento, r.ArchivoRFQ, Vendedor = uv.NombreCompleto, Coordinador = uc.NombreCompleto, Estatus = SqlFunctions.DateDiff("DAY", DateTime.Now, r.FechaVencimiento), EstatusN = r.Estatus });

                //lblRFQFolio.Text = "";

                retorno = JsonConvert.SerializeObject(Rfq);
            }
            
            return retorno;

        }

        [WebMethod]
        public static string ModificarRFQes(string id, string dtCaduca, string idContacto, string idVendedor, string idCoordinador, string Seguimiento, string Descripcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.RFQEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    Guid i = Guid.Parse(id);
                    var Existe = DataControl.tblRFQ.FirstOrDefault(r => r.IdRfq == i);
                    if(Existe != null)
                    {
                        var del = DataControl.tblRFQDet.Where(s => s.IdRfq == i);
                        foreach(var d in del)
                        {
                            DataControl.tblRFQDet.Remove(d);
                        }
                        DataControl.SaveChanges();
                        Existe.Descripcion = Descripcion;
                        Existe.FechaModificacion = DateTime.Now;
                        Existe.IdUsuarioModificar = usuario.IdUsuario;
                        Existe.Seguimiento = Seguimiento;
                        Existe.FechaVencimiento = DateTime.Parse(dtCaduca);
                        DataControl.SaveChanges();
                        tblSolicitudesAprobacion adds = new tblSolicitudesAprobacion
                        {
                            UsuarioSolicita = usuario.Usuario,
                            idUsuarioSolicita = idVendedor.ToString(),
                            timestamp = DateTime.Now,
                            Estatus = true,
                            CondicionEstatus = "Enviado",
                            Comentarios = Existe.Folio + " RFQ fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
                            idDocumento = Guid.Parse(id),
                            Tipo = "MENSAJES"
                        };
                        idRfqNueva = id;
                        DataControl.tblSolicitudesAprobacion.Add(adds);
                        DataControl.SaveChanges();
                        retorno = "RFQ modificada. "+ Existe.Folio;
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de RFQ.";
                    }                   
                }
            }
            else
            {
                retorno = "No tienes permiso de modificar RFQ.";
            }

            return retorno;
        }
    }
}