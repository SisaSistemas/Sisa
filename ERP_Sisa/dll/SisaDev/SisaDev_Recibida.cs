// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_Recibida
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
  [XmlRoot("SisaDev_Recibida")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_Recibida : DataSet
  {
    private SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable tablesp_CargarFacturasRecibidas;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_Recibida()
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
    protected SisaDev_Recibida(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_CargarFacturasRecibidas)] != null)
            base.Tables.Add((DataTable) new SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable(dataSet.Tables[nameof (sp_CargarFacturasRecibidas)]));
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
    public SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable sp_CargarFacturasRecibidas => this.tablesp_CargarFacturasRecibidas;

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
      SisaDev_Recibida sisaDevRecibida = (SisaDev_Recibida) base.Clone();
      sisaDevRecibida.InitVars();
      sisaDevRecibida.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevRecibida;
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
        if (dataSet.Tables["sp_CargarFacturasRecibidas"] != null)
          base.Tables.Add((DataTable) new SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable(dataSet.Tables["sp_CargarFacturasRecibidas"]));
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
      this.tablesp_CargarFacturasRecibidas = (SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable) base.Tables["sp_CargarFacturasRecibidas"];
      if (!initTable || this.tablesp_CargarFacturasRecibidas == null)
        return;
      this.tablesp_CargarFacturasRecibidas.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_Recibida);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_Recibida.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_CargarFacturasRecibidas = new SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable();
      base.Tables.Add((DataTable) this.tablesp_CargarFacturasRecibidas);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_CargarFacturasRecibidas() => false;

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
      SisaDev_Recibida sisaDevRecibida = new SisaDev_Recibida();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevRecibida.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevRecibida.GetSchemaSerializable();
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
    public delegate void sp_CargarFacturasRecibidasRowChangeEventHandler(
      object sender,
      SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_CargarFacturasRecibidasDataTable : 
      TypedTableBase<SisaDev_Recibida.sp_CargarFacturasRecibidasRow>
    {
      private DataColumn columnIdControlFacturas;
      private DataColumn columnFechaFactura;
      private DataColumn columnIdProveedor;
      private DataColumn columnNoFactura;
      private DataColumn columnOrdenCompra;
      private DataColumn columnProyecto;
      private DataColumn columnMoneda;
      private DataColumn columnSubTotal;
      private DataColumn columnDescuento;
      private DataColumn columnIVA;
      private DataColumn columnTotal;
      private DataColumn columnEstatus;
      private DataColumn columnFormaPago;
      private DataColumn columnProveedor;
      private DataColumn columnIdOrdenCompra;
      private DataColumn columnIdProyecto;
      private DataColumn columnViaticos;
      private DataColumn columnFechaPago;
      private DataColumn columnNombreArchivo;
      private DataColumn columnCategoria;
      private DataColumn columnAnticipo;
      private DataColumn columnNotaCredito;
      private DataColumn columnAPagar;
      private DataColumn columnEstatusProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarFacturasRecibidasDataTable()
      {
        this.TableName = "sp_CargarFacturasRecibidas";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarFacturasRecibidasDataTable(DataTable table)
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
      protected sp_CargarFacturasRecibidasDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdControlFacturasColumn => this.columnIdControlFacturas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaFacturaColumn => this.columnFechaFactura;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdProveedorColumn => this.columnIdProveedor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NoFacturaColumn => this.columnNoFactura;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OrdenCompraColumn => this.columnOrdenCompra;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ProyectoColumn => this.columnProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MonedaColumn => this.columnMoneda;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SubTotalColumn => this.columnSubTotal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DescuentoColumn => this.columnDescuento;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IVAColumn => this.columnIVA;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalColumn => this.columnTotal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FormaPagoColumn => this.columnFormaPago;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ProveedorColumn => this.columnProveedor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdOrdenCompraColumn => this.columnIdOrdenCompra;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdProyectoColumn => this.columnIdProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ViaticosColumn => this.columnViaticos;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaPagoColumn => this.columnFechaPago;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreArchivoColumn => this.columnNombreArchivo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CategoriaColumn => this.columnCategoria;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn AnticipoColumn => this.columnAnticipo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NotaCreditoColumn => this.columnNotaCredito;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn APagarColumn => this.columnAPagar;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusProyectoColumn => this.columnEstatusProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Recibida.sp_CargarFacturasRecibidasRow this[int index] => (SisaDev_Recibida.sp_CargarFacturasRecibidasRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEventHandler sp_CargarFacturasRecibidasRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEventHandler sp_CargarFacturasRecibidasRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEventHandler sp_CargarFacturasRecibidasRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEventHandler sp_CargarFacturasRecibidasRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_CargarFacturasRecibidasRow(
        SisaDev_Recibida.sp_CargarFacturasRecibidasRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Recibida.sp_CargarFacturasRecibidasRow Addsp_CargarFacturasRecibidasRow(
        Guid IdControlFacturas,
        string FechaFactura,
        Guid IdProveedor,
        string NoFactura,
        string OrdenCompra,
        string Proyecto,
        string Moneda,
        Decimal SubTotal,
        Decimal Descuento,
        Decimal IVA,
        Decimal Total,
        int Estatus,
        string FormaPago,
        string Proveedor,
        string IdOrdenCompra,
        string IdProyecto,
        int Viaticos,
        string FechaPago,
        string NombreArchivo,
        string Categoria,
        Decimal Anticipo,
        Decimal NotaCredito,
        Decimal APagar,
        string EstatusProyecto)
      {
        SisaDev_Recibida.sp_CargarFacturasRecibidasRow facturasRecibidasRow = (SisaDev_Recibida.sp_CargarFacturasRecibidasRow) this.NewRow();
        object[] objArray = new object[24]
        {
          (object) IdControlFacturas,
          (object) FechaFactura,
          (object) IdProveedor,
          (object) NoFactura,
          (object) OrdenCompra,
          (object) Proyecto,
          (object) Moneda,
          (object) SubTotal,
          (object) Descuento,
          (object) IVA,
          (object) Total,
          (object) Estatus,
          (object) FormaPago,
          (object) Proveedor,
          (object) IdOrdenCompra,
          (object) IdProyecto,
          (object) Viaticos,
          (object) FechaPago,
          (object) NombreArchivo,
          (object) Categoria,
          (object) Anticipo,
          (object) NotaCredito,
          (object) APagar,
          (object) EstatusProyecto
        };
        facturasRecibidasRow.ItemArray = objArray;
        this.Rows.Add((DataRow) facturasRecibidasRow);
        return facturasRecibidasRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Recibida.sp_CargarFacturasRecibidasRow FindByIdControlFacturas(
        Guid IdControlFacturas)
      {
        return (SisaDev_Recibida.sp_CargarFacturasRecibidasRow) this.Rows.Find(new object[1]
        {
          (object) IdControlFacturas
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable recibidasDataTable = (SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable) base.Clone();
        recibidasDataTable.InitVars();
        return (DataTable) recibidasDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdControlFacturas = this.Columns["IdControlFacturas"];
        this.columnFechaFactura = this.Columns["FechaFactura"];
        this.columnIdProveedor = this.Columns["IdProveedor"];
        this.columnNoFactura = this.Columns["NoFactura"];
        this.columnOrdenCompra = this.Columns["OrdenCompra"];
        this.columnProyecto = this.Columns["Proyecto"];
        this.columnMoneda = this.Columns["Moneda"];
        this.columnSubTotal = this.Columns["SubTotal"];
        this.columnDescuento = this.Columns["Descuento"];
        this.columnIVA = this.Columns["IVA"];
        this.columnTotal = this.Columns["Total"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnFormaPago = this.Columns["FormaPago"];
        this.columnProveedor = this.Columns["Proveedor"];
        this.columnIdOrdenCompra = this.Columns["IdOrdenCompra"];
        this.columnIdProyecto = this.Columns["IdProyecto"];
        this.columnViaticos = this.Columns["Viaticos"];
        this.columnFechaPago = this.Columns["FechaPago"];
        this.columnNombreArchivo = this.Columns["NombreArchivo"];
        this.columnCategoria = this.Columns["Categoria"];
        this.columnAnticipo = this.Columns["Anticipo"];
        this.columnNotaCredito = this.Columns["NotaCredito"];
        this.columnAPagar = this.Columns["APagar"];
        this.columnEstatusProyecto = this.Columns["EstatusProyecto"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnIdControlFacturas = new DataColumn("IdControlFacturas", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdControlFacturas);
        this.columnFechaFactura = new DataColumn("FechaFactura", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaFactura);
        this.columnIdProveedor = new DataColumn("IdProveedor", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdProveedor);
        this.columnNoFactura = new DataColumn("NoFactura", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNoFactura);
        this.columnOrdenCompra = new DataColumn("OrdenCompra", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOrdenCompra);
        this.columnProyecto = new DataColumn("Proyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnProyecto);
        this.columnMoneda = new DataColumn("Moneda", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMoneda);
        this.columnSubTotal = new DataColumn("SubTotal", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSubTotal);
        this.columnDescuento = new DataColumn("Descuento", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescuento);
        this.columnIVA = new DataColumn("IVA", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIVA);
        this.columnTotal = new DataColumn("Total", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotal);
        this.columnEstatus = new DataColumn("Estatus", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnFormaPago = new DataColumn("FormaPago", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFormaPago);
        this.columnProveedor = new DataColumn("Proveedor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnProveedor);
        this.columnIdOrdenCompra = new DataColumn("IdOrdenCompra", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdOrdenCompra);
        this.columnIdProyecto = new DataColumn("IdProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdProyecto);
        this.columnViaticos = new DataColumn("Viaticos", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnViaticos);
        this.columnFechaPago = new DataColumn("FechaPago", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaPago);
        this.columnNombreArchivo = new DataColumn("NombreArchivo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreArchivo);
        this.columnCategoria = new DataColumn("Categoria", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCategoria);
        this.columnAnticipo = new DataColumn("Anticipo", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAnticipo);
        this.columnNotaCredito = new DataColumn("NotaCredito", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNotaCredito);
        this.columnAPagar = new DataColumn("APagar", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAPagar);
        this.columnEstatusProyecto = new DataColumn("EstatusProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatusProyecto);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnIdControlFacturas
        }, true));
        this.columnIdControlFacturas.AllowDBNull = false;
        this.columnIdControlFacturas.Unique = true;
        this.columnFechaFactura.ReadOnly = true;
        this.columnFechaFactura.MaxLength = 30;
        this.columnIdProveedor.AllowDBNull = false;
        this.columnNoFactura.AllowDBNull = false;
        this.columnNoFactura.MaxLength = 100;
        this.columnOrdenCompra.AllowDBNull = false;
        this.columnOrdenCompra.MaxLength = 100;
        this.columnProyecto.AllowDBNull = false;
        this.columnProyecto.MaxLength = 150;
        this.columnMoneda.AllowDBNull = false;
        this.columnMoneda.MaxLength = 50;
        this.columnSubTotal.AllowDBNull = false;
        this.columnDescuento.AllowDBNull = false;
        this.columnIVA.AllowDBNull = false;
        this.columnTotal.AllowDBNull = false;
        this.columnEstatus.AllowDBNull = false;
        this.columnFormaPago.AllowDBNull = false;
        this.columnFormaPago.MaxLength = 500;
        this.columnProveedor.AllowDBNull = false;
        this.columnProveedor.MaxLength = 300;
        this.columnIdOrdenCompra.ReadOnly = true;
        this.columnIdOrdenCompra.MaxLength = 1;
        this.columnIdProyecto.MaxLength = 150;
        this.columnFechaPago.ReadOnly = true;
        this.columnFechaPago.MaxLength = 30;
        this.columnNombreArchivo.MaxLength = 150;
        this.columnCategoria.MaxLength = 50;
        this.columnAPagar.ReadOnly = true;
        this.columnEstatusProyecto.ReadOnly = true;
        this.columnEstatusProyecto.MaxLength = 100;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Recibida.sp_CargarFacturasRecibidasRow Newsp_CargarFacturasRecibidasRow() => (SisaDev_Recibida.sp_CargarFacturasRecibidasRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Recibida.sp_CargarFacturasRecibidasRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Recibida.sp_CargarFacturasRecibidasRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_CargarFacturasRecibidasRowChanged == null)
          return;
        this.sp_CargarFacturasRecibidasRowChanged((object) this, new SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEvent((SisaDev_Recibida.sp_CargarFacturasRecibidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_CargarFacturasRecibidasRowChanging == null)
          return;
        this.sp_CargarFacturasRecibidasRowChanging((object) this, new SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEvent((SisaDev_Recibida.sp_CargarFacturasRecibidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_CargarFacturasRecibidasRowDeleted == null)
          return;
        this.sp_CargarFacturasRecibidasRowDeleted((object) this, new SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEvent((SisaDev_Recibida.sp_CargarFacturasRecibidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_CargarFacturasRecibidasRowDeleting == null)
          return;
        this.sp_CargarFacturasRecibidasRowDeleting((object) this, new SisaDev_Recibida.sp_CargarFacturasRecibidasRowChangeEvent((SisaDev_Recibida.sp_CargarFacturasRecibidasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_CargarFacturasRecibidasRow(
        SisaDev_Recibida.sp_CargarFacturasRecibidasRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Recibida sisaDevRecibida = new SisaDev_Recibida();
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
          FixedValue = sisaDevRecibida.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_CargarFacturasRecibidasDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevRecibida.GetSchemaSerializable();
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

    public class sp_CargarFacturasRecibidasRow : DataRow
    {
      private SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable tablesp_CargarFacturasRecibidas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarFacturasRecibidasRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_CargarFacturasRecibidas = (SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdControlFacturas
      {
        get => (Guid) this[this.tablesp_CargarFacturasRecibidas.IdControlFacturasColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.IdControlFacturasColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FechaFactura
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.FechaFacturaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaFactura' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.FechaFacturaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdProveedor
      {
        get => (Guid) this[this.tablesp_CargarFacturasRecibidas.IdProveedorColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.IdProveedorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NoFactura
      {
        get => (string) this[this.tablesp_CargarFacturasRecibidas.NoFacturaColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.NoFacturaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string OrdenCompra
      {
        get => (string) this[this.tablesp_CargarFacturasRecibidas.OrdenCompraColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.OrdenCompraColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Proyecto
      {
        get => (string) this[this.tablesp_CargarFacturasRecibidas.ProyectoColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.ProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Moneda
      {
        get => (string) this[this.tablesp_CargarFacturasRecibidas.MonedaColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.MonedaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal SubTotal
      {
        get => (Decimal) this[this.tablesp_CargarFacturasRecibidas.SubTotalColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.SubTotalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Descuento
      {
        get => (Decimal) this[this.tablesp_CargarFacturasRecibidas.DescuentoColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.DescuentoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal IVA
      {
        get => (Decimal) this[this.tablesp_CargarFacturasRecibidas.IVAColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.IVAColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Total
      {
        get => (Decimal) this[this.tablesp_CargarFacturasRecibidas.TotalColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.TotalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Estatus
      {
        get => (int) this[this.tablesp_CargarFacturasRecibidas.EstatusColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FormaPago
      {
        get => (string) this[this.tablesp_CargarFacturasRecibidas.FormaPagoColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.FormaPagoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Proveedor
      {
        get => (string) this[this.tablesp_CargarFacturasRecibidas.ProveedorColumn];
        set => this[this.tablesp_CargarFacturasRecibidas.ProveedorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string IdOrdenCompra
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.IdOrdenCompraColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdOrdenCompra' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.IdOrdenCompraColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string IdProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.IdProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdProyecto' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.IdProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Viaticos
      {
        get
        {
          try
          {
            return (int) this[this.tablesp_CargarFacturasRecibidas.ViaticosColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Viaticos' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.ViaticosColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FechaPago
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.FechaPagoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaPago' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.FechaPagoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreArchivo
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.NombreArchivoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreArchivo' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.NombreArchivoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Categoria
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.CategoriaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Categoria' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.CategoriaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Anticipo
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarFacturasRecibidas.AnticipoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Anticipo' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.AnticipoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal NotaCredito
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarFacturasRecibidas.NotaCreditoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NotaCredito' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.NotaCreditoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal APagar
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarFacturasRecibidas.APagarColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'APagar' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.APagarColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string EstatusProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarFacturasRecibidas.EstatusProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'EstatusProyecto' de la tabla 'sp_CargarFacturasRecibidas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarFacturasRecibidas.EstatusProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaFacturaNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.FechaFacturaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaFacturaNull() => this[this.tablesp_CargarFacturasRecibidas.FechaFacturaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdOrdenCompraNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.IdOrdenCompraColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdOrdenCompraNull() => this[this.tablesp_CargarFacturasRecibidas.IdOrdenCompraColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdProyectoNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.IdProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdProyectoNull() => this[this.tablesp_CargarFacturasRecibidas.IdProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsViaticosNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.ViaticosColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetViaticosNull() => this[this.tablesp_CargarFacturasRecibidas.ViaticosColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaPagoNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.FechaPagoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaPagoNull() => this[this.tablesp_CargarFacturasRecibidas.FechaPagoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreArchivoNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.NombreArchivoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreArchivoNull() => this[this.tablesp_CargarFacturasRecibidas.NombreArchivoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCategoriaNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.CategoriaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCategoriaNull() => this[this.tablesp_CargarFacturasRecibidas.CategoriaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsAnticipoNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.AnticipoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetAnticipoNull() => this[this.tablesp_CargarFacturasRecibidas.AnticipoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNotaCreditoNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.NotaCreditoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNotaCreditoNull() => this[this.tablesp_CargarFacturasRecibidas.NotaCreditoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsAPagarNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.APagarColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetAPagarNull() => this[this.tablesp_CargarFacturasRecibidas.APagarColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusProyectoNull() => this.IsNull(this.tablesp_CargarFacturasRecibidas.EstatusProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusProyectoNull() => this[this.tablesp_CargarFacturasRecibidas.EstatusProyectoColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_CargarFacturasRecibidasRowChangeEvent : EventArgs
    {
      private SisaDev_Recibida.sp_CargarFacturasRecibidasRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarFacturasRecibidasRowChangeEvent(
        SisaDev_Recibida.sp_CargarFacturasRecibidasRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Recibida.sp_CargarFacturasRecibidasRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
