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
    public partial class SendMessage : System.Web.UI.Page
    {
        private string nick;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                //String nick = Session["Login"].ToString();
                nick = HttpContext.Current.Request.QueryString.Get("msgTo");
                

                try
                {
                    UsuarioCEN usuario = new UsuarioCEN();
                    IList<UsuarioEN> usuarios = usuario.DameUsuarioPorNickname(nick);

                    if (usuarios.Count == 0)
                    {
                        VerPerfilError.Text = "No Salamis found with this nickname " + nick;
                    }
                    else
                    {
                        SubtitleLabel.Text = "Messages with " + nick;

                        UsuarioEN userDst = usuarios[0];
                        {
                            string logedUser = (string)Session["Login"];
                            ImagenPerfilButton.ImageUrl = userDst.UrlFoto;
                            ImagenPerfilButton.PostBackUrl = "~/VerPerfil.aspx/" + userDst.Nickname;
                            MensajesCEN cen = new MensajesCEN();
                            IList<MensajesEN> mensajes, enviados;

                            mensajes = cen.DameTodosLosMensajesEntreUsuarios(logedUser, nick);
                            enviados = cen.DameTodosLosMensajesEnviadosPorUsuario(logedUser);

                            if (mensajes.Count == 0)
                            {
                                Label l = new Label();
                                l.Text = "There are no messages yet";

                                divMessages.Controls.Add(l);
                            }
                            else
                            {
                                foreach (MensajesEN m in mensajes)
                                {
                                    String text = m.Message, aux;
                                    int tam = 80;

                                    for (int i = 0; i < text.Length; i += tam)
                                    {
                                        aux = text.Substring(i);
                                        if (aux.Length > tam)
                                        {
                                            try
                                            {
                                                addMessage(enviados.Contains(m), aux.Substring(0, tam));
                                                //addMessage(enviados.Contains(m), text.Substring(tam));
                                            }
                                            catch (Exception) { }
                                        }
                                        else
                                            addMessage(enviados.Contains(m), aux);
                                    }
                                    
                                }
                            }
                        }
                    }

                }
                catch (Exception)
                {
                }
            }

            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        private void addMessage(bool send, string text)
        {
            Label l = new Label();
            l.Text = text;

            l.Style.Add("-webkit-border-radius", "15px 15px 15px 15px");
            l.Style.Add("-moz-border-radius", "15px 15px 15px 15px");
            l.Style.Add("border-radius", "15px 15px 15px 15px");
            l.Style.Add("padding", "0px 5px 0px 5px");
            l.Style.Add("margin-bottom", "3px");

            if (send)
            {
                l.Style.Add("background-color", "LightSkyBlue");
                l.Style.Add("float", "right");
            }
            else
            {
                l.Style.Add("background-color", "LightGreen");
                l.Style.Add("float", "left");
            }

            l.Style.Add("clear", "both");

            divMessages.Controls.Add(l);
        }




        protected void sendMessage_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                msg = textSend.Text;
                string user = (string)Session["login"];
                MensajesCEN mensajeCen = new MensajesCEN();

                mensajeCen.New_(msg, user, nick);

                //addMessage(true, msg);

                textSend.Text = "";
                LabelReport.Text = "";

                Response.Redirect("~/SendMessage.aspx?msgTo=" + nick);
            }
            catch (Exception)
            {
                LabelReport.Text = "Error sending the message, the message is too long.";
                textSend.Text = msg;
            }
        }

        /*protected void scrollToDiv()
        {
           document.getElementById().scrollIntoView();
        }*/

        /*protected void ScrollToBottom(object sender, EventArgs e)
        {
            divMessages.scrollTo(0, document.body.scrollHeight);
            
        }*/

    }

}