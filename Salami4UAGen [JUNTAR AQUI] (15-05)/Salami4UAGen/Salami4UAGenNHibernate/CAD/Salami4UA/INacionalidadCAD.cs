
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface INacionalidadCAD
{
NacionalidadEN ReadOIDDefault (string Name);

string New_ (NacionalidadEN nacionalidad);

void Modify (NacionalidadEN nacionalidad);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.NacionalidadEN> DameTodaslasNacionalidades ();
}
}
