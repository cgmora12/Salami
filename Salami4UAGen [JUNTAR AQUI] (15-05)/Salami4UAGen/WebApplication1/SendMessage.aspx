<%@ Page Title="Send Message" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="SendMessage.aspx.cs" Inherits="WebApplication1.SendMessage" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

        <h2>
            <asp:Label ID="SubtitleLabel" runat="server" Text="" />
        </h2>

        <br />
        <asp:Label ID="VerPerfilError" runat="server" Text=""></asp:Label>

        <% if (VerPerfilError.Text == "")
           { %>

        <br />
    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 250px; width: 226px; float: left; margin-top: 3px; margin-bottom: 3px'>
        
        <asp:ImageButton ID="ImagenPerfilButton" runat="server" Height="200px" Width="200px" />
        
    </div>
    
    <style type="text/css">
    
    .Scrollgrid
    { 
    
    OVERFLOW: auto; BORDER-LEFT: #000000 1px; WIDTH: 100%; BORDER-BOTTOM: #000000 1px; HEIGHT: 258px;
    scrollbar-3d-light-color:#999999;
    scrollbar-arrow-color:#9C3842;
          scrollbar-base-color:#003366;
          scrollbar-dark-shadow-color:#9C3842;
          scrollbar-face-color:#e7e7e7;
          scrollbar-highlight-color:#ffffff;
          scrollbar-shadow-color:9C3842;   
          
    
    }
    </style>
     
    <div class="Scrollgrid" id="divMessages" runat="server" style= 'border-style: none; border-color: inherit; border-width: 3px; min-height: 250px; overflow:auto; height: 500px:; width: 659px; float: left; line-height: 2em; margin: 3px 3px 3px 3px' >
    </div>

    <div style= 'height: 50px; width: 659px; border: 3px; float: Right' >
    
        <asp:Label ID="LabelReport" runat="server" ForeColor="Red" /><br />

        <asp:Panel ID="Panel1" runat="server" DefaultButton="buttonSend">
            <asp:TextBox ID="textSend" runat="server" Width="500px" class="input"  />
            <asp:Button ID="buttonSend" runat="server" Text="Send" class="button" OnClick="sendMessage_Click"/>
        </asp:Panel>
    </div>

    <% } %>

</asp:Content>

