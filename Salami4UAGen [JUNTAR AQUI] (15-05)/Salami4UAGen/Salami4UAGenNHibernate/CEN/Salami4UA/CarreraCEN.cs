

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
public partial class CarreraCEN
{
private ICarreraCAD _ICarreraCAD;

public CarreraCEN()
{
        this._ICarreraCAD = new CarreraCAD ();
}

public CarreraCEN(ICarreraCAD _ICarreraCAD)
{
        this._ICarreraCAD = _ICarreraCAD;
}

public ICarreraCAD get_ICarreraCAD ()
{
        return this._ICarreraCAD;
}

public string New_ (string p_Name)
{
        CarreraEN carreraEN = null;
        string oid;

        //Initialized CarreraEN
        carreraEN = new CarreraEN ();
        carreraEN.Name = p_Name;

        //Call to CarreraCAD

        oid = _ICarreraCAD.New_ (carreraEN);
        return oid;
}

public void Modify (string p_Carrera_OID)
{
        CarreraEN carreraEN = null;

        //Initialized CarreraEN
        carreraEN = new CarreraEN ();
        carreraEN.Name = p_Carrera_OID;
        //Call to CarreraCAD

        _ICarreraCAD.Modify (carreraEN);
}

public void Destroy (string Name)
{
        _ICarreraCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN> DameTodasLasCarreras ()
{
        return _ICarreraCAD.DameTodasLasCarreras ();
}
}
}
