using MimeKit;
using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Administracion
{
    public partial class EnviarCorreo : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static tblReqEnc ReqEditable;
        public static List<tblReqDet> ReqEditableDetalles;
        public static string id = string.Empty;
        public static string Tipo = string.Empty;
        string OCcode = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                id = Request.QueryString["id"];
                Tipo = Request.QueryString["Tipo"];
                idEnviar.InnerText = id;
                TipoEnviar.InnerText = Tipo;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtenerOC(string pid)
        {            
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid i = Guid.Parse(id);
                if (Tipo == "1")//OC
                {
                    var oc = (from r in DataControl.tblOrdenCompra
                              join p in DataControl.tblProveedores on r.IdProveedor equals p.IdProveedor
                              where  r.IdOrdenCompra.ToString() == pid// && r.idSucursal == usuario.idSucursal

                              select new { ID = r.IdOrdenCompra, FOLIO= r.Folio, DIRIGIDO= p.Proveedor, CORREO=p.Email, ENVIADOR=usuario.Correo });
                    
                    retorno = JsonConvert.SerializeObject(oc);
                    if (retorno == "[]")
                    {
                        var oc2 = (from r in DataControl.tblOrdenCompraInsumos
                                  join p in DataControl.tblProveedores on r.IdProveedor equals p.IdProveedor
                                  where  r.IdOrdenCompra.ToString() == pid// && r.idSucursal == usuario.idSucursal

                                   select new { ID = r.IdOrdenCompra, FOLIO = r.Folio, DIRIGIDO = p.Proveedor, CORREO = p.Email, ENVIADOR = usuario.Correo });
                        retorno = JsonConvert.SerializeObject(oc2);
                        if (retorno == "[]")
                        {
                            retorno = "Error, no se encontro información de correo.";
                        }
                            
                    }
                }
                else if (Tipo == "2")
                {
                    var oc = (from r in DataControl.tblCotizaciones
                              join p in DataControl.tblClienteContacto on r.idContacto equals p.idContacto
                              where r.IdCotizaciones.ToString() == pid
                              select new { ID = r.IdCotizaciones, FOLIO = r.NoCotizaciones, DIRIGIDO = p.NombreContacto, CORREO = p.Correo, ENVIADOR = usuario.Correo });
                    
                    retorno = JsonConvert.SerializeObject(oc);
                    if (retorno == "[]")
                    {
                        retorno = "Error, no se encontro información de correo.";
                    }
                }
            }
            return retorno;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string to = txtPara.Value;
            string from = txtCorreo.Value;
            string nombreFrom = usuario.NombreCompleto;
            string subject = txtSubject.Value;
            string cc = txtConCopia.Value;
            string body = editor1.InnerText;
            //string[] attch;
            List<string> attch = new List<string>();
            string sFile = string.Empty;
            string sPathFile = AppDomain.CurrentDomain.BaseDirectory; //System.Configuration.ConfigurationManager.AppSettings["PathFiles"];


            foreach (var attachment in files.PostedFiles)
            {
                sFile = attachment.FileName;
                sFile = Path.GetFileName(sFile);
                attachment.SaveAs(sPathFile + "Correos\\" + sFile);
                attch.Add(sPathFile + "Correos\\" + sFile);

            }
            //if (files.PostedFile.FileName != "")
            //{

            //    sFile = files.PostedFile.FileName;
            //    // Extraemos el nombre del fichero, sin la ruta de nuestro disco
            //    sFile = System.IO.Path.GetFileName(sFile);
            //    files.PostedFile.SaveAs(sPathFile + "Correos\\" + sFile);
            //    attch = sPathFile + "Correos\\" + sFile;
                
            //}
           //if(Tipo == "1" && files.PostedFile.FileName == "")
           // {
           //     using (var DataControl = new SisaEntitie())
           //     {
                   
           //         var oc = DataControl.tblOrdenCompra.FirstOrDefault(o => o.IdOrdenCompra.ToString() == id);
           //         if (oc != null)
           //         {
                       
           //         }
           //         else
           //         {
           //             var oci = DataControl.tblOrdenCompraInsumos.FirstOrDefault(o => o.IdOrdenCompra.ToString() == id);
           //             if (oci != null)
           //             {

           //             }
           //         }

           //     }
           // }
           // else
           //
           if(Tipo == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var cot = DataControl.tblCotizaciones.FirstOrDefault(o => o.IdCotizaciones.ToString() == id);
                    if (cot != null)
                    {
                        if (!string.IsNullOrEmpty(cot.DocumentoPdf) && !string.IsNullOrEmpty(cot.NombreArchivoPdf))
                        {
                            string[] completo64 = cot.DocumentoPdf.Split(',');
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + cot.NombreArchivoPdf;
                            using (FileStream Writer = new System.IO.FileStream(a, FileMode.Create, FileAccess.Write))
                            {
                                Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                            }
                            attch.Add(AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + cot.NombreArchivoPdf);
                        }
                        
                    }
                }
                    
            }
            
            var Sucursal = "";
            using (var dataControl = new SisaEntitie())
            {
                Sucursal = dataControl.tblOrdenCompra.Where(o => o.IdOrdenCompra.ToString().Equals(id)).Select(o => o.idSucursal).FirstOrDefault().ToString();

                if (Sucursal == "")
                {
                    Sucursal = dataControl.tblOrdenCompraInsumos.Where(o => o.IdOrdenCompra.ToString().Equals(id)).Select(o => o.idSucursal).FirstOrDefault().ToString();
                }
            }

           //bool prueba = Proceso.EnviarCorreoDocsOffice(to, body, nombreFrom, from, subject, attch, cc, Sucursal);

            if (Proceso.EnviarCorreoDocsOffice(to, body, nombreFrom, from, subject, attch, cc, Sucursal))
            {
                using (var DataControl = new SisaEntitie())
                {
                    Guid i = Guid.Parse(id);
                    if (Tipo == "1")
                    {
                        var OC = DataControl.tblOrdenCompra.FirstOrDefault(o => o.IdOrdenCompra == i);
                        if (OC != null)
                        {
                            OC.Enviada = 1;
                            DataControl.SaveChanges();
                        }

                        var OC2 = DataControl.tblOrdenCompraInsumos.FirstOrDefault(o => o.IdOrdenCompra == i);
                        if (OC2 != null)
                        {
                            OC2.Enviada = 1;
                            DataControl.SaveChanges();
                        }
                    }
                    else if (Tipo == "2")
                    {
                        var c = DataControl.tblCotizaciones.FirstOrDefault(o => o.IdCotizaciones == i);
                        if (c != null)
                        {
                            c.Estatus = 4;
                            c.IdUsuarioEnvia = usuario.IdUsuario;
                            DataControl.SaveChanges();
                        }
                    }
                }
                SuccessText.Text = "Correo enviado.";
                SuccesMessage.Visible = true;
            }
            else
            {
                FailureText.Text = "Ocurrio un error al enviar correo.";
                ErrorMessage.Visible = true;
            }
        }
    }
}