using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Cliente
{
    public partial class Proyectos : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;
        public static tblRolesContactos rolesContactos;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if(usuario != null)
            {
                rolesContactos = HttpContext.Current.Session["RolesUsuarioClienteLogueado"] as tblRolesContactos;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtenerProyectos(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            rolesContactos = HttpContext.Current.Session["RolesUsuarioClienteLogueado"] as tblRolesContactos;

            if (rolesContactos.Tipo == "COMPRAS")
            {
                if (pid == "1")
                {
                    List<Guid?> allowedEmpresas = new List<Guid?>
                    {
                        Guid.Parse("E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8"),
                        Guid.Parse("11C3483C-8E3C-4956-A6AC-A6BD908D896A"),
                        Guid.Parse("0227A2C1-D05B-49F1-9EA2-FF0C77667CC1"),
                        Guid.Parse("9DBA90B1-192D-4536-B79C-B86FDFF45CD3"),
                        Guid.Parse("9DB0E133-FEFA-497D-899A-FAD6526AB652")
                    };

                    using (var DataControl = new SisaEntitie())
                    {
                        //var proyects = (from p in DataControl.tblProyectos
                        //                join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto.ToString()
                        //                join e in DataControl.tblEmpresas on c.idEmpresa equals e.idEmpresa
                        //                join u in DataControl.tblUsuarios on p.IdLider equals u.IdUsuario.ToString()
                        //                where allowedEmpresas.Contains(e.idEmpresa) && p.Activo == 1 && p.Estatus != "6"
                        //                orderby p.FechaAlta descending
                        //                select new { 
                        //                    p.IdProyecto, 
                        //                    p.FolioProyecto, 
                        //                    p.NombreProyecto, 
                        //                    c.NombreContacto, 
                        //                    e.RazonSocial, 
                        //                    Lider = u.NombreCompleto, 
                        //                    FechaI = p.FechaInicio, 
                        //                    FechaT = p.FechaFin, 
                        //                    p.Estatus, 
                        //                    p.Activo, 
                        //                    p.FolioPO 
                        //                }
                        //            );
                        //retorno = JsonConvert.SerializeObject(proyects);

                        var proyects = DataControl.sp_Administracion().Where(a => allowedEmpresas.Contains(a.idEmpresa) && a.Estatus != "6");

                        retorno = JsonConvert.SerializeObject(proyects);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        //var proyects = (from p in DataControl.tblProyectos
                        //                join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto.ToString()
                        //                join e in DataControl.tblEmpresas on c.idEmpresa equals e.idEmpresa
                        //                join u in DataControl.tblUsuarios on p.IdLider equals u.IdUsuario.ToString()
                        //                where p.IdCliente == usuario.idContacto.ToString() && p.Activo == 1 && p.Estatus != "6" && p.IdProyecto.ToString() == pid
                        //                orderby p.FechaAlta descending
                        //                select new { 
                        //                    p.IdProyecto, 
                        //                    p.FolioProyecto, 
                        //                    p.NombreProyecto, 
                        //                    c.NombreContacto, 
                        //                    e.RazonSocial, 
                        //                    Lider = u.NombreCompleto, 
                        //                    FechaI = p.FechaInicio, 
                        //                    FechaT = p.FechaFin, 
                        //                    p.Estatus, 
                        //                    p.Activo,
                        //                    p.FolioPO
                        //                }
                        //            );
                        //retorno = JsonConvert.SerializeObject(proyects);

                        var proyects = DataControl.sp_Administracion().Where(a => a.IdCliente == usuario.idContacto.ToString() && a.Estatus != "6" && a.IdProyecto.ToString() == pid);

                        retorno = JsonConvert.SerializeObject(proyects);
                    }
                }
            }
            else
            {
                if (pid == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        //var proyects = (from p in DataControl.tblProyectos
                        //                join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto.ToString()
                        //                join e in DataControl.tblEmpresas on c.idEmpresa equals e.idEmpresa
                        //                join u in DataControl.tblUsuarios on p.IdLider equals u.IdUsuario.ToString()
                        //                where p.IdCliente == usuario.idContacto.ToString() && p.Activo == 1 && p.Estatus != "6"
                        //                orderby p.FechaAlta descending
                        //                select new { 
                        //                    p.IdProyecto, 
                        //                    p.FolioProyecto, 
                        //                    p.NombreProyecto, 
                        //                    c.NombreContacto, 
                        //                    e.RazonSocial, 
                        //                    Lider = u.NombreCompleto, 
                        //                    FechaI = p.FechaInicio, 
                        //                    FechaT = p.FechaFin, 
                        //                    p.Estatus, 
                        //                    p.Activo,
                        //                    p.FolioPO
                        //                }
                        //            );
                        //retorno = JsonConvert.SerializeObject(proyects);

                        var proyects = DataControl.sp_Administracion().Where(a => a.IdCliente == usuario.idContacto.ToString() && a.Estatus != "6");

                        retorno = JsonConvert.SerializeObject(proyects);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        //var proyects = (from p in DataControl.tblProyectos
                        //                join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto.ToString()
                        //                join e in DataControl.tblEmpresas on c.idEmpresa equals e.idEmpresa
                        //                join u in DataControl.tblUsuarios on p.IdLider equals u.IdUsuario.ToString()
                        //                where p.IdCliente == usuario.idContacto.ToString() && p.Activo == 1 && p.Estatus != "6" && p.IdProyecto.ToString() == pid
                        //                orderby p.FechaAlta descending
                        //                select new { 
                        //                    p.IdProyecto, 
                        //                    p.FolioProyecto, 
                        //                    p.NombreProyecto, 
                        //                    c.NombreContacto, 
                        //                    e.RazonSocial, 
                        //                    Lider = u.NombreCompleto, 
                        //                    FechaI = p.FechaInicio, 
                        //                    FechaT = p.FechaFin, 
                        //                    p.Estatus, 
                        //                    p.Activo,
                        //                    p.FolioPO
                        //                }
                        //            );
                        //retorno = JsonConvert.SerializeObject(proyects);

                        var proyects = DataControl.sp_Administracion().Where(a => a.IdCliente == usuario.idContacto.ToString() && a.Estatus != "6" && a.IdProyecto.ToString() == pid);

                        retorno = JsonConvert.SerializeObject(proyects);
                    }
                }
            }
            
            
            return retorno;
        }

        [WebMethod]
        public static string CargarComentarios(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var proyects = (from p in DataControl.tblComentariosProyecto
                                join u in DataControl.tblUsuarios on p.IdUsuario equals u.IdUsuario
                                where p.IdProyecto.ToString() == pid
                                orderby p.FechaComentario descending

                                select new { p.IdProyecto, p.Comentario, u.NombreCompleto, Fecha = p.FechaComentario.Day + "/" + p.FechaComentario.Month + "/" + p.FechaComentario.Year }
                                     );
                retorno = JsonConvert.SerializeObject(proyects);
            }
            return retorno;
        }

        
    }
}