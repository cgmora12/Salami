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
using System.Collections;
using System.Text;


namespace WebApplication1
{
    public partial class Perfil : System.Web.UI.Page
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

                        ImagenPerfil.ImageUrl = us.UrlFoto;
                        Nickname.Text = nick;
                        Email.Text = us.Email;
                        Name.Text = us.Name;
                        Surname.Text = us.Surname;
                        Genero.Text = us.Gender.ToString();
                        //Orientacion.Text = us.Likes.ToString();
                        NationalityLabel.Text = us.Nationality;
                        HeightLabel.Text = us.Height.ToString();
                        BodyTypeLabel.Text = us.BodyType.ToString();
                        EthnicityLabel.Text = us.Ethnicity.ToString();
                        EyeColorLabel.Text = us.EyeColor.ToString();
                        HairColorLabel.Text = us.HairColor.ToString();
                        HairLengthLabel.Text = us.HairLength.ToString();
                        HairStyleLabel.Text = us.HairStyle.ToString();
                        SmokeLabel.Text = us.Smoke.ToString();
                        ReligionLabel.Text = us.Religion.ToString();
                        BirthLabel.Text = Convert.ToString(us.Birthday).Substring(0, 10);
                        StudiesLabel.Text = us.Career;
                        CourseLabel.Text = us.Course.ToString();

                        // Gustos
                        GustosEN gustoEN = new GustosCEN().DameGustoPorNickname(nick);

                        GeneroBuscado.Text = us.Likes.ToString();
                        BodyTypeBuscado.Text = gustoEN.BodyType.ToString();
                        EthnicityBuscado.Text = gustoEN.Ethnicity.ToString();
                        EyeColorBuscado.Text = gustoEN.EyeColor.ToString();
                        HairColorBuscado.Text = gustoEN.HairColor.ToString();
                        HairLengthBuscado.Text = gustoEN.HairLength.ToString();
                        HairStyleBuscado.Text = gustoEN.HairStyle.ToString();
                        SmokeBuscado.Text = gustoEN.Smoke.ToString();

                        if (us.Comment != "")
                        {
                            CommentLabel.Text = "About me";
                            Comment.Text = us.Comment;
                        }
                        // Las multiples opciones

                        // Animales

                        AnimalesCEN petcen = new AnimalesCEN();
                        IList<AnimalesEN> animales = petcen.DameAnimalesPorUsuario(us.Nickname);

                        //IList<String> animales = us.Pets;

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

                        PetsLabel.Text = s;


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
                        FeaturesLabel.Text = s;

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
                        FilmLabel.Text = s;

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
                        MusicLabel.Text = s;

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
                        SportsLabel.Text = s;

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
                        HobbiesLabel.Text = s;

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

        protected void BotonCambiarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

        protected void BotonEditarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EditarPerfil.aspx");
        }

        protected void BotonEliminarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EliminarPerfil.aspx");
        }

        protected void ButtonVerMensajes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VerMensajesDesdePerfil.aspx");
        }
    }
}