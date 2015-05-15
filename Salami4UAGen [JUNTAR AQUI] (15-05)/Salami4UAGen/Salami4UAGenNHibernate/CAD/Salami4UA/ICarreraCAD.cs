
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface ICarreraCAD
{
CarreraEN ReadOIDDefault (string Name);

string New_ (CarreraEN carrera);

void Modify (CarreraEN carrera);


void Destroy (string Name);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN> DameTodasLasCarreras ();
}
}
