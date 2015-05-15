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
    public partial class Buscar : System.Web.UI.Page
    {
        List<UsuarioEN> listaUsuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaUsuarios = new List<UsuarioEN>();


            NacionalidadCEN nacion = new NacionalidadCEN();
            IList<NacionalidadEN> nacionalidades = nacion.DameTodaslasNacionalidades();

            AlturaCEN altura = new AlturaCEN();
            IList<AlturaEN> Alturas = altura.DameTodaslasAlturas();
            int i;

            if (TiposDeCuerpo.Items.Count == 0)
            {
                TiposDeCuerpo.Items.Insert(0, "Unspecified");

                i = 1;

                foreach (BodyTypeEnum type in Enum.GetValues(typeof(BodyTypeEnum)))
                {
                    TiposDeCuerpo.Items.Insert(i++, type.ToString());
                }

                
            }

            if (Etnia.Items.Count == 0)
            {
                Etnia.Items.Insert(0, "Unspecified");
                i = 1;
                foreach (EthnicityEnum etnia in Enum.GetValues(typeof(EthnicityEnum)))
                {
                    Etnia.Items.Insert(i++, etnia.ToString());
                }

                
            }

            if (ColorOjos.Items.Count == 0)
            {
                i = 0;
                ColorOjos.Items.Insert(i++, "Unspecified");
                foreach (EyeColorEnum color in Enum.GetValues(typeof(EyeColorEnum)))
                {
                    ColorOjos.Items.Insert(i++, color.ToString());
                }

                
            }

            if (ColorPelo.Items.Count == 0)
            {
                i = 0;
                ColorPelo.Items.Insert(i++, "Unspecified");
                foreach (HairColorEnum color in Enum.GetValues(typeof(HairColorEnum)))
                {
                    ColorPelo.Items.Insert(i++, color.ToString());
                }

                
            }


            if (LongitudPelo.Items.Count == 0)
            {
                i = 0;
                LongitudPelo.Items.Insert(i++, "Unspecified");
                foreach (HairLengthEnum hair in Enum.GetValues(typeof(HairLengthEnum)))
                {
                    LongitudPelo.Items.Insert(i++, hair.ToString());
                }

                
            }

            if (EstiloPelo.Items.Count == 0)
            {
                EstiloPelo.Items.Insert(0, "Unspecified");
                i = 1;
                foreach (HairStyleEnum hair in Enum.GetValues(typeof(HairStyleEnum)))
                {
                    EstiloPelo.Items.Insert(i++, hair.ToString());
                }

                
            }


            if (Religion.Items.Count == 0)
            {
                i = 0;
                Religion.Items.Insert(i++, "Unspecified");
                foreach (ReligionEnum religion in Enum.GetValues(typeof(ReligionEnum)))
                {
                    Religion.Items.Insert(i++, religion.ToString());
                }

                
            }


            if (Fumador.Items.Count == 0)
            {
                Fumador.Items.Insert(0, "Unspecified");
                i = 1;
                foreach (SmokeEnum smoke in Enum.GetValues(typeof(SmokeEnum)))
                {
                    Fumador.Items.Insert(i++, smoke.ToString());
                }

                
            }

            if (NacionalidadList.Items.Count == 0)
            {
                i = 0;
                NacionalidadList.Items.Insert(i++, "Unspecified");
                NacionalidadList.Items.Insert(i++, "Spanish");
                foreach (NacionalidadEN nacional in nacionalidades)
                {
                    if (nacional.Name != "Spanish")
                        NacionalidadList.Items.Insert(i++, nacional.Name);
                }

                
            }



            if (Height.Items.Count == 0)
            {
                i = 0;
                Height.Items.Insert(i++, "Unspecified");
                foreach (AlturaEN height in Alturas)
                {
                    Height.Items.Insert(i++, height.Height.ToString());
                }

                
            }


            //BusquedaExigente();
        }

        protected void Search_Click(object sender, EventArgs e)
        {

            if (StrictSearch.Checked)
            {
                BusquedaExigente();
            }

            else if (CalmSearch.Checked)
            {
                BusquedaTranquila();
            }

        }


        protected List<UsuarioEN> filtraUsuariosNuevos(List<UsuarioEN> usuariosPorAhora, List<UsuarioEN> usuariosNuevos)
        {
            List<UsuarioEN> usuarios = new List<UsuarioEN>();
            usuarios.AddRange(usuariosPorAhora);

            foreach (UsuarioEN usuarioEN in usuariosNuevos)
            {
                if (!usuariosPorAhora.Contains(usuarioEN))
                {
                    usuarios.Add(usuarioEN);
                }
            }

            return usuarios;
        }

        private void BusquedaTranquila()
        {
            listaUsuarios.Clear();

            UsuarioCEN UsuarioCEN = new UsuarioCEN();

            {
                List<UsuarioEN> listaPorGenero = new List<UsuarioEN>();
                if (RadioWoman.Checked)
                {
                    listaPorGenero.AddRange(UsuarioCEN.DameUsuarioPorGender(GenderEnum.Woman));
                }
                else if (RadioMan.Checked)
                {
                    listaPorGenero.AddRange(UsuarioCEN.DameUsuarioPorGender(GenderEnum.Man));
                }

                listaUsuarios.AddRange(listaPorGenero);
            }


            if (TiposDeCuerpo.SelectedIndex != -1 && !TiposDeCuerpo.SelectedValue.ToString().Equals("Unspecified"))
            {
                List<UsuarioEN> listaPorCuerpo = new List<UsuarioEN>();
                string tipoDeCuerpo = TiposDeCuerpo.SelectedValue;

                listaPorCuerpo.AddRange(UsuarioCEN.DameUsuarioPorBodyType(
                   (BodyTypeEnum)Enum.Parse(typeof(BodyTypeEnum), tipoDeCuerpo)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorCuerpo);
            }

            if (Etnia.SelectedIndex != -1 && !Etnia.SelectedValue.ToString().Equals("Unspecified"))
            {
                string etnia = Etnia.SelectedValue;
                List<UsuarioEN> listaPorEtnia = new List<UsuarioEN>();

                listaPorEtnia.AddRange(UsuarioCEN.DameUsuarioPorEthnicity(
                    (EthnicityEnum)Enum.Parse(typeof(EthnicityEnum), etnia)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorEtnia);

            }

            if (ColorOjos.SelectedIndex != -1 && !ColorOjos.SelectedValue.ToString().Equals("Unspecified"))
            {
                string ojos = ColorOjos.SelectedValue;
                List<UsuarioEN> listaPorColorOjos = new List<UsuarioEN>();

                listaPorColorOjos.AddRange(UsuarioCEN.DameUsuarioPorEyeColor(
                    (EyeColorEnum)Enum.Parse(typeof(EyeColorEnum), ojos)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorColorOjos);

            }


            if (ColorPelo.SelectedIndex != -1 && !ColorPelo.SelectedValue.ToString().Equals("Unspecified"))
            {
                string pelo = ColorPelo.SelectedValue;
                List<UsuarioEN> listaPorColorPelo = new List<UsuarioEN>();

                listaPorColorPelo.AddRange(UsuarioCEN.DameUsuarioPorHairColor(
                    (HairColorEnum)Enum.Parse(typeof(HairColorEnum), pelo)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorColorPelo);

            }


            if (LongitudPelo.SelectedIndex != -1 && !LongitudPelo.SelectedValue.ToString().Equals("Unspecified"))
            {
                string cabello = LongitudPelo.SelectedValue;
                List<UsuarioEN> listaPorLongitudPelo = new List<UsuarioEN>();

                listaPorLongitudPelo.AddRange(UsuarioCEN.DameUsuarioPorHairLength(
                    (HairLengthEnum)Enum.Parse(typeof(HairLengthEnum), cabello)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorLongitudPelo);
            }

            if (EstiloPelo.SelectedIndex != -1 && !EstiloPelo.SelectedValue.ToString().Equals("Unspecified"))
            {
                string peinado = EstiloPelo.SelectedValue;
                List<UsuarioEN> listaPorEstiloPelo = new List<UsuarioEN>();

                listaPorEstiloPelo.AddRange(UsuarioCEN.DameUsuarioPorHairStyle(
                    (HairStyleEnum)Enum.Parse(typeof(HairStyleEnum), peinado)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorEstiloPelo);
            }

            if (Religion.SelectedIndex != -1 && !Religion.SelectedValue.ToString().Equals("Unspecified"))
            {
                string religion = Religion.SelectedValue;
                List<UsuarioEN> listaPorReligion = new List<UsuarioEN>();

                listaPorReligion.AddRange(UsuarioCEN.DameUsuarioPorReligion(
                    (ReligionEnum)Enum.Parse(typeof(ReligionEnum), religion)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorReligion);
            }


            if (Fumador.SelectedIndex != -1 && !Fumador.SelectedValue.ToString().Equals("Unspecified"))
            {
                string fumador = Fumador.SelectedValue;
                List<UsuarioEN> listaPorFumador = new List<UsuarioEN>();

                listaPorFumador.AddRange(UsuarioCEN.DameUsuarioPorFumar((SmokeEnum)Enum.Parse(typeof(SmokeEnum), fumador)));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorFumador);
            }

            if (NacionalidadList.SelectedIndex != -1 && !NacionalidadList.SelectedValue.ToString().Equals("Unspecified"))
            {
                string valor = NacionalidadList.SelectedValue;
                List<UsuarioEN> listaPorNacionalidad = new List<UsuarioEN>();
                NacionalidadEN nacion = new NacionalidadEN();
                nacion.Name = valor;

                listaPorNacionalidad.AddRange(
                    UsuarioCEN.DameUsuarioPorNacionalidad(nacion.Name));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorNacionalidad);
            }

            if (Height.SelectedIndex != -1 && !Height.SelectedValue.ToString().Equals("Unspecified"))
            {
                string altura = Height.SelectedValue;
                List<UsuarioEN> listaPorAltura = new List<UsuarioEN>();
                AlturaEN height = new AlturaEN();

                height.Height = Int32.Parse(altura);

                listaPorAltura.AddRange(
                    UsuarioCEN.DameUsuarioPorAltura(height.Height));

                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorAltura);

            }

            if (MinAge.Text.Trim() != "" && MaxAge.Text.Trim() != "")
            {
                List<UsuarioEN> listaPorEdad = new List<UsuarioEN>();
                int actualYear = DateTime.Today.Year;
                int minAge = actualYear - Convert.ToInt32(MaxAge.Text);
                int maxAge = actualYear - Convert.ToInt32(MinAge.Text);
                listaPorEdad.AddRange(UsuarioCEN.DameUsuarioPorRangoEdad(maxAge, minAge));
                listaUsuarios = filtraUsuariosNuevos(listaUsuarios, listaPorEdad);
            }

            if (Interested.Checked)
            {
                String nick;
                UsuarioCEN usuario;
                IList<UsuarioEN> usuarios;
                UsuarioEN usu;
                List<UsuarioEN> listaUsuariosAux = new List<UsuarioEN>() ;

                try
                {
                    nick = Session["Login"].ToString();
                    usuario = new UsuarioCEN();
                    usuarios = usuario.DameUsuarioPorNickname(nick);
                    usu = usuarios[0];

                    listaUsuariosAux.AddRange(listaUsuarios);

                    foreach (UsuarioEN u in listaUsuarios)
                    {
                        if (u.Likes.ToString() != usu.Gender.ToString() && u.Likes.ToString() != "Both")
                            listaUsuariosAux.Remove(u);
                    }

                    listaUsuarios = listaUsuariosAux;

                }
                catch (Exception ex) { }
            }

            LabelSalami.Text = "Found " + listaUsuarios.Count + " Salami's";

            GridView1.DataSource = listaUsuarios;
            GridView1.DataBind();
        }

        private void BusquedaExigente()
        {
            listaUsuarios.Clear();

            UsuarioCEN UsuarioCEN = new UsuarioCEN();

            {
                List<UsuarioEN> listaPorGenero = new List<UsuarioEN>();
                if (RadioWoman.Checked)
                {
                    listaPorGenero.AddRange(UsuarioCEN.DameUsuarioPorGender(GenderEnum.Woman));
                }
                else if (RadioMan.Checked)
                {
                    listaPorGenero.AddRange(UsuarioCEN.DameUsuarioPorGender(GenderEnum.Man));
                }

                listaUsuarios.AddRange(listaPorGenero);
            }


            if (TiposDeCuerpo.SelectedIndex != -1 && !TiposDeCuerpo.SelectedValue.ToString().Equals("Unspecified"))
            {
                List<UsuarioEN> listaPorCuerpo = new List<UsuarioEN>();
                string tipoDeCuerpo = TiposDeCuerpo.SelectedValue;

                listaPorCuerpo.AddRange(UsuarioCEN.DameUsuarioPorBodyType(
                   (BodyTypeEnum)Enum.Parse(typeof(BodyTypeEnum), tipoDeCuerpo)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorCuerpo)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (Etnia.SelectedIndex != -1 && !Etnia.SelectedValue.ToString().Equals("Unspecified"))
            {
                string etnia = Etnia.SelectedValue;
                List<UsuarioEN> listaPorEtnia = new List<UsuarioEN>();

                listaPorEtnia.AddRange(UsuarioCEN.DameUsuarioPorEthnicity(
                    (EthnicityEnum)Enum.Parse(typeof(EthnicityEnum), etnia)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorEtnia)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (ColorOjos.SelectedIndex != -1 && !ColorOjos.SelectedValue.ToString().Equals("Unspecified"))
            {
                string ojos = ColorOjos.SelectedValue;
                List<UsuarioEN> listaPorColorOjos = new List<UsuarioEN>();

                listaPorColorOjos.AddRange(UsuarioCEN.DameUsuarioPorEyeColor(
                    (EyeColorEnum)Enum.Parse(typeof(EyeColorEnum), ojos)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorColorOjos)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }


            if (ColorPelo.SelectedIndex != -1 && !ColorPelo.SelectedValue.ToString().Equals("Unspecified"))
            {
                string pelo = ColorPelo.SelectedValue;
                List<UsuarioEN> listaPorColorPelo = new List<UsuarioEN>();

                listaPorColorPelo.AddRange(UsuarioCEN.DameUsuarioPorHairColor(
                    (HairColorEnum)Enum.Parse(typeof(HairColorEnum), pelo)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorColorPelo)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }


            if (LongitudPelo.SelectedIndex != -1 && !LongitudPelo.SelectedValue.ToString().Equals("Unspecified"))
            {
                string cabello = LongitudPelo.SelectedValue;
                List<UsuarioEN> listaPorLongitudPelo = new List<UsuarioEN>();

                listaPorLongitudPelo.AddRange(UsuarioCEN.DameUsuarioPorHairLength(
                    (HairLengthEnum)Enum.Parse(typeof(HairLengthEnum), cabello)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorLongitudPelo)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (EstiloPelo.SelectedIndex != -1 && !EstiloPelo.SelectedValue.ToString().Equals("Unspecified"))
            {
                string peinado = EstiloPelo.SelectedValue;
                List<UsuarioEN> listaPorEstiloPelo = new List<UsuarioEN>();

                listaPorEstiloPelo.AddRange(UsuarioCEN.DameUsuarioPorHairStyle(
                    (HairStyleEnum)Enum.Parse(typeof(HairStyleEnum), peinado)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorEstiloPelo)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (Religion.SelectedIndex != -1 && !Religion.SelectedValue.ToString().Equals("Unspecified"))
            {
                string religion = Religion.SelectedValue;
                List<UsuarioEN> listaPorReligion = new List<UsuarioEN>();

                listaPorReligion.AddRange(UsuarioCEN.DameUsuarioPorReligion(
                    (ReligionEnum)Enum.Parse(typeof(ReligionEnum), religion)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorReligion)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }


            if (Fumador.SelectedIndex != -1 && !Fumador.SelectedValue.ToString().Equals("Unspecified"))
            {
                string fumador = Fumador.SelectedValue;
                List<UsuarioEN> listaPorFumador = new List<UsuarioEN>();

                listaPorFumador.AddRange(UsuarioCEN.DameUsuarioPorFumar(
                    (SmokeEnum)Enum.Parse(typeof(SmokeEnum), fumador)));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorFumador)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (NacionalidadList.SelectedIndex != -1 && !NacionalidadList.SelectedValue.ToString().Equals("Unspecified"))
            {
                string valor = NacionalidadList.SelectedValue;
                List<UsuarioEN> listaPorNacionalidad = new List<UsuarioEN>();
                NacionalidadEN nacion = new NacionalidadEN();
                nacion.Name = valor;

                listaPorNacionalidad.AddRange(
                    UsuarioCEN.DameUsuarioPorNacionalidad(nacion.Name));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorNacionalidad)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (Height.SelectedIndex != -1 && !Height.SelectedValue.ToString().Equals("Unspecified"))
            {
                string altura = Height.SelectedValue;
                List<UsuarioEN> listaPorAltura = new List<UsuarioEN>();
                AlturaEN height = new AlturaEN();

                height.Height = Int32.Parse(altura);

                listaPorAltura.AddRange(
                    UsuarioCEN.DameUsuarioPorAltura(height.Height));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorAltura)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (MinAge.Text.Trim() != "" && MaxAge.Text.Trim() != "")
            {
                List<UsuarioEN> listaPorEdad = new List<UsuarioEN>();
                int actualYear = DateTime.Today.Year;
                int minAge = actualYear - Convert.ToInt32(MaxAge.Text);
                int maxAge = actualYear - Convert.ToInt32(MinAge.Text);
                listaPorEdad.AddRange(UsuarioCEN.DameUsuarioPorRangoEdad(maxAge, minAge));

                {
                    List<UsuarioEN> listaAux = new List<UsuarioEN>();
                    foreach (UsuarioEN u in listaPorEdad)
                    {
                        if (listaUsuarios.Contains(u))
                            listaAux.Add(u);
                    }

                    listaUsuarios = listaAux;
                }
            }

            if (Interested.Checked)
            {
                String nick;
                UsuarioCEN usuario;
                IList<UsuarioEN> usuarios;
                UsuarioEN usu;
                List<UsuarioEN> listaUsuariosAux = new List<UsuarioEN>();

                try
                {
                    nick = Session["Login"].ToString();
                    usuario = new UsuarioCEN();
                    usuarios = usuario.DameUsuarioPorNickname(nick);
                    usu = usuarios[0];

                    listaUsuariosAux.AddRange(listaUsuarios);

                    foreach (UsuarioEN u in listaUsuarios)
                    {
                        if (u.Likes.ToString() != usu.Gender.ToString() && u.Likes.ToString() != "Both")
                            listaUsuariosAux.Remove(u);
                    }

                    listaUsuarios = listaUsuariosAux;

                }
                catch (Exception) { }

            }

            LabelSalami.Text = "Found " + listaUsuarios.Count + " Salami's";

            GridView1.DataSource = listaUsuarios;
            GridView1.DataBind();

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

        protected void Recomend_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Recomendar.aspx");
        }


    }

}