<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AxlesInfo.ascx.cs" Inherits="TrafficCount.Presentation.ucSummary.AxlesInfo" %>
<link href="http://localhost/TC/css/GVStyles.css" rel="stylesheet" type="text/css" />

<div>
    <!--http://forums.asp.net/t/1001135.aspx -->   
    <asp:GridView ID="grvAxles" runat="server" Width="100%" CssClass="EU_DataTable" AutoGenerateColumns = "false">
        <Columns>            
            <asp:BoundField DataField="Axles" HeaderText ="Axles" ItemStyle-Width= "40%" ItemStyle-VerticalAlign = "Middle"   />
            <asp:BoundField DataField="LaneA" HeaderText ="Lane-A" ItemStyle-Width= "20%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="LaneB" HeaderText ="Lane-B" ItemStyle-Width= "20%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Total" HeaderText ="Sum" ItemStyle-Width= "20%" ItemStyle-VerticalAlign = "Middle" /> 
        </Columns>
    </asp:GridView>
</div>