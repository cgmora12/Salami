

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
public partial class NacionalidadCEN
{
private INacionalidadCAD _INacionalidadCAD;

public NacionalidadCEN()
{
        this._INacionalidadCAD = new NacionalidadCAD ();
}

public NacionalidadCEN(INacionalidadCAD _INacionalidadCAD)
{
        this._INacionalidadCAD = _INacionalidadCAD;
}

public INacionalidadCAD get_INacionalidadCAD ()
{
        return this._INacionalidadCAD;
}

public string New_ (string p_Name)
{
        NacionalidadEN nacionalidadEN = null;
        string oid;

        //Initialized NacionalidadEN
        nacionalidadEN = new NacionalidadEN ();
        nacionalidadEN.Name = p_Name;

        //Call to NacionalidadCAD

        oid = _INacionalidadCAD.New_ (nacionalidadEN);
        return oid;
}

public void Modify (string p_Nacionalidad_OID)
{
        NacionalidadEN nacionalidadEN = null;

        //Initialized NacionalidadEN
        nacionalidadEN = new NacionalidadEN ();
        nacionalidadEN.Name = p_Nacionalidad_OID;
        //Call to NacionalidadCAD

        _INacionalidadCAD.Modify (nacionalidadEN);
}

public void Destroy (string Name)
{
        _INacionalidadCAD.Destroy (Name);
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.NacionalidadEN> DameTodaslasNacionalidades ()
{
        return _INacionalidadCAD.DameTodaslasNacionalidades ();
}
}
}
