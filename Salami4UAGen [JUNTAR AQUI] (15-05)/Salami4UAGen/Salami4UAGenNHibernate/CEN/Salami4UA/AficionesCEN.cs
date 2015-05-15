

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
public partial class AficionesCEN
{
private IAficionesCAD _IAficionesCAD;

public AficionesCEN()
{
        this._IAficionesCAD = new AficionesCAD ();
}

public AficionesCEN(IAficionesCAD _IAficionesCAD)
{
        this._IAficionesCAD = _IAficionesCAD;
}

public IAficionesCAD get_IAficionesCAD ()
{
        return this._IAficionesCAD;
}

public string New_ (string p_Name)
{
        AficionesEN aficionesEN = null;
        string oid;

        //Initialized AficionesEN
        aficionesEN = new AficionesEN ();
        aficionesEN.Name = p_Name;

        //Call to AficionesCAD

        oid = _IAficionesCAD.New_ (aficionesEN);
        return oid;
}

public void Modify (string p_Aficiones_OID)
{
        AficionesEN aficionesEN = null;

        //Initialized AficionesEN
        aficionesEN = new AficionesEN ();
        aficionesEN.Name = p_Aficiones_OID;
        //Call to AficionesCAD

        _IAficionesCAD.Modify (aficionesEN);
}

public void Destroy (string Name)
{
        _IAficionesCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> DameTodosLosHobbies ()
{
        return _IAficionesCAD.DameTodosLosHobbies ();
}
}
}
