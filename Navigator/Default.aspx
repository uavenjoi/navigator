<%@ Page Title="Navigator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Navigator._Default" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="gmap" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="gmap" %>

	<gmap:GMap ID="Gmap1" runat="server" Width="600px" Height="400px" enableHookMouseWheelToZoom="true" />
</asp:Content>

<asp:Content runat="server" ID ="SideBarContent" ContentPlaceHolderID="SideBarContent">
	<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDyt1XztsObcNAvlgxqTDFaSwJUymGL758" type="text/javascript"></script>
	<h1>Column 2</h1>
	
	<asp:FileUpLoad id="FileUpLoad1" runat="server"  />
	<asp:Button id="UploadBtn" Text="Upload File" OnClick="OnSelected" runat="server" Width="105px" />
	<div class="file_button_container">
		<input type="file" id="file" name="file" />
		
	</div>
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

<asp:Content runat="server" ID="BottomContent" ContentPlaceHolderID="BottomContent">
	<p>Graphics</p>
</asp:Content>




