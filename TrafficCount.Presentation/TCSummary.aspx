<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TCSummary.aspx.cs" Inherits="TrafficCount.Presentation.TCSummary" %>



<%@ Register src="ucSummary/BasicInfo.ascx" tagname="BasicInfo" tagprefix="uc1" %>
<%@ Register src="ucSummary/AxlesInfo.ascx" tagname="AxlesInfo" tagprefix="uc2" %>
<%@ Register src="ucSummary/SpeedInfo.ascx" tagname="SpeedInfo" tagprefix="uc3" %>
<%@ Register src="ucSummary/LocationMap.ascx" tagname="LocationMap" tagprefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="ucSummary/AxlesDetailed.ascx" tagname="AxlesDetailed" tagprefix="uc5" %>
<%@ Register src="ucSummary/SpeedDetailed.ascx" tagname="SpeedDetailed" tagprefix="uc6" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Traffic Count Report</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link href="http://localhost/TC/CSS/Site.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" href="http://localhost/TC/CSS/jquery-ui.css" />
    <script type ="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type ="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="Scripts/rvJQuery.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" >
    
        
        
        
        <table cellspacing="0" cellpadding ="0" border= "0" style="padding:0; width:100%; margin:30; vertical-align:top;">
             <!--Header-->
            <tr style="margin:0;padding:0">
                <td style="margin:0;padding:0">
                     
                    <uc1:BasicInfo ID="BasicInfo1" runat="server" />                  
                     
                </td>   
            </tr>
        </table>
        
        
        <asp:Panel runat="server" ID="pnlInfo" Visible = "false">
        <div id="tabs">
                    <ul>
                        <li><a href="#tabs-0">Summary</a></li>
                        <li><a href="#tabs-1">Axles Details</a></li>
                        <li><a href="#tabs-2">Speed Details</a></li>
                                          
                    </ul>
        


        
        <div id="tabs-0">
        <table id="tbMain"  cellspacing="0" cellpadding ="0" border= "0" style="padding:0; width:100%; margin:30; vertical-align:top;" >
           
            <!--Axles-->
            <tr>
                <td style="margin:0;padding:0">
                                        
                    <uc2:AxlesInfo ID="AxlesInfo1" runat="server" />
                    
                </td>
            </tr>
            <!--Speed-->
            <tr>
                <td >                    
                    <uc3:SpeedInfo ID="SpeedInfo1" runat="server" />
                    
                </td>
            </tr>
        </table>
        </div>
             
        <div id="tabs-1">

            <table id="Table2"  cellspacing="0" cellpadding ="0" border= "0" style="padding:0; width:100%; margin:30; vertical-align:top;" >
           
                <!--Axles-->
                <tr>
                    <td style="margin:0;padding:0">              
                    
                        <uc5:AxlesDetailed ID="AxlesDetailed1" runat="server" />          
                    
                    
                    </td>
                </tr>         
            </table>
        </div>
        <div id="tabs-2">

             <table id="Table3"  cellspacing="0" cellpadding ="0" border= "0" style="padding:0; width:100%; margin:30; vertical-align:top;" >
           
                <!--Axles-->
                <tr>
                    <td style="margin:0;padding:0">           
                    
                        <uc6:SpeedDetailed ID="SpeedDetailed1" runat="server" />                                                            
                    
                    </td>
                </tr>         
            </table>
        </div>
        
       
                  

        </div>

        

        <table id="Table1"  cellspacing="0" cellpadding ="0" border= "1" style="padding:0; width:100%;height:400px;vertical-align:top;" >            
            <tr style="width:100%;" >
                <td style="width:500px;" align="center"  >
                    <asp:Panel ID="Panel" runat="server" HorizontalAlign="Center" > 
                        <asp:Label ID="Label1" runat="server" Font-Size = "Large" Font-Bold = "true" >Map for the Site</asp:Label>&nbsp&nbsp&nbsp                                               
                        <asp:Image ImageUrl ="~/Images/NorthArrow.JPG" width="20" height="20" runat="server" style="vertical-align= middle" />
                        

                        <br />
                        <uc4:LocationMap ID="LocationMap1" runat="server" />
                    </asp:Panel>
                    
                </td>
                <td style="margin:1px" >
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" >
                        <asp:Label runat="server" >Vehicle Type</asp:Label> <br />                                            
                        <asp:Image runat="server" ImageUrl="~/Images/VehicleType.JPG" Width="300" />                    
                    </asp:Panel>
                </td>
            </tr>
        </table>

        </asp:Panel>

    </form>
</body>
</html>
