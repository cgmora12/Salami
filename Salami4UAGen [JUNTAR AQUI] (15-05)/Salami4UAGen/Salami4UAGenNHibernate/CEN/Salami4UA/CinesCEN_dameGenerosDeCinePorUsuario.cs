
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
public partial class CinesCEN
{
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> DameGenerosDeCinePorUsuario (string nickname)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Cines_dameGenerosDeCinePorUsuario) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> todosCines = new CinesCEN ().DameTodosLosGenerosCine ();
        while (todosCines.Count != 0) {
                todosCines.RemoveAt (0);
        }

        BasicCP basic = new BasicCP ();

        try
        {
                basic.SessionInitializeTransaction ();
                CinesCAD cineCAD = new CinesCAD (basic.session);
                UsuarioCAD usuarioCAD = new UsuarioCAD (basic.session);
                UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (nickname);

                foreach (String cine in usuarioEN.Films) {
                        CinesEN c = new CinesEN ();
                        c.Name = cine;
                        todosCines.Add (c);
                }
        }
        catch (Exception ex)
        {
                return null;
        }

        return todosCines;

        /*PROTECTED REGION END*/
}
}
}
