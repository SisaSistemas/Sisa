<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRptViaticos.aspx.cs" Inherits="SisaDev.Reportes.frmRptViaticos" %>
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
                <LocalReport ReportPath="Reportes\rptViaticos.rdlc">                    
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="dsViaticos" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" SelectCommand="sp_LoadViaticos" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtIdViaticos" Name="IdViaticos" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
<%--            <asp:ObjectDataSource ID="ObDs1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="SisaDev.Rpt.SisaTableAdapters.sp_LoadViaticosTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtIdViaticos" Name="IdViaticos" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>
        </div>
        <div style="visibility:hidden;">
            <asp:TextBox ID="txtIdViaticos" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
