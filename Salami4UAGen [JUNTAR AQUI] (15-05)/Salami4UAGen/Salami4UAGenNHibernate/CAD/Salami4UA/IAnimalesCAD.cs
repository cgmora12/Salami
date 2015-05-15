
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IAnimalesCAD
{
AnimalesEN ReadOIDDefault (string Name);

string New_ (AnimalesEN animales);

void Modify (AnimalesEN animales);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> DameTodosLosAnimales ();
}
}
