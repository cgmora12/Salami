using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.CAD.Salami4UA;
using System.Net.Mail;

namespace WebApplication1
{
    public partial class VerPerfil : System.Web.UI.Page
    {
        private String admin = "admin";
        String nick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                //String nick = Session["Login"].ToString();
                nick = HttpContext.Current.Request.Url.AbsolutePath.Replace("/VerPerfil.aspx","");
                String user = Session["Login"].ToString();

                if(user == admin){
                    BotonEliminarAdmin.Visible = true;
                    btnShow.Visible = false;
                }

                try
                {
                    nick = nick.TrimStart('/');
                }
                catch (Exception ex) { }

                try
                {
                    UsuarioCEN usuario = new UsuarioCEN();
                    IList<UsuarioEN> usuarios = usuario.DameUsuarioPorNickname(nick);

                    if (usuarios.Count == 0)
                    {
                        VerPerfilError.Text = "0 Salami's found with this nickname " + nick;
                    }

                    foreach (UsuarioEN us in usuarios)
                    {

                        ImagenPerfil.ImageUrl = us.UrlFoto;
                        Nickname.Text = nick;
                        Name.Text = us.Name;
                        Surname.Text = us.Surname;
                        Genero.Text = us.Gender.ToString();
                        Orientacion.Text = us.Likes.ToString();
                        Nationality.Text = us.Nationality;
                        Height.Text = us.Height.ToString();
                        BodyType.Text = us.BodyType.ToString();
                        Ethnicity.Text = us.Ethnicity.ToString();
                        EyeColor.Text = us.EyeColor.ToString();
                        HairColor.Text = us.HairColor.ToString();
                        HairLength.Text = us.HairLength.ToString();
                        HairStyle.Text = us.HairStyle.ToString();
                        Smoke.Text = us.Smoke.ToString();
                        Religion.Text = us.Religion.ToString();
                        Birth.Text = Convert.ToString(us.Birthday).Substring(0, 10);
                        StudiesLabel.Text = us.Career;
                        CourseLabel.Text = us.Course.ToString();

                        if (us.Comment != "")
                        {
                            CommentLabel.Text = "About me";
                            Comment.Text = us.Comment;
                        }
                        // Las multiples opciones

                        // Animales

                        AnimalesCEN petcen = new AnimalesCEN();
                        IList<AnimalesEN> animales = petcen.DameAnimalesPorUsuario(us.Nickname);

                        string s = "";
                        bool primero = true;
                        foreach (AnimalesEN animal in animales)
                        {
                            if (primero)
                            {
                                primero = false;
                                s = animal.Name;
                            }

                            else
                            {
                                s += ", " + animal.Name;
                            }
                        }

                        Pets.Text = s;


                        // Caracteristicas                         
                        IList<CaracteristicasEN> caracteristicasEN = new CaracteristicasCEN().DameCaracteristicasPorUsuario(us.Nickname);
                        s = ""; primero = true;
                        foreach (CaracteristicasEN caracteristica in caracteristicasEN)
                        {
                            if (primero)
                            {
                                primero = false;
                                s = caracteristica.Name;
                            }

                            else
                            {
                                s += ", " + caracteristica.Name;
                            }
                        }
                        Features.Text = s;

                        // Generos Cine                         
                        IList<CinesEN> generosCinesEN = new CinesCEN().DameGenerosDeCinePorUsuario(us.Nickname);
                        s = ""; primero = true;
                        foreach (CinesEN cine in generosCinesEN)
                        {
                            if (primero)
                            {
                                primero = false;
                                s = cine.Name;
                            }

                            else
                            {
                                s += ", " + cine.Name;
                            }
                        }
                        Film.Text = s;

                        // Musica
                        IList<MusicasEN> MusicasEN = new MusicasCEN().DameGustosMusicalesPorUsuario(us.Nickname);
                        s = ""; primero = true;
                        foreach (MusicasEN musica in MusicasEN)
                        {
                            if (primero)
                            {
                                primero = false;
                                s = musica.Name;
                            }

                            else
                            {
                                s += ", " + musica.Name;
                            }
                        }
                        Music.Text = s;

                        // Deportes
                        IList<DeportesEN> deportesEN = new DeportesCEN().DameDeportesPorUsuario(us.Nickname);
                        s = ""; primero = true;
                        foreach (DeportesEN deporte in deportesEN)
                        {
                            if (primero)
                            {
                                primero = false;
                                s = deporte.Name;
                            }

                            else
                            {
                                s += ", " + deporte.Name;
                            }
                        }
                        Sports.Text = s;

                        // Hobbies
                        IList<AficionesEN> AficionesEN = new AficionesCEN().DameHobbiesPorUsuario(us.Nickname);
                        s = ""; primero = true;
                        foreach (AficionesEN hobbie in AficionesEN)
                        {
                            if (primero)
                            {
                                primero = false;
                                s = hobbie.Name;
                            }

                            else
                            {
                                s += ", " + hobbie.Name;
                            }
                        }
                        Hobbies.Text = s;

                    }



                }
                catch (Exception ex)
                {
                }
            }

            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }


        protected void popUpOpen_Click(object sender, EventArgs e)
        {
            String nick = HttpContext.Current.Request.Url.AbsolutePath.Replace("/VerPerfil.aspx/", "");
            NicknameReport.Text = nick;
            CauseDropDownList.Items.Insert(0, "Phishing");
            CauseDropDownList.Items.Insert(1, "Under-age");
            CauseDropDownList.Items.Insert(2, "Harassment");
            CauseDropDownList.Items.Insert(3, "Spam");
            CauseDropDownList.Items.Insert(4, "Annoying messages");
            CauseDropDownList.Items.Insert(5, "Others");
            mp1.Show();
        }

        // function that sends an email to our gmail account
        // SEND ALSO AN EMAIL TO THE REPORTED USER AND  A MESSAGE TO THE ADMIN
        protected void send_Click(object sender, EventArgs e)
        {

            String nick = HttpContext.Current.Request.Url.AbsolutePath.Replace("/VerPerfil.aspx/", "");

            // Message and email to admin
            try
            {
                string user = (string)Session["login"];
                string msg = NicknameReport.Text + " has been reported by " + user + " because of " +
                    CauseDropDownList.SelectedItem.Text.ToLower();

                MensajesCEN mensajeCen = new MensajesCEN();
                mensajeCen.New_(msg, nick, admin);

            }
            catch (Exception)
            {
                LabelReport.Text = "Error sending the message!";
            }
            
            try
            {
                Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN usuario = new Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> user = new List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                user = usuario.DameUsuarioPorNickname(NicknameReport.Text);
                Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN usuario1 = user.ElementAt(0);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("salami4ua@gmail.com");
                MailAddress toAddress = new MailAddress("salami4ua@gmail.com", nick);
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = "Salami 4UA - Report user";
                message.Body = "The user " + Session["login"] + " has reported " + NicknameReport.Text + " because of " +
                    CauseDropDownList.SelectedItem.Text.ToLower() + ".\nAdditional comment: " + ArgumentReport.Text + ".\n";
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("salami4ua@gmail.com", "salamiforua");
                smtpClient.Send(message);
                LabelReport.Text = "Message sended.";

                // Message to the reported user email
                SmtpClient smtpClient2 = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message2 = new MailMessage();
            
                MailAddress fromAddress2 = new MailAddress("salami4ua@gmail.com", "Salami4UA");
                MailAddress toAddress2 = new MailAddress(usuario1.Email, NicknameReport.Text);
                message2.From = fromAddress2;
                message2.To.Add(toAddress2);
                message2.Subject = "Salami 4UA - Reported user";
                message2.Body = "Hello " + NicknameReport.Text + ". We are sending this email from Salami4UA because you have been reported by " +
                    CauseDropDownList.SelectedItem.Text.ToLower() + ".\n If you don't change your behaviour, we will delete your account.\n" +
                    "\nSorry for the inconvenience and enjoy your experience in Salami4UA.\n";
                smtpClient2.EnableSsl = true;
                smtpClient2.Credentials = new System.Net.NetworkCredential("salami4ua@gmail.com", "salamiforua");

                smtpClient2.Send(message2);

                mp1.Hide();

            }
            catch (Exception ex)
            {
                LabelReport.Text = "The user does not exist!";
            }
        }

        protected void close_Click(object sender, EventArgs e)
        {
            mp1.Hide();
        }

        protected void BotonEliminarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                String url = "~/EliminarPerfil.aspx/" + nick;
                Response.Redirect(url);
            }
            catch (Exception) { }
        }

        protected void ButtonEnviarMensaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SendMessage.aspx?msgTo=" + nick);
        }

        protected void ButtonEnviarPinchito_Click(object sender, EventArgs e)
        {
        }
    }

}