
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
public partial class CaracteristicasCEN
{
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> DameCaracteristicasPorUsuario (string nickname)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Caracteristicas_dameCaracteristicasPorUsuario) ENABLED START*/

        // Write here your custom code...

        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> todascaracteristicas = new CaracteristicasCEN ().DameTodasLasCaracteristicas ();
        while (todascaracteristicas.Count != 0) {
                todascaracteristicas.RemoveAt (0);
        }

        BasicCP basic = new BasicCP ();

        try
        {
                basic.SessionInitializeTransaction ();
                CaracteristicasCAD caracteristicaCAD = new CaracteristicasCAD (basic.session);
                UsuarioCAD usuarioCAD = new UsuarioCAD (basic.session);
                UsuarioEN usuarioEN = usuarioCAD.ReadOIDDefault (nickname);

                foreach (String caracteristica in usuarioEN.Characteristics) {
                        CaracteristicasEN c = new CaracteristicasEN ();
                        c.Name = caracteristica;
                        todascaracteristicas.Add (c);
                }
        }
        catch (Exception ex)
        {
                return null;
        }

        return todascaracteristicas;

        /*PROTECTED REGION END*/
}
}
}
