
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
public partial class AnimalesCEN
{
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> DameAnimalesPorUsuario (string usuario)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Animales_dameAnimalesPorUsuario) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> todosanimales = new AnimalesCEN ().DameTodosLosAnimales ();
        while (todosanimales.Count != 0) {
                todosanimales.RemoveAt (0);
        }

        BasicCP basic = new BasicCP ();

        try
        {
                basic.SessionInitializeTransaction ();
                AnimalesCAD petcad = new AnimalesCAD (basic.session);
                UsuarioCAD usuariocad = new UsuarioCAD (basic.session);
                UsuarioEN usuarioEN = usuariocad.ReadOIDDefault (usuario);

                foreach (String animal in usuarioEN.Pets) {
                        AnimalesEN a = new AnimalesEN ();
                        a.Name = animal;
                        todosanimales.Add (a);
                }
        }
        catch (Exception ex)
        {
                return null;
        }

        return todosanimales;


        /*PROTECTED REGION END*/
}
}
}
