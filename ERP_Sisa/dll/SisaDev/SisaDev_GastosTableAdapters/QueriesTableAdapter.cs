// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_GastosTableAdapters.QueriesTableAdapter
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SisaDev.SisaDev_GastosTableAdapters
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
      this._commandCollection = new IDbCommand[1];
      this._commandCollection[0] = (IDbCommand) new SqlCommand();
      ((SqlCommand) this._commandCollection[0]).Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      ((DbCommand) this._commandCollection[0]).CommandText = "dbo.sp_ReporteProyectosGastos";
      ((DbCommand) this._commandCollection[0]).CommandType = CommandType.StoredProcedure;
      ((SqlCommand) this._commandCollection[0]).Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int sp_ReporteProyectosGastos()
    {
      SqlCommand command = (SqlCommand) this.CommandCollection[0];
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
  }
}
