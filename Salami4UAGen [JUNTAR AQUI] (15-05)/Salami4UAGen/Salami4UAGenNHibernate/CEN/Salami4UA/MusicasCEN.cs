

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
public partial class MusicasCEN
{
private IMusicasCAD _IMusicasCAD;

public MusicasCEN()
{
        this._IMusicasCAD = new MusicasCAD ();
}

public MusicasCEN(IMusicasCAD _IMusicasCAD)
{
        this._IMusicasCAD = _IMusicasCAD;
}

public IMusicasCAD get_IMusicasCAD ()
{
        return this._IMusicasCAD;
}

public string New_ (string p_Name)
{
        MusicasEN musicasEN = null;
        string oid;

        //Initialized MusicasEN
        musicasEN = new MusicasEN ();
        musicasEN.Name = p_Name;

        //Call to MusicasCAD

        oid = _IMusicasCAD.New_ (musicasEN);
        return oid;
}

public void Modify (string p_Musicas_OID)
{
        MusicasEN musicasEN = null;

        //Initialized MusicasEN
        musicasEN = new MusicasEN ();
        musicasEN.Name = p_Musicas_OID;
        //Call to MusicasCAD

        _IMusicasCAD.Modify (musicasEN);
}

public void Destroy (string Name)
{
        _IMusicasCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN> DameTodosLosGustosMusicales ()
{
        return _IMusicasCAD.DameTodosLosGustosMusicales ();
}
}
}
