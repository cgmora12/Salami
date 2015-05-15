

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
public partial class AnimalesCEN
{
private IAnimalesCAD _IAnimalesCAD;

public AnimalesCEN()
{
        this._IAnimalesCAD = new AnimalesCAD ();
}

public AnimalesCEN(IAnimalesCAD _IAnimalesCAD)
{
        this._IAnimalesCAD = _IAnimalesCAD;
}

public IAnimalesCAD get_IAnimalesCAD ()
{
        return this._IAnimalesCAD;
}

public string New_ (string p_Name)
{
        AnimalesEN animalesEN = null;
        string oid;

        //Initialized AnimalesEN
        animalesEN = new AnimalesEN ();
        animalesEN.Name = p_Name;

        //Call to AnimalesCAD

        oid = _IAnimalesCAD.New_ (animalesEN);
        return oid;
}

public void Modify (string p_Animales_OID)
{
        AnimalesEN animalesEN = null;

        //Initialized AnimalesEN
        animalesEN = new AnimalesEN ();
        animalesEN.Name = p_Animales_OID;
        //Call to AnimalesCAD

        _IAnimalesCAD.Modify (animalesEN);
}

public void Destroy (string Name)
{
        _IAnimalesCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> DameTodosLosAnimales ()
{
        return _IAnimalesCAD.DameTodosLosAnimales ();
}
}
}
