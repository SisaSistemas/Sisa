<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteSolicitudCotizacion.aspx.cs" Inherits="SisaDev.Cliente.ReporteSolicitudCotizacion" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
                <LocalReport ReportPath="Cliente\rptSolicitudCotizacion.rdlc">                    
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObDs1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObDs1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SisaDev._SisaAdmin_SolCotizacionTableAdapters.sp_GeneraRptSolicitudCotizacionTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtIdSolicitudCotizacion" Name="IdSolicitudCotizacion" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div style="visibility:hidden;">
            <asp:TextBox ID="txtIdSolicitudCotizacion" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtFolioSolicitud" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
