<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchWidget.ascx.cs" Inherits="TrafficCount.Presentation.ucHistory.SearchWidget" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<link href="./CSS/SearchWidget.css" rel="stylesheet" type="text/css" />
<script src="./Scripts/CommonScript.js" type="text/javascript"></script>




<table runat="server" style="width:100%;height:100%" border="1">
     <tr>
        <td colspan="2" style="width:100%">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
			<asp:TabContainer ID="tabSearch" runat="server" Width="100%" 
                AutoPostBack ="true" Height="100%"
                Font-Size ="Large" ActiveTabIndex="0" CssClass="Tabcss" style="z-index:255"
                onactivetabchanged="tabSearch_ActiveTabChanged">
                    <asp:TabPanel ID = "tabPnlLoc" runat="server" HeaderText= "Search By Location" >
                        <ContentTemplate >
                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign ="Left" style="vertical-align:middle">
                            <asp:Label ID="Label1" runat="server" CssClass="LabelText">First Road : </asp:Label>
                            <asp:TextBox ID="txtFirstRoad" Height="25px" runat="server" AutoPostBack="True" Width="110px" Font-Size="15px"
                                    ontextchanged="txtFirstRoad_TextChanged"></asp:TextBox> 
                            <asp:AutoCompleteExtender ID = "acFirstRoad" TargetControlID = "txtFirstRoad"
                                        runat="server" MinimumPrefixLength ="1" ServiceMethod="FindFirstRoad" 
                                    DelimiterCharacters="" Enabled="True" ServicePath=""/>
                            <asp:Label ID="labelSecondRoadTitle" runat="server" CssClass="LabelText">Second Road : </asp:Label>
                            <asp:TextBox ID="txtSecondRoad" runat="server" Height="25px" Width="110px"></asp:TextBox> 
                            <asp:AutoCompleteExtender ID = "acSecondRoad" TargetControlID = "txtSecondRoad" UseContextKey = "True"
                                        runat="server" MinimumPrefixLength ="1" ServiceMethod="FindSecondRoad" 
                                    DelimiterCharacters="" Enabled="True" ServicePath=""/>
                            <asp:Label ID="Label3" runat="server" Height="25px" CssClass="LabelText">Direction : </asp:Label>
                            <asp:TextBox ID="txtDir" runat="server" Height="25px" Width="50px"></asp:TextBox>                        
                            </asp:Panel>
                        </ContentTemplate>    
                    </asp:TabPanel>                 
                    <asp:TabPanel ID="tabPnlSite" runat="server" HeaderText= "Search By Site ID">
                        <ContentTemplate>
                            <asp:Label ID="Label4" runat="server" CssClass="LabelText">Site Number : </asp:Label>
                            <asp:TextBox ID="txtSite" runat="server" Height="24px"></asp:TextBox>&nbsp;
                            <asp:AutoCompleteExtender ID = "acSite" TargetControlID = "txtSite" 
                                        runat="server" MinimumPrefixLength ="1" ServiceMethod="FindSite"/>                                         
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="tabPnlUpload" runat="server" Enabled="false" HeaderText = "Upload XML File" >
                        <ContentTemplate>                            
                            <asp:Label ID="Label2" runat="server" CssClass="LabelText"> Select a XML file : </asp:Label> 
                            <asp:FileUpload ID="FileUploader" Width="300px" runat="server" />&nbsp                            
                            <asp:TextBox ID="txtExtraNum" Width="50px" runat="server" />
                            <asp:Label ID="Label5" Text="Extra Site Number" Font-Size ="Medium" runat="server" />    &nbsp

                            <asp:Button ID="btnUpload" runat="server" BackColor = "AliceBlue" Text = "Upload to DB" onclick="btnUpload_Click" />                                                                                                              
                        </ContentTemplate>
                    </asp:TabPanel>                  
            </asp:TabContainer>   
        
        </td>
    </tr> 
     <tr>
        <td style="width:70%">
            <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                <asp:Label ID="lblResult" runat="server" CssClass="LabelTextResult" Text="Result" />
                <asp:Label ID= "lblSite" runat="server" Visible="false"/>
                <asp:Label ID= "lblFirstRoad" runat="server" Visible="false"/>
                <asp:Label ID= "lblSecondRoad" runat="server" Visible="false"/>
                <asp:Label ID= "lblDir" runat="server" Visible="false"/>
            </asp:Panel>
        </td>       
        <td>
            <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
                <asp:Button ID="btnSearch" runat="server" Width="200" Text="Sumit Query" onclick="btnSearch_Click"/>
            </asp:Panel>            
        </td>
     </tr>
</table>
