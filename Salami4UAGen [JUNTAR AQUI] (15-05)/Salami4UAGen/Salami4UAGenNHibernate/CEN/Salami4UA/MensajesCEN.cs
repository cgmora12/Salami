

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CAD.Salami4UA;

namespace Salami4UAGenNHibernate.CEN.Salami4UA
{
public partial class MensajesCEN
{
private IMensajesCAD _IMensajesCAD;

public MensajesCEN()
{
        this._IMensajesCAD = new MensajesCAD ();
}

public MensajesCEN(IMensajesCAD _IMensajesCAD)
{
        this._IMensajesCAD = _IMensajesCAD;
}

public IMensajesCAD get_IMensajesCAD ()
{
        return this._IMensajesCAD;
}

public int New_ (string p_Message, string p_NicknameOrigen, string p_NicknameDestino)
{
        MensajesEN mensajesEN = null;
        int oid;

        //Initialized MensajesEN
        mensajesEN = new MensajesEN ();
        mensajesEN.Message = p_Message;

        mensajesEN.NicknameOrigen = p_NicknameOrigen;

        mensajesEN.NicknameDestino = p_NicknameDestino;

        //Call to MensajesCAD

        oid = _IMensajesCAD.New_ (mensajesEN);
        return oid;
}

public void Modify (int p_Mensajes_OID, string p_Message, string p_NicknameOrigen, string p_NicknameDestino)
{
        MensajesEN mensajesEN = null;

        //Initialized MensajesEN
        mensajesEN = new MensajesEN ();
        mensajesEN.Id = p_Mensajes_OID;
        mensajesEN.Message = p_Message;
        mensajesEN.NicknameOrigen = p_NicknameOrigen;
        mensajesEN.NicknameDestino = p_NicknameDestino;
        //Call to MensajesCAD

        _IMensajesCAD.Modify (mensajesEN);
}

public void Destroy (int Id)
{
        _IMensajesCAD.Destroy (Id);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MensajesEN> DameTodosLosMensajesEnviadosPorUsuario (string nick)
{
        return _IMensajesCAD.DameTodosLosMensajesEnviadosPorUsuario (nick);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MensajesEN> DameTodosLosMensajesRecibidosPorUsuario (string nick)
{
        return _IMensajesCAD.DameTodosLosMensajesRecibidosPorUsuario (nick);
}
public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MensajesEN> DameTodosLosMensajesEntreUsuarios (string nickOrigen, string nickDestino)
{
        return _IMensajesCAD.DameTodosLosMensajesEntreUsuarios (nickOrigen, nickDestino);
}
}
}
