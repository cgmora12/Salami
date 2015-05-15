

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
public partial class MasterCEN
{
private IMasterCAD _IMasterCAD;

public MasterCEN()
{
        this._IMasterCAD = new MasterCAD ();
}

public MasterCEN(IMasterCAD _IMasterCAD)
{
        this._IMasterCAD = _IMasterCAD;
}

public IMasterCAD get_IMasterCAD ()
{
        return this._IMasterCAD;
}

public string New_ (string p_Name)
{
        MasterEN masterEN = null;
        string oid;

        //Initialized MasterEN
        masterEN = new MasterEN ();
        masterEN.Name = p_Name;

        //Call to MasterCAD

        oid = _IMasterCAD.New_ (masterEN);
        return oid;
}

public void Modify (string p_Master_OID)
{
        MasterEN masterEN = null;

        //Initialized MasterEN
        masterEN = new MasterEN ();
        masterEN.Name = p_Master_OID;
        //Call to MasterCAD

        _IMasterCAD.Modify (masterEN);
}

public void Destroy (string Name)
{
        _IMasterCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MasterEN> DameTodosLosMasters ()
{
        return _IMasterCAD.DameTodosLosMasters ();
}
}
}
