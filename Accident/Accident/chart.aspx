<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="chart.aspx.cs" Inherits="Accident.chart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

               
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div><center>  <h1 style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-weight: lighter; color: #000066; background-color: #99CCFF">Chart For Accident</h1> <h2 role="alert" style="font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; font-weight: lighter; text-decoration: blink; background-color: #FFFFFF;">( Using to accident reson) </h2></center></div>
   <asp:Chart ID="Chart1" runat="server" BackImageAlignment="Center" BorderlineDashStyle="Solid" DataSourceID="SqlDataSource1" Height="425px" Width="596px">
        <Series>
            <asp:Series ChartArea="ChartArea1" ChartType="Pie" Name="Series1" XValueMember="Reson" YValueMembers="CoReson">
            </asp:Series>
        </Series>
       <Legends>
           <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="false" Name="Default" LegendStyle="Row" />
       </Legends>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
      <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1" Height="428px" Width="535px">
          <Series>
              <asp:Series Name="Series1" XValueMember="Reson" YValueMembers="CoReson">
              </asp:Series>
          </Series>
          <ChartAreas>
              <asp:ChartArea Name="ChartArea1">
              </asp:ChartArea>
          </ChartAreas>
      </asp:Chart>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Rode_CoverConnectionString2 %>" SelectCommand="select Reson, count(Reson) as CoReson from accident1 group by Reson"></asp:SqlDataSource>
    <div>

    </div>
</asp:Content>

