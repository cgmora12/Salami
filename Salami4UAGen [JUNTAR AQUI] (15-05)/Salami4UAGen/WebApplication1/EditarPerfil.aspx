<%@ Page Title="EditarPerfil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="EditarPerfil.aspx.cs" Inherits="WebApplication1.EditarPerfil" %>
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
        width: 650px;
        height: 250px;
    }
</style>
    <h2>
        Edit Profile
    </h2>

    <br />
    <asp:Label ID="ErrorInsertar" runat="server" Text="" ForeColor="Red"></asp:Label>
    
    <br />
    <br />
    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 800px; width: 220px; float: left'>
        <asp:Image ID="ImagenPerfil" runat="server" Height="200px" Width="200px" />
        <br /><br />
        
        <form id="form2">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Change photo" class="button" OnClick="PopUpChangePhoto_Click"/>
            <asp:Button ID="btn" runat="server" style="display:none;" />
            <!-- ModalPopupExtender -->
            
            <cc1:modalpopupextender ID="mp2" runat="server" PopupControlID="Panel1" TargetControlID="btn"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </cc1:modalpopupextender>

            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none">
               
                <asp:ValidationSummary ID="ChangePhotoSummary" runat="server" CssClass="failureNotification" 
                ValidationGroup="ChangePhotoGroup"/>
               
                <p>
                    <strong>Change Photo</strong>
                </p>
                <p style="text-align:left; margin-left:2%; color:Black">
                    Here you can change your photo profile, please introduce a valid URL of your favourite photo (JPG, PNG)
                    
                </p>

                <p style="text-align:left; margin-left:2%; color:GrayText">
                    Example: http://www.fotofoto.com/perfil.jpg
                </p>

                
                
                <p style="text-align:left; margin-left:5%">  
                    
                    <asp:Label ID="URLLabel" runat="server">URL: *</asp:Label>
                    <br />
                    
                     <asp:TextBox ID="URL" runat="server" Width="400px"></asp:TextBox>
                    <br />
                    
                    <asp:RequiredFieldValidator ID="nameReportReq" runat="server"
                                                ControlToValidate="URL" ForeColor="Red"
                                                ErrorMessage="Please introduce a valid URL" ValidationGroup="ChangePhotoGroup">
                    </asp:RequiredFieldValidator>
                   
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="The photo must be on JPG or PNG"
                    ControlToValidate="URL" ForeColor="Red" ValidationExpression="(^\S+\.)+(png|jpg)$"
                    ValidationGroup="ChangePhotoGroup">
                    </asp:RegularExpressionValidator>

                    <br />

                    
                    

                </p>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    
                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="send_Click" class="button" ValidationGroup="reportGroup"/>      
                    
                        <asp:Button ID="btnClose" runat="server" Text="Close" class="button" OnClick="close_Click"/>
                        <br /><br />

                    </ContentTemplate>
                </asp:UpdatePanel>

                <br />

            </asp:Panel>
            <!-- ModalPopupExtender -->
            </form>
         
        
        
        
        
    </div>

    <div style= 'border-style: none; border-color: inherit; border-width: 3px; height: 800px; width: 410px; float: left' >

        <asp:Label ID="PersonalDataLabel" runat="server" Text="Personal Data" Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>
        <br /><br />
        
        <asp:Label ID="NameLabel" runat="server" Text="Name" Width="100px"></asp:Label>
        <asp:TextBox ID="Name" runat="server" CssClass="textEntry" Width="176px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredName" runat="server" ControlToValidate="Name" 
            CssClass="failureNotification" ErrorMessage="The name is mandatory." ToolTip="The name is mandatory." 
            ValidationGroup="EditUserValidationGroup">*</asp:RequiredFieldValidator>
        <br />
        <br />

        <asp:Label ID="SurnameLabel" runat="server" Text="Surname" Width="100px"></asp:Label>
        <asp:TextBox ID="Surname" runat="server" CssClass="textEntry" Width="176px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredSurname" runat="server" ControlToValidate="Surname" 
            CssClass="failureNotification" ErrorMessage="The surname is mandatory." ToolTip="The surname is mandatory." 
            ValidationGroup="EditUserValidationGroup">*</asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label ID="NationalityLabel" runat="server" Text="Nationality" Width="100px"></asp:Label>
        <asp:DropDownList ID="Nacionalidades" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="AlturaLabel" runat="server" Text="Heigth" Width="100px"></asp:Label>
        <asp:DropDownList ID="Alturas" runat="server" Width="100px"></asp:DropDownList>

        
        <br /><br />

        <asp:Label ID="Label20" runat="server" Text="Body Type" Width="100px"></asp:Label>
        <asp:DropDownList ID="TiposDeCuerpo" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label22" runat="server" Text="Ethnicity" Width="100px"></asp:Label>
        <asp:DropDownList ID="Etnia" runat="server" Width="100px"></asp:DropDownList>


        <br /><br />

        <asp:Label ID="Label23" runat="server" Text="Eye Color" Width="100px"></asp:Label>
        <asp:DropDownList ID="ColorOjos" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label24" runat="server" Text="Hair Color" Width="100px"></asp:Label>
        <asp:DropDownList ID="ColorPelo" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label25" runat="server" Text="Hair Length" Width="100px"></asp:Label>
        <asp:DropDownList ID="LongitudPelo" runat="server" Width="100px"></asp:DropDownList>


        <br /><br />

        <asp:Label ID="Label26" runat="server" Text="Hair Style" Width="100px"></asp:Label>
        <asp:DropDownList ID="EstiloPelo" runat="server" Width="100px"></asp:DropDownList>


        <br /><br />

        <asp:Label ID="Label27" runat="server" Text="Smoke" Width="100px"></asp:Label>
        <asp:DropDownList ID="Fumar" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label28" runat="server" Text="Religion" Width="100px"></asp:Label>
        <asp:DropDownList ID="Religion" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label5" runat="server" Text="Genre" Width="100px"></asp:Label>
        <asp:DropDownList ID="Genero" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="CareerLabel" runat="server" Text="Studies" Width="100px"></asp:Label>
        <asp:DropDownList ID="Carreras" runat="server" Width="305px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="CourseLabel" runat="server" Text="Course" Width="100px"></asp:Label>
        <asp:DropDownList ID="Courses" runat="server" Width="100px"></asp:DropDownList>


        <br /><br /><br />  
         
        <asp:Label ID="Label1" runat="server" Text="BirthDate" Width="100px"></asp:Label>
        <asp:TextBox ID="FechaNacimiento" runat="server" CssClass="textEntry" 
            ToolTip="Example: 02/09/1992" placeholder="Example: 02/09/1992" Width="176px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFechaNacimiento" runat="server" ControlToValidate="FechaNacimiento" 
            CssClass="failureNotification" ErrorMessage="The birthdate is mandatory." ToolTip="The birthdate is mandatory." 
            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionFechaNacimiento" runat="server"
            ControlToValidate="FechaNacimiento" ForeColor=Red ValidationGroup="EditUserValidationGroup"
            ErrorMessage="Incorrect birthdate."
            ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
    
    </div>

    <div style= 'height: 800px; width: 280px; border: 3px; float: left' >  
            
            <asp:Label ID="LookingForLabel" runat="server" Text="Looking For..." Font-Bold="True" 
                        Font-Names="Tahoma" Font-Size="Medium" ForeColor="Silver"></asp:Label>

        <br /><br />

        <asp:Label ID="Label41" runat="server" Text="Genre" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="GeneroBuscado" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Body Type" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="BodyTypeBuscado" runat="server" Width="100px"></asp:DropDownList>
        
        <br /><br />
    
        <asp:Label ID="Label29" runat="server" Text="Ethnicity" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="EthnicityBuscado" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label31" runat="server" Text="Eye Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="EyeColorBuscado" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label33" runat="server" Text="Hair Color" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="HairColorBuscado" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label35" runat="server" Text="Hair Length" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="HairLengthBuscado" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />
    
        <asp:Label ID="Label37" runat="server" Text="Hair Style" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="HairStyleBuscado" runat="server" Width="100px"></asp:DropDownList>

        <br /><br />

        <asp:Label ID="Label39" runat="server" Text="Smoke" Width="100px" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="SmokeBuscado" runat="server" Width="100px"></asp:DropDownList>
            

    </div>
    
    <div style= 'height: 1400px; width: 910px; border: 3px; float: left' >  

        <asp:Label ID="LabelAnimales" runat="server" Text="Pets" BorderColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Font-Strikeout="False" ForeColor="Silver"></asp:Label>
        <asp:Label ID="ErrorAnimales" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <asp:CheckBoxList id="Animales" runat="server" RepeatDirection="Horizontal"
                            CellPadding="5" CellSpacing="5" RepeatColumns="10"></asp:CheckBoxList>
        <br /><br /><br />

        <asp:Label ID="LabelCaracteristicas" runat="server" Text="Features" BorderColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Font-Strikeout="False" ForeColor="Silver"></asp:Label>
        <asp:Label ID="ErrorCaracteristicas" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <asp:CheckBoxList id="Caracteristicas" runat="server" RepeatDirection="Horizontal"
                                CellPadding="5" CellSpacing="5" RepeatColumns="10"></asp:CheckBoxList>
        <br /><br /><br />
    
        <asp:Label ID="LabelCine" runat="server" Text="Film Tastes" BorderColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Font-Strikeout="False" ForeColor="Silver"></asp:Label>
        <asp:Label ID="ErrorCine" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <asp:CheckBoxList id="Cine" runat="server" RepeatDirection="Horizontal" 
                            CellPadding="5" CellSpacing="5" RepeatColumns="10"></asp:CheckBoxList>
        <br /><br /><br />
    
        <asp:Label ID="LabelMusica" runat="server" Text="Music Tastes" BorderColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Font-Strikeout="False" ForeColor="Silver"></asp:Label>
        <asp:Label ID="ErrorMusica" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <asp:CheckBoxList id="Musica" runat="server" RepeatDirection="Horizontal"
                                CellPadding="5" CellSpacing="5" RepeatColumns="10"></asp:CheckBoxList>
        <br /><br /><br />
    
        <asp:Label ID="LabelDeporte" runat="server" Text="Sports" BorderColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Font-Strikeout="False" ForeColor="Silver"></asp:Label>
        <asp:Label ID="ErrorDeportes" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <asp:CheckBoxList id="Deportes" runat="server" RepeatDirection="Horizontal"
                            CellPadding="5" CellSpacing="5" RepeatColumns="10"></asp:CheckBoxList>
        <br /><br /><br />
    
        <asp:Label ID="LabelHobbies" runat="server" Text="Hobbies" BorderColor="#33CCFF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Font-Strikeout="False" ForeColor="Silver"></asp:Label>
        <asp:Label ID="ErrorHobbies" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <asp:CheckBoxList id="Hobbies" runat="server" RepeatDirection="Horizontal"
                            CellPadding="5" CellSpacing="5" RepeatColumns="10"></asp:CheckBoxList>

        <br /><br /><br />
        
        <p>
        <asp:Label ID="LabelComment" runat="server" Text="Something about you"></asp:Label>

        <br />

        <asp:TextBox ID="Comment" runat="server" CssClass="textEntry" 
            TextMode="MultiLine" Height="191px" Width="340px"></asp:TextBox>
        </p>
        <p>
        <asp:RegularExpressionValidator ID="CommentValidator" runat="server"             
            ErrorMessage="The maximum characters allowed are 200"            
            ValidationExpression="^([\S\s]{0,200})$" ValidationGroup="EditUserValidationGroup"           
            ControlToValidate="Comment" ForeColor=Red          
            Display="Dynamic"></asp:RegularExpressionValidator>
                    
        <br />
        </p>
        
    </div>

    <br /><br />

    <div style= 'height: 50px; width: 800px; border: 3px; float: Right' >  
        
        <asp:Button ID="ButtonActualizar" runat="server" Text="Update Profile" OnClick="ButtonActualizar_Click" class="button" ValidationGroup="EditUserValidationGroup" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="CancelPushButton" runat="server" class='button' CausesValidation="False" CommandName="Cancel" Text="Cancel"
                        OnClick="Cancel_Click"/>
    </div>    

 </asp:Content>
