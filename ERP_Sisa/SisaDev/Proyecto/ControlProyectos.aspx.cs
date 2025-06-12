using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Proyecto
{
    public partial class ControlProyectos : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string ObtenerProyectos(string pid)
        {//b.Procedure = "dbo.sp_LoadProyectosAdmin";
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Administracion == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL")
                        {
                            var proyects = DataControl.sp_Administracion();

                            retorno = JsonConvert.SerializeObject(proyects);
                        }
                        else
                        {
                            //var proyects = DataControl.sp_Administracion().Where(a=> a.idSucursal == usuario.idSucursal);
                            var proyects = DataControl.sp_Administracion().Where(a => a.idSucursal == usuario.idSucursal);

                            if (usuario.Usuario == "scaraveo" || usuario.Usuario == "cgarcia")
                            {
                                proyects = DataControl.sp_Administracion().Where(a => a.Cliente == "FORD IRAPUATO" || a.idSucursal == usuario.idSucursal);
                            }
                            //else
                            //{
                            //    proyects = DataControl.sp_Administracion().Where(a => a.idSucursal == usuario.idSucursal);
                            //}

                            //var proyects = DataControl.sp_Administracion().Where(a => a.Cliente == "FORD IRAPUATO" || a.idSucursal == usuario.idSucursal);

                            retorno = JsonConvert.SerializeObject(proyects);
                        }
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {

                        var proyects = DataControl.sp_Administracion().Where(a => a.IdProyecto.ToString() == pid).OrderBy(a => a.ID);
                        retorno = JsonConvert.SerializeObject(proyects);

                    }
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }

            return retorno;
        }
    }
}