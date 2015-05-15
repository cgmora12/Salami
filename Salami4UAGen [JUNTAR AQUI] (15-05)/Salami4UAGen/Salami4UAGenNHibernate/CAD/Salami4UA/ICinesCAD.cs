
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface ICinesCAD
{
CinesEN ReadOIDDefault (string Name);

string New_ (CinesEN cines);

void Modify (CinesEN cines);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> DameTodosLosGenerosCine ();
}
}
