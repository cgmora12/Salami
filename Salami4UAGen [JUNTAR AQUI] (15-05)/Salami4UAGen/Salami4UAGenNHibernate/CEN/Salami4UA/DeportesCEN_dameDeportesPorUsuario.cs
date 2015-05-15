
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
public partial class DeportesCEN
{
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> DameDeportesPorUsuario (string nickname)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Deportes_dameDeportesPorUsuario) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> todoDeportes = new DeportesCEN ().DameTodosLosDeportes ();
        while (todoDeportes.Count != 0) {
                todoDeportes.RemoveAt (0);
        }

        BasicCP basic = new BasicCP ();

        try
        {
                basic.SessionInitializeTransaction ();
                DeportesCAD musicaCAD = new DeportesCAD (basic.session);
                UsuarioCAD usuarioCAD = new UsuarioCAD (basic.session);
                UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (nickname);

                foreach (String deporte in usuarioEN.Sports) {
                        DeportesEN d = new DeportesEN ();
                        d.Name = deporte;
                        todoDeportes.Add (d);
                }
        }
        catch (Exception ex)
        {
                return null;
        }

        return todoDeportes;

        /*PROTECTED REGION END*/
}
}
}
