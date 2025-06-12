// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblViaticosDetTableAdapter
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

namespace SisaDev.SisaDevFacturasTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class tblViaticosDetTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblViaticosDetTableAdapter() => this.ClearBeforeFill = true;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected internal SqlDataAdapter Adapter
    {
      get
      {
        if (this._adapter == null)
          this.InitAdapter();
        return this._adapter;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal SqlConnection Connection
    {
      get
      {
        if (this._connection == null)
          this.InitConnection();
        return this._connection;
      }
      set
      {
        this._connection = value;
        if (this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Connection = value;
        if (this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Connection = value;
        if (this.Adapter.UpdateCommand != null)
          this.Adapter.UpdateCommand.Connection = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
        {
          if (this.CommandCollection[index] != null)
            this.CommandCollection[index].Connection = value;
        }
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal SqlTransaction Transaction
    {
      get => this._transaction;
      set
      {
        this._transaction = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
          this.CommandCollection[index].Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Transaction = this._transaction;
        if (this.Adapter == null || this.Adapter.UpdateCommand == null)
          return;
        this.Adapter.UpdateCommand.Transaction = this._transaction;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected SqlCommand[] CommandCollection
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
    public bool ClearBeforeFill
    {
      get => this._clearBeforeFill;
      set => this._clearBeforeFill = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitAdapter()
    {
      this._adapter = new SqlDataAdapter();
      this._adapter.TableMappings.Add((object) new DataTableMapping()
      {
        SourceTable = "Table",
        DataSetTable = "tblViaticosDet",
        ColumnMappings = {
          {
            "IdDet",
            "IdDet"
          },
          {
            "IdViaticos",
            "IdViaticos"
          },
          {
            "FechaViaticos",
            "FechaViaticos"
          },
          {
            "Gasolina",
            "Gasolina"
          },
          {
            "Desayuno",
            "Desayuno"
          },
          {
            "Comida",
            "Comida"
          },
          {
            "Cena",
            "Cena"
          },
          {
            "Casetas",
            "Casetas"
          },
          {
            "Hotel",
            "Hotel"
          },
          {
            "Transporte",
            "Transporte"
          },
          {
            "Otros",
            "Otros"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "Ticket",
            "Ticket"
          },
          {
            "idProyecto",
            "idProyecto"
          },
          {
            "ManoObra",
            "ManoObra"
          },
          {
            "Equipo",
            "Equipo"
          },
          {
            "Materiales",
            "Materiales"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblViaticosDet] WHERE (([IdDet] = @Original_IdDet))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdDet", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblViaticosDet] ([IdDet], [IdViaticos], [FechaViaticos], [Gasolina], [Desayuno], [Comida], [Cena], [Casetas], [Hotel], [Transporte], [Otros], [Descripcion], [Ticket], [idProyecto], [ManoObra], [Equipo], [Materiales]) VALUES (@IdDet, @IdViaticos, @FechaViaticos, @Gasolina, @Desayuno, @Comida, @Cena, @Casetas, @Hotel, @Transporte, @Otros, @Descripcion, @Ticket, @idProyecto, @ManoObra, @Equipo, @Materiales)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdDet", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdViaticos", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdViaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaViaticos", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaViaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Gasolina", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Gasolina", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Desayuno", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Desayuno", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comida", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Comida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Cena", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Cena", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Casetas", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Casetas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Hotel", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Hotel", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Transporte", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Transporte", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Otros", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Otros", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Ticket", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Ticket", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ManoObra", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "ManoObra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Equipo", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Equipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Materiales", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Materiales", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblViaticosDet] SET [IdDet] = @IdDet, [IdViaticos] = @IdViaticos, [FechaViaticos] = @FechaViaticos, [Gasolina] = @Gasolina, [Desayuno] = @Desayuno, [Comida] = @Comida, [Cena] = @Cena, [Casetas] = @Casetas, [Hotel] = @Hotel, [Transporte] = @Transporte, [Otros] = @Otros, [Descripcion] = @Descripcion, [Ticket] = @Ticket, [idProyecto] = @idProyecto, [ManoObra] = @ManoObra, [Equipo] = @Equipo, [Materiales] = @Materiales WHERE (([IdDet] = @Original_IdDet))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdDet", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdViaticos", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdViaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaViaticos", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaViaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Gasolina", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Gasolina", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Desayuno", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Desayuno", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comida", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Comida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Cena", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Cena", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Casetas", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Casetas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Hotel", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Hotel", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Transporte", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Transporte", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Otros", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Otros", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Ticket", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Ticket", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ManoObra", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "ManoObra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Equipo", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Equipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Materiales", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Materiales", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdDet", DataRowVersion.Original, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitConnection()
    {
      this._connection = new SqlConnection();
      this._connection.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitCommandCollection()
    {
      this._commandCollection = new SqlCommand[1];
      this._commandCollection[0] = new SqlCommand();
      this._commandCollection[0].Connection = this.Connection;
      this._commandCollection[0].CommandText = "SELECT IdDet, IdViaticos, FechaViaticos, Gasolina, Desayuno, Comida, Cena, Casetas, Hotel, Transporte, Otros, Descripcion, Ticket, idProyecto, ManoObra, Equipo, Materiales FROM dbo.tblViaticosDet";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblViaticosDetDataTable dataTable)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual SisaDevFacturas.tblViaticosDetDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblViaticosDetDataTable viaticosDetDataTable = new SisaDevFacturas.tblViaticosDetDataTable();
      this.Adapter.Fill((DataTable) viaticosDetDataTable);
      return viaticosDetDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblViaticosDetDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblViaticosDet");

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(DataRow dataRow) => this.Adapter.Update(new DataRow[1]
    {
      dataRow
    });

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(DataRow[] dataRows) => this.Adapter.Update(dataRows);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public virtual int Delete(Guid Original_IdDet)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdDet;
      ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
      if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.DeleteCommand.Connection.Open();
      try
      {
        return this.Adapter.DeleteCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.DeleteCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public virtual int Insert(
      Guid IdDet,
      Guid IdViaticos,
      DateTime FechaViaticos,
      Decimal Gasolina,
      Decimal Desayuno,
      Decimal Comida,
      Decimal Cena,
      Decimal Casetas,
      Decimal Hotel,
      Decimal Transporte,
      Decimal Otros,
      string Descripcion,
      string Ticket,
      Guid? idProyecto,
      Decimal? ManoObra,
      Decimal? Equipo,
      Decimal? Materiales)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdDet;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdViaticos;
      this.Adapter.InsertCommand.Parameters[2].Value = (object) FechaViaticos;
      this.Adapter.InsertCommand.Parameters[3].Value = (object) Gasolina;
      this.Adapter.InsertCommand.Parameters[4].Value = (object) Desayuno;
      this.Adapter.InsertCommand.Parameters[5].Value = (object) Comida;
      this.Adapter.InsertCommand.Parameters[6].Value = (object) Cena;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Casetas;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) Hotel;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) Transporte;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) Otros;
      this.Adapter.InsertCommand.Parameters[11].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      if (Ticket == null)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) Ticket;
      if (idProyecto.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) idProyecto.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (ManoObra.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) ManoObra.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (Equipo.HasValue)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) Equipo.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      if (Materiales.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) Materiales.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      ConnectionState state = this.Adapter.InsertCommand.Connection.State;
      if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.InsertCommand.Connection.Open();
      try
      {
        return this.Adapter.InsertCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.InsertCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      Guid IdDet,
      Guid IdViaticos,
      DateTime FechaViaticos,
      Decimal Gasolina,
      Decimal Desayuno,
      Decimal Comida,
      Decimal Cena,
      Decimal Casetas,
      Decimal Hotel,
      Decimal Transporte,
      Decimal Otros,
      string Descripcion,
      string Ticket,
      Guid? idProyecto,
      Decimal? ManoObra,
      Decimal? Equipo,
      Decimal? Materiales,
      Guid Original_IdDet)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdDet;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdViaticos;
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) FechaViaticos;
      this.Adapter.UpdateCommand.Parameters[3].Value = (object) Gasolina;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) Desayuno;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) Comida;
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) Cena;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Casetas;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Hotel;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Transporte;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) Otros;
      this.Adapter.UpdateCommand.Parameters[11].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      if (Ticket == null)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) Ticket;
      if (idProyecto.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) idProyecto.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (ManoObra.HasValue)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) ManoObra.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      if (Equipo.HasValue)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Equipo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      if (Materiales.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) Materiales.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_IdDet;
      ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
      if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.UpdateCommand.Connection.Open();
      try
      {
        return this.Adapter.UpdateCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.UpdateCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      Guid IdViaticos,
      DateTime FechaViaticos,
      Decimal Gasolina,
      Decimal Desayuno,
      Decimal Comida,
      Decimal Cena,
      Decimal Casetas,
      Decimal Hotel,
      Decimal Transporte,
      Decimal Otros,
      string Descripcion,
      string Ticket,
      Guid? idProyecto,
      Decimal? ManoObra,
      Decimal? Equipo,
      Decimal? Materiales,
      Guid Original_IdDet)
    {
      return this.Update(Original_IdDet, IdViaticos, FechaViaticos, Gasolina, Desayuno, Comida, Cena, Casetas, Hotel, Transporte, Otros, Descripcion, Ticket, idProyecto, ManoObra, Equipo, Materiales, Original_IdDet);
    }
  }
}
