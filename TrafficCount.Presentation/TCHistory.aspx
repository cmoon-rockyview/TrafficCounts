<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TCHistory.aspx.cs" Inherits="TrafficCount.Presentation.TCHistory" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="ucHistory/SearchWidget.ascx" tagname="SearchWidget" tagprefix="uc1" %>
<%@ Register src="ucHistory/ChartMap.ascx" tagname="ChartMap" tagprefix="uc2" %>
<%@ Register src="ucHistory/AttTable.ascx" tagname="AttTable" tagprefix="uc3" %>
<%@ Register src="ucHistory/ZLocation.ascx" tagname="Location" tagprefix="uc4" %>

<link href="./CSS/Site.css" rel="stylesheet" type="text/css" />


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" >
    <meta name= "viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title> Traffic Count History</title>    
    
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script type ="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type ="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="Scripts/rvJQuery.js" type="text/javascript"></script> 

</head>
<body>
    <form id="form1" runat="server">
    
    <table style="padding:0; width:100%; vertical-align:top";>        
        <tr>
            <td style="width:100%">
               <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="100%">
                    <asp:Label ID="Label3" runat="server" CssClass="LabelText" Font-Size="25px">Traffic Count History</asp:Label>
                </asp:Panel> 
            </td>
        </tr>

        <tr>
            <asp:Panel runat="server">
            <td style="width:100%">                
                <uc1:SearchWidget ID="SearchWidget1" runat="server" />                                                    
            </td>
            </asp:Panel>
        </tr>
        
       
        
        <tr>
            <asp:Panel runat="server" Visible="false" ID="pnlContent">
            <td style="width:100%;padding:1" >
                 
                <div id="tabs">
                   <ul>
                        <li><a href="#tabs-0">Chart</a></li>
                        <li><a href="#tabs-1">Map</a></li>                                           
                    </ul>

                    <asp:Panel runat="server" Visible="false" ID="pnlChart">
                    <div id="tabs-0">         
                         <uc2:ChartMap ID="ChartMap1" runat="server" />
                    </div>
                    </asp:Panel>
                                     
                    <div id="tabs-1">
                        <uc4:Location ID="Location1" runat="server" />
                    </div>
               
                </div>
                
            </td>
            </asp:Panel>
            
        </tr>
            <tr>
            <td style="width:100%">
                <asp:Panel runat = "server" ID="pnlGridView" Visible ="false" >
                    <uc3:AttTable ID="AttTable1" runat="server" />
                </asp:Panel>
            </td>
        </tr>        
        </table>
    
    </form>
</body>
</html>
