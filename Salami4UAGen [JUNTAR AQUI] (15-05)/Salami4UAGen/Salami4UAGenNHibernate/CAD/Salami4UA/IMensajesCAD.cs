
using System;
using Salami4UAGenNHibernate.EN.Salami4UA;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial interface IMensajesCAD
{
MensajesEN ReadOIDDefault (int Id);

int New_ (MensajesEN mensajes);

void Modify (MensajesEN mensajes);


void Destroy (int Id);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MensajesEN> DameTodosLosMensajesEnviadosPorUsuario (string nick);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MensajesEN> DameTodosLosMensajesRecibidosPorUsuario (string nick);


System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MensajesEN> DameTodosLosMensajesEntreUsuarios (string nickOrigen, string nickDestino);
}
}
