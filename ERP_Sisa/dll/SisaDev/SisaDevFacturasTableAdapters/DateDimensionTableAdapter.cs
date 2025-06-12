// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.DateDimensionTableAdapter
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
  public class DateDimensionTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public DateDimensionTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "DateDimension",
        ColumnMappings = {
          {
            "DateKey",
            "DateKey"
          },
          {
            "Date",
            "Date"
          },
          {
            "Day",
            "Day"
          },
          {
            "DaySuffix",
            "DaySuffix"
          },
          {
            "Weekday",
            "Weekday"
          },
          {
            "WeekDayName",
            "WeekDayName"
          },
          {
            "IsWeekend",
            "IsWeekend"
          },
          {
            "IsHoliday",
            "IsHoliday"
          },
          {
            "HolidayText",
            "HolidayText"
          },
          {
            "DOWInMonth",
            "DOWInMonth"
          },
          {
            "DayOfYear",
            "DayOfYear"
          },
          {
            "WeekOfMonth",
            "WeekOfMonth"
          },
          {
            "WeekOfYear",
            "WeekOfYear"
          },
          {
            "ISOWeekOfYear",
            "ISOWeekOfYear"
          },
          {
            "Month",
            "Month"
          },
          {
            "MonthName",
            "MonthName"
          },
          {
            "Quarter",
            "Quarter"
          },
          {
            "QuarterName",
            "QuarterName"
          },
          {
            "Year",
            "Year"
          },
          {
            "MMYYYY",
            "MMYYYY"
          },
          {
            "MonthYear",
            "MonthYear"
          },
          {
            "FirstDayOfMonth",
            "FirstDayOfMonth"
          },
          {
            "LastDayOfMonth",
            "LastDayOfMonth"
          },
          {
            "FirstDayOfQuarter",
            "FirstDayOfQuarter"
          },
          {
            "LastDayOfQuarter",
            "LastDayOfQuarter"
          },
          {
            "FirstDayOfYear",
            "FirstDayOfYear"
          },
          {
            "LastDayOfYear",
            "LastDayOfYear"
          },
          {
            "FirstDayOfNextMonth",
            "FirstDayOfNextMonth"
          },
          {
            "FirstDayOfNextYear",
            "FirstDayOfNextYear"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[DateDimension] WHERE (([DateKey] = @Original_DateKey))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DateKey", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DateKey", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[DateDimension] ([DateKey], [Date], [Day], [DaySuffix], [Weekday], [WeekDayName], [IsWeekend], [IsHoliday], [HolidayText], [DOWInMonth], [DayOfYear], [WeekOfMonth], [WeekOfYear], [ISOWeekOfYear], [Month], [MonthName], [Quarter], [QuarterName], [Year], [MMYYYY], [MonthYear], [FirstDayOfMonth], [LastDayOfMonth], [FirstDayOfQuarter], [LastDayOfQuarter], [FirstDayOfYear], [LastDayOfYear], [FirstDayOfNextMonth], [FirstDayOfNextYear]) VALUES (@DateKey, @Date, @Day, @DaySuffix, @Weekday, @WeekDayName, @IsWeekend, @IsHoliday, @HolidayText, @DOWInMonth, @DayOfYear, @WeekOfMonth, @WeekOfYear, @ISOWeekOfYear, @Month, @MonthName, @Quarter, @QuarterName, @Year, @MMYYYY, @MonthYear, @FirstDayOfMonth, @LastDayOfMonth, @FirstDayOfQuarter, @LastDayOfQuarter, @FirstDayOfYear, @LastDayOfYear, @FirstDayOfNextMonth, @FirstDayOfNextYear)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DateKey", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DateKey", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Date", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Day", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Day", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DaySuffix", SqlDbType.Char, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DaySuffix", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Weekday", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weekday", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@WeekDayName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WeekDayName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsWeekend", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IsWeekend", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsHoliday", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IsHoliday", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@HolidayText", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HolidayText", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DOWInMonth", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DOWInMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DayOfYear", SqlDbType.SmallInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DayOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@WeekOfMonth", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WeekOfMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@WeekOfYear", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WeekOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ISOWeekOfYear", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ISOWeekOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Month", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Month", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MonthName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MonthName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Quarter", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quarter", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@QuarterName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "QuarterName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Year", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MMYYYY", SqlDbType.Char, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MMYYYY", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MonthYear", SqlDbType.Char, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MonthYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstDayOfMonth", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@LastDayOfMonth", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastDayOfMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstDayOfQuarter", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfQuarter", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@LastDayOfQuarter", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastDayOfQuarter", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstDayOfYear", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@LastDayOfYear", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastDayOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstDayOfNextMonth", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfNextMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstDayOfNextYear", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfNextYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[DateDimension] SET [DateKey] = @DateKey, [Date] = @Date, [Day] = @Day, [DaySuffix] = @DaySuffix, [Weekday] = @Weekday, [WeekDayName] = @WeekDayName, [IsWeekend] = @IsWeekend, [IsHoliday] = @IsHoliday, [HolidayText] = @HolidayText, [DOWInMonth] = @DOWInMonth, [DayOfYear] = @DayOfYear, [WeekOfMonth] = @WeekOfMonth, [WeekOfYear] = @WeekOfYear, [ISOWeekOfYear] = @ISOWeekOfYear, [Month] = @Month, [MonthName] = @MonthName, [Quarter] = @Quarter, [QuarterName] = @QuarterName, [Year] = @Year, [MMYYYY] = @MMYYYY, [MonthYear] = @MonthYear, [FirstDayOfMonth] = @FirstDayOfMonth, [LastDayOfMonth] = @LastDayOfMonth, [FirstDayOfQuarter] = @FirstDayOfQuarter, [LastDayOfQuarter] = @LastDayOfQuarter, [FirstDayOfYear] = @FirstDayOfYear, [LastDayOfYear] = @LastDayOfYear, [FirstDayOfNextMonth] = @FirstDayOfNextMonth, [FirstDayOfNextYear] = @FirstDayOfNextYear WHERE (([DateKey] = @Original_DateKey))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DateKey", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DateKey", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Date", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Day", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Day", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DaySuffix", SqlDbType.Char, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DaySuffix", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Weekday", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Weekday", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WeekDayName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WeekDayName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsWeekend", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IsWeekend", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsHoliday", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IsHoliday", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HolidayText", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "HolidayText", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DOWInMonth", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DOWInMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DayOfYear", SqlDbType.SmallInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DayOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WeekOfMonth", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WeekOfMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WeekOfYear", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "WeekOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ISOWeekOfYear", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ISOWeekOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Month", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Month", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MonthName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MonthName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Quarter", SqlDbType.TinyInt, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Quarter", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@QuarterName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "QuarterName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Year", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Year", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MMYYYY", SqlDbType.Char, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MMYYYY", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MonthYear", SqlDbType.Char, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MonthYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstDayOfMonth", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LastDayOfMonth", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastDayOfMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstDayOfQuarter", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfQuarter", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LastDayOfQuarter", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastDayOfQuarter", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstDayOfYear", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LastDayOfYear", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "LastDayOfYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstDayOfNextMonth", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfNextMonth", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstDayOfNextYear", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FirstDayOfNextYear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DateKey", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DateKey", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT DateKey, Date, Day, DaySuffix, Weekday, WeekDayName, IsWeekend, IsHoliday, HolidayText, DOWInMonth, DayOfYear, WeekOfMonth, WeekOfYear, ISOWeekOfYear, Month, MonthName, Quarter, QuarterName, Year, MMYYYY, MonthYear, FirstDayOfMonth, LastDayOfMonth, FirstDayOfQuarter, LastDayOfQuarter, FirstDayOfYear, LastDayOfYear, FirstDayOfNextMonth, FirstDayOfNextYear FROM dbo.DateDimension";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.DateDimensionDataTable dataTable)
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
    public virtual SisaDevFacturas.DateDimensionDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.DateDimensionDataTable dimensionDataTable = new SisaDevFacturas.DateDimensionDataTable();
      this.Adapter.Fill((DataTable) dimensionDataTable);
      return dimensionDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.DateDimensionDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "DateDimension");

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
    public virtual int Delete(int Original_DateKey)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_DateKey;
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
      int DateKey,
      DateTime Date,
      byte Day,
      string DaySuffix,
      byte Weekday,
      string WeekDayName,
      bool IsWeekend,
      bool IsHoliday,
      string HolidayText,
      byte DOWInMonth,
      short DayOfYear,
      byte WeekOfMonth,
      byte WeekOfYear,
      byte ISOWeekOfYear,
      byte Month,
      string MonthName,
      byte Quarter,
      string QuarterName,
      int Year,
      string MMYYYY,
      string MonthYear,
      DateTime FirstDayOfMonth,
      DateTime LastDayOfMonth,
      DateTime FirstDayOfQuarter,
      DateTime LastDayOfQuarter,
      DateTime FirstDayOfYear,
      DateTime LastDayOfYear,
      DateTime FirstDayOfNextMonth,
      DateTime FirstDayOfNextYear)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) DateKey;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) Date;
      this.Adapter.InsertCommand.Parameters[2].Value = (object) Day;
      this.Adapter.InsertCommand.Parameters[3].Value = DaySuffix != null ? (object) DaySuffix : throw new ArgumentNullException(nameof (DaySuffix));
      this.Adapter.InsertCommand.Parameters[4].Value = (object) Weekday;
      this.Adapter.InsertCommand.Parameters[5].Value = WeekDayName != null ? (object) WeekDayName : throw new ArgumentNullException(nameof (WeekDayName));
      this.Adapter.InsertCommand.Parameters[6].Value = (object) IsWeekend;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) IsHoliday;
      if (HolidayText == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) HolidayText;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) DOWInMonth;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) DayOfYear;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) WeekOfMonth;
      this.Adapter.InsertCommand.Parameters[12].Value = (object) WeekOfYear;
      this.Adapter.InsertCommand.Parameters[13].Value = (object) ISOWeekOfYear;
      this.Adapter.InsertCommand.Parameters[14].Value = (object) Month;
      this.Adapter.InsertCommand.Parameters[15].Value = MonthName != null ? (object) MonthName : throw new ArgumentNullException(nameof (MonthName));
      this.Adapter.InsertCommand.Parameters[16].Value = (object) Quarter;
      this.Adapter.InsertCommand.Parameters[17].Value = QuarterName != null ? (object) QuarterName : throw new ArgumentNullException(nameof (QuarterName));
      this.Adapter.InsertCommand.Parameters[18].Value = (object) Year;
      this.Adapter.InsertCommand.Parameters[19].Value = MMYYYY != null ? (object) MMYYYY : throw new ArgumentNullException(nameof (MMYYYY));
      this.Adapter.InsertCommand.Parameters[20].Value = MonthYear != null ? (object) MonthYear : throw new ArgumentNullException(nameof (MonthYear));
      this.Adapter.InsertCommand.Parameters[21].Value = (object) FirstDayOfMonth;
      this.Adapter.InsertCommand.Parameters[22].Value = (object) LastDayOfMonth;
      this.Adapter.InsertCommand.Parameters[23].Value = (object) FirstDayOfQuarter;
      this.Adapter.InsertCommand.Parameters[24].Value = (object) LastDayOfQuarter;
      this.Adapter.InsertCommand.Parameters[25].Value = (object) FirstDayOfYear;
      this.Adapter.InsertCommand.Parameters[26].Value = (object) LastDayOfYear;
      this.Adapter.InsertCommand.Parameters[27].Value = (object) FirstDayOfNextMonth;
      this.Adapter.InsertCommand.Parameters[28].Value = (object) FirstDayOfNextYear;
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
      int DateKey,
      DateTime Date,
      byte Day,
      string DaySuffix,
      byte Weekday,
      string WeekDayName,
      bool IsWeekend,
      bool IsHoliday,
      string HolidayText,
      byte DOWInMonth,
      short DayOfYear,
      byte WeekOfMonth,
      byte WeekOfYear,
      byte ISOWeekOfYear,
      byte Month,
      string MonthName,
      byte Quarter,
      string QuarterName,
      int Year,
      string MMYYYY,
      string MonthYear,
      DateTime FirstDayOfMonth,
      DateTime LastDayOfMonth,
      DateTime FirstDayOfQuarter,
      DateTime LastDayOfQuarter,
      DateTime FirstDayOfYear,
      DateTime LastDayOfYear,
      DateTime FirstDayOfNextMonth,
      DateTime FirstDayOfNextYear,
      int Original_DateKey)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) DateKey;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) Date;
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) Day;
      this.Adapter.UpdateCommand.Parameters[3].Value = DaySuffix != null ? (object) DaySuffix : throw new ArgumentNullException(nameof (DaySuffix));
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) Weekday;
      this.Adapter.UpdateCommand.Parameters[5].Value = WeekDayName != null ? (object) WeekDayName : throw new ArgumentNullException(nameof (WeekDayName));
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) IsWeekend;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) IsHoliday;
      if (HolidayText == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) HolidayText;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) DOWInMonth;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) DayOfYear;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) WeekOfMonth;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) WeekOfYear;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) ISOWeekOfYear;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) Month;
      this.Adapter.UpdateCommand.Parameters[15].Value = MonthName != null ? (object) MonthName : throw new ArgumentNullException(nameof (MonthName));
      this.Adapter.UpdateCommand.Parameters[16].Value = (object) Quarter;
      this.Adapter.UpdateCommand.Parameters[17].Value = QuarterName != null ? (object) QuarterName : throw new ArgumentNullException(nameof (QuarterName));
      this.Adapter.UpdateCommand.Parameters[18].Value = (object) Year;
      this.Adapter.UpdateCommand.Parameters[19].Value = MMYYYY != null ? (object) MMYYYY : throw new ArgumentNullException(nameof (MMYYYY));
      this.Adapter.UpdateCommand.Parameters[20].Value = MonthYear != null ? (object) MonthYear : throw new ArgumentNullException(nameof (MonthYear));
      this.Adapter.UpdateCommand.Parameters[21].Value = (object) FirstDayOfMonth;
      this.Adapter.UpdateCommand.Parameters[22].Value = (object) LastDayOfMonth;
      this.Adapter.UpdateCommand.Parameters[23].Value = (object) FirstDayOfQuarter;
      this.Adapter.UpdateCommand.Parameters[24].Value = (object) LastDayOfQuarter;
      this.Adapter.UpdateCommand.Parameters[25].Value = (object) FirstDayOfYear;
      this.Adapter.UpdateCommand.Parameters[26].Value = (object) LastDayOfYear;
      this.Adapter.UpdateCommand.Parameters[27].Value = (object) FirstDayOfNextMonth;
      this.Adapter.UpdateCommand.Parameters[28].Value = (object) FirstDayOfNextYear;
      this.Adapter.UpdateCommand.Parameters[29].Value = (object) Original_DateKey;
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
      DateTime Date,
      byte Day,
      string DaySuffix,
      byte Weekday,
      string WeekDayName,
      bool IsWeekend,
      bool IsHoliday,
      string HolidayText,
      byte DOWInMonth,
      short DayOfYear,
      byte WeekOfMonth,
      byte WeekOfYear,
      byte ISOWeekOfYear,
      byte Month,
      string MonthName,
      byte Quarter,
      string QuarterName,
      int Year,
      string MMYYYY,
      string MonthYear,
      DateTime FirstDayOfMonth,
      DateTime LastDayOfMonth,
      DateTime FirstDayOfQuarter,
      DateTime LastDayOfQuarter,
      DateTime FirstDayOfYear,
      DateTime LastDayOfYear,
      DateTime FirstDayOfNextMonth,
      DateTime FirstDayOfNextYear,
      int Original_DateKey)
    {
      return this.Update(Original_DateKey, Date, Day, DaySuffix, Weekday, WeekDayName, IsWeekend, IsHoliday, HolidayText, DOWInMonth, DayOfYear, WeekOfMonth, WeekOfYear, ISOWeekOfYear, Month, MonthName, Quarter, QuarterName, Year, MMYYYY, MonthYear, FirstDayOfMonth, LastDayOfMonth, FirstDayOfQuarter, LastDayOfQuarter, FirstDayOfYear, LastDayOfYear, FirstDayOfNextMonth, FirstDayOfNextYear, Original_DateKey);
    }
  }
}
