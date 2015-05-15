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
using Salami4UAGenNHibernate.Enumerated.Salami4UA;
using System.IO;


namespace WebApplication1
{
    public partial class EditarPerfil : System.Web.UI.Page
    {

        protected void Pruebas(object sender, EventArgs e)
        {
            
            
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                if (!Page.IsPostBack)
                {
                    InicializarValores();
                    ValoresDefinidosActualmente();

                }
            }

            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void ValoresDefinidosActualmente()
        {
            String nick = Session["Login"].ToString();

            try
            {
                UsuarioCAD usuarioCAD = new UsuarioCAD();
                UsuarioEN usuarioEN = new UsuarioEN();

                usuarioEN = usuarioCAD.ReadOIDDefault(nick);


                ImagenPerfil.ImageUrl = usuarioEN.UrlFoto;
                TiposDeCuerpo.SelectedValue = usuarioEN.BodyType.ToString();
                Etnia.SelectedValue = usuarioEN.Ethnicity.ToString();
                ColorOjos.SelectedValue = usuarioEN.EyeColor.ToString();
                ColorPelo.SelectedValue = usuarioEN.HairColor.ToString();
                LongitudPelo.SelectedValue = usuarioEN.HairLength.ToString();
                EstiloPelo.SelectedValue = usuarioEN.HairStyle.ToString();
                Fumar.SelectedValue = usuarioEN.Smoke.ToString();
                Religion.SelectedValue = usuarioEN.Religion.ToString();
                Genero.SelectedValue = usuarioEN.Gender.ToString();
                

                Nacionalidades.SelectedValue = usuarioEN.Nationality;
                Alturas.SelectedValue = usuarioEN.Height.ToString();
                Comment.Text = usuarioEN.Comment;
                Carreras.SelectedValue = usuarioEN.Career;
                Courses.SelectedValue = usuarioEN.Course.ToString();

                // Gustos
                GustosEN gustoEN = new GustosCEN().DameGustoPorNickname(nick);

                GeneroBuscado.SelectedValue = usuarioEN.Likes.ToString();
                BodyTypeBuscado.SelectedValue = gustoEN.BodyType.ToString();
                EthnicityBuscado.SelectedValue = gustoEN.Ethnicity.ToString();
                EyeColorBuscado.SelectedValue = gustoEN.EyeColor.ToString();
                HairColorBuscado.SelectedValue = gustoEN.HairColor.ToString();
                HairLengthBuscado.SelectedValue = gustoEN.HairLength.ToString();
                HairStyleBuscado.SelectedValue = gustoEN.HairStyle.ToString();
                SmokeBuscado.SelectedValue = gustoEN.Smoke.ToString();



                AnimalesCEN petcen = new AnimalesCEN();
                IList<AnimalesEN> animales = petcen.DameAnimalesPorUsuario(nick);
                ListItem listItem;

                foreach (AnimalesEN animal in animales)
                {
                    listItem = Animales.Items.FindByText(animal.Name);
                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                }

                IList<CaracteristicasEN> caracteristicasEN = new CaracteristicasCEN().DameCaracteristicasPorUsuario(nick);
                foreach (CaracteristicasEN caracteristica in caracteristicasEN)
                {
                    listItem = Caracteristicas.Items.FindByText(caracteristica.Name);
                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                }

                IList<CinesEN> cinesEN = new CinesCEN().DameGenerosDeCinePorUsuario(nick);
                foreach (CinesEN cine in cinesEN)
                {
                    listItem = Cine.Items.FindByText(cine.Name);
                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                }

                IList<MusicasEN> MusicasEN = new MusicasCEN().DameGustosMusicalesPorUsuario(nick);
                foreach (MusicasEN musica in MusicasEN)
                {
                    listItem = Musica.Items.FindByText(musica.Name);
                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                }

                IList<DeportesEN> deporteEN = new DeportesCEN().DameDeportesPorUsuario(nick);
                foreach (DeportesEN deporte in deporteEN)
                {
                    listItem = Deportes.Items.FindByText(deporte.Name);
                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                }

                IList<AficionesEN> hobbieEN = new AficionesCEN().DameHobbiesPorUsuario(nick);
                foreach (AficionesEN hobbie in hobbieEN)
                {
                    listItem = Hobbies.Items.FindByText(hobbie.Name);
                    if (listItem != null)
                    {
                        listItem.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
            }


        }

        protected void InicializarValores()
        {
            String nick = Session["Login"].ToString();

            try
            {
                UsuarioEN us = new UsuarioEN();
                UsuarioCAD usuarioCAD = new UsuarioCAD();
                us = usuarioCAD.ReadOIDDefault(nick);

                Name.Text = us.Name;
                Surname.Text = us.Surname;
                Comment.Text = us.Comment;
                FechaNacimiento.Text = Convert.ToString(us.Birthday).Substring(0, 10);
                
                int j;

                if (TiposDeCuerpo.Items.Count == 0)
                {
                    j = 0;
                    foreach (BodyTypeEnum type in Enum.GetValues(typeof(BodyTypeEnum)))
                    {
                        TiposDeCuerpo.Items.Insert(j++, type.ToString());
                    }
                }

                if (BodyTypeBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (BodyTypeEnum type in Enum.GetValues(typeof(BodyTypeEnum)))
                    {
                        BodyTypeBuscado.Items.Insert(j++, type.ToString());
                    }
                }

                if (GeneroBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (LikesEnum type in Enum.GetValues(typeof(LikesEnum)))
                    {
                        GeneroBuscado.Items.Insert(j++, type.ToString());
                    }
                }

                if (Genero.Items.Count == 0)
                {
                    j = 0;
                    foreach (GenderEnum type in Enum.GetValues(typeof(GenderEnum)))
                    {
                        Genero.Items.Insert(j++, type.ToString());
                    }
                }

                if (Etnia.Items.Count == 0)
                {
                    j = 0;
                    foreach (EthnicityEnum etnia in Enum.GetValues(typeof(EthnicityEnum)))
                    {
                        Etnia.Items.Insert(j++, etnia.ToString());
                    }
                }

                if (EthnicityBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (EthnicityEnum etnia in Enum.GetValues(typeof(EthnicityEnum)))
                    {
                        EthnicityBuscado.Items.Insert(j++, etnia.ToString());
                    }
                }

                if (ColorOjos.Items.Count == 0)
                {
                    j = 0;
                    foreach (EyeColorEnum color in Enum.GetValues(typeof(EyeColorEnum)))
                    {
                        ColorOjos.Items.Insert(j++, color.ToString());
                    }
                }

                if (EyeColorBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (EyeColorEnum color in Enum.GetValues(typeof(EyeColorEnum)))
                    {
                        EyeColorBuscado.Items.Insert(j++, color.ToString());
                    }
                }

                if (ColorPelo.Items.Count == 0)
                {
                    j = 0;
                    foreach (HairColorEnum color in Enum.GetValues(typeof(HairColorEnum)))
                    {
                        ColorPelo.Items.Insert(j++, color.ToString());
                    }
                }

                if (HairColorBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (HairColorEnum color in Enum.GetValues(typeof(HairColorEnum)))
                    {
                        HairColorBuscado.Items.Insert(j++, color.ToString());
                    }
                }


                if (LongitudPelo.Items.Count == 0)
                {
                    j = 0;
                    foreach (HairLengthEnum hair in Enum.GetValues(typeof(HairLengthEnum)))
                    {
                        LongitudPelo.Items.Insert(j++, hair.ToString());
                    }
                }

                if (HairLengthBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (HairLengthEnum hair in Enum.GetValues(typeof(HairLengthEnum)))
                    {
                        HairLengthBuscado.Items.Insert(j++, hair.ToString());
                    }
                }

                if (EstiloPelo.Items.Count == 0)
                {
                    j = 0;
                    foreach (HairStyleEnum hair in Enum.GetValues(typeof(HairStyleEnum)))
                    {
                        EstiloPelo.Items.Insert(j++, hair.ToString());
                    }
                }

                if (HairStyleBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (HairStyleEnum hair in Enum.GetValues(typeof(HairStyleEnum)))
                    {
                        HairStyleBuscado.Items.Insert(j++, hair.ToString());
                    }
                }

                if (Religion.Items.Count == 0)
                {
                    j = 0;
                    foreach (ReligionEnum religion in Enum.GetValues(typeof(ReligionEnum)))
                    {
                        Religion.Items.Insert(j++, religion.ToString());
                    }
                }


                if (Fumar.Items.Count == 0)
                {
                    j = 0;
                    foreach (SmokeEnum smoke in Enum.GetValues(typeof(SmokeEnum)))
                    {
                        Fumar.Items.Insert(j++, smoke.ToString());
                    }
                }

                if (SmokeBuscado.Items.Count == 0)
                {
                    j = 0;
                    foreach (SmokeEnum smoke in Enum.GetValues(typeof(SmokeEnum)))
                    {
                        SmokeBuscado.Items.Insert(j++, smoke.ToString());
                    }
                }

                String primero = CourseEnum.First.ToString();
                String segundo = CourseEnum.Second.ToString();
                String tercero = CourseEnum.Third.ToString();
                String cuarto = CourseEnum.Fourth.ToString();

                Courses.Items.Insert(0, new ListItem(primero, primero));
                Courses.Items.Insert(1, new ListItem(segundo, segundo));
                Courses.Items.Insert(2, new ListItem(tercero, tercero));
                Courses.Items.Insert(3, new ListItem(cuarto, cuarto));


                Salami4UAGenNHibernate.CEN.Salami4UA.CarreraCEN carrera = new Salami4UAGenNHibernate.CEN.Salami4UA.CarreraCEN();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN> carreras = carrera.DameTodasLasCarreras();

                Salami4UAGenNHibernate.CEN.Salami4UA.MasterCEN master = new Salami4UAGenNHibernate.CEN.Salami4UA.MasterCEN();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.MasterEN> masters = master.DameTodosLosMasters();

                for (int i = 0; i < carreras.Count; i++)
                {
                    Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN car = carreras.ElementAt(i);
                    String s = car.Name;
                    Carreras.Items.Add(s);
                }

                

                for (int i = 0; i < masters.Count; i++)
                {
                    Salami4UAGenNHibernate.EN.Salami4UA.MasterEN car = masters.ElementAt(i);
                    String s = car.Name;
                    Carreras.Items.Add(s);
                }

                IList<NacionalidadEN> nacionalidades = new NacionalidadCEN().DameTodaslasNacionalidades();
                for (int i = 0; i < nacionalidades.Count; i++)
                {
                    Nacionalidades.Items.Add(nacionalidades.ElementAt(i).Name);
                }

                IList<AlturaEN> alturasEN = new AlturaCEN().DameTodaslasAlturas();
                for (int i = 0; i < alturasEN.Count; i++)
                {
                    Alturas.Items.Add(alturasEN.ElementAt(i).Height.ToString());
                }

                IList<AnimalesEN> animales = new AnimalesCEN().DameTodosLosAnimales();
                for (int i = 0; i < animales.Count; i++)
                {
                    Animales.Items.Add(animales.ElementAt(i).Name);
                }

                IList<CaracteristicasEN> caracteristicas = new CaracteristicasCEN().DameTodasLasCaracteristicas();
                for (int i = 0; i < caracteristicas.Count; i++)
                {
                    Caracteristicas.Items.Add(caracteristicas.ElementAt(i).Name);
                }

                IList<CinesEN> cines = new CinesCEN().DameTodosLosGenerosCine();
                for (int i = 0; i < cines.Count; i++)
                {
                    Cine.Items.Add(cines.ElementAt(i).Name);
                }

                IList<MusicasEN> musicas = new MusicasCEN().DameTodosLosGustosMusicales();
                for (int i = 0; i < musicas.Count; i++)
                {
                    Musica.Items.Add(musicas.ElementAt(i).Name);
                }

                IList<DeportesEN> deportes = new DeportesCEN().DameTodosLosDeportes();
                for (int i = 0; i < deportes.Count; i++)
                {
                    Deportes.Items.Add(deportes.ElementAt(i).Name);
                }

                IList<AficionesEN> hobbies = new AficionesCEN().DameTodosLosHobbies();
                for (int i = 0; i < hobbies.Count; i++)
                {
                    Hobbies.Items.Add(hobbies.ElementAt(i).Name);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
            bool ok = true;
            EliminarErroresAnteriores(); // Pone en blanco los errores de los textbox

            Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN usuario = new Salami4UAGenNHibernate.CEN.Salami4UA.UsuarioCEN();


            HairColorEnum hairColor = (HairColorEnum)Enum.Parse(typeof(HairColorEnum), ColorPelo.SelectedValue);
            EyeColorEnum eyeColor = (EyeColorEnum)Enum.Parse(typeof(EyeColorEnum), ColorOjos.SelectedValue);
            HairLengthEnum hairLength = (HairLengthEnum)Enum.Parse(typeof(HairLengthEnum), LongitudPelo.SelectedValue);
            HairStyleEnum hairStyle = (HairStyleEnum)Enum.Parse(typeof(HairStyleEnum), EstiloPelo.SelectedValue);
            BodyTypeEnum bodyType = (BodyTypeEnum)Enum.Parse(typeof(BodyTypeEnum), TiposDeCuerpo.SelectedValue);
            EthnicityEnum ethnicity = (EthnicityEnum)Enum.Parse(typeof(EthnicityEnum), Etnia.SelectedValue);
            ReligionEnum religion = (ReligionEnum)Enum.Parse(typeof(ReligionEnum), Religion.SelectedValue);
            SmokeEnum smoke = (SmokeEnum)Enum.Parse(typeof(SmokeEnum), Fumar.SelectedValue);
            GenderEnum genero = (GenderEnum)Enum.Parse(typeof(GenderEnum), Genero.SelectedValue);
            LikesEnum orientacion = (LikesEnum)Enum.Parse(typeof(LikesEnum), GeneroBuscado.SelectedValue);

            DateTime tiempo = new DateTime();

            try
            {
                tiempo = Convert.ToDateTime(FechaNacimiento.Text);
            }
            catch (Exception ex)
            {
                ok = false;
                ErrorInsertar.Text = "ERROR: The date of birth  is not correct";
            }

            // CHECKBOX

            IList<string> animales = new List<string>();
            foreach (ListItem elemento in Animales.Items)
            {
                if (elemento.Selected)
                {
                    animales.Add(elemento.Value.ToString());
                }
            }

            if (animales.Count == 0)
            {
                //Mostrar error en un label
                ErrorAnimales.Text = "Please select at least one animal";
                ok = false;
            }

            IList<string> caracteristicas = new List<string>();
            foreach (ListItem elemento in Caracteristicas.Items)
            {
                if (elemento.Selected)
                {
                    caracteristicas.Add(elemento.Value.ToString());
                }
            }

            if (caracteristicas.Count == 0)
            {
                //Mostrar error en un label
                ErrorCaracteristicas.Text = "Please select at least one characteristic feature";
                ok = false;
            }

            IList<string> cines = new List<string>();
            foreach (ListItem elemento in Cine.Items)
            {
                if (elemento.Selected)
                {
                    cines.Add(elemento.Value.ToString());
                }
            }


            if (cines.Count == 0)
            {
                //Mostrar error en un label
                ErrorCine.Text = "Please select at least one genre film";
                ok = false;
            }



            IList<string> musicas = new List<string>();
            foreach (ListItem elemento in Musica.Items)
            {
                if (elemento.Selected)
                {
                    musicas.Add(elemento.Value.ToString());
                }
            }


            if (musicas.Count == 0)
            {
                //Mostrar error en un label
                ErrorMusica.Text = "Please select at least one musical taste";
                ok = false;
            }


            IList<string> deportes = new List<string>();
            foreach (ListItem elemento in Deportes.Items)
            {
                if (elemento.Selected)
                {
                    deportes.Add(elemento.Value.ToString());
                }
            }


            if (deportes.Count == 0)
            {
                //Mostrar error en un label
                ErrorDeportes.Text = "Please select at least one sport";
                ok = false;
            }


            IList<string> hobbies = new List<string>();
            foreach (ListItem elemento in Hobbies.Items)
            {
                if (elemento.Selected)
                {
                    hobbies.Add(elemento.Value.ToString());
                }
            }


            if (hobbies.Count == 0)
            {
                //Mostrar error en un label
                ErrorHobbies.Text = "Please select at least one hobby";
                ok = false;
            }

            CourseEnum curso = (CourseEnum)Enum.Parse(typeof(CourseEnum), Courses.SelectedValue);
            
            // Gusto
            HairColorEnum haircolBuscado = (HairColorEnum)Enum.Parse(typeof(HairColorEnum), HairColorBuscado.SelectedValue);
            EyeColorEnum eyeColBuscado = (EyeColorEnum)Enum.Parse(typeof(EyeColorEnum), EyeColorBuscado.SelectedValue);
            HairLengthEnum hairlenBuscado = (HairLengthEnum)Enum.Parse(typeof(HairLengthEnum), HairLengthBuscado.SelectedValue);
            HairStyleEnum hairstyBuscado = (HairStyleEnum)Enum.Parse(typeof(HairStyleEnum), HairStyleBuscado.SelectedValue);
            BodyTypeEnum corpBuscado = (BodyTypeEnum)Enum.Parse(typeof(BodyTypeEnum), BodyTypeBuscado.SelectedValue);
            EthnicityEnum etnBuscado = (EthnicityEnum)Enum.Parse(typeof(EthnicityEnum), EthnicityBuscado.SelectedValue);
            SmokeEnum smkBuscado = (SmokeEnum)Enum.Parse(typeof(SmokeEnum), SmokeBuscado.SelectedValue);
            
            if (ok)
            {
                Exception excep = null;

                try
                {
                    UsuarioCEN usuarioCEN = new UsuarioCEN();
                    String nick = Session["Login"].ToString();
                    IList<UsuarioEN> usuarios = new UsuarioCEN().DameUsuarioPorNickname(nick);

                    GustosCEN gustoCEN = new GustosCEN();
                    gustoCEN.Modify(nick, haircolBuscado, eyeColBuscado, hairlenBuscado, hairstyBuscado, corpBuscado, etnBuscado, smkBuscado);

                    foreach (UsuarioEN us in usuarios)
                    {

                        usuario.Modify(us.Nickname, us.Password, hairColor, eyeColor, hairLength, hairStyle, bodyType, ethnicity, religion,
                            smoke, us.Email, tiempo, genero, orientacion, Name.Text, Surname.Text, Comment.Text, "", Carreras.SelectedValue,
                            curso, Nacionalidades.SelectedValue, Int32.Parse(Alturas.SelectedValue),
                            animales, cines, musicas, caracteristicas, deportes, hobbies, us.UrlFoto);                         
                    }


                } catch (Exception ex)
                {
                    excep = ex;
                    EliminarErroresAnteriores();
                    ErrorInsertar.Text = "ERROR: The update of the profile was not possible";
                }

                if (excep == null)
                {
                    Response.Redirect("~/Perfil.aspx");
                }
            }

        }




        private void EliminarErroresAnteriores()
        {
            ErrorInsertar.Text = "";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Perfil.aspx");
        }

        protected void PopUpChangePhoto_Click(object sender, EventArgs e)
        {
            //ErrorURL.Text = "";
            mp2.Show();
        }

        protected void close_Click(object sender, EventArgs e)
        {
            mp2.Hide();
        }

        protected void send_Click(object sender, EventArgs e)
        {

            String nick = Session["Login"].ToString();
            Exception exp = null;

            String extension = Path.GetExtension(URL.Text);

            if (extension == ".jpg" || extension == ".png")
            {

                try
                {
                    UsuarioCEN usuarioCEN = new UsuarioCEN();
                    UsuarioEN us = new UsuarioCAD().ReadOIDDefault(nick);
                    

                    usuarioCEN.Modify(us.Nickname, us.Password, us.HairColor, us.EyeColor, us.HairLength, us.HairStyle, us.BodyType, us.Ethnicity, us.Religion,
                               us.Smoke, us.Email, us.Birthday, us.Gender, us.Likes, us.Name, us.Surname, us.Comment, "", us.Career,
                               us.Course, us.Nationality, us.Height,
                               us.Pets, us.Films, us.Musics, us.Characteristics, us.Sports, us.Hobbies, URL.Text);


                }
                catch (Exception ex)
                {
                    exp = ex;
                }


                mp2.Hide();

                // Actualizamos la foto
                Response.Redirect(Request.RawUrl);

                if (exp != null)
                {
                    ErrorInsertar.Text = "ERROR: The photo was not possible be uploaded";
                }
            }

            else
            {
                //ErrorURL.Text = "The image must be on JPG or PNG";
            }

        }

        
    }
}