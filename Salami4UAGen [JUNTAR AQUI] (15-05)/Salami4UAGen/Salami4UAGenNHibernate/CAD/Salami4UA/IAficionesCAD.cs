
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IAficionesCAD
{
AficionesEN ReadOIDDefault (string Name);

string New_ (AficionesEN aficiones);

void Modify (AficionesEN aficiones);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> DameTodosLosHobbies ();
}
}
