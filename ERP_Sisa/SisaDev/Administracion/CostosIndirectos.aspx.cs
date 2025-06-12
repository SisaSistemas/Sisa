using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Xml.Linq;

namespace SisaDev.Administracion
{
    public partial class CostosIndirectos : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;

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
        public static string ActualizaTipoCambio(string ID, string items)
        {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_ActualizaTipoCambio(ID, items));
            }
        }

        [WebMethod]
        public static string ObtieneCostosIndirectos(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_ObtieneCostosIndirectos());
            }
        }

        [WebMethod]
        public static string ObtieneTotalProyectos(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_ObtieneTotalProyectos());
            }
        }

        [WebMethod]
        public static string CargarCostosIndirectos(string Opcion, string Sucursal)
        {
            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectCostosIndirectos(Convert.ToInt32(Opcion), Convert.ToInt32(Sucursal)));
            //}

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {

                return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectCostosIndirectosResumen(Convert.ToInt32(Opcion)));
            }
        }

        [WebMethod]
        public static string VerCostosIndirectos(string FechaIni, string FechaFin)
        {
            //using (SisaEntitie sisaEntitie = new SisaEntitie())
            //{

            //    return JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectCostosIndirectos(Convert.ToInt32(Opcion), Convert.ToInt32(Sucursal)));
            //}

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {

                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCostosIndirectos(FechaIni, FechaFin));
            }
        }

        [WebMethod]
        public static string GuardarCostoIndirecto(string pCostoNomina, string pCostoImss, string pCostoTotal, string pTotalEmpleados, string pInteresGlobal, string pVacacionesGlobal, string pAguinaldoGlobal
            , string pCostoNominaHermosillo, string pCostoImssHermosillo, string pCostoTotalHermosillo, string pTotalEmpleadosHermosillo, string pPerdidaCambiariaHermosillo, string pUtilidadCambiariaHermosillo, string pComisionBancariaHermosillo
            , string pGastosAdmonHermosillo, string pConsumiblesHermosillo, string pGasolinaHermosillo, string pEquipoSeguridadHermosillo, string pInventarioHermosillo, string pViaticosHermosillo, string pCarrosHermosillo, string pUniformesHermosillo, string pVacacionesHermosillo, string pAguinaldoHermosillo
            , string pCostoNominaHermosilloCCM, string pCostoImssHermosilloCCM, string pCostoTotalHermosilloCCM, string pTotalEmpleadosHermosilloCCM, string pPerdidaCambiariaHermosilloCCM, string pUtilidadCambiariaHermosilloCCM, string pComisionBancariaHermosilloCCM
            , string pGastosAdmonHermosilloCCM, string pConsumiblesHermosilloCCM, string pGasolinaHermosilloCCM, string pEquipoSeguridadHermosilloCCM, string pInventarioHermosilloCCM, string pViaticosHermosilloCCM, string pCarrosHermosilloCCM, string pUniformesHermosilloCCM, string pVacacionesHermosilloCCM, string pAguinaldoHermosilloCCM
            , string pCostoNominaChihuahua, string pCostoImssChihuahua, string pCostoTotalChihuahua, string pTotalEmpleadosChihuahua, string pPerdidaCambiariaChihuahua, string pUtilidadCambiariaChihuahua, string pComisionBancariaChihuahua
            , string pGastosAdmonChihuahua, string pConsumiblesChihuahua, string pGasolinaChihuahua, string pEquipoSeguridadChihuahua, string pInventarioChihuahua, string pViaticosChihuahua, string pCarrosChihuahua, string pUniformesChihuahua, string pVacacionesChihuahua, string pAguinaldoChihuahua
            , string pCostoNominaChihuahuaCCM, string pCostoImssChihuahuaCCM, string pCostoTotalChihuahuaCCM, string pTotalEmpleadosChihuahuaCCM, string pPerdidaCambiariaChihuahuaCCM, string pUtilidadCambiariaChihuahuaCCM, string pComisionBancariaChihuahuaCCM
            , string pGastosAdmonChihuahuaCCM, string pConsumiblesChihuahuaCCM, string pGasolinaChihuahuaCCM, string pEquipoSeguridadChihuahuaCCM, string pInventarioChihuahuaCCM, string pViaticosChihuahuaCCM, string pCarrosChihuahuaCCM, string pUniformesChihuahuaCCM, string pVacacionesChihuahuaCCM, string pAguinaldoChihuahuaCCM
            , string pCostoNominaCuautitlan, string pCostoImssCuautitlan, string pCostoTotalCuautitlan, string pTotalEmpleadosCuautitlan, string pPerdidaCambiariaCuautitlan, string pUtilidadCambiariaCuautitlan, string pComisionBancariaCuautitlan
            , string pGastosAdmonCuautitlan, string pConsumiblesCuautitlan, string pGasolinaCuautitlan, string pEquipoSeguridadCuautitlan, string pInventarioCuautitlan, string pViaticosCuautitlan, string pCarrosCuautitlan, string pUniformesCuautitlan, string pVacacionesCuautitlan, string pAguinaldoCuautitlan
            , string pCostoNominaCuautitlanCCM, string pCostoImssCuautitlanCCM, string pCostoTotalCuautitlanCCM, string pTotalEmpleadosCuautitlanCCM, string pPerdidaCambiariaCuautitlanCCM, string pUtilidadCambiariaCuautitlanCCM, string pComisionBancariaCuautitlanCCM
            , string pGastosAdmonCuautitlanCCM, string pConsumiblesCuautitlanCCM, string pGasolinaCuautitlanCCM, string pEquipoSeguridadCuautitlanCCM, string pInventarioCuautitlanCCM, string pViaticosCuautitlanCCM, string pCarrosCuautitlanCCM, string pUniformesCuautitlanCCM, string pVacacionesCuautitlanCCM, string pAguinaldoCuautitlanCCM
            , string pCostoNominaIrapuato, string pCostoImssIrapuato, string pCostoTotalIrapuato, string pTotalEmpleadosIrapuato, string pPerdidaCambiariaIrapuato, string pUtilidadCambiariaIrapuato, string pComisionBancariaIrapuato
            , string pGastosAdmonIrapuato, string pConsumiblesIrapuato, string pGasolinaIrapuato, string pEquipoSeguridadIrapuato, string pInventarioIrapuato, string pViaticosIrapuato, string pCarrosIrapuato, string pUniformesIrapuato, string pVacacionesIrapuato, string pAguinaldoIrapuato
            , string pCostoNominaIrapuatoCCM, string pCostoImssIrapuatoCCM, string pCostoTotalIrapuatoCCM, string pTotalEmpleadosIrapuatoCCM, string pPerdidaCambiariaIrapuatoCCM, string pUtilidadCambiariaIrapuatoCCM, string pComisionBancariaIrapuatoCCM
            , string pGastosAdmonIrapuatoCCM, string pConsumiblesIrapuatoCCM, string pGasolinaIrapuatoCCM, string pEquipoSeguridadIrapuatoCCM, string pInventarioIrapuatoCCM, string pViaticosIrapuatoCCM, string pCarrosIrapuatoCCM, string pUniformesIrapuatoCCM, string pVacacionesIrapuatoCCM, string pAguinaldoIrapuatoCCM
            , string pCostoNominaQueretaro, string pCostoImssQueretaro, string pCostoTotalQueretaro, string pTotalEmpleadosQueretaro, string pPerdidaCambiariaQueretaro, string pUtilidadCambiariaQueretaro, string pComisionBancariaQueretaro
            , string pGastosAdmonQueretaro, string pConsumiblesQueretaro, string pGasolinaQueretaro, string pEquipoSeguridadQueretaro, string pInventarioQueretaro, string pViaticosQueretaro, string pCarrosQueretaro, string pUniformesQueretaro, string pVacacionesQueretaro, string pAguinaldoQueretaro
            , string pCostoNominaQueretaroCCM, string pCostoImssQueretaroCCM, string pCostoTotalQueretaroCCM, string pTotalEmpleadosQueretaroCCM, string pPerdidaCambiariaQueretaroCCM, string pUtilidadCambiariaQueretaroCCM, string pComisionBancariaQueretaroCCM
            , string pGastosAdmonQueretaroCCM, string pConsumiblesQueretaroCCM, string pGasolinaQueretaroCCM, string pEquipoSeguridadQueretaroCCM, string pInventarioQueretaroCCM, string pViaticosQueretaroCCM, string pCarrosQueretaroCCM, string pUniformesQueretaroCCM, string pVacacionesQueretaroCCM, string pAguinaldoQueretaroCCM
            , string pCostoNominaTecate, string pCostoImssTecate, string pCostoTotalTecate, string pTotalEmpleadosTecate, string pPerdidaCambiariaTecate, string pUtilidadCambiariaTecate, string pComisionBancariaTecate
            , string pGastosAdmonTecate, string pConsumiblesTecate, string pGasolinaTecate, string pEquipoSeguridadTecate, string pInventarioTecate, string pViaticosTecate, string pCarrosTecate, string pUniformesTecate, string pVacacionesTecate, string pAguinaldoTecate
            , string pCostoNominaUSA, string pCostoImssUSA, string pCostoTotalUSA, string pTotalEmpleadosUSA, string pPerdidaCambiariaUSA, string pUtilidadCambiariaUSA, string pComisionBancariaUSA
            , string pGastosAdmonUSA, string pConsumiblesUSA, string pGasolinaUSA, string pEquipoSeguridadUSA, string pInventarioUSA, string pViaticosUSA, string pCarrosUSA, string pUniformesUSA, string pVacacionesUSA, string pAguinaldoUSA
            , string pProyectosGlobal, string pProyectosHermosillo, string pProyectosHermosilloCCM, string pProyectosChihuahua, string pProyectosChihuahuaCCM, string pProyectosCuautitlan, string pProyectosCuautitlanCCM
            , string pProyectosIrapuato, string pProyectosIrapuatoCCM, string pProyectosQueretaro, string pProyectosQueretaroCCM, string pProyectosTecate, string pProyectosUSA
            , string pCotizadoGlobal, string pPorcentajeGlobal, string pCotizadoHermosillo, string pPorcentajeHermosillo, string pCotizadoHermosilloCCM, string pPorcentajeHermosilloCCM, string pCotizadoChihuahua, string pPorcentajeChihuahua, string pCotizadoChihuahuaCCM, string pPorcentajeChihuahuaCCM
            , string pCotizadoCuautitlan, string pPorcentajeCuautitlan, string pCotizadoCuautitlanCCM, string pPorcentajeCuautitlanCCM, string pCotizadoIrapuato, string pPorcentajeIrapuato, string pCotizadoIrapuatoCCM, string pPorcentajeIrapuatoCCM
            , string pCotizadoQueretaro, string pPorcentajeQueretaro, string pCotizadoQueretaroCCM, string pPorcentajeQueretaroCCM, string pCotizadoTecate, string pPorcentajeTecate, string pCotizadoUSA, string pPorcentajeUSA
            , string pFechaIni, string pFechaFin, string pTotalGlobal, string pTotalHermosillo, string pTotalHermosilloCCM, string pTotalChihuahua, string pTotalChihuahuaCCM, string pTotalCuautitlan, string pTotalCuautitlanCCM
            , string pTotalIrapuato, string pTotalIrapuatoCCM, string pTotalQueretaro, string pTotalQueretaroCCM, string pTotalTecate, string pTotalUSA
            )
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.CostoIndirecto == true)
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        
                        var tblCostoIndirectoGlobal = DataControl.tblCostoIndirectoGlobal.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoHermosilloRemove = DataControl.tblCostoIndirectoHermosillo.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoHermosilloCCMRemove = DataControl.tblCostoIndirectoHermosilloCCM.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoChihuahuaRemove = DataControl.tblCostoIndirectoChihuahua.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoChihuahuaCCMRemove = DataControl.tblCostoIndirectoChihuahuaCCM.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoCuautitlanRemove = DataControl.tblCostoIndirectoCuautitlan.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoCuautitlanCCMRemove = DataControl.tblCostoIndirectoCuautitlanCCM.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoIrapuatoRemove = DataControl.tblCostoIndirectoIrapuato.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoIrapuatoCCMRemove = DataControl.tblCostoIndirectoIrapuatoCCM.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoQueretaroRemove = DataControl.tblCostoIndirectoQueretaro.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoQueretaroCCMRemove = DataControl.tblCostoIndirectoQueretaroCCM.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoTecateRemove = DataControl.tblCostoIndirectoTecate.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);
                        var tblCostoIndirectoUSARemove = DataControl.tblCostoIndirectoUSA.FirstOrDefault(p => p.FechaIni.ToString() == pFechaIni && p.FechaFin.ToString() == pFechaFin);

                        if (tblCostoIndirectoGlobal != null)
                        {
                            DataControl.tblCostoIndirectoGlobal.Remove(tblCostoIndirectoGlobal);
                            if (DataControl.SaveChanges() > 0)
                            {
                                if (tblCostoIndirectoHermosilloRemove != null)
                                {
                                    DataControl.tblCostoIndirectoHermosillo.Remove(tblCostoIndirectoHermosilloRemove);
                                    if (DataControl.SaveChanges() > 0)
                                    {
                                        DataControl.tblCostoIndirectoHermosilloCCM.Remove(tblCostoIndirectoHermosilloCCMRemove);
                                        if (DataControl.SaveChanges() > 0)
                                        {
                                            DataControl.tblCostoIndirectoChihuahua.Remove(tblCostoIndirectoChihuahuaRemove);
                                            if (DataControl.SaveChanges() > 0)
                                            {
                                                DataControl.tblCostoIndirectoChihuahuaCCM.Remove(tblCostoIndirectoChihuahuaCCMRemove);
                                                if (DataControl.SaveChanges() > 0)
                                                {
                                                    DataControl.tblCostoIndirectoCuautitlan.Remove(tblCostoIndirectoCuautitlanRemove);
                                                    if (DataControl.SaveChanges() > 0)
                                                    {
                                                        DataControl.tblCostoIndirectoCuautitlanCCM.Remove(tblCostoIndirectoCuautitlanCCMRemove);
                                                        if (DataControl.SaveChanges() > 0)
                                                        {
                                                            DataControl.tblCostoIndirectoIrapuato.Remove(tblCostoIndirectoIrapuatoRemove);
                                                            if (DataControl.SaveChanges() > 0)
                                                            {
                                                                DataControl.tblCostoIndirectoIrapuatoCCM.Remove(tblCostoIndirectoIrapuatoCCMRemove);
                                                                if (DataControl.SaveChanges() > 0)
                                                                {
                                                                    DataControl.tblCostoIndirectoQueretaro.Remove(tblCostoIndirectoQueretaroRemove);
                                                                    if (DataControl.SaveChanges() > 0)
                                                                    {
                                                                        DataControl.tblCostoIndirectoQueretaroCCM.Remove(tblCostoIndirectoQueretaroCCMRemove);
                                                                        if (DataControl.SaveChanges() > 0)
                                                                        {
                                                                            DataControl.tblCostoIndirectoTecate.Remove(tblCostoIndirectoTecateRemove);
                                                                            if (DataControl.SaveChanges() > 0)
                                                                            {
                                                                                DataControl.tblCostoIndirectoUSA.Remove(tblCostoIndirectoUSARemove);
                                                                                DataControl.SaveChanges();
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        var porcentajeGlobal = pCotizadoGlobal != "" && pTotalGlobal != "" && decimal.Parse(pCotizadoGlobal) != decimal.Parse("0") ? (decimal.Parse(pTotalGlobal) / decimal.Parse(pCotizadoGlobal)) : decimal.Parse("0");
                        tblCostoIndirectoGlobal add = new tblCostoIndirectoGlobal
                        {
                            IdCostoIndirectoGlobal = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            NominaGlobal = pCostoNomina != "" ? Decimal.Parse(pCostoNomina) : Decimal.Parse("0"),
                            ImssGlobal = pCostoImss != "" ? Decimal.Parse(pCostoImss) : Decimal.Parse("0"),
                            TotalGlobal = pCostoTotal != "" ? Decimal.Parse(pCostoTotal) : Decimal.Parse("0"),
                            TotalEmpleadosGlobal = pTotalEmpleados != "" ? Decimal.Parse(pTotalEmpleados) : Decimal.Parse("0"),
                            InteresGlobal = pInteresGlobal != "" ? Decimal.Parse(pInteresGlobal) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosGlobal != "" ? Decimal.Parse(pProyectosGlobal) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoGlobal != "" ? Decimal.Parse(pCotizadoGlobal) : Decimal.Parse("0"),
                            Porcentaje = porcentajeGlobal,//pPorcentajeGlobal != "" ? Decimal.Parse(pPorcentajeGlobal) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesGlobal != "" ? Decimal.Parse(pVacacionesGlobal) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoGlobal != "" ? Decimal.Parse(pAguinaldoGlobal) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoGlobal.Add(add);
                        DataControl.SaveChanges();

                        var porcentajeHermosillo = pCotizadoHermosillo != "" && pTotalHermosillo != "" && decimal.Parse(pCotizadoHermosillo) != decimal.Parse("0") ? (decimal.Parse(pTotalHermosillo) / decimal.Parse(pCotizadoHermosillo)) : decimal.Parse("0");
                        tblCostoIndirectoHermosillo tblCostoIndirectoHermosillo = new tblCostoIndirectoHermosillo
                        {
                            IdCostoIndirectoHermosillo = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaHermosillo != "" ? Decimal.Parse(pCostoNominaHermosillo) : Decimal.Parse("0"),
                            Imss = pCostoImssHermosillo != "" ? Decimal.Parse(pCostoImssHermosillo) : Decimal.Parse("0"),
                            Total = pCostoTotalHermosillo != "" ? Decimal.Parse(pCostoTotalHermosillo) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosHermosillo != "" ? Decimal.Parse(pTotalEmpleadosHermosillo) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonHermosillo != "" ? Decimal.Parse(pGastosAdmonHermosillo) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesHermosillo != "" ? Decimal.Parse(pConsumiblesHermosillo) : Decimal.Parse("0"),
                            Gasolina = pGasolinaHermosillo != "" ? Decimal.Parse(pGasolinaHermosillo) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadHermosillo != "" ? Decimal.Parse(pEquipoSeguridadHermosillo) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioHermosillo != "" ? Decimal.Parse(pInventarioHermosillo) : Decimal.Parse("0"),
                            Viaticos = pViaticosHermosillo != "" ? Decimal.Parse(pViaticosHermosillo) : Decimal.Parse("0"),
                            Carros = pCarrosHermosillo != "" ? Decimal.Parse(pCarrosHermosillo) : Decimal.Parse("0"),
                            Uniformes = pUniformesHermosillo != "" ? Decimal.Parse(pUniformesHermosillo) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaHermosillo != "" ? Decimal.Parse(pPerdidaCambiariaHermosillo) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaHermosillo != "" ? Decimal.Parse(pUtilidadCambiariaHermosillo) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaHermosillo != "" ? Decimal.Parse(pComisionBancariaHermosillo) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosHermosillo != "" ? Decimal.Parse(pProyectosHermosillo) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoHermosillo != "" ? Decimal.Parse(pCotizadoHermosillo) : Decimal.Parse("0"),
                            Porcentaje = porcentajeHermosillo,//pPorcentajeHermosillo != "" ? Decimal.Parse(pPorcentajeHermosillo) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesHermosillo != "" ? Decimal.Parse(pVacacionesHermosillo) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoHermosillo != "" ? Decimal.Parse(pAguinaldoHermosillo) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoHermosillo.Add(tblCostoIndirectoHermosillo);
                        DataControl.SaveChanges();

                        var porcentajeHermosilloCCM = pCotizadoHermosilloCCM != "" && pTotalHermosilloCCM != "" && decimal.Parse(pCotizadoHermosilloCCM) != decimal.Parse("0") ? (decimal.Parse(pTotalHermosilloCCM) / decimal.Parse(pCotizadoHermosilloCCM)): decimal.Parse("0");
                        tblCostoIndirectoHermosilloCCM tblCostoIndirectoHermosilloCCM = new tblCostoIndirectoHermosilloCCM
                        {
                            IdCostoIndirectoHermosilloCCM = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaHermosilloCCM != "" ? Decimal.Parse(pCostoNominaHermosilloCCM) : Decimal.Parse("0"),
                            Imss = pCostoImssHermosilloCCM != "" ? Decimal.Parse(pCostoImssHermosilloCCM) : Decimal.Parse("0"),
                            Total = pCostoTotalHermosilloCCM != "" ? Decimal.Parse(pCostoTotalHermosilloCCM) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosHermosilloCCM != "" ? Decimal.Parse(pTotalEmpleadosHermosilloCCM) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonHermosilloCCM != "" ? Decimal.Parse(pGastosAdmonHermosilloCCM) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesHermosilloCCM != "" ? Decimal.Parse(pConsumiblesHermosilloCCM) : Decimal.Parse("0"),
                            Gasolina = pGasolinaHermosilloCCM != "" ? Decimal.Parse(pGasolinaHermosilloCCM) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadHermosilloCCM != "" ? Decimal.Parse(pEquipoSeguridadHermosilloCCM) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioHermosilloCCM != "" ? Decimal.Parse(pInventarioHermosilloCCM) : Decimal.Parse("0"),
                            Viaticos = pViaticosHermosilloCCM != "" ? Decimal.Parse(pViaticosHermosilloCCM) : Decimal.Parse("0"),
                            Carros = pCarrosHermosilloCCM != "" ? Decimal.Parse(pCarrosHermosilloCCM) : Decimal.Parse("0"),
                            Uniformes = pUniformesHermosilloCCM != "" ? Decimal.Parse(pUniformesHermosilloCCM) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaHermosilloCCM != "" ? Decimal.Parse(pPerdidaCambiariaHermosilloCCM) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaHermosilloCCM != "" ? Decimal.Parse(pUtilidadCambiariaHermosilloCCM) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaHermosilloCCM != "" ? Decimal.Parse(pComisionBancariaHermosilloCCM) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosHermosilloCCM != "" ? Decimal.Parse(pProyectosHermosilloCCM) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoHermosilloCCM != "" ? Decimal.Parse(pCotizadoHermosilloCCM) : Decimal.Parse("0"),
                            Porcentaje = porcentajeHermosilloCCM,//pPorcentajeHermosilloCCM != "" ? Decimal.Parse(pPorcentajeHermosilloCCM) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesHermosilloCCM != "" ? Decimal.Parse(pVacacionesHermosilloCCM) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoHermosilloCCM != "" ? Decimal.Parse(pAguinaldoHermosilloCCM) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoHermosilloCCM.Add(tblCostoIndirectoHermosilloCCM);
                        DataControl.SaveChanges();

                        var porcentajeChihuahua = pCotizadoChihuahua != "" && pTotalChihuahua != "" && decimal.Parse(pCotizadoChihuahua) != decimal.Parse("0") ? (decimal.Parse(pTotalChihuahua) / decimal.Parse(pCotizadoChihuahua)) : decimal.Parse("0");
                        tblCostoIndirectoChihuahua tblCostoIndirectoChihuahua = new tblCostoIndirectoChihuahua
                        {
                            IdCostoIndirectoChihuahua = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaChihuahua != "" ? Decimal.Parse(pCostoNominaChihuahua) : Decimal.Parse("0"),
                            Imss = pCostoImssChihuahua != "" ? Decimal.Parse(pCostoImssChihuahua) : Decimal.Parse("0"),
                            Total = pCostoTotalChihuahua != "" ? Decimal.Parse(pCostoTotalChihuahua) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosChihuahua != "" ? Decimal.Parse(pTotalEmpleadosChihuahua) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonChihuahua != "" ? Decimal.Parse(pGastosAdmonChihuahua) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesChihuahua != "" ? Decimal.Parse(pConsumiblesChihuahua) : Decimal.Parse("0"),
                            Gasolina = pGasolinaChihuahua != "" ? Decimal.Parse(pGasolinaChihuahua) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadChihuahua != "" ? Decimal.Parse(pEquipoSeguridadChihuahua) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioChihuahua != "" ? Decimal.Parse(pInventarioChihuahua) : Decimal.Parse("0"),
                            Viaticos = pViaticosChihuahua != "" ? Decimal.Parse(pViaticosChihuahua) : Decimal.Parse("0"),
                            Carros = pCarrosChihuahua != "" ? Decimal.Parse(pCarrosChihuahua) : Decimal.Parse("0"),
                            Uniformes = pUniformesChihuahua != "" ? Decimal.Parse(pUniformesChihuahua) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaChihuahua != "" ? Decimal.Parse(pPerdidaCambiariaChihuahua) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaChihuahua != "" ? Decimal.Parse(pUtilidadCambiariaChihuahua) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaChihuahua != "" ? Decimal.Parse(pComisionBancariaChihuahua) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosChihuahua != "" ? Decimal.Parse(pProyectosChihuahua) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoChihuahua != "" ? Decimal.Parse(pCotizadoChihuahua) : Decimal.Parse("0"),
                            Porcentaje = porcentajeChihuahua,//pPorcentajeChihuahua != "" ? Decimal.Parse(pPorcentajeChihuahua) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesChihuahua != "" ? Decimal.Parse(pVacacionesChihuahua) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoChihuahua != "" ? Decimal.Parse(pAguinaldoChihuahua) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoChihuahua.Add(tblCostoIndirectoChihuahua);
                        DataControl.SaveChanges();

                        var porcentajeChihuahuaCCM = pCotizadoChihuahuaCCM != "" && pTotalChihuahuaCCM != "" && decimal.Parse(pCotizadoChihuahuaCCM) != decimal.Parse("0") ? (decimal.Parse(pTotalChihuahuaCCM) / decimal.Parse(pCotizadoChihuahuaCCM)) : decimal.Parse("0");
                        tblCostoIndirectoChihuahuaCCM tblCostoIndirectoChihuahuaCCM = new tblCostoIndirectoChihuahuaCCM
                        {
                            IdCostoIndirectoChihuahuaCCM = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaChihuahuaCCM != "" ? Decimal.Parse(pCostoNominaChihuahuaCCM) : Decimal.Parse("0"),
                            Imss = pCostoImssChihuahuaCCM != "" ? Decimal.Parse(pCostoImssChihuahuaCCM) : Decimal.Parse("0"),
                            Total = pCostoTotalChihuahuaCCM != "" ? Decimal.Parse(pCostoTotalChihuahuaCCM) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosChihuahuaCCM != "" ? Decimal.Parse(pTotalEmpleadosChihuahuaCCM) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonChihuahuaCCM != "" ? Decimal.Parse(pGastosAdmonChihuahuaCCM) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesChihuahuaCCM != "" ? Decimal.Parse(pConsumiblesChihuahuaCCM) : Decimal.Parse("0"),
                            Gasolina = pGasolinaChihuahuaCCM != "" ? Decimal.Parse(pGasolinaChihuahuaCCM) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadChihuahuaCCM != "" ? Decimal.Parse(pEquipoSeguridadChihuahuaCCM) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioChihuahuaCCM != "" ? Decimal.Parse(pInventarioChihuahuaCCM) : Decimal.Parse("0"),
                            Viaticos = pViaticosChihuahuaCCM != "" ? Decimal.Parse(pViaticosChihuahuaCCM) : Decimal.Parse("0"),
                            Carros = pCarrosChihuahuaCCM != "" ? Decimal.Parse(pCarrosChihuahuaCCM) : Decimal.Parse("0"),
                            Uniformes = pUniformesChihuahuaCCM != "" ? Decimal.Parse(pUniformesChihuahuaCCM) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaChihuahuaCCM != "" ? Decimal.Parse(pPerdidaCambiariaChihuahuaCCM) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaChihuahuaCCM != "" ? Decimal.Parse(pUtilidadCambiariaChihuahuaCCM) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaChihuahuaCCM != "" ? Decimal.Parse(pComisionBancariaChihuahuaCCM) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosChihuahuaCCM != "" ? Decimal.Parse(pProyectosChihuahuaCCM) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoChihuahuaCCM != "" ? Decimal.Parse(pCotizadoChihuahuaCCM) : Decimal.Parse("0"),
                            Porcentaje = porcentajeChihuahuaCCM,//pPorcentajeChihuahuaCCM != "" ? Decimal.Parse(pPorcentajeChihuahuaCCM) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesChihuahuaCCM != "" ? Decimal.Parse(pVacacionesChihuahuaCCM) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoChihuahuaCCM != "" ? Decimal.Parse(pAguinaldoChihuahuaCCM) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoChihuahuaCCM.Add(tblCostoIndirectoChihuahuaCCM);
                        DataControl.SaveChanges();

                        var porcentajeCuautitlan = pCotizadoCuautitlan != "" && pTotalCuautitlan != "" && decimal.Parse(pCotizadoCuautitlan) != decimal.Parse("0") ? (decimal.Parse(pTotalCuautitlan) / decimal.Parse(pCotizadoCuautitlan)) : decimal.Parse("0");
                        tblCostoIndirectoCuautitlan tblCostoIndirectoCuautitlan = new tblCostoIndirectoCuautitlan
                        {
                            IdCostoIndirectoCuautitlan = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaCuautitlan != "" ? Decimal.Parse(pCostoNominaCuautitlan) : Decimal.Parse("0"),
                            Imss = pCostoImssCuautitlan != "" ? Decimal.Parse(pCostoImssCuautitlan) : Decimal.Parse("0"),
                            Total = pCostoTotalCuautitlan != "" ? Decimal.Parse(pCostoTotalCuautitlan) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosCuautitlan != "" ? Decimal.Parse(pTotalEmpleadosCuautitlan) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonCuautitlan != "" ? Decimal.Parse(pGastosAdmonCuautitlan) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesCuautitlan != "" ? Decimal.Parse(pConsumiblesCuautitlan) : Decimal.Parse("0"),
                            Gasolina = pGasolinaCuautitlan != "" ? Decimal.Parse(pGasolinaCuautitlan) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadCuautitlan != "" ? Decimal.Parse(pEquipoSeguridadCuautitlan) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioCuautitlan != "" ? Decimal.Parse(pInventarioCuautitlan) : Decimal.Parse("0"),
                            Viaticos = pViaticosCuautitlan != "" ? Decimal.Parse(pViaticosCuautitlan) : Decimal.Parse("0"),
                            Carros = pCarrosCuautitlan != "" ? Decimal.Parse(pCarrosCuautitlan) : Decimal.Parse("0"),
                            Uniformes = pUniformesCuautitlan != "" ? Decimal.Parse(pUniformesCuautitlan) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaCuautitlan != "" ? Decimal.Parse(pPerdidaCambiariaCuautitlan) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaCuautitlan != "" ? Decimal.Parse(pUtilidadCambiariaCuautitlan) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaCuautitlan != "" ? Decimal.Parse(pComisionBancariaCuautitlan) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosCuautitlan != "" ? Decimal.Parse(pProyectosCuautitlan) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoCuautitlan != "" ? Decimal.Parse(pCotizadoCuautitlan) : Decimal.Parse("0"),
                            Porcentaje = porcentajeCuautitlan,//pPorcentajeCuautitlan != "" ? Decimal.Parse(pPorcentajeCuautitlan) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesCuautitlan != "" ? Decimal.Parse(pVacacionesCuautitlan) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoCuautitlan != "" ? Decimal.Parse(pAguinaldoCuautitlan) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoCuautitlan.Add(tblCostoIndirectoCuautitlan);
                        DataControl.SaveChanges();

                        var porcentajeCuautitlanCCM = pCotizadoCuautitlanCCM != "" && pTotalCuautitlanCCM != "" && decimal.Parse(pCotizadoCuautitlanCCM) != decimal.Parse("0") ? (decimal.Parse(pTotalCuautitlanCCM) / decimal.Parse(pCotizadoCuautitlanCCM)) : decimal.Parse("0");
                        tblCostoIndirectoCuautitlanCCM tblCostoIndirectoCuautitlanCCM = new tblCostoIndirectoCuautitlanCCM
                        {
                            IdCostoIndirectoCuautitlanCCM = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaCuautitlanCCM != "" ? Decimal.Parse(pCostoNominaCuautitlanCCM) : Decimal.Parse("0"),
                            Imss = pCostoImssCuautitlanCCM != "" ? Decimal.Parse(pCostoImssCuautitlanCCM) : Decimal.Parse("0"),
                            Total = pCostoTotalCuautitlanCCM != "" ? Decimal.Parse(pCostoTotalCuautitlanCCM) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosCuautitlanCCM != "" ? Decimal.Parse(pTotalEmpleadosCuautitlanCCM) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonCuautitlanCCM != "" ? Decimal.Parse(pGastosAdmonCuautitlanCCM) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesCuautitlanCCM != "" ? Decimal.Parse(pConsumiblesCuautitlanCCM) : Decimal.Parse("0"),
                            Gasolina = pGasolinaCuautitlanCCM != "" ? Decimal.Parse(pGasolinaCuautitlanCCM) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadCuautitlanCCM != "" ? Decimal.Parse(pEquipoSeguridadCuautitlanCCM) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioCuautitlanCCM != "" ? Decimal.Parse(pInventarioCuautitlanCCM) : Decimal.Parse("0"),
                            Viaticos = pViaticosCuautitlanCCM != "" ? Decimal.Parse(pViaticosCuautitlanCCM) : Decimal.Parse("0"),
                            Carros = pCarrosCuautitlanCCM != "" ? Decimal.Parse(pCarrosCuautitlanCCM) : Decimal.Parse("0"),
                            Uniformes = pUniformesCuautitlanCCM != "" ? Decimal.Parse(pUniformesCuautitlanCCM) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaCuautitlanCCM != "" ? Decimal.Parse(pPerdidaCambiariaCuautitlanCCM) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaCuautitlanCCM != "" ? Decimal.Parse(pUtilidadCambiariaCuautitlanCCM) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaCuautitlanCCM != "" ? Decimal.Parse(pComisionBancariaCuautitlanCCM) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosCuautitlanCCM != "" ? Decimal.Parse(pProyectosCuautitlanCCM) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoCuautitlanCCM != "" ? Decimal.Parse(pCotizadoCuautitlanCCM) : Decimal.Parse("0"),
                            Porcentaje = porcentajeCuautitlanCCM,//pPorcentajeCuautitlanCCM != "" ? Decimal.Parse(pPorcentajeCuautitlanCCM) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesCuautitlanCCM != "" ? Decimal.Parse(pVacacionesCuautitlanCCM) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoCuautitlanCCM != "" ? Decimal.Parse(pAguinaldoCuautitlanCCM) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoCuautitlanCCM.Add(tblCostoIndirectoCuautitlanCCM);
                        DataControl.SaveChanges();

                        var porcentajeIrapuato = pCotizadoIrapuato != "" && pTotalIrapuato != "" && decimal.Parse(pCotizadoIrapuato) != decimal.Parse("0") ? (decimal.Parse(pTotalIrapuato) / decimal.Parse(pCotizadoIrapuato)) : decimal.Parse("0");
                        tblCostoIndirectoIrapuato tblCostoIndirectoIrapuato = new tblCostoIndirectoIrapuato
                        {
                            IdCostoIndirectoIrapuato = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaIrapuato != "" ? Decimal.Parse(pCostoNominaIrapuato) : Decimal.Parse("0"),
                            Imss = pCostoImssIrapuato != "" ? Decimal.Parse(pCostoImssIrapuato) : Decimal.Parse("0"),
                            Total = pCostoTotalIrapuato != "" ? Decimal.Parse(pCostoTotalIrapuato) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosIrapuato != "" ? Decimal.Parse(pTotalEmpleadosIrapuato) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonIrapuato != "" ? Decimal.Parse(pGastosAdmonIrapuato) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesIrapuato != "" ? Decimal.Parse(pConsumiblesIrapuato) : Decimal.Parse("0"),
                            Gasolina = pGasolinaIrapuato != "" ? Decimal.Parse(pGasolinaIrapuato) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadIrapuato != "" ? Decimal.Parse(pEquipoSeguridadIrapuato) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioIrapuato != "" ? Decimal.Parse(pInventarioIrapuato) : Decimal.Parse("0"),
                            Viaticos = pViaticosIrapuato != "" ? Decimal.Parse(pViaticosIrapuato) : Decimal.Parse("0"),
                            Carros = pCarrosIrapuato != "" ? Decimal.Parse(pCarrosIrapuato) : Decimal.Parse("0"),
                            Uniformes = pUniformesIrapuato != "" ? Decimal.Parse(pUniformesIrapuato) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaIrapuato != "" ? Decimal.Parse(pPerdidaCambiariaIrapuato) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaIrapuato != "" ? Decimal.Parse(pUtilidadCambiariaIrapuato) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaIrapuato != "" ? Decimal.Parse(pComisionBancariaIrapuato) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosIrapuato != "" ? Decimal.Parse(pProyectosIrapuato) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoIrapuato != "" ? Decimal.Parse(pCotizadoIrapuato) : Decimal.Parse("0"),
                            Porcentaje = porcentajeIrapuato,//pPorcentajeIrapuato != "" ? Decimal.Parse(pPorcentajeIrapuato) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesIrapuato != "" ? Decimal.Parse(pVacacionesIrapuato) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoIrapuato != "" ? Decimal.Parse(pAguinaldoIrapuato) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoIrapuato.Add(tblCostoIndirectoIrapuato);
                        DataControl.SaveChanges();

                        var porcentajeIrapuatoCCM = pCotizadoIrapuatoCCM != "" && pTotalIrapuatoCCM != "" && decimal.Parse(pCotizadoIrapuatoCCM) != decimal.Parse("0") ? (decimal.Parse(pTotalIrapuatoCCM) / decimal.Parse(pCotizadoIrapuatoCCM)) : decimal.Parse("0");
                        tblCostoIndirectoIrapuatoCCM tblCostoIndirectoIrapuatoCCM = new tblCostoIndirectoIrapuatoCCM
                        {
                            IdCostoIndirectoIrapuatoCCM = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaIrapuatoCCM != "" ? Decimal.Parse(pCostoNominaIrapuatoCCM) : Decimal.Parse("0"),
                            Imss = pCostoImssIrapuatoCCM != "" ? Decimal.Parse(pCostoImssIrapuatoCCM) : Decimal.Parse("0"),
                            Total = pCostoTotalIrapuatoCCM != "" ? Decimal.Parse(pCostoTotalIrapuatoCCM) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosIrapuatoCCM != "" ? Decimal.Parse(pTotalEmpleadosIrapuatoCCM) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonIrapuatoCCM != "" ? Decimal.Parse(pGastosAdmonIrapuatoCCM) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesIrapuatoCCM != "" ? Decimal.Parse(pConsumiblesIrapuatoCCM) : Decimal.Parse("0"),
                            Gasolina = pGasolinaIrapuatoCCM != "" ? Decimal.Parse(pGasolinaIrapuatoCCM) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadIrapuatoCCM != "" ? Decimal.Parse(pEquipoSeguridadIrapuatoCCM) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioIrapuatoCCM != "" ? Decimal.Parse(pInventarioIrapuatoCCM) : Decimal.Parse("0"),
                            Viaticos = pViaticosIrapuatoCCM != "" ? Decimal.Parse(pViaticosIrapuatoCCM) : Decimal.Parse("0"),
                            Carros = pCarrosIrapuatoCCM != "" ? Decimal.Parse(pCarrosIrapuatoCCM) : Decimal.Parse("0"),
                            Uniformes = pUniformesIrapuatoCCM != "" ? Decimal.Parse(pUniformesIrapuatoCCM) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaIrapuatoCCM != "" ? Decimal.Parse(pPerdidaCambiariaIrapuatoCCM) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaIrapuatoCCM != "" ? Decimal.Parse(pUtilidadCambiariaIrapuatoCCM) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaIrapuatoCCM != "" ? Decimal.Parse(pComisionBancariaIrapuatoCCM) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosIrapuatoCCM != "" ? Decimal.Parse(pProyectosIrapuatoCCM) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoIrapuatoCCM != "" ? Decimal.Parse(pCotizadoIrapuatoCCM) : Decimal.Parse("0"),
                            Porcentaje = pPorcentajeIrapuatoCCM != "" ? Decimal.Parse(pPorcentajeIrapuatoCCM) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesIrapuatoCCM != "" ? Decimal.Parse(pVacacionesIrapuatoCCM) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoIrapuatoCCM != "" ? Decimal.Parse(pAguinaldoIrapuatoCCM) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoIrapuatoCCM.Add(tblCostoIndirectoIrapuatoCCM);
                        DataControl.SaveChanges();

                        var porcentajeQueretaro = pCotizadoQueretaro != "" && pTotalQueretaro != "" && decimal.Parse(pCotizadoQueretaro) != decimal.Parse("0") ? (decimal.Parse(pTotalQueretaro) / decimal.Parse(pCotizadoQueretaro)) : decimal.Parse("0");
                        tblCostoIndirectoQueretaro tblCostoIndirectoQueretaro = new tblCostoIndirectoQueretaro
                        {
                            IdCostoIndirectoQueretaro = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaQueretaro != "" ? Decimal.Parse(pCostoNominaQueretaro) : Decimal.Parse("0"),
                            Imss = pCostoImssQueretaro != "" ? Decimal.Parse(pCostoImssQueretaro) : Decimal.Parse("0"),
                            Total = pCostoTotalQueretaro != "" ? Decimal.Parse(pCostoTotalQueretaro) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosQueretaro != "" ? Decimal.Parse(pTotalEmpleadosQueretaro) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonQueretaro != "" ? Decimal.Parse(pGastosAdmonQueretaro) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesQueretaro != "" ? Decimal.Parse(pConsumiblesQueretaro) : Decimal.Parse("0"),
                            Gasolina = pGasolinaQueretaro != "" ? Decimal.Parse(pGasolinaQueretaro) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadQueretaro != "" ? Decimal.Parse(pEquipoSeguridadQueretaro) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioQueretaro != "" ? Decimal.Parse(pInventarioQueretaro) : Decimal.Parse("0"),
                            Viaticos = pViaticosQueretaro != "" ? Decimal.Parse(pViaticosQueretaro) : Decimal.Parse("0"),
                            Carros = pCarrosQueretaro != "" ? Decimal.Parse(pCarrosQueretaro) : Decimal.Parse("0"),
                            Uniformes = pUniformesQueretaro != "" ? Decimal.Parse(pUniformesQueretaro) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaQueretaro != "" ? Decimal.Parse(pPerdidaCambiariaQueretaro) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaQueretaro != "" ? Decimal.Parse(pUtilidadCambiariaQueretaro) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaQueretaro != "" ? Decimal.Parse(pComisionBancariaQueretaro) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosQueretaro != "" ? Decimal.Parse(pProyectosQueretaro) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoQueretaro != "" ? Decimal.Parse(pCotizadoQueretaro) : Decimal.Parse("0"),
                            Porcentaje = porcentajeQueretaro,//pPorcentajeQueretaro != "" ? Decimal.Parse(pPorcentajeQueretaro) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesQueretaro != "" ? Decimal.Parse(pVacacionesQueretaro) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoQueretaro != "" ? Decimal.Parse(pAguinaldoQueretaro) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoQueretaro.Add(tblCostoIndirectoQueretaro);
                        DataControl.SaveChanges();

                        var porcentajeQueretaroCCM = pCotizadoQueretaroCCM != "" && pTotalQueretaroCCM != "" && decimal.Parse(pCotizadoQueretaroCCM) != decimal.Parse("0") ? (decimal.Parse(pTotalQueretaroCCM) / decimal.Parse(pCotizadoQueretaroCCM)) : decimal.Parse("0");
                        tblCostoIndirectoQueretaroCCM tblCostoIndirectoQueretaroCCM = new tblCostoIndirectoQueretaroCCM
                        {
                            IdCostoIndirectoQueretaroCCM = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaQueretaroCCM != "" ? Decimal.Parse(pCostoNominaQueretaroCCM) : Decimal.Parse("0"),
                            Imss = pCostoImssQueretaroCCM != "" ? Decimal.Parse(pCostoImssQueretaroCCM) : Decimal.Parse("0"),
                            Total = pCostoTotalQueretaroCCM != "" ? Decimal.Parse(pCostoTotalQueretaroCCM) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosQueretaroCCM != "" ? Decimal.Parse(pTotalEmpleadosQueretaroCCM) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonQueretaroCCM != "" ? Decimal.Parse(pGastosAdmonQueretaroCCM) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesQueretaroCCM != "" ? Decimal.Parse(pConsumiblesQueretaroCCM) : Decimal.Parse("0"),
                            Gasolina = pGasolinaQueretaroCCM != "" ? Decimal.Parse(pGasolinaQueretaroCCM) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadQueretaroCCM != "" ? Decimal.Parse(pEquipoSeguridadQueretaroCCM) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioQueretaroCCM != "" ? Decimal.Parse(pInventarioQueretaroCCM) : Decimal.Parse("0"),
                            Viaticos = pViaticosQueretaroCCM != "" ? Decimal.Parse(pViaticosQueretaroCCM) : Decimal.Parse("0"),
                            Carros = pCarrosQueretaroCCM != "" ? Decimal.Parse(pCarrosQueretaroCCM) : Decimal.Parse("0"),
                            Uniformes = pUniformesQueretaroCCM != "" ? Decimal.Parse(pUniformesQueretaroCCM) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaQueretaroCCM != "" ? Decimal.Parse(pPerdidaCambiariaQueretaroCCM) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaQueretaroCCM != "" ? Decimal.Parse(pUtilidadCambiariaQueretaroCCM) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaQueretaroCCM != "" ? Decimal.Parse(pComisionBancariaQueretaroCCM) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosQueretaroCCM != "" ? Decimal.Parse(pProyectosQueretaroCCM) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoQueretaroCCM != "" ? Decimal.Parse(pCotizadoQueretaroCCM) : Decimal.Parse("0"),
                            Porcentaje = porcentajeQueretaroCCM,//pPorcentajeQueretaroCCM != "" ? Decimal.Parse(pPorcentajeQueretaroCCM) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesQueretaroCCM != "" ? Decimal.Parse(pVacacionesQueretaroCCM) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoQueretaroCCM != "" ? Decimal.Parse(pAguinaldoQueretaroCCM) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoQueretaroCCM.Add(tblCostoIndirectoQueretaroCCM);
                        DataControl.SaveChanges();

                        var porcentajeTecate = pCotizadoTecate != "" && pTotalTecate != "" && decimal.Parse(pCotizadoTecate) != decimal.Parse("0") ? (decimal.Parse(pTotalTecate) / decimal.Parse(pCotizadoTecate)) : decimal.Parse("0");
                        tblCostoIndirectoTecate tblCostoIndirectoTecate = new tblCostoIndirectoTecate
                        {
                            IdCostoIndirectoTecate = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaTecate != "" ? Decimal.Parse(pCostoNominaTecate) : Decimal.Parse("0"),
                            Imss = pCostoImssTecate != "" ? Decimal.Parse(pCostoImssTecate) : Decimal.Parse("0"),
                            Total = pCostoTotalTecate != "" ? Decimal.Parse(pCostoTotalTecate) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosTecate != "" ? Decimal.Parse(pTotalEmpleadosTecate) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonTecate != "" ? Decimal.Parse(pGastosAdmonTecate) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesTecate != "" ? Decimal.Parse(pConsumiblesTecate) : Decimal.Parse("0"),
                            Gasolina = pGasolinaTecate != "" ? Decimal.Parse(pGasolinaTecate) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadTecate != "" ? Decimal.Parse(pEquipoSeguridadTecate) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioTecate != "" ? Decimal.Parse(pInventarioTecate) : Decimal.Parse("0"),
                            Viaticos = pViaticosTecate != "" ? Decimal.Parse(pViaticosTecate) : Decimal.Parse("0"),
                            Carros = pCarrosTecate != "" ? Decimal.Parse(pCarrosTecate) : Decimal.Parse("0"),
                            Uniformes = pUniformesTecate != "" ? Decimal.Parse(pUniformesTecate) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaTecate != "" ? Decimal.Parse(pPerdidaCambiariaTecate) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaTecate != "" ? Decimal.Parse(pUtilidadCambiariaTecate) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaTecate != "" ? Decimal.Parse(pComisionBancariaTecate) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosTecate != "" ? Decimal.Parse(pProyectosTecate) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoTecate != "" ? Decimal.Parse(pCotizadoTecate) : Decimal.Parse("0"),
                            Porcentaje = porcentajeTecate,//pPorcentajeTecate != "" ? Decimal.Parse(pPorcentajeTecate) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesTecate != "" ? Decimal.Parse(pVacacionesTecate) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoTecate != "" ? Decimal.Parse(pAguinaldoTecate) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoTecate.Add(tblCostoIndirectoTecate);
                        DataControl.SaveChanges();

                        var porcentajeUSA = pCotizadoUSA != "" && pTotalUSA != "" && decimal.Parse(pCotizadoUSA) != decimal.Parse("0") ? (decimal.Parse(pTotalUSA) / decimal.Parse(pCotizadoUSA)) : decimal.Parse("0");
                        tblCostoIndirectoUSA tblCostoIndirectoUSA = new tblCostoIndirectoUSA
                        {
                            IdCostoIndirectoUSA = Guid.NewGuid(),
                            Semana = 0,
                            FechaIni = DateTime.Parse(pFechaIni),
                            FechaFin = DateTime.Parse(pFechaFin),
                            Nomina = pCostoNominaUSA != "" ? Decimal.Parse(pCostoNominaUSA) : Decimal.Parse("0"),
                            Imss = pCostoImssUSA != "" ? Decimal.Parse(pCostoImssUSA) : Decimal.Parse("0"),
                            Total = pCostoTotalUSA != "" ? Decimal.Parse(pCostoTotalUSA) : Decimal.Parse("0"),
                            TotalEmpleados = pTotalEmpleadosUSA != "" ? Decimal.Parse(pTotalEmpleadosUSA) : Decimal.Parse("0"),
                            GastosAdministrativos = pGastosAdmonUSA != "" ? Decimal.Parse(pGastosAdmonUSA) : Decimal.Parse("0"),
                            ConsumiblesTaller = pConsumiblesUSA != "" ? Decimal.Parse(pConsumiblesUSA) : Decimal.Parse("0"),
                            Gasolina = pGasolinaUSA != "" ? Decimal.Parse(pGasolinaUSA) : Decimal.Parse("0"),
                            EquipoSeguridad = pEquipoSeguridadUSA != "" ? Decimal.Parse(pEquipoSeguridadUSA) : Decimal.Parse("0"),
                            InventarioSisa = pInventarioUSA != "" ? Decimal.Parse(pInventarioUSA) : Decimal.Parse("0"),
                            Viaticos = pViaticosUSA != "" ? Decimal.Parse(pViaticosUSA) : Decimal.Parse("0"),
                            Carros = pCarrosUSA != "" ? Decimal.Parse(pCarrosUSA) : Decimal.Parse("0"),
                            Uniformes = pUniformesUSA != "" ? Decimal.Parse(pUniformesUSA) : Decimal.Parse("0"),
                            PerdidaCambiaria = pPerdidaCambiariaUSA != "" ? Decimal.Parse(pPerdidaCambiariaUSA) : Decimal.Parse("0"),
                            UtilidadCambiaria = pUtilidadCambiariaUSA != "" ? Decimal.Parse(pUtilidadCambiariaUSA) : Decimal.Parse("0"),
                            Intereses = Decimal.Parse("0"),
                            ComisionesBancarias = pComisionBancariaUSA != "" ? Decimal.Parse(pComisionBancariaUSA) : Decimal.Parse("0"),
                            TotalProyectos = pProyectosUSA != "" ? Decimal.Parse(pProyectosUSA) : Decimal.Parse("0"),
                            TotalCotizado = pCotizadoUSA != "" ? Decimal.Parse(pCotizadoUSA) : Decimal.Parse("0"),
                            Porcentaje = porcentajeUSA,//pPorcentajeUSA != "" ? Decimal.Parse(pPorcentajeUSA) : Decimal.Parse("0"),
                            Vacaciones = pVacacionesUSA != "" ? Decimal.Parse(pVacacionesUSA) : Decimal.Parse("0"),
                            Aguinaldo = pAguinaldoUSA != "" ? Decimal.Parse(pAguinaldoUSA) : Decimal.Parse("0"),
                            FechaAlta = DateTime.Now,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaModificacion = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario
                        };
                        DataControl.tblCostoIndirectoUSA.Add(tblCostoIndirectoUSA);
                        DataControl.SaveChanges();
                        //if (FechaPago.Length > 0)
                        //{
                        //    add.FechaPago = DateTime.Parse(FechaPago);
                        //    DataControl.SaveChanges();
                        //}
                        //if (ProgramacionPago.Length > 0)
                        //{
                        //    add.ProgramacionPago = DateTime.Parse(ProgramacionPago);
                        //    DataControl.SaveChanges();
                        //}
                        //if (FechaPA.Length > 0)
                        //{
                        //    add.FechaPA = DateTime.Parse(FechaPA);
                        //    DataControl.SaveChanges();
                        //}

                        retorno = "Datos Guardados.";
                    }
                }
                else
                {
                    retorno = "No tienes permiso.";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }
    }
}