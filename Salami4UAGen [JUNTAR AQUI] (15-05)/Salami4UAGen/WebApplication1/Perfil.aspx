<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Perfil.aspx.cs" Inherits="WebApplication1.Perfil" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Profile
    </h2>
    <br /><br />
    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 800px; width: 226px; float: left'>
        <asp:Image ID="ImagenPerfil" runat="server" Height="200px" Width="200px" />
    </div>

    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 1400px; width: 359px; float: left; line-height: 2em;' >
        
        <asp:Label ID="Label25" runat="server" Text="Personal Data" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
    
        <br />
        
        <asp:Label ID="Label1" runat="server" Text="Nickname" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Nickname" runat="server" Text="" Width="100px"></asp:Label>

        <br />
    
        <asp:Label ID="Label2" runat="server" Text="Email" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Email" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label22" runat="server" Text="Name" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Name" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label24" runat="server" Text="Surname" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Surname" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label11" runat="server" Text="Genre" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Genero" runat="server" Text="" Width="100px"></asp:Label>

        <br />
    
        <asp:Label ID="Label3" runat="server" Text="Nationality" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="NationalityLabel" runat="server" Text="" Width="100px"></asp:Label>


        <br />
    
        <asp:Label ID="Label4" runat="server" Text="Height" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HeightLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />
        
        <asp:Label ID="Label6" runat="server" Text="Body Type" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="BodyTypeLabel" runat="server" Text="" Width="100px"></asp:Label>
        
        <br />
    
        <asp:Label ID="Label8" runat="server" Text="Ethnicity" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="EthnicityLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label10" runat="server" Text="Eye Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="EyeColorLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label12" runat="server" Text="Hair Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairColorLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label14" runat="server" Text="Hair Length" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairLengthLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />
    
        <asp:Label ID="Label16" runat="server" Text="Hair Style" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairStyleLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label18" runat="server" Text="Smoke" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="SmokeLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label5" runat="server" Text="Religion" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="ReligionLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label20" runat="server" Text="Birthdate" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="BirthLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label23" runat="server" Text="Studies" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="StudiesLabel" runat="server" Width="255px"></asp:Label>

        <br />

        <asp:Label ID="Label26" runat="server" Text="Course" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="CourseLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br /><br />

        <asp:Label ID="Label9" runat="server" Text="Pets" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver" ></asp:Label>
        <asp:Label ID="PetsLabel" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="Label13" runat="server" Text="Features" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="FeaturesLabel" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />
    
        <asp:Label ID="Label17" runat="server" Text="Film Tastes" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="FilmLabel" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="Label21" runat="server" Text="Music Tastes" Width="200px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="MusicLabel" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="Label7" runat="server" Text="Sports" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="SportsLabel" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />
    
        <asp:Label ID="Label15" runat="server" Text="Hobbies" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="HobbiesLabel" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="CommentLabel" runat="server" Text="" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Comment" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

    </div>

    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 1400px; width: 300px; float: left; line-height: 2em;' >
    
        <asp:Label ID="LookingForLabel" runat="server" Text="Looking For..." Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>

        <br />
        <asp:Label ID="Label41" runat="server" Text="Genre" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="GeneroBuscado" runat="server" Text="" Width="100px"></asp:Label>

        <br />
        <asp:Label ID="Label27" runat="server" Text="Body Type" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="BodyTypeBuscado" runat="server" Text="" Width="100px"></asp:Label>
        
        <br />
    
        <asp:Label ID="Label29" runat="server" Text="Ethnicity" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="EthnicityBuscado" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label31" runat="server" Text="Eye Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="EyeColorBuscado" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label33" runat="server" Text="Hair Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairColorBuscado" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label35" runat="server" Text="Hair Length" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairLengthBuscado" runat="server" Text="" Width="100px"></asp:Label>

        <br />
    
        <asp:Label ID="Label37" runat="server" Text="Hair Style" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairStyleBuscado" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label39" runat="server" Text="Smoke" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="SmokeBuscado" runat="server" Text="" Width="100px"></asp:Label>
    
    </div>

    <div style= 'height: 50px; width: 800px; border: 3px; float: Right' >
    
        <asp:Button ID="BotonEditarPerfil" runat="server" Text="Edit Profile" OnClick="BotonEditarPerfil_Click" Width="130px" class="button"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BotonCambiarPassword" runat="server" Text="Change Password" OnClick="BotonCambiarPassword_Click" class="button"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BotonEliminarPerfil" runat="server" Text="Delete Profile" OnClick="BotonEliminarPerfil_Click" class="button"/>
        
        
        
    </div>


 </asp:Content>