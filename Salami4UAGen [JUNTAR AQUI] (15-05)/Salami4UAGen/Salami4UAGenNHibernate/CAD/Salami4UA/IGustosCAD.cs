
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IGustosCAD
{
GustosEN ReadOIDDefault (string Nickname);

string New_ (GustosEN gustos);

void Modify (GustosEN gustos);


void Destroy (string Nickname);


GustosEN DameGustoPorNickname (string Nickname);
}
}
