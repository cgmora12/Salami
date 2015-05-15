
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
public partial class MusicasCEN
{
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN> DameGustosMusicalesPorUsuario (string nickname)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Musicas_dameGustosMusicalesPorUsuario) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN> todoMusica = new MusicasCEN ().DameTodosLosGustosMusicales ();
        while (todoMusica.Count != 0) {
                todoMusica.RemoveAt (0);
        }

        BasicCP basic = new BasicCP ();

        try
        {
                basic.SessionInitializeTransaction ();
                MusicasCAD musicaCAD = new MusicasCAD (basic.session);
                UsuarioCAD usuarioCAD = new UsuarioCAD (basic.session);
                UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (nickname);

                foreach (String musica in usuarioEN.Musics) {
                        MusicasEN m = new MusicasEN ();
                        m.Name = musica;
                        todoMusica.Add (m);
                }
        }
        catch (Exception ex)
        {
                return null;
        }

        return todoMusica;

        /*PROTECTED REGION END*/
}
}
}
