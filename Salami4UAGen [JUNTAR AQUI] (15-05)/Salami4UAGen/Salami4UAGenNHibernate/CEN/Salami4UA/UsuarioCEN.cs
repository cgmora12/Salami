

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CAD.Salami4UA;

namespace Salami4UAGenNHibernate.CEN.Salami4UA
{
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string New_ (string p_Nickname, string p_Password, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum p_HairColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum p_EyeColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum p_HairLength, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum p_HairStyle, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum p_BodyType, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum p_Ethnicity, Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum p_Religion, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum p_Smoke, string p_email, Nullable<DateTime> p_Birthday, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum p_Gender, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum p_Likes, string p_Name, string p_Surname, string p_Comment, string p_ValidationCode, string p_Career, Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum p_Course, string p_Nationality, int p_Height, System.Collections.Generic.IList<string> p_Pets, System.Collections.Generic.IList<string> p_Films, System.Collections.Generic.IList<string> p_Musics, System.Collections.Generic.IList<string> p_Characteristics, System.Collections.Generic.IList<string> p_Sports, System.Collections.Generic.IList<string> p_Hobbies, string p_UrlFoto, string p_gustos)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nickname = p_Nickname;

        usuarioEN.Password = p_Password;

        usuarioEN.HairColor = p_HairColor;

        usuarioEN.EyeColor = p_EyeColor;

        usuarioEN.HairLength = p_HairLength;

        usuarioEN.HairStyle = p_HairStyle;

        usuarioEN.BodyType = p_BodyType;

        usuarioEN.Ethnicity = p_Ethnicity;

        usuarioEN.Religion = p_Religion;

        usuarioEN.Smoke = p_Smoke;

        usuarioEN.Email = p_email;

        usuarioEN.Birthday = p_Birthday;

        usuarioEN.Gender = p_Gender;

        usuarioEN.Likes = p_Likes;

        usuarioEN.Name = p_Name;

        usuarioEN.Surname = p_Surname;

        usuarioEN.Comment = p_Comment;

        usuarioEN.ValidationCode = p_ValidationCode;

        usuarioEN.Career = p_Career;

        usuarioEN.Course = p_Course;

        usuarioEN.Nationality = p_Nationality;

        usuarioEN.Height = p_Height;

        usuarioEN.Pets = p_Pets;

        usuarioEN.Films = p_Films;

        usuarioEN.Musics = p_Musics;

        usuarioEN.Characteristics = p_Characteristics;

        usuarioEN.Sports = p_Sports;

        usuarioEN.Hobbies = p_Hobbies;

        usuarioEN.UrlFoto = p_UrlFoto;


        if (p_gustos != null) {
                usuarioEN.Gustos = new Salami4UAGenNHibernate.EN.Salami4UA.GustosEN ();
                usuarioEN.Gustos.Nickname = p_gustos;
        }

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_Password, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum p_HairColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum p_EyeColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum p_HairLength, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum p_HairStyle, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum p_BodyType, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum p_Ethnicity, Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum p_Religion, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum p_Smoke, string p_email, Nullable<DateTime> p_Birthday, Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum p_Gender, Salami4UAGenNHibernate.Enumerated.Salami4UA.LikesEnum p_Likes, string p_Name, string p_Surname, string p_Comment, string p_ValidationCode, string p_Career, Salami4UAGenNHibernate.Enumerated.Salami4UA.CourseEnum p_Course, string p_Nationality, int p_Height, System.Collections.Generic.IList<string> p_Pets, System.Collections.Generic.IList<string> p_Films, System.Collections.Generic.IList<string> p_Musics, System.Collections.Generic.IList<string> p_Characteristics, System.Collections.Generic.IList<string> p_Sports, System.Collections.Generic.IList<string> p_Hobbies, string p_UrlFoto)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nickname = p_Usuario_OID;
        usuarioEN.Password = p_Password;
        usuarioEN.HairColor = p_HairColor;
        usuarioEN.EyeColor = p_EyeColor;
        usuarioEN.HairLength = p_HairLength;
        usuarioEN.HairStyle = p_HairStyle;
        usuarioEN.BodyType = p_BodyType;
        usuarioEN.Ethnicity = p_Ethnicity;
        usuarioEN.Religion = p_Religion;
        usuarioEN.Smoke = p_Smoke;
        usuarioEN.Email = p_email;
        usuarioEN.Birthday = p_Birthday;
        usuarioEN.Gender = p_Gender;
        usuarioEN.Likes = p_Likes;
        usuarioEN.Name = p_Name;
        usuarioEN.Surname = p_Surname;
        usuarioEN.Comment = p_Comment;
        usuarioEN.ValidationCode = p_ValidationCode;
        usuarioEN.Career = p_Career;
        usuarioEN.Course = p_Course;
        usuarioEN.Nationality = p_Nationality;
        usuarioEN.Height = p_Height;
        usuarioEN.Pets = p_Pets;
        usuarioEN.Films = p_Films;
        usuarioEN.Musics = p_Musics;
        usuarioEN.Characteristics = p_Characteristics;
        usuarioEN.Sports = p_Sports;
        usuarioEN.Hobbies = p_Hobbies;
        usuarioEN.UrlFoto = p_UrlFoto;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string Nickname)
{
        _IUsuarioCAD.Destroy (Nickname);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEmail (string mail)
{
        return _IUsuarioCAD.DameUsuarioPorEmail (mail);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorNickname (string nombre)
{
        return _IUsuarioCAD.DameUsuarioPorNickname (nombre);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameTodosLosUsuarios ()
{
        return _IUsuarioCAD.DameTodosLosUsuarios ();
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorBodyType (Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum bodyType)
{
        return _IUsuarioCAD.DameUsuarioPorBodyType (bodyType);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEthnicity (Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum etnia)
{
        return _IUsuarioCAD.DameUsuarioPorEthnicity (etnia);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEyeColor (Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum color)
{
        return _IUsuarioCAD.DameUsuarioPorEyeColor (color);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairColor (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum color)
{
        return _IUsuarioCAD.DameUsuarioPorHairColor (color);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairLength (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum tamanyo)
{
        return _IUsuarioCAD.DameUsuarioPorHairLength (tamanyo);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairStyle (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum estilo)
{
        return _IUsuarioCAD.DameUsuarioPorHairStyle (estilo);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorReligion (Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum religion)
{
        return _IUsuarioCAD.DameUsuarioPorReligion (religion);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorFumar (Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum fumar)
{
        return _IUsuarioCAD.DameUsuarioPorFumar (fumar);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorGender (Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum genero)
{
        return _IUsuarioCAD.DameUsuarioPorGender (genero);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorNacionalidad (string nacionalidad)
{
        return _IUsuarioCAD.DameUsuarioPorNacionalidad (nacionalidad);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorAltura (int altura)
{
        return _IUsuarioCAD.DameUsuarioPorAltura (altura);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorRangoEdad (int min, int max)
{
        return _IUsuarioCAD.DameUsuarioPorRangoEdad (min, max);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorCarrera (string carrera)
{
        return _IUsuarioCAD.DameUsuarioPorCarrera (carrera);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorCurso (string curso)
{
        return _IUsuarioCAD.DameUsuarioPorCurso (curso);
}
}
}
