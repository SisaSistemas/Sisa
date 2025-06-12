<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteCotizacion.aspx.cs" Inherits="SisaDev.Ventas.ReporteCotizacion" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width:100%; height:100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ZoomPercent="120" Width="100%" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
                <LocalReport ReportPath="Reportes\Cotizacion.rdlc" DisplayName="Cotizacion">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="dscoti" />
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="dsDetalles" />
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource3" Name="dsNotas" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="sp_CargarCotizacionesReporteNotasAclaratorias" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="5D5D6F0E-87AF-4ECF-BF5F-5EDA9DE01BA2" Name="Id" QueryStringField="IdCotizacion" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="sp_CargarCotizacionesReporteDetalles" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="5D5D6F0E-87AF-4ECF-BF5F-5EDA9DE01BA2" Name="Id" QueryStringField="IdCotizacion" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="sp_CargarCotizacionesReporte" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="773553AB-A8CA-47E0-8565-9185D15FBB7B" Name="Id" QueryStringField="IdCotizacion" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div style="visibility:hidden;">
            <asp:TextBox ID="txtIdCotizacion" runat="server"></asp:TextBox>
        </div>
    </form>

    
</body>
</html>

