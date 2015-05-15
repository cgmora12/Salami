using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.EN.Salami4UA;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private String admin = "admin";
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            ForgotPasswordLink.NavigateUrl = "~/ForgotPassword.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            Session.Clear();
        }


        public static string GetMd5Hash(string input)
        {

            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        protected void LoginButton_Click(object LoginButton, EventArgs e)
        {
            try
            {
                UsuarioCEN usuario = new UsuarioCEN();
                
                if (usuario.ValidationUser(LoginUser.UserName, GetMd5Hash(LoginUser.Password)))
                {
                    //Check if it is the admin user
                    try{
                        IList<UsuarioEN> usu = usuario.DameUsuarioPorNickname(LoginUser.UserName);
                    
                        UsuarioEN u = usu.ElementAt(0);
                        if(String.Compare(u.Nickname, admin) == 0){
                            ErrorValidacion.Text = "";
                            Session["login"] = LoginUser.UserName;
                            Response.Redirect("~/Admin.aspx");
                        }


                    }catch(Exception){}

                    //Check if it is a new user
                    try
                    {
                        IList<UsuarioEN> usu = usuario.DameUsuarioPorNickname(LoginUser.UserName);

                        UsuarioEN u = usu.ElementAt(0);
                        if (String.Compare(u.ValidationCode , "NotValidated") == 0)
                        {
                            usuario.AddValidation(u.Nickname, "");
                            string msg = u.Nickname + " has validated his account.";

                            MensajesCEN mensajeCen = new MensajesCEN();
                            mensajeCen.New_(msg, u.Nickname, admin);
                        }


                    }
                    catch (Exception) { }
                    
                    ErrorValidacion.Text = "";
                    Session["login"] = LoginUser.UserName;
                    Response.Redirect("~/Default.aspx");
                }

                else
                {
                    ErrorValidacion.Text = "The nickname or the password are wrong.";
                }



            }
            catch (Exception ex)
            {
                ErrorValidacion.Text = "The nickname or the password are wrong.";
            }
        }

        protected void change_password(object changeButton, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

    }
}
