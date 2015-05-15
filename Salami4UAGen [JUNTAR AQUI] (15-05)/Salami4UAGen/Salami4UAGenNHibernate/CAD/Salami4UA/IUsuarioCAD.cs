
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string Nickname);

string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string Nickname);



System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEmail (string mail);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorNickname (string nombre);



System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameTodosLosUsuarios ();


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorBodyType (Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum bodyType);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEthnicity (Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum etnia);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorEyeColor (Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum color);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairColor (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum color);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairLength (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum tamanyo);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorHairStyle (Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum estilo);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorReligion (Salami4UAGenNHibernate.Enumerated.Salami4UA.ReligionEnum religion);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorFumar (Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum fumar);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorGender (Salami4UAGenNHibernate.Enumerated.Salami4UA.GenderEnum genero);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorNacionalidad (string nacionalidad);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorAltura (int altura);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorRangoEdad (int min, int max);



System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorCarrera (string carrera);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN> DameUsuarioPorCurso (string curso);
}
}
