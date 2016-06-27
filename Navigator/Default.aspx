<%@ Page Title="Navigator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Navigator._Default" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="gmap" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="gmap" %>

	<gmap:GMap ID="Gmap1" runat="server" Width="800px" Height="500px" enableHookMouseWheelToZoom="true" />
</asp:Content>

<asp:Content runat="server" ID ="SideBarContent" ContentPlaceHolderID="SideBarContent">
	<h1>Column 2</h1>
	<asp:Button ID="LoginButton" runat="server"  Text="Add new location" onclientclick="openfileDialog()"  />
	<table style="border:1px solid;">
		<tr style="border:1px solid">
			<td>First</td>
			<td>Second</td>
		</tr>
			<tr>
			<td>1</td>
			<td>2</td>
		</tr>
	</table>
</asp:Content>
