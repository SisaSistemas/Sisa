using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Proyecto
{
    public partial class VerViaticos : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idViaticoUrl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idViaticoUrl = Request.QueryString["IdViaticos"];
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string EliminarViatico(string Id, string Gastada, string Entregada, string Diferencia)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ViaticosEliminar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblViaticosDet det = ((IQueryable<tblViaticosDet>)sisaEntitie.tblViaticosDet).FirstOrDefault<tblViaticosDet>((Expression<Func<tblViaticosDet, bool>>)(p => p.IdDet.ToString() == Id));
                        if (det != null)
                        {
                            tblViaticos tblViaticos = ((IQueryable<tblViaticos>)sisaEntitie.tblViaticos).FirstOrDefault<tblViaticos>((Expression<Func<tblViaticos, bool>>)(v => v.ID == det.IdViaticos));
                            Decimal num1 = 0M;
                            if (det.Gasolina > 0M)
                                num1 = det.Gasolina;
                            else if (det.Desayuno > 0M)
                                num1 = det.Desayuno;
                            else if (det.Comida > 0M)
                                num1 = det.Comida;
                            else if (det.Cena > 0M)
                                num1 = det.Cena;
                            else if (det.Casetas > 0M)
                                num1 = det.Casetas;
                            else if (det.Hotel > 0M)
                                num1 = det.Hotel;
                            else if (det.Transporte > 0M)
                                num1 = det.Transporte;
                            else if (det.Otros > 0M)
                                num1 = det.Otros;
                            Decimal? nullable = det.ManoObra;
                            Decimal num2 = 0M;
                            if (nullable.GetValueOrDefault() > num2 & nullable.HasValue)
                            {
                                nullable = det.ManoObra;
                                num1 = nullable.Value;
                            }
                            nullable = det.Equipo;
                            Decimal num3 = 0M;
                            if (nullable.GetValueOrDefault() > num3 & nullable.HasValue)
                            {
                                nullable = det.Equipo;
                                num1 = nullable.Value;
                            }
                            nullable = det.Materiales;
                            Decimal num4 = 0M;
                            if (nullable.GetValueOrDefault() > num4 & nullable.HasValue)
                            {
                                nullable = det.Materiales;
                                num1 = nullable.Value;
                            }
                            tblViaticos.CantGastada = tblViaticos.CantGastada > 0M ? tblViaticos.CantGastada - num1 : tblViaticos.CantGastada;
                            sisaEntitie.tblViaticosDet.Remove(det);
                            sisaEntitie.SaveChanges();
                            tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(a => a.idDocumento == Id));
                            if (eficienciasDesglose != null)
                            {
                                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                                sisaEntitie.SaveChanges();
                            }
                            str = "Viatico eliminado.";
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
        
        [WebMethod]
        public static string EliminarDocumento(string Id, string Opcion)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ViaticosEliminar || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblViaticosDet tblViaticosDet = ((IQueryable<tblViaticosDet>)sisaEntitie.tblViaticosDet).FirstOrDefault<tblViaticosDet>((Expression<Func<tblViaticosDet, bool>>)(p => p.IdDet.ToString() == Id));
                        if (tblViaticosDet != null)
                        {
                            tblViaticosDet.Ticket = "";
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
        public static string CargarDocumentos(string Id, string Opcion)
        {
            string empty = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    return JsonConvert.SerializeObject((object)((IQueryable<tblViaticosDet>)sisaEntitie.tblViaticosDet).Where<tblViaticosDet>((Expression<Func<tblViaticosDet, bool>>)(p => p.IdDet.ToString() == Id)).Select(p => new
                    {
                        Ticket = p.Ticket != default(string) ? p.Ticket : "",
                        IdDet = p.IdDet
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
            if (rolesUsuarios.ViaticosEditar || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        Guid id = Guid.Parse(Id);
                        tblViaticosDet tblViaticosDet = ((IQueryable<tblViaticosDet>)sisaEntitie.tblViaticosDet).FirstOrDefault<tblViaticosDet>((Expression<Func<tblViaticosDet, bool>>)(p => p.IdDet == id));
                        if (tblViaticosDet != null)
                        {
                            tblViaticosDet.Ticket = File;
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
        public static string Cargar(string IdViatico)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadViaticos_Result>)sisaEntitie.sp_LoadViaticos(IdViatico)).OrderBy<sp_LoadViaticos_Result, DateTime?>((Func<sp_LoadViaticos_Result, DateTime?>)(s => s.FechaViaticos)));
            }
                
        }

        [WebMethod]
        public static string CargarInfoGeneral(string id)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)((IEnumerable<sp_CargaListaViaticos_Result>)sisaEntitie.sp_CargaListaViaticos()).FirstOrDefault<sp_CargaListaViaticos_Result>((Func<sp_CargaListaViaticos_Result, bool>)(a => a.ID.ToString() == id)));
            }
                
        }
        
        [WebMethod]
        public static string CargarSuma(string IdViatico)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_LoadSumaColumnasViaticos(IdViatico));
            }
                
        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombos(new int?(int32)));
            }

        }

        [WebMethod]
        public static string GuardarViaticoDetalle(string idProyecto, string txtDescripcion, string txtCantidad, string Tick, string cmbGasto, string txtFechaGasto, string idViatico)
        {
            string str1 = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ViaticosAgregar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblViaticosDet add = new tblViaticosDet()
                    {
                        IdDet = Guid.NewGuid(),
                        IdViaticos = Guid.Parse(idViatico),
                        FechaViaticos = Convert.ToDateTime(txtFechaGasto),
                        Descripcion = txtDescripcion,
                        Ticket = Tick,
                        idProyecto = new Guid?(Guid.Parse(idProyecto))
                    };
                    switch (Convert.ToInt32(cmbGasto))
                    {
                        case 1:
                            add.Gasolina = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 2:
                            add.Desayuno = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 3:
                            add.Comida = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 4:
                            add.Cena = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 5:
                            add.Casetas = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 6:
                            add.Hotel = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 7:
                            add.Transporte = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 8:
                            add.Otros = Decimal.Parse(txtCantidad);
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 9:
                            add.Materiales = new Decimal?(Decimal.Parse(txtCantidad));
                            add.ManoObra = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 10:
                            add.ManoObra = new Decimal?(Decimal.Parse(txtCantidad));
                            add.Materiales = new Decimal?(0M);
                            add.Equipo = new Decimal?(0M);
                            break;
                        case 11:
                            add.Equipo = new Decimal?(Decimal.Parse(txtCantidad));
                            add.Materiales = new Decimal?(0M);
                            add.ManoObra = new Decimal?(0M);
                            break;
                    }
                    sisaEntitie.tblViaticosDet.Add(add);
                    if (sisaEntitie.SaveChanges() > 0)
                    {
                        tblViaticos tblViaticos = ((IQueryable<tblViaticos>)sisaEntitie.tblViaticos).FirstOrDefault<tblViaticos>((Expression<Func<tblViaticos, bool>>)(v => v.ID.ToString().Trim() == idViatico));
                        tblViaticos.CantGastada += Decimal.Parse(txtCantidad);
                        tblViaticos.Diferencia = new Decimal?(tblViaticos.CantEntregada - tblViaticos.CantGastada);
                        sisaEntitie.SaveChanges();
                        Decimal? nullable = add.Materiales;
                        Decimal num1 = 0M;
                        if (!(nullable.GetValueOrDefault() > num1 & nullable.HasValue))
                        {
                            nullable = add.ManoObra;
                            Decimal num2 = 0M;
                            if (!(nullable.GetValueOrDefault() > num2 & nullable.HasValue))
                            {
                                nullable = add.Equipo;
                                Decimal num3 = 0M;
                                if (!(nullable.GetValueOrDefault() > num3 & nullable.HasValue))
                                    goto label_27;
                            }
                        }
                        Decimal num4 = Decimal.Parse(txtCantidad);
                        string str2 = "";
                        nullable = add.Materiales;
                        Decimal num5 = 0M;
                        if (nullable.GetValueOrDefault() > num5 & nullable.HasValue)
                        {
                            str2 = "MATERIAL";
                        }
                        else
                        {
                            nullable = add.ManoObra;
                            Decimal num6 = 0M;
                            if (nullable.GetValueOrDefault() > num6 & nullable.HasValue)
                            {
                                str2 = "MANOOBRA";
                            }
                            else
                            {
                                nullable = add.Equipo;
                                Decimal num7 = 0M;
                                if (nullable.GetValueOrDefault() > num7 & nullable.HasValue)
                                    str2 = "EQUIPO";
                            }
                        }
                        tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(e => e.idDocumento.ToString() == add.IdDet.ToString()));
                        if (eficienciasDesglose1 != null)
                        {
                            eficienciasDesglose1.idProyecto = idProyecto;
                            eficienciasDesglose1.idDocumento = add.IdDet.ToString();
                            eficienciasDesglose1.Categoria = str2.ToUpper();
                            eficienciasDesglose1.Total = new Decimal?(num4);
                            eficienciasDesglose1.TipoDoc = "VD";
                            sisaEntitie.SaveChanges();
                        }
                        else
                        {
                            tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
                            {
                                idProyecto = idProyecto,
                                idDocumento = add.IdDet.ToString(),
                                Categoria = str2.ToUpper(),
                                Total = new Decimal?(num4),
                                TipoDoc = "VD",
                                Folio = "",
                                FechaDoc = new DateTime?(add.FechaViaticos),
                                idUsuarioUltimo = VerViaticos.usuario.IdUsuario.ToString()
                            };
                            sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose2);
                            sisaEntitie.SaveChanges();
                        }
                    label_27:
                        str1 = "Detalle creado.";
                    }
                    else
                        str1 = "Ocurrio un problema al guardar gasto viatico.";
                }
            }
            else
                str1 = "No tienes permiso de agregar gasto viatico.";
            return str1;
        }

        [WebMethod]
        public static string ActualizarCantidad(string ActualizarCantidad)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblViaticos tblViaticos = ((IQueryable<tblViaticos>)sisaEntitie.tblViaticos).FirstOrDefault<tblViaticos>((Expression<Func<tblViaticos, bool>>)(p => p.ID.ToString() == VerViaticos.idViaticoUrl));
                        if (tblViaticos != null)
                        {
                            tblViaticos.CantEntregada = Decimal.Parse(ActualizarCantidad);
                            tblViaticos.Diferencia = new Decimal?(tblViaticos.CantEntregada - tblViaticos.CantGastada);
                            sisaEntitie.SaveChanges();
                            str = "Cantidad actualizada.";
                        }
                        else
                            str = "No se encontro información de viatico, intenta de nuevo recargando página";
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
        public static string CargarCantidadEntregada(string IdViatico)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                empty = JsonConvert.SerializeObject(sisaEntitie.sp_LoadViaticosDetCantEntregada(IdViatico).Where(a => a.Activo == 1).OrderBy(s => s.FechaAlta));
                return empty;
                //return JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadViaticosDetCantEntregada_Result>)sisaEntitie.sp_LoadViaticosDetCantEntregada(IdViatico)).OrderBy<sp_LoadViaticosDetCantEntregada_Result, DateTime?>((Func<sp_LoadViaticosDetCantEntregada_Result, DateTime?>)(s => s.FechaAlta)));
            }
        }

        [WebMethod]
        public static string GuardarCantidadEntregada(string idViaticos, string Cantidad)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ViaticosAgregar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblViaticosDetCantEntregada addCantidadEntregada = new tblViaticosDetCantEntregada()
                        {
                            IdViaticosDetCantEntregada = Guid.NewGuid(),
                            IdViaticos = Guid.Parse(idViaticos),
                            Cantidad = Convert.ToDecimal(Cantidad),
                            Activo = 1,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaAlta = DateTime.Now,
                            IdUsuarioModificacion = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioElimina = usuario.IdUsuario,
                            FechaElimina = DateTime.Now
                        };
                        sisaEntitie.tblViaticosDetCantEntregada.Add(addCantidadEntregada);
                        if (sisaEntitie.SaveChanges() > 0)
                        {
                            //Aqui se tiene que actualizar la tabla de viaticos, el total o cantidad agregada

                            tblViaticos tblViaticos = sisaEntitie.tblViaticos.FirstOrDefault(p => p.ID.ToString() == VerViaticos.idViaticoUrl);//((IQueryable<tblViaticos>)sisaEntitie.tblViaticos).FirstOrDefault<tblViaticos>((Expression<Func<tblViaticos, bool>>)(p => p.ID.ToString() == VerViaticos.idViaticoUrl));
                            if (tblViaticos != null)
                            {
                                tblViaticos.CantEntregada = (tblViaticos.CantEntregada + Convert.ToDecimal(Cantidad));//Decimal.Parse(ActualizarCantidad);
                                tblViaticos.Diferencia = ((tblViaticos.CantEntregada + Convert.ToDecimal(Cantidad)) - tblViaticos.CantGastada);
                                sisaEntitie.SaveChanges();
                                //str = "Cantidad actualizada.";
                                str = "Guardado con Exito!!";
                            }
                            else
                            {
                                str = "No se encontro información de viatico, intenta de nuevo recargando página";
                            }
                                
                            
                        }
                        else
                        {
                            str = "Ocurrio un error favor de avisar al administrador del sistema...";
                        }
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de agregar.";
            return str;
        }

        [WebMethod]
        public static string EliminarCantidadEntregada(string idViaticosDetCantEntregada)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ViaticosAgregar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {

                        decimal cantidadEliminada = 0;

                        tblViaticosDetCantEntregada eliminarCantidadEntregada = sisaEntitie.tblViaticosDetCantEntregada.FirstOrDefault(p => p.IdViaticosDetCantEntregada.ToString() == idViaticosDetCantEntregada);
                        if (eliminarCantidadEntregada != null)
                        {
                            cantidadEliminada = eliminarCantidadEntregada.Cantidad;
                            eliminarCantidadEntregada.Activo = 0;
                            eliminarCantidadEntregada.FechaElimina = DateTime.Now;
                            eliminarCantidadEntregada.IdUsuarioElimina = usuario.IdUsuario;
                            if (sisaEntitie.SaveChanges() > 0)
                            {
                                tblViaticos tblViaticos = sisaEntitie.tblViaticos.FirstOrDefault(p => p.ID.ToString() == VerViaticos.idViaticoUrl);
                                if (tblViaticos != null)
                                {
                                    tblViaticos.CantEntregada = (tblViaticos.CantEntregada - cantidadEliminada);
                                    tblViaticos.Diferencia = ((tblViaticos.CantEntregada - cantidadEliminada) - tblViaticos.CantGastada);
                                    sisaEntitie.SaveChanges();
                                    //str = "Cantidad actualizada.";
                                    str = "Guardado con Exito!!";
                                }
                                else
                                {
                                    str = "No se encontro información de viatico, intenta de nuevo recargando página";
                                }
                            }
                            else
                            {
                                str = "Ocurrio un error favor de avisar al administrador del sistema...";
                            }
                        }
                        else
                        {
                            str = "No se encontro información de viatico, intenta de nuevo recargando página";
                        }

                        
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de agregar.";
            return str;
        }
    }
}