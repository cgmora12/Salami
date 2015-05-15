using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.Enumerated.Salami4UA;

namespace WebApplication1
{
    public partial class Recomendar : System.Web.UI.Page
    {
        private List<UsuarioEN> listaUsuarios;
        private UsuarioEN user;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaUsuarios = new List<UsuarioEN>();
            UsuarioCEN cen = new UsuarioCEN();

            try
            {
                user = null;
                string nick = (string)this.Session["login"];

                if (nick != null && nick != "")
                    user = cen.DameUsuarioPorNickname(nick)[0];
            }
            catch (Exception)
            {
            }

            if (user != null)
            {
                IList<UsuarioEN> listaGenero, listaCuerpo, listaPeloColor, listaPeloLong,
                    listaPeloTipo, listaOjos, listaEtnia, listaFumar;
                
                GustosCEN gustoCen = new GustosCEN();
                GustosEN gusto = gustoCen.DameGustoPorNickname(user.Nickname);

                if (user.Likes == LikesEnum.Man)
                    listaGenero = cen.DameUsuarioPorGender(GenderEnum.Man);
                else if (user.Likes == LikesEnum.Woman)
                    listaGenero = cen.DameUsuarioPorGender(GenderEnum.Woman);
                else
                    listaGenero = cen.DameTodosLosUsuarios();


                listaCuerpo = cen.DameUsuarioPorBodyType(gusto.BodyType);
                listaPeloColor = cen.DameUsuarioPorHairColor(gusto.HairColor);
                listaPeloLong = cen.DameUsuarioPorHairLength(gusto.HairLength);
                listaPeloTipo = cen.DameUsuarioPorHairStyle(gusto.HairStyle);
                listaOjos = cen.DameUsuarioPorEyeColor(gusto.EyeColor);
                listaEtnia = cen.DameUsuarioPorEthnicity(gusto.Ethnicity);
                listaFumar = cen.DameUsuarioPorFumar(gusto.Smoke);

                listaUsuarios = unirListas(listaGenero,
                    unirListas(listaCuerpo,
                    unirListas(listaPeloColor,
                    unirListas(listaPeloLong,
                    unirListas(listaPeloTipo,
                    unirListas(listaOjos, 
                    unirListas(listaEtnia, listaFumar)))))));

                /*
                if (listaUsuarios.Contains(user))
                    listaUsuarios.Remove(user);
                 */

            }


            LabelSalami.Text = "Found " + listaUsuarios.Count + " Salami's";

            GridView1.DataSource = listaUsuarios;
            GridView1.DataBind();
        }



        private List<UsuarioEN> unirListas(IList<UsuarioEN> usuariosPorAhora, IList<UsuarioEN> usuariosNuevos)
        {
            List<UsuarioEN> usuarios = new List<UsuarioEN>();

            foreach (UsuarioEN usuarioEN in usuariosNuevos)
            {
                if (usuariosPorAhora.Contains(usuarioEN))
                {
                    usuarios.Add(usuarioEN);
                }
            }

            return usuarios;
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