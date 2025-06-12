<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteOrdenCompra.aspx.cs" Inherits="SisaDev.Compras.ReporteOrdenCompra" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ZoomPercent="120" Width="100%" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                <LocalReport ReportPath="Rpt\rptOrdenCompra.rdlc">                    
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObDs2" Name="dsOrdenCompraDet" />
                        <rsweb:ReportDataSource DataSourceId="ObDs1" Name="dsOrdenCompraEnc" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObDs1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SisaDev.Rpt.SisaTableAdapters.sp_GeneraReporteOrdenCompraEncTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtIdOrdenCompra" Name="IdOrdenCompra" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="ObDs2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SisaDev.Rpt.SisaTableAdapters.sp_GeneraReporteOrdenCompraDetTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtIdOrdenCompra" Name="IdOrdenCompra" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div style="visibility:hidden;">
            <asp:TextBox ID="txtNombreOrden" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtIdOrdenCompra" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
