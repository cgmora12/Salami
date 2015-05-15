

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
public partial class AlturaCEN
{
private IAlturaCAD _IAlturaCAD;

public AlturaCEN()
{
        this._IAlturaCAD = new AlturaCAD ();
}

public AlturaCEN(IAlturaCAD _IAlturaCAD)
{
        this._IAlturaCAD = _IAlturaCAD;
}

public IAlturaCAD get_IAlturaCAD ()
{
        return this._IAlturaCAD;
}

public int New_ (int p_height)
{
        AlturaEN alturaEN = null;
        int oid;

        //Initialized AlturaEN
        alturaEN = new AlturaEN ();
        alturaEN.Height = p_height;

        //Call to AlturaCAD

        oid = _IAlturaCAD.New_ (alturaEN);
        return oid;
}

public void Modify (int p_Altura_OID)
{
        AlturaEN alturaEN = null;

        //Initialized AlturaEN
        alturaEN = new AlturaEN ();
        alturaEN.Height = p_Altura_OID;
        //Call to AlturaCAD

        _IAlturaCAD.Modify (alturaEN);
}

public void Destroy (int height)
{
        _IAlturaCAD.Destroy (height);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AlturaEN> DameTodaslasAlturas ()
{
        return _IAlturaCAD.DameTodaslasAlturas ();
}
}
}
