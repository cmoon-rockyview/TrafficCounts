<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttTable.ascx.cs" Inherits="TrafficCount.Presentation.ucHistory.AttTable" %>

<link href="http://localhost/TC/css/GVStyles.css" rel="stylesheet" type="text/css" />

<!--Grid Table Parts-->    
<asp:GridView ID="gvTCHistory" runat="server" CellPadding="4" ForeColor="#3333" CssClass= "EU_DataTable"
    AutoGenerateColumns = "false" Width="100%" HorizontalAlign="Center" 
    onrowdeleting="gvTCHistory_RowDeleting">
<Columns>
    <asp:BoundField DataField="SiteID" HeaderText ="Site" />
    <asp:BoundField DataField="Date" HeaderText ="Date" />
    <asp:BoundField DataField="Location" HeaderText ="Location" />
    <asp:BoundField DataField="PostedLimit" HeaderText ="Posted Limit" />
    <asp:BoundField DataField="NumofVolume" HeaderText ="Grand Total" />            
    <asp:BoundField DataField="Percentile85" HeaderText ="Percentile (85%)" />
    <asp:BoundField DataField="PercentageTrucks" HeaderText ="Percentage Trucks (%)" />    
            
    <asp:TemplateField HeaderText = "Link To Report">
        <ItemTemplate>
            <asp:HyperLink ID="hlkReport" runat="server" NavigateUrl = '<%#Bind("LinkToSummary")%>' Text = "Link to Summary" Target="_blank"></asp:HyperLink>                    
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Delete?">

        <ItemTemplate>
            <span onclick="return confirm('Are you sure to Delete the record?')">
                <asp:LinkButton ID="lnkB" runat="Server" Text="Delete" CommandName="Delete"></asp:LinkButton>
            </span>
        </ItemTemplate>

    </asp:TemplateField>


</Columns>




</asp:GridView>
    

