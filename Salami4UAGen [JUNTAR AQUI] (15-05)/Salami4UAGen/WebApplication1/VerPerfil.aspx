<%@ Page Title="Ver Perfil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
    CodeBehind="VerPerfil.aspx.cs" Inherits="WebApplication1.VerPerfil" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 420px;
        height: 600px;
    }
</style>
        <h2>
            Profile
        </h2>

        <br />
        <asp:Label ID="VerPerfilError" runat="server" Text=""></asp:Label>

        <% if (VerPerfilError.Text == "")
           { %>

        <br />
    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 800px; width: 226px; float: left'>
        
        <asp:Image ID="ImagenPerfil" runat="server" Height="200px" Width="200px" />
        <br /><br />
        <asp:Button ID="ButtonEnviarMensaje" runat="server" Text="Send Message" OnClick="ButtonEnviarMensaje_Click" class="button" Width="200px"/>
        <br /><br />
        <asp:Button ID="ButtonEnviarPinchito" runat="server" Text="Send Pinchito" OnClick="ButtonEnviarPinchito_Click" class="button" Width="200px"/>
    
    </div>


  
    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 1208px; width: 659px; float: left; line-height: 2em;' >
        
        <asp:Label ID="NicknameLabel" runat="server" Text="Nickname" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Nickname" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="NameLabel" runat="server" Text="Name" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Name" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="SurnameLabel" runat="server" Text="Surname" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Surname" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="GeneroLabel" runat="server" Text="Genre" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Genero" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="OrientacionLabel" runat="server" Text="Look for" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Orientacion" runat="server" Text="" Width="100px"></asp:Label>

        <br />
    
        <asp:Label ID="NationalityLabel" runat="server" Text="Nationality" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Nationality" runat="server" Text="" Width="100px"></asp:Label>


        <br />
    
        <asp:Label ID="HeightLabel" runat="server" Text="Height" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Height" runat="server" Text="" Width="100px"></asp:Label>

        <br />
        
        <asp:Label ID="BodyTypeLabel" runat="server" Text="Body Type" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="BodyType" runat="server" Text="" Width="100px"></asp:Label>
        
        <br />
    
        <asp:Label ID="EthnicityLabel" runat="server" Text="Ethnicity" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Ethnicity" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="EyeColorLabel" runat="server" Text="Eye Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="EyeColor" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="HairColorLabel" runat="server" Text="Hair Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairColor" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="HairLengthLabel" runat="server" Text="Hair Length" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairLength" runat="server" Text="" Width="100px"></asp:Label>

        <br />
    
        <asp:Label ID="HairStyleLabel" runat="server" Text="Hair Style" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="HairStyle" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="SmokeLabel" runat="server" Text="Smoke" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Smoke" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="ReligionLabel" runat="server" Text="Religion" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Religion" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="BirthLabel" runat="server" Text="Birthdate" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="Birth" runat="server" Text="" Width="100px"></asp:Label>

        <br />

        <asp:Label ID="Label23" runat="server" Text="Studies" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="StudiesLabel" runat="server" Width="524px"></asp:Label>

        <br />

        <asp:Label ID="Label26" runat="server" Text="Course" Width="100px" Font-Bold="True"></asp:Label>
        <asp:Label ID="CourseLabel" runat="server" Text="" Width="100px"></asp:Label>

        <br /><br />

        <asp:Label ID="PetsLabel" runat="server" Text="Pets" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver" ></asp:Label>
        <asp:Label ID="Pets" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="FeaturesLabel" runat="server" Text="Features" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Features" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />
    
        <asp:Label ID="FilmLabel" runat="server" Text="Film Tastes" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Film" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="MusicLabel" runat="server" Text="Music Tastes" Width="200px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Music" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="SportsLabel" runat="server" Text="Sports" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Sports" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />
    
        <asp:Label ID="HobbiesLabel" runat="server" Text="Hobbies" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Hobbies" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />

        <asp:Label ID="CommentLabel" runat="server" Text="" Width="100px" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <asp:Label ID="Comment" runat="server" Text="" Width="600px"></asp:Label>

        <br /><br />


    </div>

    <div style= 'height: 50px; width: 800px; border: 3px; float: Right' >
    
        <form id="form1">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Button ID="btnShow" runat="server" Text="Report User" class="button" OnClick="popUpOpen_Click"/>
            <asp:Button ID="btn" runat="server" style="display:none;" />
            
            <!-- ModalPopupExtender -->
            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btn"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>


            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
                <p>
                    <strong>Report User</strong>
                </p>
                <p style="text-align:left; margin-left:2%">
                    If you have any trouble with a user, please report it here.
                </p>
                <br />
                <p style="text-align:left; margin-left:5%">
                    <asp:Label ID="NicknameReportLabel" runat="server">Nickname: *</asp:Label>
                    <br />
                    <asp:TextBox ID="NicknameReport" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="nameReportReq" runat="server"
                                                ControlToValidate="NicknameReport" ForeColor="Red"
                                                ErrorMessage="Please introduce the nickname to report." ValidationGroup="reportGroup">
                    </asp:RequiredFieldValidator>
                    <br />
                </p>

                <p style="text-align:left; margin-left:5%">
                    <asp:Label ID="Label1" runat="server">Cause of report: *</asp:Label>
                    <br />
                    <asp:DropDownList ID="CauseDropDownList" runat="server"></asp:DropDownList>
                    <br /><br />
                </p>
                
                <p style="text-align:left; margin-left:5%">
                    <asp:Label ID="ArgumentReportLabel" runat="server">Argument for reporting: *</asp:Label>
                    <br />
                    <asp:TextBox ID="ArgumentReport" runat="server" TextMode="MultiLine" Width="300px" Height="180px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="ArgumentReportReq" runat="server" 
                                                ControlToValidate="ArgumentReport" ForeColor="Red"
                                                ErrorMessage="Please introduce the argument to report." ValidationGroup="reportGroup">
                    </asp:RequiredFieldValidator>
                    <br />
                </p>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    
                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="send_Click" class="button" ValidationGroup="reportGroup"/>      
                    
                        <asp:Button ID="btnClose" runat="server" Text="Close" class="button" OnClick="close_Click"/>
                        <br /><br />
                        <asp:Label ID="LabelReport" runat="server" ForeColor="Red"></asp:Label>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <br />

            </asp:Panel>
            <!-- ModalPopupExtender -->
        </form>
        
        <asp:Button ID="BotonEliminarAdmin" Visible="false" runat="server" Text="Delete Profile" OnClick="BotonEliminarPerfil_Click" class="button"/>
        
    </div>

    <% } %>

</asp:Content>

