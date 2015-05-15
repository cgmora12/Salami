

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
public partial class DeportesCEN
{
private IDeportesCAD _IDeportesCAD;

public DeportesCEN()
{
        this._IDeportesCAD = new DeportesCAD ();
}

public DeportesCEN(IDeportesCAD _IDeportesCAD)
{
        this._IDeportesCAD = _IDeportesCAD;
}

public IDeportesCAD get_IDeportesCAD ()
{
        return this._IDeportesCAD;
}

public string New_ (string p_Name)
{
        DeportesEN deportesEN = null;
        string oid;

        //Initialized DeportesEN
        deportesEN = new DeportesEN ();
        deportesEN.Name = p_Name;

        //Call to DeportesCAD

        oid = _IDeportesCAD.New_ (deportesEN);
        return oid;
}

public void Modify (string p_Deportes_OID)
{
        DeportesEN deportesEN = null;

        //Initialized DeportesEN
        deportesEN = new DeportesEN ();
        deportesEN.Name = p_Deportes_OID;
        //Call to DeportesCAD

        _IDeportesCAD.Modify (deportesEN);
}

public void Destroy (string Name)
{
        _IDeportesCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> DameTodosLosDeportes ()
{
        return _IDeportesCAD.DameTodosLosDeportes ();
}
}
}
