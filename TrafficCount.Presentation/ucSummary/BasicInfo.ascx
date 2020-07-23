<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicInfo.ascx.cs" Inherits="TrafficCount.Presentation.ucSummary.BasicInfo" %>
<link href="./CSS/Header.css" rel="stylesheet" type="text/css" />
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Panel runat="server" HorizontalAlign= "Center">
    <asp:ToolkitScriptManager ID= "MainScriptManger" runat="server" EnablePageMethods = "true"></asp:ToolkitScriptManager>
    <table width="100%" id="tbTitle" cellspacing="0" cellpadding ="0"  style="padding:0 ; margin:0 ; width:100%" >
        
        <tr align="center"  >
        
            <td>
                <%--<asp:Image ID="Image1" runat="server" Width= "100" Height= "50" ImageUrl ="" />--%>
                <img src="./Images/RVC.png" width="200" height="50" />
                <%--<asp:Image Id="imgMyImage" ImageUrl="./Images/RVC_Logo2010.bmp" Width="80" Height="40" runat="server" /> --%>
            </td>                       
            <td style="margin:0;padding:0">                        
                <asp:Label ID="lblTitleName" runat="server" CssClass="HeaderText">Traffic Count Report</asp:Label>            
            </td>
            <td id ="cellSearch">
                <asp:Panel runat="server" DefaultButton="btnSiteID">
                <asp:Label ID="Label6" runat="server" Font-Size="Small">SITE ID: </asp:Label>
                <asp:TextBox ID="txtSiteID" runat="server" Width="80"></asp:TextBox>
                <asp:AutoCompleteExtender ID="acFindSite" runat="server" EnableCaching="true" 
                    MinimumPrefixLength="1" ServiceMethod="FindSite" TargetControlID="txtSiteID" />
                <asp:Button ID="btnSiteID" runat="server" onclick="btnSiteID_Click" Text="Search" Width="60" />
                </asp:Panel>
            </td>
     
            <td>
                <asp:Panel runat="server" BorderStyle= "Solid" >
                <asp:Label ID="lblTwpTitle" runat = "server" Font-Size="10"  >TWP NO.</asp:Label> <br />
                <asp:Label ID="lblTwp" runat="server" CssClass="TwpText">78 </asp:Label>
                </asp:Panel>
            </td>

        </tr>

    </table>

    
    <asp:Panel runat="server" HorizontalAlign="Center">
        <asp:Label ID="lblLocation" Font-Size= "Large" runat="server" Font-Bold="true"  ></asp:Label>       &nbsp
        <asp:Label ID="lblLegalDesc" Font-Size= "Large" runat="server" Font-Bold="true"  ></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlBasicInfo" runat="server" Visible="false">
    <table width="100%" id="tbMain" cellspacing="0" cellpadding ="0" border= "1" style="padding:0 ; margin:0 ; width:100%" >
        <tr>
            
            <td style="width:33.333%">                
                <asp:Label ID="lblDate" runat="server"  >Date:</asp:Label>
            </td>
            <td style="width:33.333%">                
                <asp:Label ID="lblLengthOfCount" runat="server"   > Length of Count: </asp:Label>
            </td>
            <td style="width:33.333%">                
                <asp:Label ID="lblPostedSpeed" runat="server"   > Posted Speed: </asp:Label>
            </td>
            
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="lblTotalTrafficVolume" runat = "server" >Total Traffic Volume: </asp:Label>                
            </td>
            <td>
                <asp:Label ID="lblPercentile85" runat = "server"  >85th Percentile: </asp:Label>                
            </td>
            <td>
                <asp:Label ID = "lblTruckPercentage" runat = "server"  >Truck Percentage: </asp:Label>
            </td>
            
            
        </tr>
        <tr>                     

            <td>
                <asp:Label ID="lblLaneA" runat="server"  ></asp:Label>                
            </td>
            <td>                
                <asp:Label ID="lblLaneB" runat="server"   ></asp:Label>
            </td>

              <td>                
                <asp:HyperLink ID="hlkHistory" runat="server" Text="To History Page" Target="_blank" />                
            </td>    
        </tr>           
    </table>
    </asp:Panel>
</asp:Panel>
