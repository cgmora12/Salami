<%@ Page Title="Change password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="WebApplication1.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Change password
    </h2>
    <p>
        <asp:Label ID="LoginOk" runat="server" ForeColor="Green"></asp:Label>
        <asp:Label ID="LoginFail" runat="server" ForeColor="Red"></asp:Label>
    </p>
    
    <% if (LoginOk.Text == "") { %>
    
    <p>
        Use the following form to change your password.
    </p>
    <p>
        The old password is required and the new passwords must match and have at least <%= Membership.MinRequiredPasswordLength %> characters.
    </p>
    
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ChangeUserPasswordValidationGroup"/>
            
            
            <asp:Panel ID="Panel1" runat="server" DefaultButton="ChangePasswordPushButton">
                <div class="accountInfo">
                    <fieldset class="changePassword" style="background-color:#FBFDFF">
                        <legend>Account info</legend>
                        <p>
                            <asp:Label ID="UsernameLabel" runat="server" AssociatedControlID="Username">Username:</asp:Label>
                            <asp:TextBox ID="Username" runat="server" CssClass="textEntry" Width="320px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Username" 
                                 CssClass="failureNotification" ErrorMessage="The username is mandatory." ToolTip="The username is mandatory." 
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        </p>

                        <p>
                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old password:</asp:Label>
                            <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                                 CssClass="failureNotification" ErrorMessage="The old password is mandatory." ToolTip="The old password is mandatory." 
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New password:</asp:Label>
                            <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                                 CssClass="failureNotification" ErrorMessage="The new password is mandatory." ToolTip="The new password is mandatory." 
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NewPasswordRequiredSize" runat="server"
                                ControlToValidate="NewPassword" ForeColor=Red
                                ErrorMessage="Incorrect password. It must have almost 6 alphanumeric characters."
                                ValidationExpression="^[a-zA-Z0-9]{6,}$" ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RegularExpressionValidator>
                          
                        </p>
                        <br />

                        <p id="passwordDescription"></p>
                        <p id="passwordStrength"></p>
                        <p id="pswd_info">
                            <strong>Strong Password Tips:</strong>
                            <ul>
                                    <li class="invalid" id="length">At least 6 characters</li>
                                    <li class="invalid" id="pnum">At least one number</li>
                                    <li class="invalid" id="capital">At least one lowercase &amp; one uppercase letter</li>
                                    <li class="invalid" id="spchar">At least one special character</li>
                            </ul>
                        </p>
                    
                        <br /><br />
                        <p>
                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm the new password:</asp:Label>
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="The confirm password is mandatory."
                                 ToolTip="The confirm password is mandatory." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm the password must match with the new password."
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                        </p>
                    </fieldset>
                    <p style="margin-left: 5%">
                    
                        <asp:Button ID="ChangePasswordPushButton" runat="server" class='button' CommandName="ChangePassword" Text="Change Password" 
                                ValidationGroup="ChangeUserPasswordValidationGroup" OnClick="Continuar_Click"/>
                        <asp:Button ID="CancelPushButton" runat="server" class='button' CausesValidation="False" CommandName="Cancel" Text="Cancel"
                            OnClick="Cancel_Click"/>
                        <br />
                    </p>
                
                </div>
            </asp:Panel>
    

   
<br />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>
        $("#NewPassword").on("focus keyup", function () {
            var score = 0;
            var a = $(this).val();
            var desc = new Array();

            // strength desc
            desc[0] = "Too short";
            desc[1] = "Weak";
            desc[2] = "Good";
            desc[3] = "Strong";
            desc[4] = "Best";

            $("#pwd_strength_wrap").fadeIn(400);

            // password length
            if (a.length >= 6) {
                $("#length").removeClass("invalid").addClass("valid");
                score++;
            } else {
                $("#length").removeClass("valid").addClass("invalid");
            }

            // at least 1 digit in password
            if (a.match(/\d/)) {
                $("#pnum").removeClass("invalid").addClass("valid");
                score++;
            } else {
                $("#pnum").removeClass("valid").addClass("invalid");
            }

            // at least 1 capital & lower letter in password
            if (a.match(/[A-Z]/) && a.match(/[a-z]/)) {
                $("#capital").removeClass("invalid").addClass("valid");
                score++;
            } else {
                $("#capital").removeClass("valid").addClass("invalid");
            }

            // at least 1 special character in password {
            if (a.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/)) {
                $("#spchar").removeClass("invalid").addClass("valid");
                score++;
            } else {
                $("#spchar").removeClass("valid").addClass("invalid");
            }


            if (a.length > 0) {
                //show strength text
                $("#passwordDescription").text(desc[score]);
                // show indicator
                $("#passwordStrength").removeClass().addClass("strength" + score);
            } else {
                $("#passwordDescription").text("Password not entered");
                $("#passwordStrength").removeClass().addClass("strength");
            }
        });

        $("#NewPassword").blur(function () {
            $("#pwd_strength_wrap").fadeOut(400);
        });
    </script>
    <br />

    <% }  %>
</asp:Content>
