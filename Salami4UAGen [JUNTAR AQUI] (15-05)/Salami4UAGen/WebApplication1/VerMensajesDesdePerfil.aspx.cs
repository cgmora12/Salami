using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace WebApplication1
{
    public partial class VerMensajesDesdePerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                try
                {
                    String nick = Session["login"].ToString();

                    UsuarioCEN usuarioCEN = new UsuarioCEN();
                    MensajesCEN mensajesCEN = new MensajesCEN();

                    IList<UsuarioEN> todosUsuarios = usuarioCEN.DameTodosLosUsuarios();
                    IList<UsuarioEN> usuarios = new List<UsuarioEN>();

                    foreach (UsuarioEN us in todosUsuarios)
                    {
                        IList<MensajesEN> mensajes = mensajesCEN.DameTodosLosMensajesEntreUsuarios(nick, us.Nickname);

                        if (mensajes.Count != 0)
                        {
                            usuarios.Add(us);
                        }
                    }

                    GridView1.DataSource = usuarios;
                    GridView1.DataBind();
                }catch(Exception ex)
                {}
            }
            
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
       }

        public string ChopString(string s)
        {
            try
            {
                s = s.Substring(0, 10);
            }
            catch (Exception) { }

            return s;
        }
    }
}