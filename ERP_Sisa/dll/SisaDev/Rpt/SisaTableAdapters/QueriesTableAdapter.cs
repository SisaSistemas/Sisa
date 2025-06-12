// Decompiled with JetBrains decompiler
// Type: SisaDev.Rpt.SisaTableAdapters.QueriesTableAdapter
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SisaDev.Rpt.SisaTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class QueriesTableAdapter : Component
  {
    private IDbCommand[] _commandCollection;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected IDbCommand[] CommandCollection
    {
      get
      {
        if (this._commandCollection == null)
          this.InitCommandCollection();
        return this._commandCollection;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitCommandCollection()
    {
      this._commandCollection = new IDbCommand[106];
      this._commandCollection[0] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[0]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[0]).CommandText = "dbo.JT_LoadControlFacturas";
      ((DbCommand) this._commandCollection[0]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@Mes", SqlDbType.VarChar, 6, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@NoFactura", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[1] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[1]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[1]).CommandText = "dbo.JT_LoadFacturasEmitidas";
      ((DbCommand) this._commandCollection[1]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[1]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[1]).Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 6, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[1]).Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[1]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[1]).Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[1]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[2] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[2]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[2]).CommandText = "dbo.MezclaProductos";
      ((DbCommand) this._commandCollection[2]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[2]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[2]).Parameters.Add(new SqlParameter("@Productos", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[3] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[3]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[3]).CommandText = "dbo.sp_ActualizaCantidadEntregadaOC";
      ((DbCommand) this._commandCollection[3]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[3]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[3]).Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[3]).Parameters.Add(new SqlParameter("@Item", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[3]).Parameters.Add(new SqlParameter("@CantidadRecibida", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[4] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[4]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[4]).CommandText = "dbo.sp_ActualizaDatosInfoCenter";
      ((DbCommand) this._commandCollection[4]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[4]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[4]).Parameters.Add(new SqlParameter("@NombreRobot", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[4]).Parameters.Add(new SqlParameter("@TrabajoElectrico", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 19, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[4]).Parameters.Add(new SqlParameter("@TrabajoMecanico", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 19, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[5] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[5]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[5]).CommandText = "dbo.sp_ActualizaDatosInfoCenterValiant";
      ((DbCommand) this._commandCollection[5]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[5]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[5]).Parameters.Add(new SqlParameter("@IdEstacion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[5]).Parameters.Add(new SqlParameter("@Electrico", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 19, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[5]).Parameters.Add(new SqlParameter("@Mecanico", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 19, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[5]).Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[6] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[6]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[6]).CommandText = "dbo.sp_ActualizaSueldoUsuario";
      ((DbCommand) this._commandCollection[6]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[6]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[6]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[6]).Parameters.Add(new SqlParameter("@Sueldo", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[6]).Parameters.Add(new SqlParameter("@IdUsuarioModifico", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[7] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[7]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[7]).CommandText = "dbo.sp_BDExcelRober";
      ((DbCommand) this._commandCollection[7]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[7]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[8] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[8]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[8]).CommandText = "dbo.sp_CambiaEstatusMaquinado";
      ((DbCommand) this._commandCollection[8]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[8]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[8]).Parameters.Add(new SqlParameter("@IdMaquinado", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[8]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[9] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[9]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[9]).CommandText = "dbo.sp_CambiaEstatusTask";
      ((DbCommand) this._commandCollection[9]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[9]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[9]).Parameters.Add(new SqlParameter("@IdTask", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[9]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[9]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[10] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[10]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[10]).CommandText = "dbo.sp_CambiarEstatusProyecto";
      ((DbCommand) this._commandCollection[10]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[10]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[10]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[10]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[10]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar, 15, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[11] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[11]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[11]).CommandText = "dbo.sp_CancelaCotizacion";
      ((DbCommand) this._commandCollection[11]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[11]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[11]).Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[11]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[11]).Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[12] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[12]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[12]).CommandText = "dbo.sp_CancelaOrdenCompra";
      ((DbCommand) this._commandCollection[12]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[12]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[12]).Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[12]).Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[12]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[13] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[13]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[13]).CommandText = "dbo.sp_CargarFacturas";
      ((DbCommand) this._commandCollection[13]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@Mes", SqlDbType.VarChar, 6, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@NoFactura", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[13]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[14] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[14]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[14]).CommandText = "dbo.sp_CargarOrdenCompraProveedor";
      ((DbCommand) this._commandCollection[14]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[14]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[14]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[15] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[15]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[15]).CommandText = "dbo.sp_ChatMessageInsert";
      ((DbCommand) this._commandCollection[15]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[15]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[15]).Parameters.Add(new SqlParameter("@IdFrom", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[15]).Parameters.Add(new SqlParameter("@From", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[15]).Parameters.Add(new SqlParameter("@IdTo", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[15]).Parameters.Add(new SqlParameter("@To", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[15]).Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[16] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[16]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[16]).CommandText = "dbo.sp_DesactivaCliente";
      ((DbCommand) this._commandCollection[16]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[16]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[16]).Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[16]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[17] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[17]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[17]).CommandText = "dbo.sp_DesactivaMaterial";
      ((DbCommand) this._commandCollection[17]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[17]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[17]).Parameters.Add(new SqlParameter("@IdMaterial", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[17]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[18] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[18]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[18]).CommandText = "dbo.sp_DesactivaProveedor";
      ((DbCommand) this._commandCollection[18]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[18]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[18]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[18]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[19] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[19]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[19]).CommandText = "dbo.sp_DesactivaProveedorMaterial";
      ((DbCommand) this._commandCollection[19]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[19]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[19]).Parameters.Add(new SqlParameter("@IdProveedorMaterial", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[19]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[20] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[20]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[20]).CommandText = "dbo.sp_DesactivaProyecto";
      ((DbCommand) this._commandCollection[20]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[20]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[20]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[20]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[21] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[21]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[21]).CommandText = "dbo.sp_DesactivaUsuario";
      ((DbCommand) this._commandCollection[21]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[21]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[21]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[21]).Parameters.Add(new SqlParameter("@IdUsuarioQuien", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[22] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[22]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[22]).CommandText = "dbo.sp_EnviaCorreo";
      ((DbCommand) this._commandCollection[22]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[22]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[22]).Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[22]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[23] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[23]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[23]).CommandText = "dbo.sp_GraficaPastelUtilidad";
      ((DbCommand) this._commandCollection[23]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[23]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[23]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[24] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[24]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[24]).CommandText = "dbo.sp_GraficaUtilidad";
      ((DbCommand) this._commandCollection[24]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[24]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[24]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[25] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[25]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[25]).CommandText = "dbo.sp_GuardarFacturaEmitida";
      ((DbCommand) this._commandCollection[25]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@IdFacturasEmitidas", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@NoCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@NoOrdenCompra", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@ProgramacionPago", SqlDbType.VarChar, 20, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@PorPagar", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@FechaPago", SqlDbType.VarChar, 20, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[25]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[26] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[26]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[26]).CommandText = "dbo.sp_InsertaComentarioCotizacion";
      ((DbCommand) this._commandCollection[26]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[26]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[26]).Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[26]).Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[26]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[27] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[27]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[27]).CommandText = "dbo.sp_InsertaComentarioProyecto";
      ((DbCommand) this._commandCollection[27]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[27]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[27]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[27]).Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[27]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[28] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[28]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[28]).CommandText = "dbo.sp_InsertaComentariosOrdenCompra";
      ((DbCommand) this._commandCollection[28]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[28]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[28]).Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[28]).Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[28]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[29] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[29]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[29]).CommandText = "dbo.sp_InsertaFallaReconocimientoVoz";
      ((DbCommand) this._commandCollection[29]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[29]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[29]).Parameters.Add(new SqlParameter("@Vin", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[29]).Parameters.Add(new SqlParameter("@Falla", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[30] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[30]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[30]).CommandText = "dbo.sp_InsertaImagenesInfoCenter";
      ((DbCommand) this._commandCollection[30]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[30]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[30]).Parameters.Add(new SqlParameter("@IdEstacion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[30]).Parameters.Add(new SqlParameter("@ImagenReporte", SqlDbType.Image, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[31] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[31]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[31]).CommandText = "dbo.sp_InsertaNotaAclaratoria";
      ((DbCommand) this._commandCollection[31]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[31]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[31]).Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[31]).Parameters.Add(new SqlParameter("@NotaAclaratoria", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[32] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[32]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[32]).CommandText = "dbo.sp_InsertaProveedorContacto";
      ((DbCommand) this._commandCollection[32]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[32]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[32]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[32]).Parameters.Add(new SqlParameter("@NombreContacto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[32]).Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[32]).Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[32]).Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[33] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[33]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[33]).CommandText = "dbo.sp_InsertFacturasEmitidas";
      ((DbCommand) this._commandCollection[33]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@FolioFactura", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@FechaFactura", SqlDbType.DateTime, 8, ParameterDirection.Input, (byte) 23, (byte) 3, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@RfcReceptor", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@NombreReceptor", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@Retencion", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@TipoCambio", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 6, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[33]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[34] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[34]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[34]).CommandText = "dbo.sp_InsertFacturaXML";
      ((DbCommand) this._commandCollection[34]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[34]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[34]).Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[34]).Parameters.Add(new SqlParameter("@Archivo", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[35] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[35]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[35]).CommandText = "dbo.sp_InsertGasto";
      ((DbCommand) this._commandCollection[35]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@NoFactura", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@TipoGasto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@Importe", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime, 8, ParameterDirection.Input, (byte) 23, (byte) 3, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[35]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[36] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[36]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[36]).CommandText = "dbo.sp_InsertLocalizacion";
      ((DbCommand) this._commandCollection[36]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[36]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[36]).Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 10, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[36]).Parameters.Add(new SqlParameter("@Latitud", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 4, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[36]).Parameters.Add(new SqlParameter("@Longitud", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 4, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[37] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[37]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[37]).CommandText = "dbo.sp_InsertMaterialImagen";
      ((DbCommand) this._commandCollection[37]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@IdMaterial", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@FileExtension", SqlDbType.VarChar, 10, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@FileSize", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@FileContentType", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[37]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[38] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[38]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[38]).CommandText = "dbo.sp_InsertOrdenCompraDetalle";
      ((DbCommand) this._commandCollection[38]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Item", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Unidad", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Importe", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@TiempoEntrega", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@CantidadRecibida", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[38]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[39] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[39]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[39]).CommandText = "dbo.sp_InsertOrdenTrabajo";
      ((DbCommand) this._commandCollection[39]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[39]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[39]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[39]).Parameters.Add(new SqlParameter("@FechaPruebas", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[39]).Parameters.Add(new SqlParameter("@FechaEntrega", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[39]).Parameters.Add(new SqlParameter("@IdUsuarioCoordinador", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[40] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[40]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[40]).CommandText = "dbo.sp_InsertProveedorMaterialPrecio";
      ((DbCommand) this._commandCollection[40]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@IdMaterial", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@UnidadMedida", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@IdMoneda", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@IdProveedorMaterial", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[40]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[41] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[41]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[41]).CommandText = "dbo.sp_InsertProyectoRequerimiento";
      ((DbCommand) this._commandCollection[41]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[41]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[41]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[41]).Parameters.Add(new SqlParameter("@Requerimiento", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[41]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[42] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[42]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[42]).CommandText = "dbo.sp_InsertProyectoTask";
      ((DbCommand) this._commandCollection[42]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@Task", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[42]).Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[43] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[43]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[43]).CommandText = "dbo.sp_InsertReqDet";
      ((DbCommand) this._commandCollection[43]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@IdReqEnc", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@Item", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@Unidad", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@NumParte", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[43]).Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[44] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[44]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[44]).CommandText = "dbo.sp_InsertRFQ";
      ((DbCommand) this._commandCollection[44]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@IdRfq", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@Round", SqlDbType.VarChar, 10, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime, 8, ParameterDirection.Input, (byte) 23, (byte) 3, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@FechaVencimiento", SqlDbType.DateTime, 8, ParameterDirection.Input, (byte) 23, (byte) 3, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@FolioRQ", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@IdComprador", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[44]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[45] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[45]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[45]).CommandText = "dbo.sp_InsertSeguimientoRFQ";
      ((DbCommand) this._commandCollection[45]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[45]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[45]).Parameters.Add(new SqlParameter("@IdRfq", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[45]).Parameters.Add(new SqlParameter("@Seguimiento", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[45]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[46] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[46]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[46]).CommandText = "dbo.sp_InsertTaskComentarios";
      ((DbCommand) this._commandCollection[46]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[46]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[46]).Parameters.Add(new SqlParameter("@IdTask", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[46]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[46]).Parameters.Add(new SqlParameter("@Comentario", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[47] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[47]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[47]).CommandText = "dbo.sp_InsertTaskImagen";
      ((DbCommand) this._commandCollection[47]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@IdTask", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@FileExtension", SqlDbType.VarChar, 10, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@FileSize", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@FileContentType", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[47]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[48] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[48]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[48]).CommandText = "dbo.sp_InsertTimmingsExcel";
      ((DbCommand) this._commandCollection[48]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@Actividad", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@Tarea", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@FechaIni", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@Asignado", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@DiasTrans", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@Avance", SqlDbType.VarChar, 20, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[48]).Parameters.Add(new SqlParameter("@Fila", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[49] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[49]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[49]).CommandText = "dbo.sp_InsertUpdateClientes";
      ((DbCommand) this._commandCollection[49]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@RazonSocial", SqlDbType.VarChar, 250, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@TelefonoEmpresa", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@UsuarioCliente", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@ContrasenaCliente", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@MapaCoordenadas", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Logotipo", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[49]).Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[50] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[50]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[50]).CommandText = "dbo.sp_InsertUpdateEventoCalendario";
      ((DbCommand) this._commandCollection[50]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@IdCalendario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@Titulo", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.DateTime, 8, ParameterDirection.Input, (byte) 23, (byte) 3, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@FechaFinal", SqlDbType.DateTime, 8, ParameterDirection.Input, (byte) 23, (byte) 3, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@TodoDia", SqlDbType.Bit, 1, ParameterDirection.Input, (byte) 1, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[50]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[51] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[51]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[51]).CommandText = "dbo.sp_InsertUpdateHabilidad";
      ((DbCommand) this._commandCollection[51]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[51]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[51]).Parameters.Add(new SqlParameter("@IdHabilidad", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[51]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[51]).Parameters.Add(new SqlParameter("@Habilidad", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[51]).Parameters.Add(new SqlParameter("@Porcentaje", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[51]).Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[52] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[52]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[52]).CommandText = "dbo.sp_InsertUpdateHorasHombre";
      ((DbCommand) this._commandCollection[52]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@IdHorasHombre", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Lunes", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Martes", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Miercoles", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Jueves", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Viernes", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Sabado", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Domingo", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[52]).Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[53] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[53]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[53]).CommandText = "dbo.sp_InsertUpdateListaPendientes";
      ((DbCommand) this._commandCollection[53]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[53]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[53]).Parameters.Add(new SqlParameter("@IdListaPendientes", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[53]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[53]).Parameters.Add(new SqlParameter("@Pendiente", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[53]).Parameters.Add(new SqlParameter("@Completado", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[54] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[54]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[54]).CommandText = "dbo.sp_InsertUpdateMaquinado";
      ((DbCommand) this._commandCollection[54]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdMaquina", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@NoParte", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@FechaOC", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@FechaEntrega", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdDiseno", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdMasterCam", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdEncargadoProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdDisenador", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@IdQuienHizo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@HorasMaquina", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[54]).Parameters.Add(new SqlParameter("@CantidadPzas", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[55] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[55]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[55]).CommandText = "dbo.sp_InsertUpdatePermisos";
      ((DbCommand) this._commandCollection[55]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[55]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[55]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[55]).Parameters.Add(new SqlParameter("@IdMenu", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[55]).Parameters.Add(new SqlParameter("@Visible", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[56] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[56]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[56]).CommandText = "dbo.sp_InsertUpdateProyectos";
      ((DbCommand) this._commandCollection[56]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@IdLider", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[56]).Parameters.Add(new SqlParameter("@CostoCotizacion", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[57] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[57]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[57]).CommandText = "dbo.sp_InsertUpdateRFQVentas";
      ((DbCommand) this._commandCollection[57]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@IdRFQ", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@FolioRfq", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@IdUsuarioVendedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@IdUsuarioCoordinador", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@Empresa", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@FechaRFQ", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@FechaEntrega", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@Enviado", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@Seguimiento", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[57]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[58] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[58]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[58]).CommandText = "dbo.sp_InsertUpdateUsuarios";
      ((DbCommand) this._commandCollection[58]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Contrasena", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Foto", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Permisos", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Puesto", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@IdUsuarioActualiza", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[58]).Parameters.Add(new SqlParameter("@EsLider", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[59] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[59]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[59]).CommandText = "dbo.sp_InsertUsuarioHorasHombre";
      ((DbCommand) this._commandCollection[59]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[59]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[59]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[59]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[60] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[60]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[60]).CommandText = "dbo.sp_LoadTimming";
      ((DbCommand) this._commandCollection[60]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[60]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[61] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[61]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[61]).CommandText = "dbo.sp_ObtieneFolioCotizacion";
      ((DbCommand) this._commandCollection[61]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[61]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[61]).Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[62] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[62]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[62]).CommandText = "dbo.sp_ObtieneFolioOrdenCompra";
      ((DbCommand) this._commandCollection[62]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[62]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[62]).Parameters.Add(new SqlParameter("@FolioOC", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[63] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[63]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[63]).CommandText = "dbo.sp_ObtieneFolioReq";
      ((DbCommand) this._commandCollection[63]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[63]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[63]).Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[64] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[64]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[64]).CommandText = "dbo.sp_ObtieneFolioRFQ";
      ((DbCommand) this._commandCollection[64]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[64]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[64]).Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[65] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[65]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[65]).CommandText = "dbo.sp_ResumenTotales";
      ((DbCommand) this._commandCollection[65]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@Mes", SqlDbType.VarChar, 6, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@NoFactura", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[65]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[66] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[66]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[66]).CommandText = "dbo.sp_ResumenTotalesFacturasEmitidas";
      ((DbCommand) this._commandCollection[66]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[66]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[66]).Parameters.Add(new SqlParameter("@Anio", SqlDbType.VarChar, 6, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[66]).Parameters.Add(new SqlParameter("@Cliente", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[66]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[66]).Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[66]).Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[67] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[67]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[67]).CommandText = "dbo.sp_ResumenTotalesOC";
      ((DbCommand) this._commandCollection[67]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[67]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[67]).Parameters.Add(new SqlParameter("@Valor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[68] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[68]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[68]).CommandText = "dbo.sp_Sincronizacion_Clientes";
      ((DbCommand) this._commandCollection[68]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[68]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[68]).Parameters.Add(new SqlParameter("@Clientes", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[69] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[69]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[69]).CommandText = "dbo.sp_Sincronizacion_ComentariosProyecto";
      ((DbCommand) this._commandCollection[69]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[69]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[69]).Parameters.Add(new SqlParameter("@ComentariosProyecto", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[70] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[70]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[70]).CommandText = "dbo.sp_Sincronizacion_Cotizacion";
      ((DbCommand) this._commandCollection[70]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[70]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[70]).Parameters.Add(new SqlParameter("@Cotizacion", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[71] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[71]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[71]).CommandText = "dbo.sp_Sincronizacion_FolioCotizacion";
      ((DbCommand) this._commandCollection[71]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[71]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[71]).Parameters.Add(new SqlParameter("@FolioCotizacion", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[72] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[72]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[72]).CommandText = "dbo.sp_Sincronizacion_Gastos";
      ((DbCommand) this._commandCollection[72]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[72]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[72]).Parameters.Add(new SqlParameter("@Gastos", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[73] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[73]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[73]).CommandText = "dbo.sp_Sincronizacion_Habilidades";
      ((DbCommand) this._commandCollection[73]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[73]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[73]).Parameters.Add(new SqlParameter("@Habilidades", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[74] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[74]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[74]).CommandText = "dbo.sp_Sincronizacion_ListaPendientes";
      ((DbCommand) this._commandCollection[74]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[74]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[74]).Parameters.Add(new SqlParameter("@ListaPendientes", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[75] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[75]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[75]).CommandText = "dbo.sp_Sincronizacion_MatrizMecanico";
      ((DbCommand) this._commandCollection[75]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[75]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[75]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[76] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[76]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[76]).CommandText = "dbo.sp_Sincronizacion_Menu";
      ((DbCommand) this._commandCollection[76]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[76]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[76]).Parameters.Add(new SqlParameter("@Menus", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[77] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[77]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[77]).CommandText = "dbo.sp_Sincronizacion_NotaAclaratoria";
      ((DbCommand) this._commandCollection[77]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[77]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[77]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[78] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[78]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[78]).CommandText = "dbo.sp_Sincronizacion_Permisos";
      ((DbCommand) this._commandCollection[78]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[78]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[78]).Parameters.Add(new SqlParameter("@Permisos", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[79] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[79]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[79]).CommandText = "dbo.sp_Sincronizacion_Proveedores";
      ((DbCommand) this._commandCollection[79]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[79]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[79]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[80] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[80]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[80]).CommandText = "dbo.sp_Sincronizacion_Proyectos";
      ((DbCommand) this._commandCollection[80]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[80]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[80]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[81] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[81]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[81]).CommandText = "dbo.sp_Sincronizacion_ProyectosTaskImagen";
      ((DbCommand) this._commandCollection[81]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[81]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[81]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[82] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[82]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[82]).CommandText = "dbo.sp_Sincronizacion_ProyectoTasks";
      ((DbCommand) this._commandCollection[82]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[82]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[82]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[83] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[83]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[83]).CommandText = "dbo.sp_Sincronizacion_ProyectoTasksComentarios";
      ((DbCommand) this._commandCollection[83]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[83]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[83]).Parameters.Add(new SqlParameter("@Parametro", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[84] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[84]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[84]).CommandText = "dbo.sp_Sincronizacion_Usuarios";
      ((DbCommand) this._commandCollection[84]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[84]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[84]).Parameters.Add(new SqlParameter("@Usuarios", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[85] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[85]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[85]).CommandText = "dbo.sp_Sincronizacion_Viaticos";
      ((DbCommand) this._commandCollection[85]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[85]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[85]).Parameters.Add(new SqlParameter("@Viatico", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[86] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[86]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[86]).CommandText = "dbo.sp_Sincronizacion_ViaticosDet";
      ((DbCommand) this._commandCollection[86]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[86]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[86]).Parameters.Add(new SqlParameter("@ViaticoDet", SqlDbType.Structured, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[87] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[87]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[87]).CommandText = "dbo.sp_SubeArchivoCotizacion";
      ((DbCommand) this._commandCollection[87]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[87]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[87]).Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[87]).Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[87]).Parameters.Add(new SqlParameter("@Documento", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[88] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[88]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[88]).CommandText = "dbo.sp_SubeArchivosFacturas";
      ((DbCommand) this._commandCollection[88]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[88]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[88]).Parameters.Add(new SqlParameter("@IdControlFacturas", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[88]).Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[88]).Parameters.Add(new SqlParameter("@Documento", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[89] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[89]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[89]).CommandText = "dbo.sp_SubeArchivosProyectos";
      ((DbCommand) this._commandCollection[89]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[89]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[89]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[89]).Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[89]).Parameters.Add(new SqlParameter("@Documento", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[89]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.VarChar, 5, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[90] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[90]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[90]).CommandText = "dbo.sp_TerminarCapturaHorasHombre";
      ((DbCommand) this._commandCollection[90]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[90]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[90]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[90]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[91] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[91]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[91]).CommandText = "dbo.sp_TerminarProyecto";
      ((DbCommand) this._commandCollection[91]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[91]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[91]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[91]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[92] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[92]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[92]).CommandText = "dbo.sp_UpdateCostoProyecto";
      ((DbCommand) this._commandCollection[92]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[92]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[92]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[92]).Parameters.Add(new SqlParameter("@Costo", SqlDbType.Decimal, 13, ParameterDirection.Input, (byte) 20, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[92]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[93] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[93]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[93]).CommandText = "dbo.sp_UpdateImagenUsuario";
      ((DbCommand) this._commandCollection[93]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[93]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[93]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[93]).Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[94] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[94]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[94]).CommandText = "dbo.sp_UpdatePerfilUsuario";
      ((DbCommand) this._commandCollection[94]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[94]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[94]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[94]).Parameters.Add(new SqlParameter("@Perfil", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[95] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[95]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[95]).CommandText = "dbo.sp_UpdateTask";
      ((DbCommand) this._commandCollection[95]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@IdTask", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@Task", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[95]).Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[96] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[96]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[96]).CommandText = "dbo.W_Sp_Pag_CapturaViaticos";
      ((DbCommand) this._commandCollection[96]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[96]).Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[97] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[97]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[97]).CommandText = "dbo.W_Sp_Pag_Clientes";
      ((DbCommand) this._commandCollection[97]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[97]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[98] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[98]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[98]).CommandText = "dbo.W_Sp_Pag_Cotizaciones";
      ((DbCommand) this._commandCollection[98]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[98]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[99] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[99]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[99]).CommandText = "dbo.W_Sp_Pag_Maquinados";
      ((DbCommand) this._commandCollection[99]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[99]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[100] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[100]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[100]).CommandText = "dbo.W_Sp_Pag_Materiales";
      ((DbCommand) this._commandCollection[100]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[100]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[101] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[101]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[101]).CommandText = "dbo.W_Sp_Pag_Proveedores";
      ((DbCommand) this._commandCollection[101]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[101]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[102] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[102]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[102]).CommandText = "dbo.W_Sp_Pag_Proyectos";
      ((DbCommand) this._commandCollection[102]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[102]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[103] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[103]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[103]).CommandText = "dbo.W_Sp_Pag_ProyectoTasks";
      ((DbCommand) this._commandCollection[103]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[103]).Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[104] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[104]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[104]).CommandText = "dbo.W_Sp_Pag_Requisiciones";
      ((DbCommand) this._commandCollection[104]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[104]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[105] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[105]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[105]).CommandText = "dbo.W_Sp_Pag_Viaticos";
      ((DbCommand) this._commandCollection[105]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@iDisplayStart", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@iDisplayLength", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@sSortingCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@sSortingDir_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@iSortingCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@sSearch", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@sSearchableCol_delim", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@iSearchableCols", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@iTotalRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@iTotalDisplayRecords", SqlDbType.Int, 4, ParameterDirection.InputOutput, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      ((SqlCommand) this._commandCollection[105]).Parameters.Add(new SqlParameter("@Opcion", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int JT_LoadControlFacturas(
      string Mes,
      string IdProveedor,
      string NoFactura,
      string Proyecto,
      string Moneda,
      int? Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[0];
      if (Mes == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Mes;
      if (IdProveedor == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdProveedor;
      if (NoFactura == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) NoFactura;
      if (Proyecto == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Proyecto;
      if (Moneda == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Moneda;
      if (Estatus.HasValue)
        command.Parameters[6].Value = (object) Estatus.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int JT_LoadFacturasEmitidas(
      string Anio,
      string Cliente,
      string IdProyecto,
      string Moneda,
      int? Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[1];
      if (Anio == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Anio;
      if (Cliente == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Cliente;
      if (IdProyecto == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdProyecto;
      if (Moneda == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Moneda;
      if (Estatus.HasValue)
        command.Parameters[5].Value = (object) Estatus.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int MezclaProductos(object Productos)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[2];
      if (Productos == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Productos;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ActualizaCantidadEntregadaOC(
      string IdOrdenCompra,
      int? Item,
      Decimal? CantidadRecibida)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[3];
      if (IdOrdenCompra == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdOrdenCompra;
      if (Item.HasValue)
        command.Parameters[2].Value = (object) Item.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (CantidadRecibida.HasValue)
        command.Parameters[3].Value = (object) CantidadRecibida.Value;
      else
        command.Parameters[3].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ActualizaDatosInfoCenter(
      string NombreRobot,
      Decimal? TrabajoElectrico,
      Decimal? TrabajoMecanico)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[4];
      if (NombreRobot == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) NombreRobot;
      if (TrabajoElectrico.HasValue)
        command.Parameters[2].Value = (object) TrabajoElectrico.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (TrabajoMecanico.HasValue)
        command.Parameters[3].Value = (object) TrabajoMecanico.Value;
      else
        command.Parameters[3].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ActualizaDatosInfoCenterValiant(
      int? IdEstacion,
      Decimal? Electrico,
      Decimal? Mecanico,
      string Comentarios)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[5];
      if (IdEstacion.HasValue)
        command.Parameters[1].Value = (object) IdEstacion.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (Electrico.HasValue)
        command.Parameters[2].Value = (object) Electrico.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (Mecanico.HasValue)
        command.Parameters[3].Value = (object) Mecanico.Value;
      else
        command.Parameters[3].Value = (object) DBNull.Value;
      if (Comentarios == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Comentarios;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ActualizaSueldoUsuario(
      string IdUsuario,
      Decimal? Sueldo,
      string IdUsuarioModifico)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[6];
      if (IdUsuario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdUsuario;
      if (Sueldo.HasValue)
        command.Parameters[2].Value = (object) Sueldo.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (IdUsuarioModifico == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuarioModifico;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_BDExcelRober()
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[7];
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CambiaEstatusMaquinado(string IdMaquinado, int? Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[8];
      if (IdMaquinado == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdMaquinado;
      if (Estatus.HasValue)
        command.Parameters[2].Value = (object) Estatus.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CambiaEstatusTask(string IdTask, int? Estatus, int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[9];
      if (IdTask == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdTask;
      if (Estatus.HasValue)
        command.Parameters[2].Value = (object) Estatus.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[3].Value = (object) Opcion.Value;
      else
        command.Parameters[3].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CambiarEstatusProyecto(
      string IdProyecto,
      string IdUsuario,
      string Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[10];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      if (Estatus == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Estatus;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CancelaCotizacion(
      string IdCotizacion,
      string IdUsuario,
      string Comentario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[11];
      if (IdCotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCotizacion;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      if (Comentario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Comentario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CancelaOrdenCompra(string IdOrdenCompra, string Motivo, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[12];
      if (IdOrdenCompra == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdOrdenCompra;
      if (Motivo == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Motivo;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CargarFacturas(
      string Mes,
      string IdProveedor,
      string NoFactura,
      string Proyecto,
      string Moneda,
      int? Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[13];
      if (Mes == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Mes;
      if (IdProveedor == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdProveedor;
      if (NoFactura == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) NoFactura;
      if (Proyecto == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Proyecto;
      if (Moneda == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Moneda;
      if (Estatus.HasValue)
        command.Parameters[6].Value = (object) Estatus.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_CargarOrdenCompraProveedor(string IdProveedor)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[14];
      if (IdProveedor == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProveedor;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ChatMessageInsert(
      string IdFrom,
      string From,
      string IdTo,
      string To,
      string Message)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[15];
      if (IdFrom == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdFrom;
      if (From == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) From;
      if (IdTo == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdTo;
      if (To == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) To;
      if (Message == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Message;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_DesactivaCliente(string IdCliente, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[16];
      if (IdCliente == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCliente;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_DesactivaMaterial(string IdMaterial, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[17];
      if (IdMaterial == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdMaterial;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_DesactivaProveedor(string IdProveedor, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[18];
      if (IdProveedor == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProveedor;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_DesactivaProveedorMaterial(string IdProveedorMaterial, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[19];
      if (IdProveedorMaterial == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProveedorMaterial;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_DesactivaProyecto(string IdProyecto, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[20];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_DesactivaUsuario(string IdUsuario, string IdUsuarioQuien)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[21];
      if (IdUsuario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdUsuario;
      if (IdUsuarioQuien == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuarioQuien;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_EnviaCorreo(string IdCotizacion, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[22];
      if (IdCotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCotizacion;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_GraficaPastelUtilidad(string IdProyecto)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[23];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_GraficaUtilidad(string IdProyecto)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[24];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_GuardarFacturaEmitida(
      string IdFacturasEmitidas,
      string IdProyecto,
      string NoCotizacion,
      string NoOrdenCompra,
      string ProgramacionPago,
      Decimal? PorPagar,
      string FechaPago,
      int? Estatus,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[25];
      if (IdFacturasEmitidas == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdFacturasEmitidas;
      if (IdProyecto == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdProyecto;
      if (NoCotizacion == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) NoCotizacion;
      if (NoOrdenCompra == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) NoOrdenCompra;
      if (ProgramacionPago == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) ProgramacionPago;
      if (PorPagar.HasValue)
        command.Parameters[6].Value = (object) PorPagar.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (FechaPago == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) FechaPago;
      if (Estatus.HasValue)
        command.Parameters[8].Value = (object) Estatus.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[9].Value = (object) DBNull.Value;
      else
        command.Parameters[9].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaComentarioCotizacion(
      string IdCotizacion,
      string Comentario,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[26];
      if (IdCotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCotizacion;
      if (Comentario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Comentario;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaComentarioProyecto(
      string IdProyecto,
      string Comentario,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[27];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (Comentario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Comentario;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaComentariosOrdenCompra(
      string IdOrdenCompra,
      string Comentario,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[28];
      if (IdOrdenCompra == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdOrdenCompra;
      if (Comentario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Comentario;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaFallaReconocimientoVoz(string Vin, string Falla)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[29];
      if (Vin == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Vin;
      if (Falla == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Falla;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaImagenesInfoCenter(int? IdEstacion, byte[] ImagenReporte)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[30];
      if (IdEstacion.HasValue)
        command.Parameters[1].Value = (object) IdEstacion.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (ImagenReporte == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) ImagenReporte;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaNotaAclaratoria(string IdCotizacion, string NotaAclaratoria)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[31];
      if (IdCotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCotizacion;
      if (NotaAclaratoria == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NotaAclaratoria;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertaProveedorContacto(
      string IdProveedor,
      string NombreContacto,
      string Telefono,
      string Email,
      string Departamento)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[32];
      if (IdProveedor == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProveedor;
      if (NombreContacto == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NombreContacto;
      if (Telefono == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Telefono;
      if (Email == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Email;
      if (Departamento == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Departamento;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertFacturasEmitidas(
      string FolioFactura,
      DateTime? FechaFactura,
      string RfcReceptor,
      string NombreReceptor,
      Decimal? SubTotal,
      Decimal? Iva,
      Decimal? Retencion,
      Decimal? Total,
      string Moneda,
      Decimal? TipoCambio,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[33];
      if (FolioFactura == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) FolioFactura;
      if (FechaFactura.HasValue)
        command.Parameters[2].Value = (object) FechaFactura.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (RfcReceptor == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) RfcReceptor;
      if (NombreReceptor == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) NombreReceptor;
      if (SubTotal.HasValue)
        command.Parameters[5].Value = (object) SubTotal.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (Iva.HasValue)
        command.Parameters[6].Value = (object) Iva.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (Retencion.HasValue)
        command.Parameters[7].Value = (object) Retencion.Value;
      else
        command.Parameters[7].Value = (object) DBNull.Value;
      if (Total.HasValue)
        command.Parameters[8].Value = (object) Total.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (Moneda == null)
        command.Parameters[9].Value = (object) DBNull.Value;
      else
        command.Parameters[9].Value = (object) Moneda;
      if (TipoCambio.HasValue)
        command.Parameters[10].Value = (object) TipoCambio.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertFacturaXML(string NombreArchivo, string Archivo)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[34];
      if (NombreArchivo == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) NombreArchivo;
      if (Archivo == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Archivo;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertGasto(
      string IdProyecto,
      string NoFactura,
      string TipoGasto,
      string Descripcion,
      Decimal? Importe,
      Decimal? Iva,
      Decimal? Total,
      DateTime? Fecha,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[35];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (NoFactura == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NoFactura;
      if (TipoGasto == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) TipoGasto;
      if (Descripcion == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Descripcion;
      if (Importe.HasValue)
        command.Parameters[5].Value = (object) Importe.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (Iva.HasValue)
        command.Parameters[6].Value = (object) Iva.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (Total.HasValue)
        command.Parameters[7].Value = (object) Total.Value;
      else
        command.Parameters[7].Value = (object) DBNull.Value;
      if (Fecha.HasValue)
        command.Parameters[8].Value = (object) Fecha.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[9].Value = (object) DBNull.Value;
      else
        command.Parameters[9].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertLocalizacion(string ID, Decimal? Latitud, Decimal? Longitud)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[36];
      if (ID == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) ID;
      if (Latitud.HasValue)
        command.Parameters[2].Value = (object) Latitud.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (Longitud.HasValue)
        command.Parameters[3].Value = (object) Longitud.Value;
      else
        command.Parameters[3].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertMaterialImagen(
      string IdMaterial,
      string Imagen,
      string FileName,
      string FileExtension,
      string FileSize,
      string FileContentType,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[37];
      if (IdMaterial == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdMaterial;
      if (Imagen == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Imagen;
      if (FileName == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) FileName;
      if (FileExtension == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) FileExtension;
      if (FileSize == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) FileSize;
      if (FileContentType == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) FileContentType;
      if (IdUsuario == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertOrdenCompraDetalle(
      string IdOrdenCompra,
      int? Item,
      string Codigo,
      string Descripcion,
      string Comentarios,
      Decimal? Cantidad,
      string Unidad,
      Decimal? Precio,
      Decimal? Importe,
      string TiempoEntrega,
      Decimal? CantidadRecibida,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[38];
      if (IdOrdenCompra == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdOrdenCompra;
      if (Item.HasValue)
        command.Parameters[2].Value = (object) Item.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (Codigo == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Codigo;
      if (Descripcion == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Descripcion;
      if (Comentarios == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Comentarios;
      if (Cantidad.HasValue)
        command.Parameters[6].Value = (object) Cantidad.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (Unidad == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) Unidad;
      if (Precio.HasValue)
        command.Parameters[8].Value = (object) Precio.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (Importe.HasValue)
        command.Parameters[9].Value = (object) Importe.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (TiempoEntrega == null)
        command.Parameters[10].Value = (object) DBNull.Value;
      else
        command.Parameters[10].Value = (object) TiempoEntrega;
      if (CantidadRecibida.HasValue)
        command.Parameters[11].Value = (object) CantidadRecibida.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[12].Value = (object) Opcion.Value;
      else
        command.Parameters[12].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertOrdenTrabajo(
      string IdProyecto,
      string FechaPruebas,
      string FechaEntrega,
      string IdUsuarioCoordinador)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[39];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (FechaPruebas == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) FechaPruebas;
      if (FechaEntrega == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) FechaEntrega;
      if (IdUsuarioCoordinador == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) IdUsuarioCoordinador;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertProveedorMaterialPrecio(
      string IdProveedor,
      string IdMaterial,
      string UnidadMedida,
      Decimal? Precio,
      string IdMoneda,
      string IdProveedorMaterial,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[40];
      if (IdProveedor == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProveedor;
      if (IdMaterial == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdMaterial;
      if (UnidadMedida == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) UnidadMedida;
      if (Precio.HasValue)
        command.Parameters[4].Value = (object) Precio.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (IdMoneda == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) IdMoneda;
      if (IdProveedorMaterial == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) IdProveedorMaterial;
      if (IdUsuario == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertProyectoRequerimiento(
      string IdProyecto,
      string Requerimiento,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[41];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (Requerimiento == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Requerimiento;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertProyectoTask(
      string IdProyecto,
      string Task,
      string IdUsuario,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      string Comentarios,
      string IdUsuarioAlta)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[42];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (Task == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Task;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      if (FechaInicio.HasValue)
        command.Parameters[4].Value = (object) FechaInicio.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (FechaFin.HasValue)
        command.Parameters[5].Value = (object) FechaFin.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (Comentarios == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) Comentarios;
      if (IdUsuarioAlta == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) IdUsuarioAlta;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertReqDet(
      string IdReqEnc,
      int? Item,
      string Descripcion,
      int? Cantidad,
      string Unidad,
      string NumParte,
      string Marca)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[43];
      if (IdReqEnc == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdReqEnc;
      if (Item.HasValue)
        command.Parameters[2].Value = (object) Item.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (Descripcion == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Descripcion;
      if (Cantidad.HasValue)
        command.Parameters[4].Value = (object) Cantidad.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (Unidad == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Unidad;
      if (NumParte == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) NumParte;
      if (Marca == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) Marca;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertRFQ(
      string IdRfq,
      string Folio,
      string Round,
      DateTime? Fecha,
      DateTime? FechaVencimiento,
      string IdCliente,
      string FolioRQ,
      string IdComprador,
      int? Estatus,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[44];
      if (IdRfq == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdRfq;
      if (Folio == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Folio;
      if (Round == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Round;
      if (Fecha.HasValue)
        command.Parameters[4].Value = (object) Fecha.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (FechaVencimiento.HasValue)
        command.Parameters[5].Value = (object) FechaVencimiento.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (IdCliente == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) IdCliente;
      if (FolioRQ == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) FolioRQ;
      if (IdComprador == null)
        command.Parameters[8].Value = (object) DBNull.Value;
      else
        command.Parameters[8].Value = (object) IdComprador;
      if (Estatus.HasValue)
        command.Parameters[9].Value = (object) Estatus.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[10].Value = (object) DBNull.Value;
      else
        command.Parameters[10].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertSeguimientoRFQ(string IdRfq, string Seguimiento, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[45];
      if (IdRfq == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdRfq;
      if (Seguimiento == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Seguimiento;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertTaskComentarios(string IdTask, string IdUsuario, string Comentario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[46];
      if (IdTask == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdTask;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      if (Comentario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Comentario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertTaskImagen(
      string IdTask,
      string Imagen,
      string Descripcion,
      string FileName,
      string FileExtension,
      string FileSize,
      string FileContentType,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[47];
      if (IdTask == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdTask;
      if (Imagen == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Imagen;
      if (Descripcion == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Descripcion;
      if (FileName == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) FileName;
      if (FileExtension == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) FileExtension;
      if (FileSize == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) FileSize;
      if (FileContentType == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) FileContentType;
      if (IdUsuario == null)
        command.Parameters[8].Value = (object) DBNull.Value;
      else
        command.Parameters[8].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertTimmingsExcel(
      string NombreProyecto,
      string Actividad,
      string Tarea,
      string FechaIni,
      string FechaFin,
      string Asignado,
      string DiasTrans,
      string Avance,
      int? Fila)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[48];
      if (NombreProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) NombreProyecto;
      if (Actividad == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Actividad;
      if (Tarea == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Tarea;
      if (FechaIni == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) FechaIni;
      if (FechaFin == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) FechaFin;
      if (Asignado == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) Asignado;
      if (DiasTrans == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) DiasTrans;
      if (Avance == null)
        command.Parameters[8].Value = (object) DBNull.Value;
      else
        command.Parameters[8].Value = (object) Avance;
      if (Fila.HasValue)
        command.Parameters[9].Value = (object) Fila.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateClientes(
      string IdCliente,
      string RazonSocial,
      string Contacto,
      string Email,
      string Departamento,
      string TelefonoEmpresa,
      string Celular,
      string UsuarioCliente,
      string ContrasenaCliente,
      string MapaCoordenadas,
      string Logotipo,
      string Direccion,
      string IdUsuario,
      int? Activo)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[49];
      if (IdCliente == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCliente;
      if (RazonSocial == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) RazonSocial;
      if (Contacto == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Contacto;
      if (Email == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Email;
      if (Departamento == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Departamento;
      if (TelefonoEmpresa == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) TelefonoEmpresa;
      if (Celular == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) Celular;
      if (UsuarioCliente == null)
        command.Parameters[8].Value = (object) DBNull.Value;
      else
        command.Parameters[8].Value = (object) UsuarioCliente;
      if (ContrasenaCliente == null)
        command.Parameters[9].Value = (object) DBNull.Value;
      else
        command.Parameters[9].Value = (object) ContrasenaCliente;
      if (MapaCoordenadas == null)
        command.Parameters[10].Value = (object) DBNull.Value;
      else
        command.Parameters[10].Value = (object) MapaCoordenadas;
      if (Logotipo == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) Logotipo;
      if (Direccion == null)
        command.Parameters[12].Value = (object) DBNull.Value;
      else
        command.Parameters[12].Value = (object) Direccion;
      if (IdUsuario == null)
        command.Parameters[13].Value = (object) DBNull.Value;
      else
        command.Parameters[13].Value = (object) IdUsuario;
      if (Activo.HasValue)
        command.Parameters[14].Value = (object) Activo.Value;
      else
        command.Parameters[14].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateEventoCalendario(
      string IdCalendario,
      string Titulo,
      string Descripcion,
      DateTime? FechaInicio,
      DateTime? FechaFinal,
      bool? TodoDia,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[50];
      if (IdCalendario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCalendario;
      if (Titulo == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Titulo;
      if (Descripcion == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Descripcion;
      if (FechaInicio.HasValue)
        command.Parameters[4].Value = (object) FechaInicio.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (FechaFinal.HasValue)
        command.Parameters[5].Value = (object) FechaFinal.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (TodoDia.HasValue)
        command.Parameters[6].Value = (object) TodoDia.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateHabilidad(
      string IdHabilidad,
      string IdUsuario,
      string Habilidad,
      Decimal? Porcentaje,
      string Comentarios)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[51];
      if (IdHabilidad == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdHabilidad;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      if (Habilidad == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Habilidad;
      if (Porcentaje.HasValue)
        command.Parameters[4].Value = (object) Porcentaje.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (Comentarios == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Comentarios;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateHorasHombre(
      string IdProyecto,
      string IdHorasHombre,
      string IdUsuario,
      int? Lunes,
      int? Martes,
      int? Miercoles,
      int? Jueves,
      int? Viernes,
      int? Sabado,
      int? Domingo,
      int? Activo)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[52];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (IdHorasHombre == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdHorasHombre;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      if (Lunes.HasValue)
        command.Parameters[4].Value = (object) Lunes.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (Martes.HasValue)
        command.Parameters[5].Value = (object) Martes.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (Miercoles.HasValue)
        command.Parameters[6].Value = (object) Miercoles.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (Jueves.HasValue)
        command.Parameters[7].Value = (object) Jueves.Value;
      else
        command.Parameters[7].Value = (object) DBNull.Value;
      if (Viernes.HasValue)
        command.Parameters[8].Value = (object) Viernes.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (Sabado.HasValue)
        command.Parameters[9].Value = (object) Sabado.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (Domingo.HasValue)
        command.Parameters[10].Value = (object) Domingo.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Activo.HasValue)
        command.Parameters[11].Value = (object) Activo.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateListaPendientes(
      string IdListaPendientes,
      string IdUsuario,
      string Pendiente,
      int? Completado)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[53];
      if (IdListaPendientes == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdListaPendientes;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      if (Pendiente == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Pendiente;
      if (Completado.HasValue)
        command.Parameters[4].Value = (object) Completado.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateMaquinado(
      string IdMaquina,
      string IdProyecto,
      string NombreProyecto,
      string NoParte,
      DateTime? FechaOC,
      DateTime? FechaEntrega,
      string IdDiseno,
      string IdMasterCam,
      int? Estatus,
      string IdEncargadoProyecto,
      string IdDisenador,
      string IdQuienHizo,
      string Observaciones,
      int? HorasMaquina,
      int? CantidadPzas)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[54];
      if (IdMaquina == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdMaquina;
      if (IdProyecto == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdProyecto;
      if (NombreProyecto == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) NombreProyecto;
      if (NoParte == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) NoParte;
      if (FechaOC.HasValue)
        command.Parameters[5].Value = (object) FechaOC.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (FechaEntrega.HasValue)
        command.Parameters[6].Value = (object) FechaEntrega.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (IdDiseno == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) IdDiseno;
      if (IdMasterCam == null)
        command.Parameters[8].Value = (object) DBNull.Value;
      else
        command.Parameters[8].Value = (object) IdMasterCam;
      if (Estatus.HasValue)
        command.Parameters[9].Value = (object) Estatus.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (IdEncargadoProyecto == null)
        command.Parameters[10].Value = (object) DBNull.Value;
      else
        command.Parameters[10].Value = (object) IdEncargadoProyecto;
      if (IdDisenador == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) IdDisenador;
      if (IdQuienHizo == null)
        command.Parameters[12].Value = (object) DBNull.Value;
      else
        command.Parameters[12].Value = (object) IdQuienHizo;
      if (Observaciones == null)
        command.Parameters[13].Value = (object) DBNull.Value;
      else
        command.Parameters[13].Value = (object) Observaciones;
      if (HorasMaquina.HasValue)
        command.Parameters[14].Value = (object) HorasMaquina.Value;
      else
        command.Parameters[14].Value = (object) DBNull.Value;
      if (CantidadPzas.HasValue)
        command.Parameters[15].Value = (object) CantidadPzas.Value;
      else
        command.Parameters[15].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdatePermisos(string IdUsuario, int? IdMenu, int? Visible)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[55];
      if (IdUsuario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdUsuario;
      if (IdMenu.HasValue)
        command.Parameters[2].Value = (object) IdMenu.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (Visible.HasValue)
        command.Parameters[3].Value = (object) Visible.Value;
      else
        command.Parameters[3].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateProyectos(
      string IdProyecto,
      string NombreProyecto,
      string Descripcion,
      string IdLider,
      string IdCliente,
      int? Estatus,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      string IdUsuario,
      string IdCotizacion,
      Decimal? CostoCotizacion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[56];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (NombreProyecto == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NombreProyecto;
      if (Descripcion == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Descripcion;
      if (IdLider == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) IdLider;
      if (IdCliente == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) IdCliente;
      if (Estatus.HasValue)
        command.Parameters[6].Value = (object) Estatus.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (FechaInicio.HasValue)
        command.Parameters[7].Value = (object) FechaInicio.Value;
      else
        command.Parameters[7].Value = (object) DBNull.Value;
      if (FechaFin.HasValue)
        command.Parameters[8].Value = (object) FechaFin.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[9].Value = (object) DBNull.Value;
      else
        command.Parameters[9].Value = (object) IdUsuario;
      if (IdCotizacion == null)
        command.Parameters[10].Value = (object) DBNull.Value;
      else
        command.Parameters[10].Value = (object) IdCotizacion;
      if (CostoCotizacion.HasValue)
        command.Parameters[11].Value = (object) CostoCotizacion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateRFQVentas(
      string IdRFQ,
      string FolioRfq,
      string Descripcion,
      string IdUsuarioVendedor,
      string IdUsuarioCoordinador,
      string Empresa,
      string Contacto,
      DateTime? FechaRFQ,
      DateTime? FechaEntrega,
      int? Enviado,
      int? Estatus,
      string Seguimiento,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[57];
      if (IdRFQ == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdRFQ;
      if (FolioRfq == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) FolioRfq;
      if (Descripcion == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Descripcion;
      if (IdUsuarioVendedor == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) IdUsuarioVendedor;
      if (IdUsuarioCoordinador == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) IdUsuarioCoordinador;
      if (Empresa == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) Empresa;
      if (Contacto == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) Contacto;
      if (FechaRFQ.HasValue)
        command.Parameters[8].Value = (object) FechaRFQ.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (FechaEntrega.HasValue)
        command.Parameters[9].Value = (object) FechaEntrega.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (Enviado.HasValue)
        command.Parameters[10].Value = (object) Enviado.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        command.Parameters[11].Value = (object) Estatus.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      if (Seguimiento == null)
        command.Parameters[12].Value = (object) DBNull.Value;
      else
        command.Parameters[12].Value = (object) Seguimiento;
      if (IdUsuario == null)
        command.Parameters[13].Value = (object) DBNull.Value;
      else
        command.Parameters[13].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUpdateUsuarios(
      string IdUsuario,
      string NombreCompleto,
      string Usuario,
      string Contrasena,
      string Foto,
      int? Permisos,
      string Puesto,
      string Telefono,
      string Correo,
      string IdUsuarioActualiza,
      int? Activo,
      int? EsLider)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[58];
      if (IdUsuario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdUsuario;
      if (NombreCompleto == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NombreCompleto;
      if (Usuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Usuario;
      if (Contrasena == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Contrasena;
      if (Foto == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Foto;
      if (Permisos.HasValue)
        command.Parameters[6].Value = (object) Permisos.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      if (Puesto == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) Puesto;
      if (Telefono == null)
        command.Parameters[8].Value = (object) DBNull.Value;
      else
        command.Parameters[8].Value = (object) Telefono;
      if (Correo == null)
        command.Parameters[9].Value = (object) DBNull.Value;
      else
        command.Parameters[9].Value = (object) Correo;
      if (IdUsuarioActualiza == null)
        command.Parameters[10].Value = (object) DBNull.Value;
      else
        command.Parameters[10].Value = (object) IdUsuarioActualiza;
      if (Activo.HasValue)
        command.Parameters[11].Value = (object) Activo.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      if (EsLider.HasValue)
        command.Parameters[12].Value = (object) EsLider.Value;
      else
        command.Parameters[12].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_InsertUsuarioHorasHombre(string IdProyecto, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[59];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_LoadTimming()
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[60];
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ObtieneFolioCotizacion(ref string Folio)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[61];
      if (Folio == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Folio;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      Folio = command.Parameters[1].Value == null || command.Parameters[1].Value.GetType() == typeof (DBNull) ? (string) null : (string) command.Parameters[1].Value;
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ObtieneFolioOrdenCompra(ref string FolioOC)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[62];
      if (FolioOC == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) FolioOC;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      FolioOC = command.Parameters[1].Value == null || command.Parameters[1].Value.GetType() == typeof (DBNull) ? (string) null : (string) command.Parameters[1].Value;
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ObtieneFolioReq(ref string Folio)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[63];
      if (Folio == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Folio;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      Folio = command.Parameters[1].Value == null || command.Parameters[1].Value.GetType() == typeof (DBNull) ? (string) null : (string) command.Parameters[1].Value;
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ObtieneFolioRFQ(ref string Folio)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[64];
      if (Folio == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Folio;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      Folio = command.Parameters[1].Value == null || command.Parameters[1].Value.GetType() == typeof (DBNull) ? (string) null : (string) command.Parameters[1].Value;
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ResumenTotales(
      string Mes,
      string IdProveedor,
      string NoFactura,
      string Proyecto,
      string Moneda,
      int? Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[65];
      if (Mes == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Mes;
      if (IdProveedor == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdProveedor;
      if (NoFactura == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) NoFactura;
      if (Proyecto == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Proyecto;
      if (Moneda == null)
        command.Parameters[5].Value = (object) DBNull.Value;
      else
        command.Parameters[5].Value = (object) Moneda;
      if (Estatus.HasValue)
        command.Parameters[6].Value = (object) Estatus.Value;
      else
        command.Parameters[6].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ResumenTotalesFacturasEmitidas(
      string Anio,
      string Cliente,
      string IdProyecto,
      string Moneda,
      int? Estatus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[66];
      if (Anio == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Anio;
      if (Cliente == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Cliente;
      if (IdProyecto == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdProyecto;
      if (Moneda == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Moneda;
      if (Estatus.HasValue)
        command.Parameters[5].Value = (object) Estatus.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ResumenTotalesOC(string Valor)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[67];
      if (Valor == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) Valor;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Clientes(object Clientes)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[68];
      if (Clientes == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Clientes;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_ComentariosProyecto(object ComentariosProyecto)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[69];
      if (ComentariosProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = ComentariosProyecto;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Cotizacion(object Cotizacion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[70];
      if (Cotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Cotizacion;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_FolioCotizacion(object FolioCotizacion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[71];
      if (FolioCotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = FolioCotizacion;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Gastos(object Gastos)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[72];
      if (Gastos == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Gastos;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Habilidades(object Habilidades)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[73];
      if (Habilidades == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Habilidades;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_ListaPendientes(object ListaPendientes)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[74];
      if (ListaPendientes == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = ListaPendientes;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_MatrizMecanico(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[75];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Menu(object Menus)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[76];
      if (Menus == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Menus;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_NotaAclaratoria(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[77];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Permisos(object Permisos)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[78];
      if (Permisos == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Permisos;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Proveedores(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[79];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Proyectos(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[80];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_ProyectosTaskImagen(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[81];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_ProyectoTasks(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[82];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_ProyectoTasksComentarios(object Parametro)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[83];
      if (Parametro == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Parametro;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Usuarios(object Usuarios)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[84];
      if (Usuarios == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Usuarios;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_Viaticos(object Viatico)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[85];
      if (Viatico == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = Viatico;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_Sincronizacion_ViaticosDet(object ViaticoDet)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[86];
      if (ViaticoDet == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = ViaticoDet;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_SubeArchivoCotizacion(
      string IdCotizacion,
      string NombreArchivo,
      string Documento)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[87];
      if (IdCotizacion == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdCotizacion;
      if (NombreArchivo == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NombreArchivo;
      if (Documento == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Documento;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_SubeArchivosFacturas(
      string IdControlFacturas,
      string NombreArchivo,
      string Documento)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[88];
      if (IdControlFacturas == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdControlFacturas;
      if (NombreArchivo == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NombreArchivo;
      if (Documento == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Documento;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_SubeArchivosProyectos(
      string IdProyecto,
      string NombreArchivo,
      string Documento,
      string Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[89];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (NombreArchivo == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) NombreArchivo;
      if (Documento == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) Documento;
      if (Opcion == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) Opcion;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_TerminarCapturaHorasHombre(string IdProyecto, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[90];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_TerminarProyecto(string IdProyecto, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[91];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (IdUsuario == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_UpdateCostoProyecto(string IdProyecto, Decimal? Costo, string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[92];
      if (IdProyecto == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdProyecto;
      if (Costo.HasValue)
        command.Parameters[2].Value = (object) Costo.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_UpdateImagenUsuario(string IdUsuario, string Imagen)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[93];
      if (IdUsuario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdUsuario;
      if (Imagen == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Imagen;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_UpdatePerfilUsuario(string IdUsuario, string Perfil)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[94];
      if (IdUsuario == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdUsuario;
      if (Perfil == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Perfil;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_UpdateTask(
      string IdTask,
      string Task,
      string IdUsuario,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      string Comentarios,
      string IdUsuarioAlta)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[95];
      if (IdTask == null)
        command.Parameters[1].Value = (object) DBNull.Value;
      else
        command.Parameters[1].Value = (object) IdTask;
      if (Task == null)
        command.Parameters[2].Value = (object) DBNull.Value;
      else
        command.Parameters[2].Value = (object) Task;
      if (IdUsuario == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) IdUsuario;
      if (FechaInicio.HasValue)
        command.Parameters[4].Value = (object) FechaInicio.Value;
      else
        command.Parameters[4].Value = (object) DBNull.Value;
      if (FechaFin.HasValue)
        command.Parameters[5].Value = (object) FechaFin.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (Comentarios == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) Comentarios;
      if (IdUsuarioAlta == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) IdUsuarioAlta;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      try
      {
        return command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_CapturaViaticos(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      string IdUsuario)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[96];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (IdUsuario == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) IdUsuario;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Clientes(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[97];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[11].Value = (object) Opcion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Cotizaciones(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[98];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[11].Value = (object) Opcion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Maquinados(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[99];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[11].Value = (object) Opcion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Materiales(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[100];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[11].Value = (object) Opcion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Proveedores(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[101];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[11].Value = (object) Opcion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Proyectos(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      string Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[102];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) Opcion;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_ProyectoTasks(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      string IdProyecto)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[103];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (IdProyecto == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) IdProyecto;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Requisiciones(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      int? Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[104];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion.HasValue)
        command.Parameters[11].Value = (object) Opcion.Value;
      else
        command.Parameters[11].Value = (object) DBNull.Value;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int W_Sp_Pag_Viaticos(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ref int? iTotalRecords,
      ref int? iTotalDisplayRecords,
      string Opcion)
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[105];
      if (iDisplayStart.HasValue)
        command.Parameters[1].Value = (object) iDisplayStart.Value;
      else
        command.Parameters[1].Value = (object) DBNull.Value;
      if (iDisplayLength.HasValue)
        command.Parameters[2].Value = (object) iDisplayLength.Value;
      else
        command.Parameters[2].Value = (object) DBNull.Value;
      if (sSortingCol_delim == null)
        command.Parameters[3].Value = (object) DBNull.Value;
      else
        command.Parameters[3].Value = (object) sSortingCol_delim;
      if (sSortingDir_delim == null)
        command.Parameters[4].Value = (object) DBNull.Value;
      else
        command.Parameters[4].Value = (object) sSortingDir_delim;
      if (iSortingCols.HasValue)
        command.Parameters[5].Value = (object) iSortingCols.Value;
      else
        command.Parameters[5].Value = (object) DBNull.Value;
      if (sSearch == null)
        command.Parameters[6].Value = (object) DBNull.Value;
      else
        command.Parameters[6].Value = (object) sSearch;
      if (sSearchableCol_delim == null)
        command.Parameters[7].Value = (object) DBNull.Value;
      else
        command.Parameters[7].Value = (object) sSearchableCol_delim;
      if (iSearchableCols.HasValue)
        command.Parameters[8].Value = (object) iSearchableCols.Value;
      else
        command.Parameters[8].Value = (object) DBNull.Value;
      if (iTotalRecords.HasValue)
        command.Parameters[9].Value = (object) iTotalRecords.Value;
      else
        command.Parameters[9].Value = (object) DBNull.Value;
      if (iTotalDisplayRecords.HasValue)
        command.Parameters[10].Value = (object) iTotalDisplayRecords.Value;
      else
        command.Parameters[10].Value = (object) DBNull.Value;
      if (Opcion == null)
        command.Parameters[11].Value = (object) DBNull.Value;
      else
        command.Parameters[11].Value = (object) Opcion;
      ConnectionState state = command.Connection.State;
      if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        command.Connection.Open();
      int num;
      try
      {
        num = command.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          command.Connection.Close();
      }
      if (command.Parameters[9].Value == null || command.Parameters[9].Value.GetType() == typeof (DBNull))
        iTotalRecords = new int?();
      else
        iTotalRecords = new int?((int) command.Parameters[9].Value);
      if (command.Parameters[10].Value == null || command.Parameters[10].Value.GetType() == typeof (DBNull))
        iTotalDisplayRecords = new int?();
      else
        iTotalDisplayRecords = new int?((int) command.Parameters[10].Value);
      return num;
    }
  }
}
