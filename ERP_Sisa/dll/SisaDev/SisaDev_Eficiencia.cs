// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_Eficiencia
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SisaDev
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [XmlRoot("SisaDev_Eficiencia")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_Eficiencia : DataSet
  {
    private SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable tablesp_ReporteProyectosEficienciasVistas;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_Eficiencia()
    {
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected SisaDev_Eficiencia(SerializationInfo info, StreamingContext context)
      : base(info, context, false)
    {
      if (this.IsBinarySerialized(info, context))
      {
        this.InitVars(false);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
      else
      {
        string s = (string) info.GetValue("XmlSchema", typeof (string));
        if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
        {
          DataSet dataSet = new DataSet();
          dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
          if (dataSet.Tables[nameof (sp_ReporteProyectosEficienciasVistas)] != null)
            base.Tables.Add((DataTable) new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable(dataSet.Tables[nameof (sp_ReporteProyectosEficienciasVistas)]));
          this.DataSetName = dataSet.DataSetName;
          this.Prefix = dataSet.Prefix;
          this.Namespace = dataSet.Namespace;
          this.Locale = dataSet.Locale;
          this.CaseSensitive = dataSet.CaseSensitive;
          this.EnforceConstraints = dataSet.EnforceConstraints;
          this.Merge(dataSet, false, MissingSchemaAction.Add);
          this.InitVars();
        }
        else
          this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        this.GetSerializationData(info, context);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable sp_ReporteProyectosEficienciasVistas => this.tablesp_ReporteProyectosEficienciasVistas;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get => this._schemaSerializationMode;
      set => this._schemaSerializationMode = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables => base.Tables;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations => base.Relations;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public override DataSet Clone()
    {
      SisaDev_Eficiencia sisaDevEficiencia = (SisaDev_Eficiencia) base.Clone();
      sisaDevEficiencia.InitVars();
      sisaDevEficiencia.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevEficiencia;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override bool ShouldSerializeTables() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override bool ShouldSerializeRelations() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["sp_ReporteProyectosEficienciasVistas"] != null)
          base.Tables.Add((DataTable) new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable(dataSet.Tables["sp_ReporteProyectosEficienciasVistas"]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
      {
        int num = (int) this.ReadXml(reader);
        this.InitVars();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal void InitVars() => this.InitVars(true);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal void InitVars(bool initTable)
    {
      this.tablesp_ReporteProyectosEficienciasVistas = (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable) base.Tables["sp_ReporteProyectosEficienciasVistas"];
      if (!initTable || this.tablesp_ReporteProyectosEficienciasVistas == null)
        return;
      this.tablesp_ReporteProyectosEficienciasVistas.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_Eficiencia);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_Eficiencia.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_ReporteProyectosEficienciasVistas = new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable();
      base.Tables.Add((DataTable) this.tablesp_ReporteProyectosEficienciasVistas);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_ReporteProyectosEficienciasVistas() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      SisaDev_Eficiencia sisaDevEficiencia = new SisaDev_Eficiencia();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevEficiencia.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevEficiencia.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            current.Write((Stream) memoryStream2);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return schemaComplexType;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return schemaComplexType;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void sp_ReporteProyectosEficienciasVistasRowChangeEventHandler(
      object sender,
      SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_ReporteProyectosEficienciasVistasDataTable : 
      TypedTableBase<SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow>
    {
      private DataColumn columnIdProyecto;
      private DataColumn columnNombreProyecto;
      private DataColumn columnGastos;
      private DataColumn columnProyeccion;
      private DataColumn columnSucursal;
      private DataColumn columnFolioProyecto;
      private DataColumn columnEstatus;
      private DataColumn columnResultado;
      private DataColumn columnCotizaco;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_ReporteProyectosEficienciasVistasDataTable()
      {
        this.TableName = "sp_ReporteProyectosEficienciasVistas";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_ReporteProyectosEficienciasVistasDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected sp_ReporteProyectosEficienciasVistasDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdProyectoColumn => this.columnIdProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreProyectoColumn => this.columnNombreProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GastosColumn => this.columnGastos;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ProyeccionColumn => this.columnProyeccion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SucursalColumn => this.columnSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FolioProyectoColumn => this.columnFolioProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ResultadoColumn => this.columnResultado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CotizacoColumn => this.columnCotizaco;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow this[
        int index]
      {
        return (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) this.Rows[index];
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEventHandler sp_ReporteProyectosEficienciasVistasRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEventHandler sp_ReporteProyectosEficienciasVistasRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEventHandler sp_ReporteProyectosEficienciasVistasRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEventHandler sp_ReporteProyectosEficienciasVistasRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_ReporteProyectosEficienciasVistasRow(
        SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow Addsp_ReporteProyectosEficienciasVistasRow(
        Guid IdProyecto,
        string NombreProyecto,
        Decimal Gastos,
        Decimal Proyeccion,
        string Sucursal,
        string FolioProyecto,
        string Estatus,
        Decimal Resultado,
        Decimal Cotizaco)
      {
        SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow eficienciasVistasRow = (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) this.NewRow();
        object[] objArray = new object[9]
        {
          (object) IdProyecto,
          (object) NombreProyecto,
          (object) Gastos,
          (object) Proyeccion,
          (object) Sucursal,
          (object) FolioProyecto,
          (object) Estatus,
          (object) Resultado,
          (object) Cotizaco
        };
        eficienciasVistasRow.ItemArray = objArray;
        this.Rows.Add((DataRow) eficienciasVistasRow);
        return eficienciasVistasRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable eficienciasVistasDataTable = (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable) base.Clone();
        eficienciasVistasDataTable.InitVars();
        return (DataTable) eficienciasVistasDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdProyecto = this.Columns["IdProyecto"];
        this.columnNombreProyecto = this.Columns["NombreProyecto"];
        this.columnGastos = this.Columns["Gastos"];
        this.columnProyeccion = this.Columns["Proyeccion"];
        this.columnSucursal = this.Columns["Sucursal"];
        this.columnFolioProyecto = this.Columns["FolioProyecto"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnResultado = this.Columns["Resultado"];
        this.columnCotizaco = this.Columns["Cotizaco"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnIdProyecto = new DataColumn("IdProyecto", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdProyecto);
        this.columnNombreProyecto = new DataColumn("NombreProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreProyecto);
        this.columnGastos = new DataColumn("Gastos", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGastos);
        this.columnProyeccion = new DataColumn("Proyeccion", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnProyeccion);
        this.columnSucursal = new DataColumn("Sucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSucursal);
        this.columnFolioProyecto = new DataColumn("FolioProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFolioProyecto);
        this.columnEstatus = new DataColumn("Estatus", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnResultado = new DataColumn("Resultado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnResultado);
        this.columnCotizaco = new DataColumn("Cotizaco", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCotizaco);
        this.columnIdProyecto.AllowDBNull = false;
        this.columnNombreProyecto.MaxLength = 100;
        this.columnSucursal.MaxLength = 100;
        this.columnFolioProyecto.MaxLength = 100;
        this.columnEstatus.MaxLength = 50;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow Newsp_ReporteProyectosEficienciasVistasRow() => (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_ReporteProyectosEficienciasVistasRowChanged == null)
          return;
        this.sp_ReporteProyectosEficienciasVistasRowChanged((object) this, new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEvent((SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_ReporteProyectosEficienciasVistasRowChanging == null)
          return;
        this.sp_ReporteProyectosEficienciasVistasRowChanging((object) this, new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEvent((SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_ReporteProyectosEficienciasVistasRowDeleted == null)
          return;
        this.sp_ReporteProyectosEficienciasVistasRowDeleted((object) this, new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEvent((SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_ReporteProyectosEficienciasVistasRowDeleting == null)
          return;
        this.sp_ReporteProyectosEficienciasVistasRowDeleting((object) this, new SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRowChangeEvent((SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_ReporteProyectosEficienciasVistasRow(
        SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Eficiencia sisaDevEficiencia = new SisaDev_Eficiencia();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = 0M;
        xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = 1M;
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = sisaDevEficiencia.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_ReporteProyectosEficienciasVistasDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevEficiencia.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    public class sp_ReporteProyectosEficienciasVistasRow : DataRow
    {
      private SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable tablesp_ReporteProyectosEficienciasVistas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_ReporteProyectosEficienciasVistasRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_ReporteProyectosEficienciasVistas = (SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdProyecto
      {
        get => (Guid) this[this.tablesp_ReporteProyectosEficienciasVistas.IdProyectoColumn];
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.IdProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosEficienciasVistas.NombreProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreProyecto' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.NombreProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Gastos
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosEficienciasVistas.GastosColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Gastos' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.GastosColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Proyeccion
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosEficienciasVistas.ProyeccionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Proyeccion' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.ProyeccionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Sucursal
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosEficienciasVistas.SucursalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Sucursal' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.SucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FolioProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosEficienciasVistas.FolioProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FolioProyecto' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.FolioProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Estatus
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosEficienciasVistas.EstatusColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Estatus' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Resultado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosEficienciasVistas.ResultadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Resultado' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.ResultadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Cotizaco
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosEficienciasVistas.CotizacoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Cotizaco' de la tabla 'sp_ReporteProyectosEficienciasVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosEficienciasVistas.CotizacoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreProyectoNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.NombreProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreProyectoNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.NombreProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGastosNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.GastosColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGastosNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.GastosColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsProyeccionNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.ProyeccionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetProyeccionNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.ProyeccionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSucursalNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.SucursalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSucursalNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.SucursalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFolioProyectoNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.FolioProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFolioProyectoNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.FolioProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.EstatusColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.EstatusColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsResultadoNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.ResultadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetResultadoNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.ResultadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCotizacoNull() => this.IsNull(this.tablesp_ReporteProyectosEficienciasVistas.CotizacoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCotizacoNull() => this[this.tablesp_ReporteProyectosEficienciasVistas.CotizacoColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_ReporteProyectosEficienciasVistasRowChangeEvent : EventArgs
    {
      private SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_ReporteProyectosEficienciasVistasRowChangeEvent(
        SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Eficiencia.sp_ReporteProyectosEficienciasVistasRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
