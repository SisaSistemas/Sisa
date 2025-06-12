// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_CotiDet
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
  [XmlRoot("SisaDev_CotiDet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_CotiDet : DataSet
  {
    private SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable tablesp_CargarCotizacionesReporteDetalles;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_CotiDet()
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
    protected SisaDev_CotiDet(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_CargarCotizacionesReporteDetalles)] != null)
            base.Tables.Add((DataTable) new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable(dataSet.Tables[nameof (sp_CargarCotizacionesReporteDetalles)]));
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
    public SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable sp_CargarCotizacionesReporteDetalles => this.tablesp_CargarCotizacionesReporteDetalles;

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
      SisaDev_CotiDet sisaDevCotiDet = (SisaDev_CotiDet) base.Clone();
      sisaDevCotiDet.InitVars();
      sisaDevCotiDet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevCotiDet;
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
        if (dataSet.Tables["sp_CargarCotizacionesReporteDetalles"] != null)
          base.Tables.Add((DataTable) new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable(dataSet.Tables["sp_CargarCotizacionesReporteDetalles"]));
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
      this.tablesp_CargarCotizacionesReporteDetalles = (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable) base.Tables["sp_CargarCotizacionesReporteDetalles"];
      if (!initTable || this.tablesp_CargarCotizacionesReporteDetalles == null)
        return;
      this.tablesp_CargarCotizacionesReporteDetalles.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_CotiDet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_CotiDet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_CargarCotizacionesReporteDetalles = new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable();
      base.Tables.Add((DataTable) this.tablesp_CargarCotizacionesReporteDetalles);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_CargarCotizacionesReporteDetalles() => false;

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
      SisaDev_CotiDet sisaDevCotiDet = new SisaDev_CotiDet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevCotiDet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevCotiDet.GetSchemaSerializable();
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
    public delegate void sp_CargarCotizacionesReporteDetallesRowChangeEventHandler(
      object sender,
      SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_CargarCotizacionesReporteDetallesDataTable : 
      TypedTableBase<SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow>
    {
      private DataColumn columnItem;
      private DataColumn columnDescripcion;
      private DataColumn columnCantidad;
      private DataColumn columnPrecio;
      private DataColumn columnImporte;
      private DataColumn columnUnidad;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesReporteDetallesDataTable()
      {
        this.TableName = "sp_CargarCotizacionesReporteDetalles";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesReporteDetallesDataTable(DataTable table)
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
      protected sp_CargarCotizacionesReporteDetallesDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ItemColumn => this.columnItem;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DescripcionColumn => this.columnDescripcion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CantidadColumn => this.columnCantidad;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PrecioColumn => this.columnPrecio;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ImporteColumn => this.columnImporte;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn UnidadColumn => this.columnUnidad;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow this[int index] => (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEventHandler sp_CargarCotizacionesReporteDetallesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEventHandler sp_CargarCotizacionesReporteDetallesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEventHandler sp_CargarCotizacionesReporteDetallesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEventHandler sp_CargarCotizacionesReporteDetallesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_CargarCotizacionesReporteDetallesRow(
        SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow Addsp_CargarCotizacionesReporteDetallesRow(
        long Item,
        string Descripcion,
        Decimal Cantidad,
        Decimal Precio,
        Decimal Importe,
        string Unidad)
      {
        SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow reporteDetallesRow = (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) this.NewRow();
        object[] objArray = new object[6]
        {
          (object) Item,
          (object) Descripcion,
          (object) Cantidad,
          (object) Precio,
          (object) Importe,
          (object) Unidad
        };
        reporteDetallesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) reporteDetallesRow);
        return reporteDetallesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable detallesDataTable = (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable) base.Clone();
        detallesDataTable.InitVars();
        return (DataTable) detallesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnItem = this.Columns["Item"];
        this.columnDescripcion = this.Columns["Descripcion"];
        this.columnCantidad = this.Columns["Cantidad"];
        this.columnPrecio = this.Columns["Precio"];
        this.columnImporte = this.Columns["Importe"];
        this.columnUnidad = this.Columns["Unidad"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnItem = new DataColumn("Item", typeof (long), (string) null, MappingType.Element);
        this.columnItem.ExtendedProperties.Add((object) "Generator_ColumnPropNameInRow", (object) "Item");
        this.columnItem.ExtendedProperties.Add((object) "Generator_ColumnPropNameInTable", (object) "ItemColumn");
        this.columnItem.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "columnItem");
        this.columnItem.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "Item");
        this.Columns.Add(this.columnItem);
        this.columnDescripcion = new DataColumn("Descripcion", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescripcion);
        this.columnCantidad = new DataColumn("Cantidad", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCantidad);
        this.columnPrecio = new DataColumn("Precio", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrecio);
        this.columnImporte = new DataColumn("Importe", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnImporte);
        this.columnUnidad = new DataColumn("Unidad", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUnidad);
        this.columnItem.ReadOnly = true;
        this.columnDescripcion.MaxLength = 150;
        this.columnUnidad.MaxLength = 50;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow Newsp_CargarCotizacionesReporteDetallesRow() => (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_CargarCotizacionesReporteDetallesRowChanged == null)
          return;
        this.sp_CargarCotizacionesReporteDetallesRowChanged((object) this, new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEvent((SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_CargarCotizacionesReporteDetallesRowChanging == null)
          return;
        this.sp_CargarCotizacionesReporteDetallesRowChanging((object) this, new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEvent((SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_CargarCotizacionesReporteDetallesRowDeleted == null)
          return;
        this.sp_CargarCotizacionesReporteDetallesRowDeleted((object) this, new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEvent((SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_CargarCotizacionesReporteDetallesRowDeleting == null)
          return;
        this.sp_CargarCotizacionesReporteDetallesRowDeleting((object) this, new SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRowChangeEvent((SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_CargarCotizacionesReporteDetallesRow(
        SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_CotiDet sisaDevCotiDet = new SisaDev_CotiDet();
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
          FixedValue = sisaDevCotiDet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_CargarCotizacionesReporteDetallesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevCotiDet.GetSchemaSerializable();
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

    public class sp_CargarCotizacionesReporteDetallesRow : DataRow
    {
      private SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable tablesp_CargarCotizacionesReporteDetalles;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesReporteDetallesRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_CargarCotizacionesReporteDetalles = (SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public long Item
      {
        get
        {
          try
          {
            return (long) this[this.tablesp_CargarCotizacionesReporteDetalles.ItemColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Item' de la tabla 'sp_CargarCotizacionesReporteDetalles' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteDetalles.ItemColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Descripcion
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizacionesReporteDetalles.DescripcionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Descripcion' de la tabla 'sp_CargarCotizacionesReporteDetalles' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteDetalles.DescripcionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Cantidad
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarCotizacionesReporteDetalles.CantidadColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Cantidad' de la tabla 'sp_CargarCotizacionesReporteDetalles' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteDetalles.CantidadColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Precio
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarCotizacionesReporteDetalles.PrecioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Precio' de la tabla 'sp_CargarCotizacionesReporteDetalles' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteDetalles.PrecioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Importe
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarCotizacionesReporteDetalles.ImporteColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Importe' de la tabla 'sp_CargarCotizacionesReporteDetalles' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteDetalles.ImporteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Unidad
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizacionesReporteDetalles.UnidadColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Unidad' de la tabla 'sp_CargarCotizacionesReporteDetalles' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteDetalles.UnidadColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsItemNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteDetalles.ItemColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetItemNull() => this[this.tablesp_CargarCotizacionesReporteDetalles.ItemColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescripcionNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteDetalles.DescripcionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescripcionNull() => this[this.tablesp_CargarCotizacionesReporteDetalles.DescripcionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCantidadNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteDetalles.CantidadColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCantidadNull() => this[this.tablesp_CargarCotizacionesReporteDetalles.CantidadColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrecioNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteDetalles.PrecioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrecioNull() => this[this.tablesp_CargarCotizacionesReporteDetalles.PrecioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsImporteNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteDetalles.ImporteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetImporteNull() => this[this.tablesp_CargarCotizacionesReporteDetalles.ImporteColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsUnidadNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteDetalles.UnidadColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetUnidadNull() => this[this.tablesp_CargarCotizacionesReporteDetalles.UnidadColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_CargarCotizacionesReporteDetallesRowChangeEvent : EventArgs
    {
      private SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesReporteDetallesRowChangeEvent(
        SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiDet.sp_CargarCotizacionesReporteDetallesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
