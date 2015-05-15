
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
public partial class AficionesCEN
{
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> DameHobbiesPorUsuario (string nickname)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Aficiones_dameHobbiesPorUsuario) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> todosHobbies = new AficionesCEN ().DameTodosLosHobbies ();
        while (todosHobbies.Count != 0) {
                todosHobbies.RemoveAt (0);
        }

        BasicCP basic = new BasicCP ();

        try
        {
                basic.SessionInitializeTransaction ();
                AficionesCAD hobbieCAD = new AficionesCAD (basic.session);
                UsuarioCAD usuarioCAD = new UsuarioCAD (basic.session);
                UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (nickname);

                foreach (String hob in usuarioEN.Hobbies) {
                        AficionesEN a = new AficionesEN ();
                        a.Name = hob;
                        todosHobbies.Add (a);
                }
        }
        catch (Exception ex)
        {
                return null;
        }

        return todosHobbies;

        /*PROTECTED REGION END*/
}
}
}
