<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebApplication1.ForgotPassword" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Forgotten your password?
    </h2>
    <p>
        <asp:Label ID="Description" runat="server" Text="Please introduce your nickname and your email to start the recover password process."></asp:Label>
        <asp:Label ID="Description2" runat="server" Text=""></asp:Label>
        <asp:Label ID="Description3" runat="server" Text=""></asp:Label>
     </p>

     <p>
        <asp:Label ID="ErrorValidacion" runat="server" CssClass="failureNotification"></asp:Label>
    </p>

     <% if (Description.Text != "")
        { %>

    <p>

        <asp:Label ID="NicknameLabel" runat="server" AssociatedControlID="Nickname">Nickname</asp:Label>
        <br />
        <asp:TextBox ID="Nickname" runat="server" class="textEntry" Width="320px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NicknameRequired" runat="server" ControlToValidate="Nickname" 
                CssClass="failureNotification" ErrorMessage="The nickname is mandatory." ToolTip="The nickname is mandatory." 
                ValidationGroup="ForgotValidation">*</asp:RequiredFieldValidator>
        <br />
    </p>
    <p>
    
        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email</asp:Label>
        <br />
        <asp:TextBox ID="Email" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                CssClass="failureNotification" ErrorMessage="The email is mandatory." ToolTip="The email is mandatory." 
                ValidationGroup="ForgotValidation">*</asp:RequiredFieldValidator>
        <br />
    
    </p>

    <p>
        <asp:Button ID="ContinueButton" runat="server" class='button' Text="Continue" ValidationGroup="ForgotValidation" onclick="ContinueButton_Click" />
        <asp:Button ID="ValidationCodeLink" runat="server" class='button' Text="I already have a validation code" onclick="ValidationCodeButton_Click" />
    </p>

    <% }
        else if (Description2.Text != "")
        { %>

    <p>

        <asp:Label ID="Nickname2Label" runat="server" AssociatedControlID="Nickname2">Nickname</asp:Label>
        <br />
        <asp:TextBox ID="Nickname2" runat="server" class="textEntry" Width="320px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Nickname2" 
                CssClass="failureNotification" ErrorMessage="The nickname is mandatory." ToolTip="The nickname is mandatory." 
                ValidationGroup="ForgotValidation2">*</asp:RequiredFieldValidator>
        <br />
    </p>
    <p>

        <asp:Label ID="ValidationLabel" runat="server" AssociatedControlID="Validation">Validation code</asp:Label>
        <br />
        <asp:TextBox ID="Validation" runat="server" class="textEntry" Width="320px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredValidation" runat="server" ControlToValidate="Validation" 
                CssClass="failureNotification" ErrorMessage="The validation code is mandatory." ToolTip="The validation code is mandatory." 
                ValidationGroup="ForgotValidation2">*</asp:RequiredFieldValidator>
        <br />
    </p>
    <p>
        <asp:Label ID="NewPasswordRecoverLabel" runat="server" AssociatedControlID="NewPasswordRecover">New password</asp:Label>                  
        <br />
        <asp:TextBox ID="NewPasswordRecover" runat="server" CssClass="passwordEntry" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
        <asp:RequiredFieldValidator ID="NewPasswordRecoverRequired" runat="server" ControlToValidate="NewPasswordRecover" 
                CssClass="failureNotification" ErrorMessage="The new password is mandatory." ToolTip="The new password is mandatory." 
                ValidationGroup="ForgotValidation2">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="NewPasswordRecoverRequiredSize" runat="server"
            ControlToValidate="NewPasswordRecover" ForeColor=Red
            ErrorMessage="Incorrect password. It must have almost 6 alphanumeric characters."
            ValidationExpression="^[a-zA-Z0-9]{6,}$" ValidationGroup="ForgotValidation2"></asp:RegularExpressionValidator>
                          
    </p>

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
        <asp:Label ID="ConfirmNewPasswordRecoverLabel" runat="server" AssociatedControlID="ConfirmNewPasswordRecover">Confirm the new password</asp:Label>
        <br />
        <asp:TextBox ID="ConfirmNewPasswordRecover" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRecoverRequired" runat="server" ControlToValidate="ConfirmNewPasswordRecover" 
                CssClass="failureNotification" Display="Dynamic" ErrorMessage="The confirm password is mandatory."
                ToolTip="The confirm password is mandatory." ValidationGroup="ForgotValidation2">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="NewPasswordCompareRecover" runat="server" ControlToCompare="NewPasswordRecover" ControlToValidate="ConfirmNewPasswordRecover" 
                CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm the password must match with the new password."
                ValidationGroup="ForgotValidation2">*</asp:CompareValidator>
    </p>

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>
        $("#NewPasswordRecover").on("focus keyup", function () {
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

        $("#NewPasswordRecover").blur(function () {
            $("#pwd_strength_wrap").fadeOut(400);
        });
    </script>
    <br />

    <p style="text-align: left; margin-left: 5%;">
        <asp:Button ID="SubmitButton" runat="server" class='button' Text="Submit" ValidationGroup="ForgotValidation2" onclick="SubmitButton_Click" />
    </p>

    

    <% } %>

</asp:Content>

