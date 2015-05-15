
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using Salami4UAGenNHibernate.CAD.Salami4UA;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // ANIMALES DOMESTICOS

                AnimalesCEN pet = new AnimalesCEN ();



                pet.New_ ("Dog");
                pet.New_ ("Cat");
                pet.New_ ("Bird");
                pet.New_ ("Fish");
                pet.New_ ("Horse");
                pet.New_ ("Rabbit");
                pet.New_ ("Exotic animals");
                pet.New_ ("Hamster");
                pet.New_ ("I have not animals");
                pet.New_ ("Other");

                // ALTURA

                AlturaCEN height = new AlturaCEN ();

                height.New_ (140);
                height.New_ (145);
                height.New_ (150);
                height.New_ (155);
                height.New_ (160);
                height.New_ (165);
                height.New_ (170);
                height.New_ (175);
                height.New_ (180);
                height.New_ (185);
                height.New_ (190);
                height.New_ (195);
                height.New_ (200);
                height.New_ (205);
                height.New_ (210);
                height.New_ (215);
                height.New_ (220);

                // Hobbies

                AficionesCEN hoobies = new AficionesCEN ();

                hoobies.New_ ("Travel");
                hoobies.New_ ("Practice sports");
                hoobies.New_ ("To cook");
                hoobies.New_ ("Animals");
                hoobies.New_ ("Rides");
                hoobies.New_ ("Computers / Internet");
                hoobies.New_ ("Cars / Motorbikes");
                hoobies.New_ ("Dance");
                hoobies.New_ ("Video Games");
                hoobies.New_ ("Writing");
                hoobies.New_ ("Volunteering");
                hoobies.New_ ("Music");
                hoobies.New_ ("Reading");
                hoobies.New_ ("Photography");
                hoobies.New_ ("Theater");
                hoobies.New_ ("Exhibitions");
                hoobies.New_ ("Television");
                hoobies.New_ ("Painting / Drawing");
                hoobies.New_ ("Decoration");
                hoobies.New_ ("Gardening");
                hoobies.New_ ("Cardgames");
                hoobies.New_ ("BoardGames");

                // Sports

                DeportesCEN sport = new DeportesCEN ();

                sport.New_ ("Football");
                sport.New_ ("Fitness");
                sport.New_ ("Tennis");
                sport.New_ ("Basketball");
                sport.New_ ("Athletics");
                sport.New_ ("Gymnastics");
                sport.New_ ("Ski / Snowboard");
                sport.New_ ("Motorcycling");
                sport.New_ ("Martial arts");
                sport.New_ ("Volleyball");
                sport.New_ ("Sailing");
                sport.New_ ("Horse riding");
                sport.New_ ("Swimming");
                sport.New_ ("Cycling");
                sport.New_ ("Trekking");
                sport.New_ ("Motoring");
                sport.New_ ("Dance");
                sport.New_ ("Run");
                sport.New_ ("Extreme sports");
                sport.New_ ("Boxing");
                sport.New_ ("Table tennis");
                sport.New_ ("Other water sports");
                sport.New_ ("Handball");

                // Gustos Musicales

                MusicasCEN musica = new MusicasCEN ();

                musica.New_ ("Pop");
                musica.New_ ("Disco");
                musica.New_ ("Dance");
                musica.New_ ("Blues");
                musica.New_ ("Jazz");
                musica.New_ ("Rap");
                musica.New_ ("Country");
                musica.New_ ("Rock");
                musica.New_ ("Latin");
                musica.New_ ("Classical");
                musica.New_ ("Soul");
                musica.New_ ("Gospel");
                musica.New_ ("Hip-Hop");
                musica.New_ ("Opera");
                musica.New_ ("Tecno");
                musica.New_ ("International");
                musica.New_ ("Soundtracks");
                musica.New_ ("Traditional");

                // Nacionalidad

                NacionalidadCEN nacionalidad = new NacionalidadCEN ();

                nacionalidad.New_ ("Spanish");
                nacionalidad.New_ ("Danish");
                nacionalidad.New_ ("British");
                nacionalidad.New_ ("Estonian");
                nacionalidad.New_ ("Finnish");
                nacionalidad.New_ ("Icelandic");
                nacionalidad.New_ ("Irish");
                nacionalidad.New_ ("Latvian");
                nacionalidad.New_ ("Lithuanian");
                nacionalidad.New_ ("Norwegian");
                nacionalidad.New_ ("Scottish");
                nacionalidad.New_ ("Swedish");
                nacionalidad.New_ ("Welsh");
                nacionalidad.New_ ("Austrian");
                nacionalidad.New_ ("Belgian");
                nacionalidad.New_ ("French");
                nacionalidad.New_ ("German");
                nacionalidad.New_ ("Dutch");
                nacionalidad.New_ ("Swiss");
                nacionalidad.New_ ("Albanian");
                nacionalidad.New_ ("Croatian");
                nacionalidad.New_ ("Cypriot");
                nacionalidad.New_ ("Greek");
                nacionalidad.New_ ("Italian");
                nacionalidad.New_ ("Portuguese");
                nacionalidad.New_ ("Serbian");
                nacionalidad.New_ ("Slovenian");
                nacionalidad.New_ ("Belarusian");
                nacionalidad.New_ ("Bulgarian");
                nacionalidad.New_ ("Czech");
                nacionalidad.New_ ("Huagarian");
                nacionalidad.New_ ("Polish");
                nacionalidad.New_ ("Romanian");
                nacionalidad.New_ ("Russian");
                nacionalidad.New_ ("Slovak");
                nacionalidad.New_ ("Ukrainian");
                nacionalidad.New_ ("Canadian");
                nacionalidad.New_ ("Mexican");
                nacionalidad.New_ ("American");
                nacionalidad.New_ ("Cuban");
                nacionalidad.New_ ("Guatemalan");
                nacionalidad.New_ ("Jamaican");
                nacionalidad.New_ ("Argentinian");
                nacionalidad.New_ ("Bolivian");
                nacionalidad.New_ ("Brazilian");
                nacionalidad.New_ ("Chilean");
                nacionalidad.New_ ("Colombian");
                nacionalidad.New_ ("Ecuadorian");
                nacionalidad.New_ ("Paraguayan");
                nacionalidad.New_ ("Peruvian");
                nacionalidad.New_ ("Uruguayan");
                nacionalidad.New_ ("Venezuelan");
                nacionalidad.New_ ("Georgian");
                nacionalidad.New_ ("Iranian");
                nacionalidad.New_ ("Iraqi");
                nacionalidad.New_ ("Israeli");
                nacionalidad.New_ ("Jordanian");
                nacionalidad.New_ ("Kuwaiti");
                nacionalidad.New_ ("Lebanese");
                nacionalidad.New_ ("Palestinian");
                nacionalidad.New_ ("Saudi Arabian");
                nacionalidad.New_ ("Syrian");
                nacionalidad.New_ ("Turkish");
                nacionalidad.New_ ("Yemeni");
                nacionalidad.New_ ("Afghan");
                nacionalidad.New_ ("Bangladeshi");
                nacionalidad.New_ ("Indian");
                nacionalidad.New_ ("Kazakh");
                nacionalidad.New_ ("Nepalese");
                nacionalidad.New_ ("Pakistani");
                nacionalidad.New_ ("Sri Lankan");
                nacionalidad.New_ ("Chinese");
                nacionalidad.New_ ("Japanese");
                nacionalidad.New_ ("Mongolian");
                nacionalidad.New_ ("North Korean");
                nacionalidad.New_ ("South Korean");
                nacionalidad.New_ ("Taiwanese");
                nacionalidad.New_ ("Cambodian");
                nacionalidad.New_ ("Indonesian");
                nacionalidad.New_ ("Laotian");
                nacionalidad.New_ ("Malaysian");
                nacionalidad.New_ ("Burmese");
                nacionalidad.New_ ("Filipino");
                nacionalidad.New_ ("Singaporean");
                nacionalidad.New_ ("Thai");
                nacionalidad.New_ ("Vietnamese");
                nacionalidad.New_ ("Australian");
                nacionalidad.New_ ("Fijian");
                nacionalidad.New_ ("New Zealand");
                nacionalidad.New_ ("Algerian");
                nacionalidad.New_ ("Egyptian");
                nacionalidad.New_ ("Ghanaian");
                nacionalidad.New_ ("Ivorian");
                nacionalidad.New_ ("Lybian");
                nacionalidad.New_ ("Moroccan");
                nacionalidad.New_ ("Nigeria");
                nacionalidad.New_ ("Tunisian");
                nacionalidad.New_ ("Ethiopian");
                nacionalidad.New_ ("Kenyan");
                nacionalidad.New_ ("Somali");
                nacionalidad.New_ ("Sudanese");
                nacionalidad.New_ ("Tanzanian");
                nacionalidad.New_ ("Ugandan");
                nacionalidad.New_ ("Angola");
                nacionalidad.New_ ("Botswanan");
                nacionalidad.New_ ("Congolese");
                nacionalidad.New_ ("Malagasy");
                nacionalidad.New_ ("Mozambican");
                nacionalidad.New_ ("Namibian");
                nacionalidad.New_ ("South African");
                nacionalidad.New_ ("Zambian");
                nacionalidad.New_ ("Zimbabwean");

                // G�neros de cine

                CinesCEN genre = new CinesCEN ();

                genre.New_ ("Action");
                genre.New_ ("Adventure");
                genre.New_ ("Horror");
                genre.New_ ("Documentaries");
                genre.New_ ("Police");
                genre.New_ ("Fantasia");
                genre.New_ ("Erotic");
                genre.New_ ("Animated cartoon");
                genre.New_ ("Manga");
                genre.New_ ("Comedy");
                genre.New_ ("Science fiction");
                genre.New_ ("Romantic comedy");
                genre.New_ ("Historical");
                genre.New_ ("Drama");
                genre.New_ ("Animation");
                genre.New_ ("Musical");
                genre.New_ ("Western");
                genre.New_ ("Thriller");
                genre.New_ ("Other");

                // Caracteristicas personales

                CaracteristicasCEN feature = new CaracteristicasCEN ();

                feature.New_ ("No preference");
                feature.New_ ("Attentive");
                feature.New_ ("Adventurer");
                feature.New_ ("Good-humored");
                feature.New_ ("Conciliator");
                feature.New_ ("Demanding");
                feature.New_ ("Generous");
                feature.New_ ("Inspires confidence");
                feature.New_ ("Proud");
                feature.New_ ("Reserved");
                feature.New_ ("Sociable");
                feature.New_ ("Shy");
                feature.New_ ("Quiet");

                MasterCEN master = new MasterCEN ();


                master.New_ ("Professional Archaeology and Integral Management of the Heritage");
                master.New_ ("Catalan Language Consulting and Literary Culture ");
                master.New_ ("Local Development and Territorial Innovation ");
                master.New_ ("Teaching of Spanish and English as Second Languages (L2) or Foreign Languages (FL)");
                master.New_ ("Literary Studies ");
                master.New_ ("History Identities in the Western Mediterranean (15th-19th C.) ");
                master.New_ ("History of Contemporary Europe");
                master.New_ ("History of Science and Scientific Communication");
                master.New_ ("English and Spanish for Specific Purposes");
                master.New_ ("Humanities Research in the Digital Age");
                master.New_ ("Planning and Management of Natural Disasters");
                master.New_ ("Institutional Translation");
                master.New_ ("Analysis and Management of Mediterranean Ecosystems");
                master.New_ ("Biomedicine");
                master.New_ ("Biotechnology for Health and Sustainability");
                master.New_ ("Electrochemistry. Science & Technology ");
                master.New_ ("Materials Science ");
                master.New_ ("Sustainable Fisheries Management ");
                master.New_ ("Sustainable Management and Water Technologies ");
                master.New_ ("Management and Restoration of Natural Environment ");
                master.New_ ("Nanoscience and Molecular Nanotechnology ");
                master.New_ ("Applied Palaeontology");
                master.New_ ("Sustainable and Environmental Chemistry ");
                master.New_ ("Medical Chemistry ");
                master.New_ ("Nursing Sciences Research");
                master.New_ ("Clinical and Community Nutrition");
                master.New_ ("Optometry Advanced Visual and Visual Health");
                master.New_ ("Public Health");
                master.New_ ("Legal Practice");
                master.New_ ("Business Administration (MBA)");
                master.New_ ("Communication and Creative Industries");
                master.New_ ("Cooperation to Development");
                master.New_ ("Law on Environmental Sustainability");
                master.New_ ("Tourism Management and Planning");
                master.New_ ("Applied Economics");
                master.New_ ("Quantitative Economics");
                master.New_ ("Educational Research");
                master.New_ ("Criminal Investigation and Forensic Science");
                master.New_ ("Procurement");
                master.New_ ("Teacher Training in Compulsory and Upper Secondary Compulsory Education, Vocational Studies and Languages");
                master.New_ ("Penal Law System");
                master.New_ ("Automation and Robotics");
                master.New_ ("Applications Development and Web Services");
                master.New_ ("Architectura");
                master.New_ ("Software Development for Mobile Devices");
                master.New_ ("Building Management");
                master.New_ ("Geological Engineering");
                master.New_ ("Materials, Water and Soil Engineering");
                master.New_ ("Telecommunication Engineering");
                master.New_ ("Computer Engineering");
                master.New_ ("Computer Technology");
                master.New_ ("Occupational Hazard Prevention");
                master.New_ ("Civil Engineering");
                master.New_ ("Chemical Engineering");

                CarreraCEN career = new CarreraCEN ();

                career.New_ ("Spanish: Language and Literature");
                career.New_ ("Arabic & Islamic Studies");
                career.New_ ("French Studies");
                career.New_ ("English Studies");
                career.New_ ("Catalan Studies");
                career.New_ ("History");
                career.New_ ("Humanities");
                career.New_ ("Translation and Interpreting");
                career.New_ ("Biology");
                career.New_ ("Marine Studies");
                career.New_ ("Geology");
                career.New_ ("Mathematics");
                career.New_ ("Chemistry");
                career.New_ ("Nursing");
                career.New_ ("Human Nutrition & Dietetics");
                career.New_ ("Optics and Optometry");
                career.New_ ("Business Administration");
                career.New_ ("Physical Activity and Sports Sciences");
                career.New_ ("Criminology");
                career.New_ ("Law");
                career.New_ ("Law and Bssiness Administration");
                career.New_ ("Law and Criminology");
                career.New_ ("Economics");
                career.New_ ("Geography and Land Use Planning");
                career.New_ ("Public Management & Administration");
                career.New_ ("Pre-school Education Speciality");
                career.New_ ("Primary Education Speciality");
                career.New_ ("Publicity and Public Relations");
                career.New_ ("Labour Relations and Human Resources");
                career.New_ ("Sociology");
                career.New_ ("Social Work");
                career.New_ ("Tourism");
                career.New_ ("Tourism and Bussiness Administration");
                career.New_ ("Architecture");
                career.New_ ("Architectural Technology (formerly Building Engineering)");
                career.New_ ("Fundamentals of Architecture");
                career.New_ ("Sound and Image in Telecommunication Engineering");
                career.New_ ("Civil Engineering");
                career.New_ ("Computer Engineering");
                career.New_ ("Multimedia Engineering");
                career.New_ ("Chemical Engineering");


                // Usuario admin

                UsuarioCEN usuario = new UsuarioCEN ();

                AnimalesCEN animal = new AnimalesCEN ();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> animalesEN = animal.DameTodosLosAnimales ();
                List<string> animales = new List<string>();
                foreach (AnimalesEN p in animalesEN) {
                        animales.Add (p.Name);
                }



                AficionesCEN hobbie = new AficionesCEN ();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> AficionesEN = hobbie.DameTodosLosHobbies ();
                List<string> hobbiesString = new List<string>();
                foreach (AficionesEN p in AficionesEN) {
                        hobbiesString.Add (p.Name);
                }




                CaracteristicasCEN caracteristica = new CaracteristicasCEN ();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> caracteristicasEN = caracteristica.DameTodasLasCaracteristicas ();
                List<string> caracteristicas = new List<string>();
                foreach (CaracteristicasEN p in caracteristicasEN) {
                        caracteristicas.Add (p.Name);
                }



                CinesCEN cine = new CinesCEN ();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> cinesEN = cine.DameTodosLosGenerosCine ();
                List<string> cines = new List<string>();
                foreach (CinesEN p in cinesEN) {
                        cines.Add (p.Name);
                }



                MusicasCEN music = new MusicasCEN ();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN> musicasEN = musica.DameTodosLosGustosMusicales ();
                List<string> musicas = new List<string>();
                foreach (MusicasEN p in musicasEN) {
                        musicas.Add (p.Name);
                }


                DeportesCEN deporte = new DeportesCEN ();
                IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> deportesEN = deporte.DameTodosLosDeportes ();
                List<string> deportes = new List<string>();
                foreach (DeportesEN p in deportesEN) {
                        deportes.Add (p.Name);
                }

                GustosCEN gustoCen = new GustosCEN ();
                gustoCen.New_ ("admin", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("admin", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Hairless,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Curly, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Agnostic,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No, "salami4ua@gmail.com",
                        DateTime.Today, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Both, "Admin", "Admin", "I'm the boss", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.First,
                        "Spanish", 180, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "http://www.consejosgratis.es/wp-content/uploads/2011/02/estudiar-administracion.jpg", "admin");




                DateTime tiempo = new DateTime ();
                tiempo = Convert.ToDateTime ("05/02/1989");

                gustoCen.New_ ("cuqui85", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("cuqui85", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Brown, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Green,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Normal, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Straight,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Slim, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.European,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Agnostic, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.Often, "cuqui85@alu.ua.es",
                        tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Woman, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Man, "Lucy", "Milles",
                        "I want to find men COME ON!", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.Second,
                        "Polish", 165, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "http://farm6.static.flickr.com/5072/5905429328_e253c5a5a7.jpg", "cuqui85");


                tiempo = Convert.ToDateTime ("15/12/1965");
                gustoCen.New_ ("CapitanSalami", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("CapitanSalami", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.LightBrown, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Brown, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Shaven, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Straight, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Solidly, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.Mediterranean,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Catholic, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.Occasionally,
                        "capitanSalami@alu.ua.es", tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Woman,
                        "Amador", "Rivas", "Do you want Salami? PINCHITO FOR YOU?", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.First,
                        "Spanish", 185, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "https://lh3.ggpht.com/-B-3nCRO6UKUuXRzsOQNsgr1OPX8TWYxQucpE7xSE_t-GdhJCq_Xt1iJ6toDIhKVTA", "CapitanSalami");

                tiempo = Convert.ToDateTime ("25/08/1970");
                gustoCen.New_ ("PepitoBoss", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("PepitoBoss", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.DarkBrown, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Blue, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Short, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Curly, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Slim, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.Mediterranean,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Atheist, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No,
                        "pepitoboss@alu.ua.es", tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Woman,
                        "Roberto", "Miralles", "I'm The BOSS of the people!!", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.Fourth,
                        "Belgian", 170, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "https://pbs.twimg.com/profile_images/475403851839721472/TjwOIzOq.jpeg", "PepitoBoss");


                tiempo = Convert.ToDateTime ("10/06/1977");
                gustoCen.New_ ("EdgarMICO", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("EdgarMICO", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Gray, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Grey, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Normal, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Straight, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.Asian,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Christian, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.Often,
                        "edgar@alu.ua.es", tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Both,
                        "Edgar", "Bellot", "I'm from MONOVAR, terreta del caloret!!", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.Second,
                        "North Korean", 185, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "https://pbs.twimg.com/profile_images/3521949696/ee2215236fcab381753b9d5f4176f422.jpeg", "EdgarMICO");


                tiempo = Convert.ToDateTime ("10/06/1945");
                gustoCen.New_ ("4Never", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("4Never", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Redhead, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Hazel, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Shaven, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Curly, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Sports, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.Arab,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Hindu, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.Occasionally,
                        "david@alu.ua.es", tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Woman,
                        "David", "Martinez", "Salami, salami, salami... if you know what I mean", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.Third,
                        "Pakistani", 180, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "https://pbs.twimg.com/profile_images/2796970460/00c0bf364afcc569a960342e3bebac3f.jpeg", "4Never");

                tiempo = Convert.ToDateTime ("20/04/1984");
                gustoCen.New_ ("CesicarCEO", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("CesicarCEO", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.White, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Hairless, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Straight, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Normal, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.Mestizo,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Orthodox, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No,
                        "cesar@alu.ua.es", tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Woman,
                        "Cesar", "Gonzalez", "I'm already AVALAIBLE...", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.Second,
                        "Israeli", 175, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "https://pbs.twimg.com/profile_images/586659555129630722/Oou0chNo.jpg", "CesicarCEO");


                tiempo = Convert.ToDateTime ("17/11/1996");
                gustoCen.New_ ("Albertico", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Black, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Bald, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.African, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.No);

                usuario.New_ ("Albertico", "81dc9bdb52d04dc20036dbd8313ed055", Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum.Blonde, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum.Other, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum.Long, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum.Curly, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum.Corpulent, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum.Latino,
                        Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum.Buddhist, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum.Often,
                        "alberto@alu.ua.es", tiempo, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum.Man, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum.Woman,
                        "Alberto", "Esteban", "If you want to have a great moment...", "", "Carrera", Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum.Third,
                        "New Zealand", 175, animales, cines, musicas, caracteristicas, deportes, hobbiesString, "https://pbs.twimg.com/profile_images/3569994446/139702a8893b224512a13854b6fb61f8.jpeg", "Albertico");

































































































                /*List<Salami4UAGenNHibernate.EN.Mediaplayer.MusicTrackEN> musicTracks = new List<Salami4UAGenNHibernate.EN.Mediaplayer.MusicTrackEN>();
                 * Salami4UAGenNHibernate.EN.Mediaplayer.UsuarioEN UsuarioEN = new Salami4UAGenNHibernate.EN.Mediaplayer.UsuarioEN();
                 * Salami4UAGenNHibernate.EN.Mediaplayer.ArtistEN artistEN = new Salami4UAGenNHibernate.EN.Mediaplayer.ArtistEN();
                 * Salami4UAGenNHibernate.EN.Mediaplayer.MusicTrackEN musicTrackEN = new Salami4UAGenNHibernate.EN.Mediaplayer.MusicTrackEN();
                 * Salami4UAGenNHibernate.CEN.Mediaplayer.ArtistCEN artistCEN = new Salami4UAGenNHibernate.CEN.Mediaplayer.ArtistCEN();
                 * Salami4UAGenNHibernate.CEN.Mediaplayer.UsuarioCEN UsuarioCEN = new Salami4UAGenNHibernate.CEN.Mediaplayer.UsuarioCEN();
                 * Salami4UAGenNHibernate.CEN.Mediaplayer.MusicTrackCEN musicTrackCEN = new Salami4UAGenNHibernate.CEN.Mediaplayer.MusicTrackCEN();
                 * Salami4UAGenNHibernate.CEN.Mediaplayer.PlayListCEN playListCEN = new Salami4UAGenNHibernate.CEN.Mediaplayer.PlayListCEN();
                 *
                 *              //Add Users
                 * UsuarioEN.Email = "user@user.com";
                 * UsuarioEN.Name = "user";
                 * UsuarioEN.Surname = "userSurname";
                 * UsuarioEN.Password = "user";
                 * UsuarioCEN.New_(UsuarioEN.Name, UsuarioEN.Surname, UsuarioEN.Email, UsuarioEN.Password);
                 *
                 * //Add Music Track1
                 * musicTrackEN.Id = "http://www2.b3ta.com/mp3/Beer Beer Beer (YOB mix).mp3";
                 * musicTrackEN.Format = "mp3";
                 * musicTrackEN.Lyrics = "Beer Beer Beer Beer Beer Beer ..";
                 * musicTrackEN.Name = "Beer Beer Beer";
                 * musicTrackEN.Company = "Company";
                 * musicTrackEN.Cover = "http://www.tomasabraham.com.ar/cajadig/2007/images/nro18-2/beer1.jpg";
                 * musicTrackEN.Price = 20;
                 * musicTrackEN.Rating = 5;
                 * musicTrackEN.CommunityRating = 5;
                 * musicTrackEN.Duration = 200;
                 * musicTrackCEN.New_(musicTrackEN.Id, musicTrackEN.Format, musicTrackEN.Lyrics, musicTrackEN.Name,
                 *  musicTrackEN.Company, musicTrackEN.Cover, musicTrackEN.CommunityRating, musicTrackEN.Rating,
                 *  musicTrackEN.Price, musicTrackEN.Duration);
                 * musicTracks.Add(musicTrackEN);
                 * musicTrackCEN.AsignUser(musicTrackEN.Id,UsuarioEN.Email);
                 *
                 * //Define Album
                 * //Salami4UAGenNHibernate.CEN.Mediaplayer.AlbumCEN albumCEN = new Salami4UAGenNHibernate.CEN.Mediaplayer.AlbumCEN();
                 * //albumCEN.New_("Album 1", "This is a Album 1", artists, musicTracks);*/
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
