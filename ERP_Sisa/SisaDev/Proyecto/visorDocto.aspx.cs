using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Proyecto
{
    public partial class visorDocto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Direccion física del archivo PDF que queremos visualizar.
            //NOTA: Como el nombre del archivo lo pasamos a través de la URL, por eso es necesario
            //obtenerlo a traves del objeto REQUEST.
            //string FileName = @"D:\Proyectos\" + Request.QueryString.ToString();
            string Folio = Request.QueryString["Proyecto"];
            string FileName = @"C:\SisaFiles\Proyectos\" + Folio + @"\" + Request.QueryString["Docto"];

            //Borra todas las salidas del flujo de memoria
            Response.ClearContent();
            //Borra todos los encabezados del flujo de memoria
            Response.ClearHeaders();
            //Añade una cabecera HTTP al flujo de salida
            Response.AddHeader("Content-Disposition", "inline;filename=" + FileName);
            //Obtiene o establece el tipo MIME de HTTP del flujo de salida
            Response.ContentType = "application/pdf";
            //Escribe el contenido del archivo especificado en un flujo de salida de respuesta HTTP como un bloque de archivos
            Response.WriteFile(FileName);
            //envía toda la salida del buffer al cliente
            Response.Flush();
            //Borra todas las salidas de contenidos del flujo de memoria
            Response.Clear();
        }
    }
}