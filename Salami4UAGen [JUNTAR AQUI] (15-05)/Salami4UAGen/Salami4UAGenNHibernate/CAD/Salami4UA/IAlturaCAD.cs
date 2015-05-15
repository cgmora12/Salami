
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IAlturaCAD
{
AlturaEN ReadOIDDefault (int height);

int New_ (AlturaEN altura);

void Modify (AlturaEN altura);


void Destroy (int height);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AlturaEN> DameTodaslasAlturas ();
}
}
