

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
public partial class CinesCEN
{
private ICinesCAD _ICinesCAD;

public CinesCEN()
{
        this._ICinesCAD = new CinesCAD ();
}

public CinesCEN(ICinesCAD _ICinesCAD)
{
        this._ICinesCAD = _ICinesCAD;
}

public ICinesCAD get_ICinesCAD ()
{
        return this._ICinesCAD;
}

public string New_ (string p_Name)
{
        CinesEN cinesEN = null;
        string oid;

        //Initialized CinesEN
        cinesEN = new CinesEN ();
        cinesEN.Name = p_Name;

        //Call to CinesCAD

        oid = _ICinesCAD.New_ (cinesEN);
        return oid;
}

public void Modify (string p_Cines_OID)
{
        CinesEN cinesEN = null;

        //Initialized CinesEN
        cinesEN = new CinesEN ();
        cinesEN.Name = p_Cines_OID;
        //Call to CinesCAD

        _ICinesCAD.Modify (cinesEN);
}

public void Destroy (string Name)
{
        _ICinesCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> DameTodosLosGenerosCine ()
{
        return _ICinesCAD.DameTodosLosGenerosCine ();
}
}
}
