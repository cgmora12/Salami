
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IDeportesCAD
{
DeportesEN ReadOIDDefault (string Name);

string New_ (DeportesEN deportes);

void Modify (DeportesEN deportes);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> DameTodosLosDeportes ();
}
}
