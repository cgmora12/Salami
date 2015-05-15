using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using Salami4UAGenNHibernate.Enumerated.Salami4UA;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        private string admin = "admin";
        protected void InicializarValores()
        {
            if (botoncarrera.Checked == true) // Estudia carrera
            {
                CareerList.Visible = true;
                CareerLabel.Visible = true;
                MasterList.Visible = false;
                MasterLabel.Visible = false;
                CourseList.Visible = true;
                CourseLabel.Visible = true;
                //botoncarrera.Checked = false;

            }

            Label.Text = "";

            NacionalidadCEN nacion = new NacionalidadCEN();
            IList<NacionalidadEN> nacionalidades = nacion.DameTodaslasNacionalidades();

            AlturaCEN altura = new AlturaCEN();
            IList<AlturaEN> alturas = altura.DameTodaslasAlturas();

            int j;

            if (TiposDeCuerpo.Items.Count == 0)
            {
                j = 0;
                foreach (BodyTypeEnum type in Enum.GetValues(typeof(BodyTypeEnum)))
                {
                    TiposDeCuerpo.Items.Insert(j++, type.ToString());
                }
            }

            if (TiposDeCuerpoBuscado.Items.Count == 0)
            {
                j = 0;
                foreach (BodyTypeEnum type in Enum.GetValues(typeof(BodyTypeEnum)))
                {
                    TiposDeCuerpoBuscado.Items.Insert(j++, type.ToString());
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

            if(Orientacion.Items.Count == 0)
            {
                j=0;
                foreach (LikesEnum type in Enum.GetValues(typeof(LikesEnum)))
                {
                    Orientacion.Items.Insert(j++, type.ToString());
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

            if (EtniaBuscada.Items.Count == 0)
            {
                j = 0;
                foreach (EthnicityEnum etnia in Enum.GetValues(typeof(EthnicityEnum)))
                {
                    EtniaBuscada.Items.Insert(j++, etnia.ToString());
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

            if (ColorOjosBuscado.Items.Count == 0)
            {
                j = 0;
                foreach (EyeColorEnum color in Enum.GetValues(typeof(EyeColorEnum)))
                {
                    ColorOjosBuscado.Items.Insert(j++, color.ToString());
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

            if (ColorPeloBuscado.Items.Count == 0)
            {
                j = 0;
                foreach (HairColorEnum color in Enum.GetValues(typeof(HairColorEnum)))
                {
                    ColorPeloBuscado.Items.Insert(j++, color.ToString());
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

            if (LongitudPeloBuscado.Items.Count == 0)
            {
                j = 0;
                foreach (HairLengthEnum hair in Enum.GetValues(typeof(HairLengthEnum)))
                {
                    LongitudPeloBuscado.Items.Insert(j++, hair.ToString());
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

            if (EstiloPeloBuscado.Items.Count == 0)
            {
                j = 0;
                foreach (HairStyleEnum hair in Enum.GetValues(typeof(HairStyleEnum)))
                {
                    EstiloPeloBuscado.Items.Insert(j++, hair.ToString());
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


            if (Fumador.Items.Count == 0)
            {
                j = 0;
                foreach (SmokeEnum smoke in Enum.GetValues(typeof(SmokeEnum)))
                {
                    Fumador.Items.Insert(j++, smoke.ToString());
                }
            }

            if (FumadorBuscado.Items.Count == 0)
            {
                j = 0;
                foreach (SmokeEnum smoke in Enum.GetValues(typeof(SmokeEnum)))
                {
                    FumadorBuscado.Items.Insert(j++, smoke.ToString());
                }
            }

            for (int i = 0; i < nacionalidades.Count; i++)
            {

                NacionalidadEN nacionalidad = nacionalidades.ElementAt(i);
                String s = nacionalidad.Name;

                // Insertar s en el listview
                NacionalidadList.Items.Insert(i, new ListItem(s, s));
            }

            NacionalidadList.SelectedValue = "Spanish";

            CaracteristicasCEN caracteristica = new CaracteristicasCEN();
            IList<CaracteristicasEN> caracteristicas = caracteristica.DameTodasLasCaracteristicas();


            for (int i = 0; i < caracteristicas.Count; i++)
            {
                CaracteristicasEN car = caracteristicas.ElementAt(i);
                String s = car.Name;
                ListaCaracteristicas.Items.Add(s);
            }

            for (int i = 0; i < alturas.Count; i++)
            {

                AlturaEN altura1 = alturas.ElementAt(i);
                String s = (altura1.Height).ToString();

                // Insertar s en el listview
                Height.Items.Insert(i, new ListItem(s, s));
            }

            AnimalesCEN animal = new AnimalesCEN();
            IList<AnimalesEN> animales = animal.DameTodosLosAnimales();

            String primero = CourseEnum.First.ToString();
            String segundo = CourseEnum.Second.ToString();
            String tercero = CourseEnum.Third.ToString();
            String cuarto = CourseEnum.Fourth.ToString();

            CourseList.Items.Insert(0, new ListItem(primero, primero));
            CourseList.Items.Insert(1, new ListItem(segundo, segundo));
            CourseList.Items.Insert(2, new ListItem(tercero, tercero));
            CourseList.Items.Insert(3, new ListItem(cuarto, cuarto));

            CarreraCEN carrera = new CarreraCEN();
            IList<CarreraEN> carreras = carrera.DameTodasLasCarreras();

            MasterCEN master = new MasterCEN();
            IList<MasterEN> masters = master.DameTodosLosMasters();

            for (int i = 0; i < carreras.Count; i++)
            {
                CarreraEN car = carreras.ElementAt(i);
                String s = car.Name;
                CareerList.Items.Add(s);
            }

            for (int i = 0; i < masters.Count; i++)
            {
                MasterEN car = masters.ElementAt(i);
                String s = car.Name;
                MasterList.Items.Add(s);
            }


            for (int i = 0; i < animales.Count; i++)
            {
                AnimalesEN an = animales.ElementAt(i);
                String s = an.Name;
                ListaAnimales.Items.Add(s);
            }


            CinesCEN cine = new CinesCEN();
            IList<CinesEN> cines = cine.DameTodosLosGenerosCine();


            for (int i = 0; i < cines.Count; i++)
            {
                CinesEN genre = cines.ElementAt(i);
                String s = genre.Name;
                ListaCine.Items.Add(s);
            }

            MusicasCEN musica = new MusicasCEN();
            IList<MusicasEN> musicas = musica.DameTodosLosGustosMusicales();

            for (int i = 0; i < musicas.Count; i++)
            {
                MusicasEN mus = musicas.ElementAt(i);
                String s = mus.Name;
                ListaMusica.Items.Add(s);
            }

            DeportesCEN deporte = new DeportesCEN();
            IList<DeportesEN> deportes = deporte.DameTodosLosDeportes();

            for (int i = 0; i < deportes.Count; i++)
            {
                DeportesEN sport = deportes.ElementAt(i);
                String s = sport.Name;
                ListaDeportes.Items.Add(s);
            }

            AficionesCEN hobbie = new AficionesCEN();
            IList<AficionesEN> hobbies = hobbie.DameTodosLosHobbies();

            for (int i = 0; i < hobbies.Count; i++)
            {
                AficionesEN hob = hobbies.ElementAt(i);
                String s = hob.Name;
                ListaHobbies.Items.Add(s);

            }

            TermsOfUseLink.Text = "Terms and conditions of use.";
            TermsOfUseLink.NavigateUrl = "../Terms.aspx";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializarValores();
            }
        }


        protected void Continuar_Click(object sender, EventArgs e)
        {
            bool ok = true;
            EliminarErroresAnteriores(); // Pone en blanco los errores de los textbox

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            MailMessage message = new MailMessage();
            try
            {
                StringBuilder password = new StringBuilder();
                char ch;
                int n;
                for (int i = 0; i < 5; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    n = Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65));
                    password.Append(ch); password.Append(n);
                }


                MailAddress fromAddress = new MailAddress("salami4ua@gmail.com", "Salami4UA");
                MailAddress toAddress = new MailAddress(Email.Text, UserName.Text);
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = "Welcome to Salami4ua";
                message.Body = "You are now an user of Salami4ua with the account " + UserName.Text +
                    ". \n\n Your password will be " + password.ToString() + "\n\n" +
                    "Please click the following link: \n http://localhost:49837/Account/Login.aspx";
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("salami4ua@gmail.com", "salamiforua");



                UsuarioCEN usuario = new UsuarioCEN();


                IList<string> animales = new List<string>();
                foreach (ListItem elemento in ListaAnimales.Items)
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
                foreach (ListItem elemento in ListaCaracteristicas.Items)
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
                foreach (ListItem elemento in ListaCine.Items)
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
                foreach (ListItem elemento in ListaMusica.Items)
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
                foreach (ListItem elemento in ListaDeportes.Items)
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
                foreach (ListItem elemento in ListaHobbies.Items)
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


                HairColorEnum hairColor = (HairColorEnum)Enum.Parse(typeof(HairColorEnum), ColorPelo.SelectedValue);
                EyeColorEnum eyeColor = (EyeColorEnum)Enum.Parse(typeof(EyeColorEnum), ColorOjos.SelectedValue);
                HairLengthEnum hairLength = (HairLengthEnum)Enum.Parse(typeof(HairLengthEnum), LongitudPelo.SelectedValue);
                HairStyleEnum hairStyle = (HairStyleEnum)Enum.Parse(typeof(HairStyleEnum), EstiloPelo.SelectedValue);
                BodyTypeEnum bodyType = (BodyTypeEnum)Enum.Parse(typeof(BodyTypeEnum), TiposDeCuerpo.SelectedValue);
                EthnicityEnum ethnicity = (EthnicityEnum)Enum.Parse(typeof(EthnicityEnum), Etnia.SelectedValue);
                ReligionEnum religion = (ReligionEnum)Enum.Parse(typeof(ReligionEnum), Religion.SelectedValue);
                SmokeEnum smoke = (SmokeEnum)Enum.Parse(typeof(SmokeEnum), Fumador.SelectedValue);
                GenderEnum genero = (GenderEnum)Enum.Parse(typeof(GenderEnum), Genero.SelectedValue);
                LikesEnum orientacion = (LikesEnum)Enum.Parse(typeof(LikesEnum), Orientacion.SelectedValue);

                CourseEnum curso = (CourseEnum)Enum.Parse(typeof(CourseEnum), CourseList.SelectedValue);
               
                HairColorEnum colPelBuscado = (HairColorEnum)Enum.Parse(typeof(HairColorEnum), ColorPeloBuscado.SelectedValue);
                HairStyleEnum styPelBuscado = (HairStyleEnum)Enum.Parse(typeof(HairStyleEnum), EstiloPeloBuscado.SelectedValue);
                HairLengthEnum longPelBuscado = (HairLengthEnum)Enum.Parse(typeof(HairLengthEnum), LongitudPeloBuscado.SelectedValue);
                EyeColorEnum colOjosBuscado = (EyeColorEnum)Enum.Parse(typeof(EyeColorEnum), ColorOjosBuscado.SelectedValue);
                BodyTypeEnum bodTypeBuscado = (BodyTypeEnum)Enum.Parse(typeof(BodyTypeEnum), TiposDeCuerpoBuscado.SelectedValue);
                EthnicityEnum etniBuscado = (EthnicityEnum)Enum.Parse(typeof(EthnicityEnum), EtniaBuscada.SelectedValue);
                SmokeEnum fumBuscado = (SmokeEnum)Enum.Parse(typeof(SmokeEnum), FumadorBuscado.SelectedValue);
                

                DateTime tiempo = new DateTime();

                try
                {
                    tiempo = Convert.ToDateTime(FechaNacimiento.Text);
                    var age = GetAge(tiempo);
                    if (age < 18)
                    {
                        ErrorUnderAge.Text = "You must be 18 years old";
                        ok = false;
                    }
                    else
                    {
                        ErrorUnderAge.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    ok = false;
                }

                


                IList<UsuarioEN> listaUsuarios = new List<UsuarioEN>();
                listaUsuarios = usuario.DameUsuarioPorNickname(UserName.Text);

                if (listaUsuarios.Count != 0)
                {
                    ok = false;
                    ErrorNickname.Text = "ERROR: This nickname already exists. Please select another one.";
                    UserName.Text = "";

                }

                if (!TermsOfUse.Checked)
                {
                    ok = false;
                    ErrorTerms.Text = "You have to accept the terms of use.";
                }
                else
                {
                    ErrorTerms.Text = "";
                }

                if (ok)
                {

                    // Gustos
                    GustosCEN gustoCEN = new GustosCEN();
                    gustoCEN.New_(UserName.Text, colPelBuscado, colOjosBuscado, longPelBuscado, styPelBuscado, bodTypeBuscado, etniBuscado, fumBuscado);


                    usuario.New_(UserName.Text, Login.GetMd5Hash(password.ToString()), hairColor, eyeColor, hairLength, hairStyle, bodyType, ethnicity, religion, smoke, Email.Text,
                        tiempo, genero, orientacion, Name.Text, Surname.Text, Comment.Text, "NotValidated", CareerList.SelectedValue, curso,
                        NacionalidadList.SelectedValue, Int32.Parse(Height.SelectedValue), animales, cines, musicas, caracteristicas, deportes, hobbies, "http://10hotmail.com/wp-content/uploads/2012/05/Agregar-contactos-Yahoo-MSN-Messenger.png", UserName.Text);
                        


                    smtpClient.Send(message);
                    Label.Text = "Your account has been created! Check your email to log in Salami4UA! \n" +
                        "<a href=\"https://www1.webmail.ua.es/login0.php3?idi=es\" target=\"_blank\"> WebMail  </a>" +
                        "\nPlease log in <a href=\"/Account/Login.aspx\">here</a>." +
                        "\n\n Regards, Salami4UA Team.";

                    try
                    {
                        string msg = UserName.Text + " has created his new account without validation.";

                        MensajesCEN mensajeCen = new MensajesCEN();
                        mensajeCen.New_(msg, UserName.Text, admin);

                    }
                    catch (Exception)
                    {
                    }

                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Label.Text = ex.Message;
            }
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);

        private void EliminarErroresAnteriores()
        {
            ErrorHobbies.Text = "";
            ErrorDeportes.Text = "";
            ErrorCine.Text = "";
            ErrorMusica.Text = "";
            ErrorCaracteristicas.Text = "";
            ErrorNickname.Text = "";
            ErrorTerms.Text = "";
            ErrorUnderAge.Text = "";
        }

        protected void clickarCarrera(object sender, EventArgs e)
        {
            if (botoncarrera.Checked == true) // Estudia carrera
            {
                CareerList.Visible = true;
                CareerLabel.Visible = true;
                MasterList.Visible = false;
                MasterLabel.Visible = false;
                CourseList.Visible = true;
                CourseLabel.Visible = true;
                //botoncarrera.Checked = false;

            }

            else if (botonmaster.Checked == true) // Estudia master
            {
                MasterList.Visible = true;
                MasterLabel.Visible = true;
                CareerList.Visible = false;
                CareerLabel.Visible = false;
                CourseList.Visible = true;
                CourseLabel.Visible = true;
                //botonmaster.Checked = false;

            }

        }

        protected void ListaCaracteristicas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int GetAge(DateTime bornDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bornDate.Year;
            if (bornDate > today.AddYears(-age))
                age--;

            return age;
        }

    }
}
