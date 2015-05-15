using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.EN.Salami4UA;
using System.Net.Mail;

namespace WebApplication1.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {

                String nick = Session["Login"].ToString();

                try
                {
                    UsuarioCEN usuario = new UsuarioCEN();
                    IList<UsuarioEN> usuarios = usuario.DameUsuarioPorNickname(nick);

                    foreach (UsuarioEN us in usuarios)
                    {
                        Username.Text = nick;
                    }
                }
                catch (Exception ex) { }
            }

            LoginOk.Text = "";
            LoginFail.Text = "";
        }

        protected void Continuar_Click(object sender, EventArgs e)
        {
            Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN usuario = new Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN();
            try
            {

                if (usuario.CambiarPassword(Username.Text, Login.GetMd5Hash(CurrentPassword.Text), Login.GetMd5Hash(NewPassword.Text)))
                {

                    LoginOk.Text = "The password has been changed!";

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    MailMessage message = new MailMessage();
                    try
                    {
                        IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> user = new List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                        user = usuario.DameUsuarioPorNickname(Username.Text);
                        Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN usuario1 = user.ElementAt(0);
                        

                        MailAddress fromAddress = new MailAddress("salami4ua@gmail.com", "Salami4UA");
                        MailAddress toAddress = new MailAddress(usuario1.Email, Username.Text);
                        message.From = fromAddress;
                        message.To.Add(toAddress);
                        message.Subject = "Salami4ua - Change password";
                        message.Body = "Your password has been changed. Thank you for using Salami4UA as " + Username.Text + ". \n\n " +
                            "Please click the following link: \n http://localhost:49837/Account/Login.aspx"+
                            "\n\n Regards, Salami4UA Team.";
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new System.Net.NetworkCredential("salami4ua@gmail.com", "salamiforua");

                        smtpClient.Send(message);

                        LoginFail.Text = "";
                        Username.Text = "";

                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
                else
                {
                    LoginFail.Text = "Error in username or password, try again.";
                    LoginOk.Text = "";
                }
            }

            catch (Exception e1)
            {
                LoginFail.Text = "Error in username or password, try again.";
                LoginOk.Text = "";
            }
        }


        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Perfil.aspx");
        }
    }
}
