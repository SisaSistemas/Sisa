// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_FR
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
  [XmlRoot("SisaDev_FR")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_FR : DataSet
  {
    private SisaDev_FR.sp_CargarFacturasEmitidasDataTable tablesp_CargarFacturasEmitidas;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_FR()
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
    protected SisaDev_FR(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_CargarFacturasEmitidas)] != null)
            base.Tables.Add((DataTable) new SisaDev_FR.sp_CargarFacturasEmitidasDataTable(dataSet.Tables[nameof (sp_CargarFacturasEmitidas)]));
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
    public SisaDev_FR.sp_CargarFacturasEmitidasDataTable sp_CargarFacturasEmitidas => this.tablesp_CargarFacturasEmitidas;

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
      SisaDev_FR sisaDevFr = (SisaDev_FR) base.Clone();
      sisaDevFr.InitVars();
      sisaDevFr.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevFr;
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
        if (dataSet.Tables["sp_CargarFacturasEmitidas"] != null)
          base.Tables.Add((DataTable) new SisaDev_FR.sp_CargarFacturasEmitidasDataTable(dataSet.Tables["sp_CargarFacturasEmitidas"]));
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
      this.tablesp_CargarFacturasEmitidas = (SisaDev_FR.sp_CargarFacturasEmitidasDataTable) base.Tables["sp_CargarFacturasEmitidas"];
      if (!initTable || this.tablesp_CargarFacturasEmitidas == null)
        return;
      this.tablesp_CargarFacturasEmitidas.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_FR);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_FR.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_CargarFacturasEmitidas = new SisaDev_FR.sp_CargarFacturasEmitidasDataTable();
      base.Tables.Add((DataTable) this.tablesp_CargarFacturasEmitidas);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_CargarFacturasEmitidas() => false;

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
      SisaDev_FR sisaDevFr = new SisaDev_FR();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevFr.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevFr.GetSchemaSerializable();
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
    public delegate void sp_CargarFacturasEmitidasRowChangeEventHandler(
      object sender,
      SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_CargarFacturasEmitidasDataTable : 
      TypedTableBase<SisaDev_FR.sp_CargarFacturasEmitidasRow>
    {
      private DataColumn columnIdFacturasEmitidas;
      private DataColumn columnFolioFactura;
      private DataColumn columnFechaFactura;
      private DataColumn columnRfcReceptor;
      private DataColumn columnNombreReceptor;
      private DataColumn columnNombreProyecto;
      private DataColumn columnNoCotizacion;
      private DataColumn columnOrdenCompraRecibida;
      private DataColumn columnSubTotal;
      private DataColumn columnIva;
      private DataColumn columnRetencion;
      private DataColumn columnTotal;
      private DataColumn columnMoneda;
      private DataColumn columnProgramacionPago;
      private DataColumn columnPorPagar;
      private DataColumn columnFechaPago;
      private DataColumn columnEstatus;
      private DataColumn columnIdProyecto;
      private DataColumn columnProgramacionPago1;
      private DataColumn columnEstatus1;
      private DataColumn columnFechaFactura1;
      private DataColumn columnFechaPago1;
      private DataColumn columnNombreArchivo;
      private DataColumn columnArchivoPDF;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarFacturasEmitidasDataTable()
      {
        this.TableName = "sp_CargarFacturasEmitidas";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarFacturasEmitidasDataTable(DataTable table)
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
      protected sp_CargarFacturasEmitidasDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdFacturasEmitidasColumn => this.columnIdFacturasEmitidas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FolioFacturaColumn => this.columnFolioFactura;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaFacturaColumn => this.columnFechaFactura;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RfcReceptorColumn => this.columnRfcReceptor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreReceptorColumn => this.columnNombreReceptor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreProyectoColumn => this.columnNombreProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NoCotizacionColumn => this.columnNoCotizacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OrdenCompraRecibidaColumn => this.columnOrdenCompraRecibida;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SubTotalColumn => this.columnSubTotal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IvaColumn => this.columnIva;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RetencionColumn => this.columnRetencion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalColumn => this.columnTotal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MonedaColumn => this.columnMoneda;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ProgramacionPagoColumn => this.columnProgramacionPago;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PorPagarColumn => this.columnPorPagar;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaPagoColumn => this.columnFechaPago;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdProyectoColumn => this.columnIdProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ProgramacionPago1Column => this.columnProgramacionPago1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Estatus1Column => this.columnEstatus1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaFactura1Column => this.columnFechaFactura1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaPago1Column => this.columnFechaPago1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreArchivoColumn => this.columnNombreArchivo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ArchivoPDFColumn => this.columnArchivoPDF;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_FR.sp_CargarFacturasEmitidasRow this[int index] => (SisaDev_FR.sp_CargarFacturasEmitidasRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEventHandler sp_CargarFacturasEmitidasRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEventHandler sp_CargarFacturasEmitidasRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEventHandler sp_CargarFacturasEmitidasRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEventHandler sp_CargarFacturasEmitidasRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_CargarFacturasEmitidasRow(SisaDev_FR.sp_CargarFacturasEmitidasRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_FR.sp_CargarFacturasEmitidasRow Addsp_CargarFacturasEmitidasRow(
        Guid IdFacturasEmitidas,
        string FolioFactura,
        DateTime FechaFactura,
        string RfcReceptor,
        string NombreReceptor,
        string NombreProyecto,
        string NoCotizacion,
        string OrdenCompraRecibida,
        Decimal SubTotal,
        Decimal Iva,
        Decimal Retencion,
        Decimal Total,
        string Moneda,
        DateTime ProgramacionPago,
        Decimal PorPagar,
        DateTime FechaPago,
        int Estatus,
        string IdProyecto,
        string ProgramacionPago1,
        string Estatus1,
        string FechaFactura1,
        string FechaPago1,
        string NombreArchivo,
        string ArchivoPDF)
      {
        SisaDev_FR.sp_CargarFacturasEmitidasRow facturasEmitidasRow = (SisaDev_FR.sp_CargarFacturasEmitidasRow) this.NewRow();
        object[] objArray = new object[24]
        {
          (object) IdFacturasEmitidas,
          (object) FolioFactura,
          (object) FechaFactura,
          (object) RfcReceptor,
          (object) NombreReceptor,
          (object) NombreProyecto,
          (object) NoCotizacion,
          (object) OrdenCompraRecibida,
          (object) SubTotal,
          (object) Iva,
          (object) Retencion,
          (object) Total,
          (object) Moneda,
          (object) ProgramacionPago,
          (object) PorPagar,
          (object) FechaPago,
          (object) Estatus,
          (object) IdProyecto,
          (object) ProgramacionPago1,
          (object) Estatus1,
          (object) FechaFactura1,
          (object) FechaPago1,
          (object) NombreArchivo,
          (object) ArchivoPDF
        };
        facturasEmitidasRow.ItemArray = objArray;
        this.Rows.Add((DataRow) facturasEmitidasRow);
        return facturasEmitidasRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_FR.sp_CargarFacturasEmitidasRow FindByIdFacturasEmitidas(
        Guid IdFacturasEmitidas)
      {
        return (SisaDev_FR.sp_CargarFacturasEmitidasRow) this.Rows.Find(new object[1]
        {
          (object) IdFacturasEmitidas
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_FR.sp_CargarFacturasEmitidasDataTable emitidasDataTable = (SisaDev_FR.sp_CargarFacturasEmitidasDataTable) base.Clone();
        emitidasDataTable.InitVars();
        return (DataTable) emitidasDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_FR.sp_CargarFacturasEmitidasDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdFacturasEmitidas = this.Columns["IdFacturasEmitidas"];
        this.columnFolioFactura = this.Columns["FolioFactura"];
        this.columnFechaFactura = this.Columns["FechaFactura"];
        this.columnRfcReceptor = this.Columns["RfcReceptor"];
        this.columnNombreReceptor = this.Columns["NombreReceptor"];
        this.columnNombreProyecto = this.Columns["NombreProyecto"];
        this.columnNoCotizacion = this.Columns["NoCotizacion"];
        this.columnOrdenCompraRecibida = this.Columns["OrdenCompraRecibida"];
        this.columnSubTotal = this.Columns["SubTotal"];
        this.columnIva = this.Columns["Iva"];
        this.columnRetencion = this.Columns["Retencion"];
        this.columnTotal = this.Columns["Total"];
        this.columnMoneda = this.Columns["Moneda"];
        this.columnProgramacionPago = this.Columns["ProgramacionPago"];
        this.columnPorPagar = this.Columns["PorPagar"];
        this.columnFechaPago = this.Columns["FechaPago"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnIdProyecto = this.Columns["IdProyecto"];
        this.columnProgramacionPago1 = this.Columns["ProgramacionPago1"];
        this.columnEstatus1 = this.Columns["Estatus1"];
        this.columnFechaFactura1 = this.Columns["FechaFactura1"];
        this.columnFechaPago1 = this.Columns["FechaPago1"];
        this.columnNombreArchivo = this.Columns["NombreArchivo"];
        this.columnArchivoPDF = this.Columns["ArchivoPDF"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnIdFacturasEmitidas = new DataColumn("IdFacturasEmitidas", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdFacturasEmitidas);
        this.columnFolioFactura = new DataColumn("FolioFactura", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFolioFactura);
        this.columnFechaFactura = new DataColumn("FechaFactura", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaFactura);
        this.columnRfcReceptor = new DataColumn("RfcReceptor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRfcReceptor);
        this.columnNombreReceptor = new DataColumn("NombreReceptor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreReceptor);
        this.columnNombreProyecto = new DataColumn("NombreProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreProyecto);
        this.columnNoCotizacion = new DataColumn("NoCotizacion", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNoCotizacion);
        this.columnOrdenCompraRecibida = new DataColumn("OrdenCompraRecibida", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOrdenCompraRecibida);
        this.columnSubTotal = new DataColumn("SubTotal", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSubTotal);
        this.columnIva = new DataColumn("Iva", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIva);
        this.columnRetencion = new DataColumn("Retencion", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRetencion);
        this.columnTotal = new DataColumn("Total", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotal);
        this.columnMoneda = new DataColumn("Moneda", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMoneda);
        this.columnProgramacionPago = new DataColumn("ProgramacionPago", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnProgramacionPago);
        this.columnPorPagar = new DataColumn("PorPagar", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPorPagar);
        this.columnFechaPago = new DataColumn("FechaPago", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaPago);
        this.columnEstatus = new DataColumn("Estatus", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnIdProyecto = new DataColumn("IdProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdProyecto);
        this.columnProgramacionPago1 = new DataColumn("ProgramacionPago1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnProgramacionPago1);
        this.columnEstatus1 = new DataColumn("Estatus1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus1);
        this.columnFechaFactura1 = new DataColumn("FechaFactura1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaFactura1);
        this.columnFechaPago1 = new DataColumn("FechaPago1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaPago1);
        this.columnNombreArchivo = new DataColumn("NombreArchivo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreArchivo);
        this.columnArchivoPDF = new DataColumn("ArchivoPDF", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnArchivoPDF);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnIdFacturasEmitidas
        }, true));
        this.columnIdFacturasEmitidas.AllowDBNull = false;
        this.columnIdFacturasEmitidas.Unique = true;
        this.columnFolioFactura.AllowDBNull = false;
        this.columnFolioFactura.MaxLength = 50;
        this.columnFechaFactura.AllowDBNull = false;
        this.columnRfcReceptor.AllowDBNull = false;
        this.columnRfcReceptor.MaxLength = 100;
        this.columnNombreReceptor.AllowDBNull = false;
        this.columnNombreReceptor.MaxLength = 200;
        this.columnNombreProyecto.ReadOnly = true;
        this.columnNombreProyecto.MaxLength = 100;
        this.columnNoCotizacion.ReadOnly = true;
        this.columnNoCotizacion.MaxLength = 150;
        this.columnOrdenCompraRecibida.MaxLength = 100;
        this.columnSubTotal.AllowDBNull = false;
        this.columnIva.AllowDBNull = false;
        this.columnTotal.AllowDBNull = false;
        this.columnMoneda.AllowDBNull = false;
        this.columnMoneda.MaxLength = 50;
        this.columnProgramacionPago.ReadOnly = true;
        this.columnFechaPago.ReadOnly = true;
        this.columnEstatus.AllowDBNull = false;
        this.columnIdProyecto.ReadOnly = true;
        this.columnIdProyecto.MaxLength = 150;
        this.columnProgramacionPago1.ReadOnly = true;
        this.columnProgramacionPago1.MaxLength = 30;
        this.columnEstatus1.ReadOnly = true;
        this.columnEstatus1.MaxLength = 9;
        this.columnFechaFactura1.ReadOnly = true;
        this.columnFechaFactura1.MaxLength = 30;
        this.columnFechaPago1.ReadOnly = true;
        this.columnFechaPago1.MaxLength = 30;
        this.columnNombreArchivo.MaxLength = 150;
        this.columnArchivoPDF.MaxLength = int.MaxValue;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_FR.sp_CargarFacturasEmitidasRow Newsp_CargarFacturasEmitidasRow() => (SisaDev_FR.sp_CargarFacturasEmitidasRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_FR.sp_CargarFacturasEmitidasRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_FR.sp_CargarFacturasEmitidasRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_CargarFacturasEmitidasRowChanged == null)
          return;
        this.sp_CargarFacturasEmitidasRowChanged((object) this, new SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEvent((SisaDev_FR.sp_CargarFacturasEmitidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_CargarFacturasEmitidasRowChanging == null)
          return;
        this.sp_CargarFacturasEmitidasRowChanging((object) this, new SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEvent((SisaDev_FR.sp_CargarFacturasEmitidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_CargarFacturasEmitidasRowDeleted == null)
          return;
        this.sp_CargarFacturasEmitidasRowDeleted((object) this, new SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEvent((SisaDev_FR.sp_CargarFacturasEmitidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_CargarFacturasEmitidasRowDeleting == null)
          return;
        this.sp_CargarFacturasEmitidasRowDeleting((object) this, new SisaDev_FR.sp_CargarFacturasEmitidasRowChangeEvent((SisaDev_FR.sp_CargarFacturasEmitidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_CargarFacturasEmitidasRow(SisaDev_FR.sp_CargarFacturasEmitidasRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_FR sisaDevFr = new SisaDev_FR();
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
          FixedValue = sisaDevFr.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_CargarFacturasEmitidasDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevFr.GetSchemaSerializable();
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

    public class sp_CargarFacturasEmitidasRow : DataRow
    {
      private SisaDev_FR.sp_CargarFacturasEmitidasDataTable tablesp_CargarFacturasEmitidas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarFacturasEmitidasRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_CargarFacturasEmitidas = (SisaDev_FR.sp_CargarFacturasEmitidasDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdFacturasEmitidas
      {
        get => (Guid) this[this.tablesp_CargarFacturasEmitidas.IdFacturasEmitidasColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.IdFacturasEmitidasColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FolioFactura
      {
        get => (string) this[this.tablesp_CargarFacturasEmitidas.FolioFacturaColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.FolioFacturaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaFactura
      {
        get => (DateTime) this[this.tablesp_CargarFacturasEmitidas.FechaFacturaColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.FechaFacturaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RfcReceptor
      {
        get => (string) this[this.tablesp_CargarFacturasEmitidas.RfcReceptorColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.RfcReceptorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreReceptor
      {
        get => (string) this[this.tablesp_CargarFacturasEmitidas.NombreReceptorColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.NombreReceptorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.NombreProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreProyecto' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.NombreProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NoCotizacion
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.NoCotizacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NoCotizacion' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.NoCotizacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string OrdenCompraRecibida
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.OrdenCompraRecibidaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'OrdenCompraRecibida' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.OrdenCompraRecibidaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal SubTotal
      {
        get => (Decimal) this[this.tablesp_CargarFacturasEmitidas.SubTotalColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.SubTotalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Iva
      {
        get => (Decimal) this[this.tablesp_CargarFacturasEmitidas.IvaColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.IvaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Retencion
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarFacturasEmitidas.RetencionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Retencion' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.RetencionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Total
      {
        get => (Decimal) this[this.tablesp_CargarFacturasEmitidas.TotalColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.TotalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Moneda
      {
        get => (string) this[this.tablesp_CargarFacturasEmitidas.MonedaColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.MonedaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ProgramacionPago
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_CargarFacturasEmitidas.ProgramacionPagoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ProgramacionPago' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.ProgramacionPagoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal PorPagar
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarFacturasEmitidas.PorPagarColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'PorPagar' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.PorPagarColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaPago
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_CargarFacturasEmitidas.FechaPagoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaPago' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.FechaPagoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Estatus
      {
        get => (int) this[this.tablesp_CargarFacturasEmitidas.EstatusColumn];
        set => this[this.tablesp_CargarFacturasEmitidas.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string IdProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.IdProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdProyecto' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.IdProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ProgramacionPago1
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.ProgramacionPago1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ProgramacionPago1' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.ProgramacionPago1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Estatus1
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.Estatus1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Estatus1' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.Estatus1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FechaFactura1
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.FechaFactura1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaFactura1' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.FechaFactura1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FechaPago1
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.FechaPago1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaPago1' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.FechaPago1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreArchivo
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.NombreArchivoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreArchivo' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.NombreArchivoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ArchivoPDF
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasEmitidas.ArchivoPDFColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ArchivoPDF' de la tabla 'sp_CargarFacturasEmitidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasEmitidas.ArchivoPDFColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreProyectoNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.NombreProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreProyectoNull() => this[this.tablesp_CargarFacturasEmitidas.NombreProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNoCotizacionNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.NoCotizacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNoCotizacionNull() => this[this.tablesp_CargarFacturasEmitidas.NoCotizacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOrdenCompraRecibidaNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.OrdenCompraRecibidaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOrdenCompraRecibidaNull() => this[this.tablesp_CargarFacturasEmitidas.OrdenCompraRecibidaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRetencionNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.RetencionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRetencionNull() => this[this.tablesp_CargarFacturasEmitidas.RetencionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsProgramacionPagoNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.ProgramacionPagoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetProgramacionPagoNull() => this[this.tablesp_CargarFacturasEmitidas.ProgramacionPagoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPorPagarNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.PorPagarColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPorPagarNull() => this[this.tablesp_CargarFacturasEmitidas.PorPagarColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaPagoNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.FechaPagoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaPagoNull() => this[this.tablesp_CargarFacturasEmitidas.FechaPagoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdProyectoNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.IdProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdProyectoNull() => this[this.tablesp_CargarFacturasEmitidas.IdProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsProgramacionPago1Null() => this.IsNull(this.tablesp_CargarFacturasEmitidas.ProgramacionPago1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetProgramacionPago1Null() => this[this.tablesp_CargarFacturasEmitidas.ProgramacionPago1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatus1Null() => this.IsNull(this.tablesp_CargarFacturasEmitidas.Estatus1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatus1Null() => this[this.tablesp_CargarFacturasEmitidas.Estatus1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaFactura1Null() => this.IsNull(this.tablesp_CargarFacturasEmitidas.FechaFactura1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaFactura1Null() => this[this.tablesp_CargarFacturasEmitidas.FechaFactura1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaPago1Null() => this.IsNull(this.tablesp_CargarFacturasEmitidas.FechaPago1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaPago1Null() => this[this.tablesp_CargarFacturasEmitidas.FechaPago1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreArchivoNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.NombreArchivoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreArchivoNull() => this[this.tablesp_CargarFacturasEmitidas.NombreArchivoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsArchivoPDFNull() => this.IsNull(this.tablesp_CargarFacturasEmitidas.ArchivoPDFColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetArchivoPDFNull() => this[this.tablesp_CargarFacturasEmitidas.ArchivoPDFColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_CargarFacturasEmitidasRowChangeEvent : EventArgs
    {
      private SisaDev_FR.sp_CargarFacturasEmitidasRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarFacturasEmitidasRowChangeEvent(
        SisaDev_FR.sp_CargarFacturasEmitidasRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_FR.sp_CargarFacturasEmitidasRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
