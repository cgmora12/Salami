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
    public partial class Admin : System.Web.UI.Page
    {
        UsuarioCEN usuario = new UsuarioCEN();
        List<UsuarioEN> listaUsuarios = new List<UsuarioEN>();
        List<UsuarioEN> usuarios = new List<UsuarioEN>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                String nick = Session["Login"].ToString();
                if (String.Compare(nick, "admin") == 0)
                {
                    try
                    {
                        IList<UsuarioEN> usu = usuario.DameTodosLosUsuarios();
                        listaUsuarios.AddRange(usu);

                        LabelSalamiAdmin.Text = "There are " + listaUsuarios.Count + " Salami's";
                        AdminGridView.DataSource = listaUsuarios;
                        AdminGridView.DataBind();
                    }
                    catch (Exception) { LabelSalamiAdmin.Text = "There are no users... "; }
                }
                else
                {
                    Response.Redirect("~/Account/Login.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void search_nickname(object sender, EventArgs e)
        {
            if (NicknameRadio.Checked)
            {
                try
                {
                    listaUsuarios.Clear();

                    IList<UsuarioEN> usu = usuario.DameUsuarioPorNickname(NicknameSearch.Text);
                    listaUsuarios.AddRange(usu);

                    LabelSalamiAdmin.Text = "There are " + listaUsuarios.Count + " Salami's";
                    AdminGridView.DataSource = listaUsuarios;
                    AdminGridView.DataBind();
                }
                catch (Exception)
                {
                    LabelSalamiAdmin.Text = "There are no users with this nickname.";
                }
            }
            else if(ShowAllRadio.Checked)
            {
                try
                {
                    listaUsuarios.Clear();
                    IList<UsuarioEN> usu = usuario.DameTodosLosUsuarios();
                    listaUsuarios.AddRange(usu);

                    LabelSalamiAdmin.Text = "There are " + listaUsuarios.Count + " Salami's";
                    AdminGridView.DataSource = listaUsuarios;
                    AdminGridView.DataBind();
                }
                catch (Exception) { LabelSalamiAdmin.Text = "There are no users... "; }
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