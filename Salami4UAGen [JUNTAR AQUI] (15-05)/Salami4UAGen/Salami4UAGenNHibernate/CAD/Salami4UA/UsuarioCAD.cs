
using System;
using System.Text;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.Exceptions;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (string Nickname)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), Nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}


public string New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                if (usuario.Gustos != null) {
                        usuario.Gustos = (Salami4UAGenNHibernate.EN.Salami4UA.GustosEN)session.Load (typeof(Salami4UAGenNHibernate.EN.Salami4UA.GustosEN), usuario.Gustos.Nickname);

                        usuario.Gustos.Usuario = usuario;
                }

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Nickname;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Nickname);

                usuarioEN.Password = usuario.Password;


                usuarioEN.HairColor = usuario.HairColor;


                usuarioEN.EyeColor = usuario.EyeColor;


                usuarioEN.HairLength = usuario.HairLength;


                usuarioEN.HairStyle = usuario.HairStyle;


                usuarioEN.BodyType = usuario.BodyType;


                usuarioEN.Ethnicity = usuario.Ethnicity;


                usuarioEN.Religion = usuario.Religion;


                usuarioEN.Smoke = usuario.Smoke;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Birthday = usuario.Birthday;


                usuarioEN.Gender = usuario.Gender;


                usuarioEN.Likes = usuario.Likes;


                usuarioEN.Name = usuario.Name;


                usuarioEN.Surname = usuario.Surname;


                usuarioEN.Comment = usuario.Comment;


                usuarioEN.ValidationCode = usuario.ValidationCode;


                usuarioEN.Career = usuario.Career;


                usuarioEN.Course = usuario.Course;


                usuarioEN.Nationality = usuario.Nationality;


                usuarioEN.Height = usuario.Height;


                usuarioEN.Pets = usuario.Pets;


                usuarioEN.Films = usuario.Films;


                usuarioEN.Musics = usuario.Musics;


                usuarioEN.Characteristics = usuario.Characteristics;


                usuarioEN.Sports = usuario.Sports;


                usuarioEN.Hobbies = usuario.Hobbies;


                usuarioEN.UrlFoto = usuario.UrlFoto;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string Nickname)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), Nickname);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEmail (string mail)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Email = :mail";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorEmailHQL");
                query.SetParameter ("mail", mail);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorNickname (string nombre)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Nickname = :nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorNicknameHQL");
                query.SetParameter ("nombre", nombre);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameTodosLosUsuarios ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameTodosLosUsuariosHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorBodyType (Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum bodyType)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.BodyType = :bodyType";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorBodyTypeHQL");
                query.SetParameter ("bodyType", bodyType);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEthnicity (Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum etnia)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Ethnicity = :etnia";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorEthnicityHQL");
                query.SetParameter ("etnia", etnia);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEyeColor (Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum color)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.EyeColor = :color";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorEyeColorHQL");
                query.SetParameter ("color", color);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairColor (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum color)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.HairColor = :color";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorHairColorHQL");
                query.SetParameter ("color", color);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairLength (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum tamanyo)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.HairLength = :tamanyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorHairLengthHQL");
                query.SetParameter ("tamanyo", tamanyo);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairStyle (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum estilo)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.HairStyle = :estilo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorHairStyleHQL");
                query.SetParameter ("estilo", estilo);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorReligion (Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum religion)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Religion = :religion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorReligionHQL");
                query.SetParameter ("religion", religion);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorFumar (Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum fumar)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Smoke = :fumar";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorFumarHQL");
                query.SetParameter ("fumar", fumar);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorGender (Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum genero)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Gender = :genero";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorGenderHQL");
                query.SetParameter ("genero", genero);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorNacionalidad (string nacionalidad)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Nationality = :nacionalidad";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorNacionalidadHQL");
                query.SetParameter ("nacionalidad", nacionalidad);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorAltura (int altura)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Height = :altura";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorAlturaHQL");
                query.SetParameter ("altura", altura);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorRangoEdad (int min, int max)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE year(c.Birthday) < :min AND year(c.Birthday) > :max";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorRangoEdadHQL");
                query.SetParameter ("min", min);
                query.SetParameter ("max", max);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorCarrera (string carrera)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Career = :carrera";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorCarreraHQL");
                query.SetParameter ("carrera", carrera);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorCurso (Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum curso)
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN c WHERE c.Course = :curso";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorCursoHQL");
                query.SetParameter ("curso", curso);

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
