<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChartMap.ascx.cs" Inherits="TrafficCount.Presentation.ucHistory.ChartMap" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Panel runat="server">
<table id="tbMain" cellspacing="0" cellpadding ="0" border= "0" style="padding:0 ; margin:0 ; width:100% ; z-index:0" >
    <tr style="margin:0;width:100;">
                
        <!--Traffic Count History-->
        <td align="center">
            <asp:Panel runat="server">
            <asp:Label ID="Label1" runat ="server" >Traffic Volume Change</asp:Label> <br/>            
               
            <asp:Chart ID="ChartTrafficVolume"  runat="server" BackColor="ActiveBorder"  >
                <Series>
                    <asp:Series Name="TrafficVolume" ChartType="Line" ChartArea="VolumeArea" BorderColor="Red" BorderWidth="5">
                        
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="VolumeArea">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </asp:Panel>                 

        </td>
            <!--85 Percentile History-->
        <td align="center">
            <asp:Panel runat="server">
            <asp:Label ID="Label2" runat ="server" >Traffic 85% Percentile Change</asp:Label> <br />       
                <asp:Chart ID="ChartTrafficPercentile85" runat="server" BackColor="ActiveBorder">
                <Series>
                    <asp:Series Name="TrafficPercentile85" ChartType="Line" ChartArea="VolumeArea" BorderColor="Red" BorderWidth="5" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="VolumeArea">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            </asp:Panel> 
        </td>
           

    </tr>
</table>
</asp:Panel>            
               
