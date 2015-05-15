

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
public partial class CaracteristicasCEN
{
private ICaracteristicasCAD _ICaracteristicasCAD;

public CaracteristicasCEN()
{
        this._ICaracteristicasCAD = new CaracteristicasCAD ();
}

public CaracteristicasCEN(ICaracteristicasCAD _ICaracteristicasCAD)
{
        this._ICaracteristicasCAD = _ICaracteristicasCAD;
}

public ICaracteristicasCAD get_ICaracteristicasCAD ()
{
        return this._ICaracteristicasCAD;
}

public string New_ (string p_Name)
{
        CaracteristicasEN caracteristicasEN = null;
        string oid;

        //Initialized CaracteristicasEN
        caracteristicasEN = new CaracteristicasEN ();
        caracteristicasEN.Name = p_Name;

        //Call to CaracteristicasCAD

        oid = _ICaracteristicasCAD.New_ (caracteristicasEN);
        return oid;
}

public void Modify (string p_Caracteristicas_OID)
{
        CaracteristicasEN caracteristicasEN = null;

        //Initialized CaracteristicasEN
        caracteristicasEN = new CaracteristicasEN ();
        caracteristicasEN.Name = p_Caracteristicas_OID;
        //Call to CaracteristicasCAD

        _ICaracteristicasCAD.Modify (caracteristicasEN);
}

public void Destroy (string Name)
{
        _ICaracteristicasCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> DameTodasLasCaracteristicas ()
{
        return _ICaracteristicasCAD.DameTodasLasCaracteristicas ();
}
}
}
