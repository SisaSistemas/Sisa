// Decompiled with JetBrains decompiler
// Type: SisaDev._SisaAdmin_CopiaDataSet
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
  [XmlRoot("_SisaAdmin_CopiaDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class _SisaAdmin_CopiaDataSet : DataSet
  {
    private _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable tablesp_LoadOrdenCompra;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public _SisaAdmin_CopiaDataSet()
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
    protected _SisaAdmin_CopiaDataSet(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_LoadOrdenCompra)] != null)
            base.Tables.Add((DataTable) new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable(dataSet.Tables[nameof (sp_LoadOrdenCompra)]));
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
    public _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable sp_LoadOrdenCompra => this.tablesp_LoadOrdenCompra;

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
      _SisaAdmin_CopiaDataSet adminCopiaDataSet = (_SisaAdmin_CopiaDataSet) base.Clone();
      adminCopiaDataSet.InitVars();
      adminCopiaDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) adminCopiaDataSet;
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
        if (dataSet.Tables["sp_LoadOrdenCompra"] != null)
          base.Tables.Add((DataTable) new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable(dataSet.Tables["sp_LoadOrdenCompra"]));
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
      this.tablesp_LoadOrdenCompra = (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable) base.Tables["sp_LoadOrdenCompra"];
      if (!initTable || this.tablesp_LoadOrdenCompra == null)
        return;
      this.tablesp_LoadOrdenCompra.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (_SisaAdmin_CopiaDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/_SisaAdmin_CopiaDataSet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_LoadOrdenCompra = new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable();
      base.Tables.Add((DataTable) this.tablesp_LoadOrdenCompra);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_LoadOrdenCompra() => false;

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
      _SisaAdmin_CopiaDataSet adminCopiaDataSet = new _SisaAdmin_CopiaDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = adminCopiaDataSet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = adminCopiaDataSet.GetSchemaSerializable();
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
    public delegate void sp_LoadOrdenCompraRowChangeEventHandler(
      object sender,
      _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_LoadOrdenCompraDataTable : 
      TypedTableBase<_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow>
    {
      private DataColumn columnIdOrdenCompra;
      private DataColumn columnFolio;
      private DataColumn columnProveedor;
      private DataColumn columnNombreComercial;
      private DataColumn columnReferenciaCot;
      private DataColumn columnNombreProyecto;
      private DataColumn columnPedidoPor;
      private DataColumn columnSubTotal;
      private DataColumn columnIva;
      private DataColumn columnTotal;
      private DataColumn columnEnviada;
      private DataColumn columnEstatus;
      private DataColumn columnFechaModificacion;
      private DataColumn columnUsuarioModifico;
      private DataColumn columnMoneda;
      private DataColumn columnEmail;
      private DataColumn columnFechaCreacion;
      private DataColumn columnNoFactura;
      private DataColumn columnEstatusFactura;
      private DataColumn columnidSucursal;
      private DataColumn columnCiudadSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_LoadOrdenCompraDataTable()
      {
        this.TableName = "sp_LoadOrdenCompra";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_LoadOrdenCompraDataTable(DataTable table)
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
      protected sp_LoadOrdenCompraDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdOrdenCompraColumn => this.columnIdOrdenCompra;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FolioColumn => this.columnFolio;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ProveedorColumn => this.columnProveedor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreComercialColumn => this.columnNombreComercial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReferenciaCotColumn => this.columnReferenciaCot;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreProyectoColumn => this.columnNombreProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PedidoPorColumn => this.columnPedidoPor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SubTotalColumn => this.columnSubTotal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IvaColumn => this.columnIva;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalColumn => this.columnTotal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EnviadaColumn => this.columnEnviada;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaModificacionColumn => this.columnFechaModificacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn UsuarioModificoColumn => this.columnUsuarioModifico;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MonedaColumn => this.columnMoneda;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EmailColumn => this.columnEmail;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaCreacionColumn => this.columnFechaCreacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NoFacturaColumn => this.columnNoFactura;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusFacturaColumn => this.columnEstatusFactura;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn idSucursalColumn => this.columnidSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CiudadSucursalColumn => this.columnCiudadSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow this[int index] => (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEventHandler sp_LoadOrdenCompraRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEventHandler sp_LoadOrdenCompraRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEventHandler sp_LoadOrdenCompraRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEventHandler sp_LoadOrdenCompraRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_LoadOrdenCompraRow(_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow Addsp_LoadOrdenCompraRow(
        Guid IdOrdenCompra,
        string Folio,
        string Proveedor,
        string NombreComercial,
        string ReferenciaCot,
        string NombreProyecto,
        string PedidoPor,
        Decimal SubTotal,
        Decimal Iva,
        Decimal Total,
        int Enviada,
        int Estatus,
        DateTime FechaModificacion,
        string UsuarioModifico,
        string Moneda,
        string Email,
        DateTime FechaCreacion,
        string NoFactura,
        int EstatusFactura,
        Guid idSucursal,
        string CiudadSucursal)
      {
        _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow loadOrdenCompraRow = (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) this.NewRow();
        object[] objArray = new object[21]
        {
          (object) IdOrdenCompra,
          (object) Folio,
          (object) Proveedor,
          (object) NombreComercial,
          (object) ReferenciaCot,
          (object) NombreProyecto,
          (object) PedidoPor,
          (object) SubTotal,
          (object) Iva,
          (object) Total,
          (object) Enviada,
          (object) Estatus,
          (object) FechaModificacion,
          (object) UsuarioModifico,
          (object) Moneda,
          (object) Email,
          (object) FechaCreacion,
          (object) NoFactura,
          (object) EstatusFactura,
          (object) idSucursal,
          (object) CiudadSucursal
        };
        loadOrdenCompraRow.ItemArray = objArray;
        this.Rows.Add((DataRow) loadOrdenCompraRow);
        return loadOrdenCompraRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable ordenCompraDataTable = (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable) base.Clone();
        ordenCompraDataTable.InitVars();
        return (DataTable) ordenCompraDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdOrdenCompra = this.Columns["IdOrdenCompra"];
        this.columnFolio = this.Columns["Folio"];
        this.columnProveedor = this.Columns["Proveedor"];
        this.columnNombreComercial = this.Columns["NombreComercial"];
        this.columnReferenciaCot = this.Columns["ReferenciaCot"];
        this.columnNombreProyecto = this.Columns["NombreProyecto"];
        this.columnPedidoPor = this.Columns["PedidoPor"];
        this.columnSubTotal = this.Columns["SubTotal"];
        this.columnIva = this.Columns["Iva"];
        this.columnTotal = this.Columns["Total"];
        this.columnEnviada = this.Columns["Enviada"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnFechaModificacion = this.Columns["FechaModificacion"];
        this.columnUsuarioModifico = this.Columns["UsuarioModifico"];
        this.columnMoneda = this.Columns["Moneda"];
        this.columnEmail = this.Columns["Email"];
        this.columnFechaCreacion = this.Columns["FechaCreacion"];
        this.columnNoFactura = this.Columns["NoFactura"];
        this.columnEstatusFactura = this.Columns["EstatusFactura"];
        this.columnidSucursal = this.Columns["idSucursal"];
        this.columnCiudadSucursal = this.Columns["CiudadSucursal"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnIdOrdenCompra = new DataColumn("IdOrdenCompra", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdOrdenCompra);
        this.columnFolio = new DataColumn("Folio", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFolio);
        this.columnProveedor = new DataColumn("Proveedor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnProveedor);
        this.columnNombreComercial = new DataColumn("NombreComercial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreComercial);
        this.columnReferenciaCot = new DataColumn("ReferenciaCot", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReferenciaCot);
        this.columnNombreProyecto = new DataColumn("NombreProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreProyecto);
        this.columnPedidoPor = new DataColumn("PedidoPor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPedidoPor);
        this.columnSubTotal = new DataColumn("SubTotal", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSubTotal);
        this.columnIva = new DataColumn("Iva", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIva);
        this.columnTotal = new DataColumn("Total", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotal);
        this.columnEnviada = new DataColumn("Enviada", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEnviada);
        this.columnEstatus = new DataColumn("Estatus", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnFechaModificacion = new DataColumn("FechaModificacion", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaModificacion);
        this.columnUsuarioModifico = new DataColumn("UsuarioModifico", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUsuarioModifico);
        this.columnMoneda = new DataColumn("Moneda", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMoneda);
        this.columnEmail = new DataColumn("Email", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmail);
        this.columnFechaCreacion = new DataColumn("FechaCreacion", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaCreacion);
        this.columnNoFactura = new DataColumn("NoFactura", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNoFactura);
        this.columnEstatusFactura = new DataColumn("EstatusFactura", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatusFactura);
        this.columnidSucursal = new DataColumn("idSucursal", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnidSucursal);
        this.columnCiudadSucursal = new DataColumn("CiudadSucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCiudadSucursal);
        this.columnIdOrdenCompra.ReadOnly = true;
        this.columnFolio.ReadOnly = true;
        this.columnFolio.MaxLength = 50;
        this.columnProveedor.ReadOnly = true;
        this.columnProveedor.MaxLength = 300;
        this.columnNombreComercial.ReadOnly = true;
        this.columnNombreComercial.MaxLength = 150;
        this.columnReferenciaCot.ReadOnly = true;
        this.columnReferenciaCot.MaxLength = 200;
        this.columnNombreProyecto.ReadOnly = true;
        this.columnNombreProyecto.MaxLength = 200;
        this.columnPedidoPor.ReadOnly = true;
        this.columnPedidoPor.MaxLength = 100;
        this.columnSubTotal.ReadOnly = true;
        this.columnIva.ReadOnly = true;
        this.columnTotal.ReadOnly = true;
        this.columnEnviada.ReadOnly = true;
        this.columnEstatus.ReadOnly = true;
        this.columnFechaModificacion.ReadOnly = true;
        this.columnUsuarioModifico.ReadOnly = true;
        this.columnUsuarioModifico.MaxLength = 100;
        this.columnMoneda.ReadOnly = true;
        this.columnMoneda.MaxLength = 150;
        this.columnEmail.ReadOnly = true;
        this.columnEmail.MaxLength = 150;
        this.columnFechaCreacion.ReadOnly = true;
        this.columnNoFactura.ReadOnly = true;
        this.columnNoFactura.MaxLength = 100;
        this.columnEstatusFactura.ReadOnly = true;
        this.columnidSucursal.ReadOnly = true;
        this.columnCiudadSucursal.ReadOnly = true;
        this.columnCiudadSucursal.MaxLength = 50;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow Newsp_LoadOrdenCompraRow() => (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_LoadOrdenCompraRowChanged == null)
          return;
        this.sp_LoadOrdenCompraRowChanged((object) this, new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEvent((_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_LoadOrdenCompraRowChanging == null)
          return;
        this.sp_LoadOrdenCompraRowChanging((object) this, new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEvent((_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_LoadOrdenCompraRowDeleted == null)
          return;
        this.sp_LoadOrdenCompraRowDeleted((object) this, new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEvent((_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_LoadOrdenCompraRowDeleting == null)
          return;
        this.sp_LoadOrdenCompraRowDeleting((object) this, new _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRowChangeEvent((_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_LoadOrdenCompraRow(_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        _SisaAdmin_CopiaDataSet adminCopiaDataSet = new _SisaAdmin_CopiaDataSet();
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
          FixedValue = adminCopiaDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_LoadOrdenCompraDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = adminCopiaDataSet.GetSchemaSerializable();
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

    public class sp_LoadOrdenCompraRow : DataRow
    {
      private _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable tablesp_LoadOrdenCompra;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_LoadOrdenCompraRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_LoadOrdenCompra = (_SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdOrdenCompra
      {
        get
        {
          try
          {
            return (Guid) this[this.tablesp_LoadOrdenCompra.IdOrdenCompraColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdOrdenCompra' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.IdOrdenCompraColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Folio
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.FolioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Folio' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.FolioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Proveedor
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.ProveedorColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Proveedor' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.ProveedorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreComercial
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.NombreComercialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreComercial' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.NombreComercialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ReferenciaCot
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.ReferenciaCotColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ReferenciaCot' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.ReferenciaCotColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.NombreProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreProyecto' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.NombreProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string PedidoPor
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.PedidoPorColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'PedidoPor' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.PedidoPorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal SubTotal
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_LoadOrdenCompra.SubTotalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'SubTotal' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.SubTotalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Iva
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_LoadOrdenCompra.IvaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Iva' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.IvaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Total
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_LoadOrdenCompra.TotalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Total' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.TotalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Enviada
      {
        get
        {
          try
          {
            return (int) this[this.tablesp_LoadOrdenCompra.EnviadaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Enviada' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.EnviadaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Estatus
      {
        get
        {
          try
          {
            return (int) this[this.tablesp_LoadOrdenCompra.EstatusColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Estatus' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaModificacion
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_LoadOrdenCompra.FechaModificacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaModificacion' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.FechaModificacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string UsuarioModifico
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.UsuarioModificoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'UsuarioModifico' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.UsuarioModificoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Moneda
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.MonedaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Moneda' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.MonedaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Email
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.EmailColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Email' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.EmailColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaCreacion
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_LoadOrdenCompra.FechaCreacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaCreacion' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.FechaCreacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NoFactura
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.NoFacturaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NoFactura' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.NoFacturaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int EstatusFactura
      {
        get
        {
          try
          {
            return (int) this[this.tablesp_LoadOrdenCompra.EstatusFacturaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'EstatusFactura' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.EstatusFacturaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid idSucursal
      {
        get
        {
          try
          {
            return (Guid) this[this.tablesp_LoadOrdenCompra.idSucursalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'idSucursal' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.idSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CiudadSucursal
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_LoadOrdenCompra.CiudadSucursalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CiudadSucursal' de la tabla 'sp_LoadOrdenCompra' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_LoadOrdenCompra.CiudadSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdOrdenCompraNull() => this.IsNull(this.tablesp_LoadOrdenCompra.IdOrdenCompraColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdOrdenCompraNull() => this[this.tablesp_LoadOrdenCompra.IdOrdenCompraColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFolioNull() => this.IsNull(this.tablesp_LoadOrdenCompra.FolioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFolioNull() => this[this.tablesp_LoadOrdenCompra.FolioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsProveedorNull() => this.IsNull(this.tablesp_LoadOrdenCompra.ProveedorColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetProveedorNull() => this[this.tablesp_LoadOrdenCompra.ProveedorColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreComercialNull() => this.IsNull(this.tablesp_LoadOrdenCompra.NombreComercialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreComercialNull() => this[this.tablesp_LoadOrdenCompra.NombreComercialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReferenciaCotNull() => this.IsNull(this.tablesp_LoadOrdenCompra.ReferenciaCotColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReferenciaCotNull() => this[this.tablesp_LoadOrdenCompra.ReferenciaCotColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreProyectoNull() => this.IsNull(this.tablesp_LoadOrdenCompra.NombreProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreProyectoNull() => this[this.tablesp_LoadOrdenCompra.NombreProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPedidoPorNull() => this.IsNull(this.tablesp_LoadOrdenCompra.PedidoPorColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPedidoPorNull() => this[this.tablesp_LoadOrdenCompra.PedidoPorColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSubTotalNull() => this.IsNull(this.tablesp_LoadOrdenCompra.SubTotalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSubTotalNull() => this[this.tablesp_LoadOrdenCompra.SubTotalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIvaNull() => this.IsNull(this.tablesp_LoadOrdenCompra.IvaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIvaNull() => this[this.tablesp_LoadOrdenCompra.IvaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalNull() => this.IsNull(this.tablesp_LoadOrdenCompra.TotalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalNull() => this[this.tablesp_LoadOrdenCompra.TotalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEnviadaNull() => this.IsNull(this.tablesp_LoadOrdenCompra.EnviadaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEnviadaNull() => this[this.tablesp_LoadOrdenCompra.EnviadaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusNull() => this.IsNull(this.tablesp_LoadOrdenCompra.EstatusColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusNull() => this[this.tablesp_LoadOrdenCompra.EstatusColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaModificacionNull() => this.IsNull(this.tablesp_LoadOrdenCompra.FechaModificacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaModificacionNull() => this[this.tablesp_LoadOrdenCompra.FechaModificacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsUsuarioModificoNull() => this.IsNull(this.tablesp_LoadOrdenCompra.UsuarioModificoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetUsuarioModificoNull() => this[this.tablesp_LoadOrdenCompra.UsuarioModificoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMonedaNull() => this.IsNull(this.tablesp_LoadOrdenCompra.MonedaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMonedaNull() => this[this.tablesp_LoadOrdenCompra.MonedaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEmailNull() => this.IsNull(this.tablesp_LoadOrdenCompra.EmailColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEmailNull() => this[this.tablesp_LoadOrdenCompra.EmailColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaCreacionNull() => this.IsNull(this.tablesp_LoadOrdenCompra.FechaCreacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaCreacionNull() => this[this.tablesp_LoadOrdenCompra.FechaCreacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNoFacturaNull() => this.IsNull(this.tablesp_LoadOrdenCompra.NoFacturaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNoFacturaNull() => this[this.tablesp_LoadOrdenCompra.NoFacturaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusFacturaNull() => this.IsNull(this.tablesp_LoadOrdenCompra.EstatusFacturaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusFacturaNull() => this[this.tablesp_LoadOrdenCompra.EstatusFacturaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsidSucursalNull() => this.IsNull(this.tablesp_LoadOrdenCompra.idSucursalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetidSucursalNull() => this[this.tablesp_LoadOrdenCompra.idSucursalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCiudadSucursalNull() => this.IsNull(this.tablesp_LoadOrdenCompra.CiudadSucursalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCiudadSucursalNull() => this[this.tablesp_LoadOrdenCompra.CiudadSucursalColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_LoadOrdenCompraRowChangeEvent : EventArgs
    {
      private _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_LoadOrdenCompraRowChangeEvent(
        _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public _SisaAdmin_CopiaDataSet.sp_LoadOrdenCompraRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
