<%@ Page Title="Buscar" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Buscar.aspx.cs" Inherits="WebApplication1.Buscar" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2>
            Search
        </h2>
    
            <% if (Session["login"] != null){ %>
    <p>
        Select your preferences to find your ideal salami.&nbsp;
        
       
        <asp:RadioButton id="StrictSearch" Text="Strict search" Checked="True" GroupName="SearchType" runat="server" />&nbsp;&nbsp;&nbsp;
        <asp:RadioButton id="CalmSearch" Text="Calm search"  GroupName="SearchType" runat="server" /> 
    </p>
        <span class="failureNotification">
            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
        </span>
        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                ValidationGroup="RegisterUserValidationGroup"/>

        <asp:Panel ID="Panel1" runat="server" DefaultButton="BuscarButton">
            <div class="accountInfo">
                <fieldset class="filter">
                    <legend>Filter</legend>
                    <p>
                        <asp:RadioButton id="RadioWoman" Text="Woman" Checked="True" GroupName="RadioGroup1" runat="server" />
                        <asp:RadioButton id="RadioMan" Text="Man" GroupName="RadioGroup1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         Interested in me?
                        <asp:CheckBox ID="Interested" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Age between:&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="MinAge" runat="server" Width="34px" ToolTip="Number Please"></asp:TextBox>

                        &nbsp;&nbsp;&nbsp; and &nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:TextBox ID="MaxAge" runat="server" Width="34px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CompareValidator runat="server" ID="CompareValidator1" ForeColor="Red" ControlToValidate="MinAge" Type="Integer" Operator="DataTypeCheck" ErrorMessage="You must enter a number." />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CompareValidator runat="server" ID="valNumber"  ForeColor="Red" ControlToValidate="MaxAge" Type="Integer" Operator="DataTypeCheck" ErrorMessage="You must enter a number." />
                    

                        <br /><br />

                        <asp:Label ID="NationalityLabel" runat="server">Nationality: </asp:Label>
                        <asp:DropDownList ID="NacionalidadList" runat="server"></asp:DropDownList>

                        &nbsp;&nbsp;

                        <asp:Label ID="BodyTypeLabel" runat="server">Body type: </asp:Label>
                        <asp:DropDownList ID="TiposDeCuerpo" runat="server"> </asp:DropDownList>

                        &nbsp;&nbsp;

                        <asp:Label ID="AlturaLabel" runat="server">Height: </asp:Label>
                        <asp:DropDownList ID="Height" runat="server"></asp:DropDownList>
                    
                        &nbsp;&nbsp;

                        <asp:Label ID="EthnicityLabel" runat="server">Ethnicity: </asp:Label>
                        <asp:DropDownList ID="Etnia" runat="server" style="margin-left: 0px"></asp:DropDownList>

                         &nbsp;&nbsp;

                        <asp:Label ID="EyeColorLabel" runat="server">Eye Color: </asp:Label>
                        <asp:DropDownList ID="ColorOjos" runat="server" Height="16px" style="margin-left: 0px"> </asp:DropDownList>
           
                        <br /><br />

                        <asp:Label ID="HairColorLabel" runat="server">Hair Color: </asp:Label>
                        <asp:DropDownList ID="ColorPelo" runat="server"> </asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;

                        <asp:Label ID="HairLength" runat="server">Hair length: </asp:Label>
                        <asp:DropDownList ID="LongitudPelo" runat="server"></asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;

                        <asp:Label ID="HairStyleLabel" runat="server">Hair style: </asp:Label>
                        <asp:DropDownList ID="EstiloPelo" runat="server"> </asp:DropDownList>

                        &nbsp;&nbsp;&nbsp;

                        <asp:Label ID="ReligionLabel" runat="server">Religion: </asp:Label>
                        <asp:DropDownList ID="Religion" runat="server"> </asp:DropDownList>
                    
                        &nbsp;&nbsp;&nbsp;

                        <asp:Label ID="SmokeLabel" runat="server">Smoke: </asp:Label>
                        <asp:DropDownList ID="Fumador" runat="server"> </asp:DropDownList>

                        <br /><br />
                    </p>
                
                
                    <p class="submitButton">
                        <asp:Button Style="float:left" ID="ButtonRecomend" runat="server" class="button"  Text="See perfect match" OnClick="Recomend_Click"/>
                        <asp:Button Style="float:right" ID="BuscarButton" runat="server" class="button" CommandName="MoveNext" Text="Search" OnClick="Search_Click"/>
                    </p>
                            
                </fieldset>

            </div>
        </asp:Panel>
    
        <div class="resoultInfo" style="margin-left: 10px">
            <h3>
                <asp:Label ID="LabelSalami" runat="server"></asp:Label>
            </h3>
            <br />

            <!--
            <asp:Table ID="Tabla" runat="server" BorderWidth="1" >
            </asp:Table> 
            -->

            <asp:GridView ID="GridView1" runat="server"
                 AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" >
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" BorderColor="White" BorderStyle="Solid" 
                    BorderWidth="2px" BackColor="#EFF3FB" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                           <asp:ImageButton ID="ImagenPerfilBuscador" runat="server" Height="70px" Width="70px" 
                                    PostBackUrl='<%#"VerPerfil.aspx/" + Eval("Nickname") %>' ImageUrl='<%# Eval("UrlFoto") %>'/>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nickname">
                        <ItemTemplate>
                           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"VerPerfil.aspx/" + Eval("Nickname") %>' 
                                            Text='<%#Bind("Nickname") %>'></asp:HyperLink>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" />
                    <asp:BoundField DataField="Gender" HeaderText="Genre" />
                    <asp:BoundField DataField="Likes" HeaderText="Interested in" />
                    <asp:TemplateField HeaderText="Birthday">
                        <ItemTemplate>
                            <asp:Label ID="BirthLabel" runat="server" Text='<%# ChopString(Eval("Birthday").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
            </asp:ObjectDataSource>
            <br /><br />

        </div>
        
                 <% }
                   else
                   { 
                 %>
    
    <p>
        Please <a href="/Account/Login.aspx">Log in</a> to use this function
    </p>

                  <% }   %>

</asp:Content>
