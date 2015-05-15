<%@ Page Title="EliminarPerfil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="EliminarPerfil.aspx.cs" Inherits="WebApplication1.EliminarPerfil" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Delete User
    </h2>
    
    
    <br />
    <asp:Label ID="ErrorEliminar" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

   <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="DeleteUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="DeleteUserValidationGroup"/>

            <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonEliminar">
                <div class="accountInfo">
                    <fieldset class="changePassword" style="background-color: #FBFDFF">
                        <legend>Account Information</legend>
                        <p>
                            <asp:Label ID="UsernameLabel" Text="Nickname:  " runat="server"></asp:Label>
                            <asp:Label ID="Username" runat="server" ></asp:Label>
                        
                        </p>

                        <p>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Introduce the password:</asp:Label>
                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                 CssClass="failureNotification" ErrorMessage="The password is mandatory." ToolTip="The password is mandatory." 
                                 ValidationGroup="DeleteUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm the password:</asp:Label>
                            <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" 
                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="The confirmation of the password is mandatory."
                                 ToolTip="The confirmation of the password is mandatory." ValidationGroup="DeleteUserValidationGroup">*</asp:RequiredFieldValidator>
                        
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="The password and the confirmation password does not match."
                                 ValidationGroup="DeleteUserValidationGroup">*</asp:CompareValidator>
                        </p>
                    </fieldset>
                    <p class="submitButton">
                        <asp:Button ID="ButtonCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" class="button"/>
                        <asp:Button ID="ButtonEliminar" runat="server" CommandName="ChangePassword" Text="Delete Profile" 
                             ValidationGroup="DeleteUserValidationGroup" OnClick="ButtonEliminar_Click" class="button"/>
                    </p>
                </div>
            </asp:Panel>

 </asp:Content>
