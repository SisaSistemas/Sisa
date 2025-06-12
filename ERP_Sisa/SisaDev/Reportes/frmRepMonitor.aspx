<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRepMonitor.aspx.cs" Inherits="SisaDev.Reportes.frmRepMonitor" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" Height="952px" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="1873px">
                <LocalReport ReportPath="Reportes\rptMonitor.rdlc">
                   <%-- <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="dsCot" />
                    </DataSources>--%>
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="dsMonitor" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="SELECT * FROM [tblProyectosProyeccionFinancieraReporte]"></asp:SqlDataSource>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="sp_CargarCotizaciones" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
      --%>  </div>
    </form>
</body>
</html>
