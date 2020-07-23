<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AxlesDetailed.ascx.cs" Inherits="TrafficCount.Presentation.ucSummary.AxlesDetailed" %>
<br />

<asp:Label ID="AxlesLegend" runat= "server" Font-Size = "Large">
[Time]: 24-Hour Time (0000-2359)  [Dir]: Direction code [Cls]: Class totals [Total]: Number in time step
</asp:Label>
                                 


  

<asp:GridView ID="grvAxlesDetailed" runat="server" Width="100%" CssClass = "EU_DataTable" AutoGenerateColumns = "false">
   <Columns>            
            <asp:BoundField DataField="TimeCaptured" HeaderText ="Time" ItemStyle-Width= "8%" ItemStyle-VerticalAlign = "Middle"   />
            <asp:BoundField DataField="Lane" HeaderText ="Dir" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="MotorCycles" HeaderText ="Motor Cycles(Cls1)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="PassengerCars" HeaderText ="Passenger Cars(Cls2)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="TwoAxleFourTires" HeaderText ="Two Axle Four Tires(Cls3)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="Buses" HeaderText ="Buses(Cls4)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="TwoAxleSixTires" HeaderText ="Two Axle Six Tires(Cls5)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="ThreeAxleSingleUnitTruck" HeaderText ="Three Axle Single Unit Truck(Cls6)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="FourOrMoreAxleSignleUnitTruck" HeaderText ="Four Or More Axle Signle Unit Truck(Cls7)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="FourOrLessAxleSingleTrailerTruck" HeaderText ="Four Or Less Axle Single Trailer Truck(Cls8)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="FiveAxleSignleTrailerTruck" HeaderText ="Five Axle Signle Trailer Truck(Cls9)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="SixOrMoreAxleSignleTrailerTruck" HeaderText ="Six Or More Axle Signle Trailer Truck(Cls10)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />            
            <asp:BoundField DataField="FiveLessAxleMultiTrailerTruck" HeaderText ="Five Less Axle Multi Trailer Truck(Cls11)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="SixAxleMultiTrailerTruck" HeaderText ="Six Axle Multi Trailer Truck(Cls12)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="SevenMoreAxleMultiTrailerTruck" HeaderText ="Seven More Axle Multi Trailer Truck(Cls13)" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />
            <asp:BoundField DataField="TruckCount" HeaderText ="Truck Count" ItemStyle-Width= "5%" ItemStyle-VerticalAlign = "Middle" />                      
            <asp:BoundField DataField="Total" HeaderText ="Total" ItemStyle-Width= "10%" ItemStyle-VerticalAlign = "Middle" /> 
    </Columns>   
</asp:GridView>



  
 