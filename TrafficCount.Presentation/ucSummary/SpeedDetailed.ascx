<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpeedDetailed.ascx.cs" Inherits="TrafficCount.Presentation.ucSummary.SpeedDetailed" %>
<br />

<asp:Label ID="AxlesLegend" runat= "server" Font-Size = "Large">
[Time]: 24-Hour Time (0000-2359)  [Dir]: Direction code [Vbin]: Speed bin totals [Mean]:Average Speed [Total]: Number in time step
</asp:Label>


<asp:GridView ID="grvSpeedDetailed" runat="server" Width="100%" CssClass = "EU_DataTable" AutoGenerateColumns = "False">
     <Columns> 
                
            <asp:BoundField DataField="TimeCaptured" HeaderText ="Time" ItemStyle-Width= "8%" ItemStyle-VerticalAlign = "Middle"   />
            <asp:BoundField DataField="Lane" HeaderText ="Dir" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp0To10" HeaderText ="Vbin 0-10" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp10To20" HeaderText ="Vbin 10-20" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp20To30" HeaderText ="Vbin 20-30" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp30To40" HeaderText ="Vbin 30-40" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp40To50" HeaderText ="Vbin 40-50" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp50To60" HeaderText ="Vbin 50-60" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp60To70" HeaderText ="Vbin 60-70" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp70To80" HeaderText ="Vbin 70-80" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp80To90" HeaderText ="Vbin 80-90" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp90To100" HeaderText ="Vbin 90-100" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Sp100To110" HeaderText ="Vbin 100-110" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp110To120" HeaderText ="Vbin 110-120" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp120To130" HeaderText ="Vbin 120-130" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp130To140" HeaderText ="Vbin 130-140" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp140To150" HeaderText ="Vbin 140-150" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp150To160" HeaderText ="Vbin 150-160" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="Sp160To200" HeaderText ="Vbin 160-200" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="spMean" HeaderText ="Mean" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />                        
            <asp:BoundField DataField="Total" HeaderText ="Total" ItemStyle-Width= "10%" ItemStyle-VerticalAlign = "Middle" /> 

    </Columns>   
</asp:GridView>


