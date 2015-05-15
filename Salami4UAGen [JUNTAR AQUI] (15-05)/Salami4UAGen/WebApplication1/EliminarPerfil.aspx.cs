using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.CAD.Salami4UA;
using Salami4UAGenNHibernate.Enumerated;
using Salami4UAGenNHibernate.Exceptions;
using Salami4UAGenNHibernate.Properties;
using Salami4UAGenNHibernate.Utils;
using System.Net.Mail;

namespace WebApplication1
{
    public partial class EliminarPerfil : System.Web.UI.Page
    {
        private String admin = "admin";
        private String nick = "";
        private String userDeleted = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Login"] != null)
                {
                    if (Session["Login"].ToString() == admin)
                    {
                        userDeleted = HttpContext.Current.Request.Url.AbsolutePath.Replace("/EliminarPerfil.aspx", "");

                        try
                        {
                            userDeleted = userDeleted.TrimStart('/');
                            Username.Text = userDeleted;
                        }
                        catch (Exception ex) { }

                    }
                    else
                    {
                        nick = Session["Login"].ToString();
                        Username.Text = nick;
                    }
                }
                
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
            catch (Exception)
            {
            }

        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {

            nick = Session["Login"].ToString();
            Exception exp = null;
            bool passwordCorrecto = false;

            try
            {
                //userDeleted = HttpContext.Current.Request.Url.AbsolutePath.Replace("/EliminarPerfil.aspx", "");

                UsuarioCEN usuarioCEN = new UsuarioCEN();

                UsuarioCAD UsuarioCAD = new UsuarioCAD();
                UsuarioEN usuarioEN = UsuarioCAD.ReadOIDDefault(nick);

                if (usuarioCEN.ValidationUser(nick, Account.Login.GetMd5Hash(Password.Text)))
                {
                    passwordCorrecto = true;

                    if (userDeleted != "")
                    {
                        sendMessage(userDeleted);
                        usuarioCEN.Destroy(userDeleted);
                        Response.Redirect("~/Admin.aspx");
                    }
                    else
                    {
                        usuarioCEN.Destroy(nick);
                        //Session.Clear();
                    }
                }

                else
                {
                    ErrorEliminar.Text = "ERROR: The user and the password don't match";
                }

               
                
            }
            catch (Exception ex)
            {
                ErrorEliminar.Text = "ERROR: The user could not be deleted";
                exp = ex;
            }

            try
            {

                if (exp == null && passwordCorrecto)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
            catch (Exception ex)
            { }
          
        }

        protected void sendMessage(string deleted)
        {
            Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN usuario = new Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN();
            IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> user = new List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
            user = usuario.DameUsuarioPorNickname(deleted);
            Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN usuario1 = user.ElementAt(0);

            // Message to the deleted user email
            SmtpClient smtpClient2 = new SmtpClient("smtp.gmail.com", 587);
            MailMessage message2 = new MailMessage();

            MailAddress fromAddress2 = new MailAddress("salami4ua@gmail.com", "Salami4UA");
            MailAddress toAddress2 = new MailAddress(usuario1.Email, deleted);
            message2.From = fromAddress2;
            message2.To.Add(toAddress2);
            message2.Subject = "Salami 4UA - Deleted user";
            message2.Body = "Hello " + deleted + ". We are sending this email from Salami4UA because you have been deleted from the page.\n"
                + "This may have been caused by some reports to your user or because a bad behaviour in the page.\n" + 
                "If you disagree, please answer this mail and we will check it.\n\n" + "Regards, Salami4UA.";
            smtpClient2.EnableSsl = true;
            smtpClient2.Credentials = new System.Net.NetworkCredential("salami4ua@gmail.com", "salamiforua");

            smtpClient2.Send(message2);
        }
     }
 }
