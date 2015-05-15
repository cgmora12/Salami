
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IMasterCAD
{
MasterEN ReadOIDDefault (string Name);

string New_ (MasterEN master);

void Modify (MasterEN master);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MasterEN> DameTodosLosMasters ();
}
}
