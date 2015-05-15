
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface ICaracteristicasCAD
{
CaracteristicasEN ReadOIDDefault (string Name);

string New_ (CaracteristicasEN caracteristicas);

void Modify (CaracteristicasEN caracteristicas);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> DameTodasLasCaracteristicas ();
}
}
