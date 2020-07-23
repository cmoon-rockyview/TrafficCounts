<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpeedInfo.ascx.cs" Inherits="TrafficCount.Presentation.ucSummary.SpeedInfo" %>
<link href="http://localhost/TC/css/GVStyles.css" rel="stylesheet" type="text/css" />

<br />

<asp:GridView ID="grvSpeed" runat="server" Width="100%" CssClass = "EU_DataTable" AutoGenerateColumns = "false">
    <Columns>            
            <asp:BoundField DataField="Speed" HeaderText ="Speed (Km/H)" ItemStyle-Width= "40%" ItemStyle-VerticalAlign = "Middle"   />
            <asp:BoundField DataField="LaneA" HeaderText ="Lane-A" ItemStyle-Width= "20%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="LaneB" HeaderText ="Lane-B" ItemStyle-Width= "20%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Total" HeaderText ="Sum" ItemStyle-Width= "20%" ItemStyle-VerticalAlign = "Middle" /> 
    </Columns>
</asp:GridView>