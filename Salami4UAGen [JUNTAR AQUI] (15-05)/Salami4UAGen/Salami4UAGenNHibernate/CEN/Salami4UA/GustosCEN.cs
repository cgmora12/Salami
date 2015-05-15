

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
public partial class GustosCEN
{
private IGustosCAD _IGustosCAD;

public GustosCEN()
{
        this._IGustosCAD = new GustosCAD ();
}

public GustosCEN(IGustosCAD _IGustosCAD)
{
        this._IGustosCAD = _IGustosCAD;
}

public IGustosCAD get_IGustosCAD ()
{
        return this._IGustosCAD;
}

public string New_ (string p_Nickname, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum p_HairColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum p_EyeColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum p_HairLength, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum p_HairStyle, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum p_BodyType, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum p_Ethnicity, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum p_Smoke)
{
        GustosEN gustosEN = null;
        string oid;

        //Initialized GustosEN
        gustosEN = new GustosEN ();
        gustosEN.Nickname = p_Nickname;

        gustosEN.HairColor = p_HairColor;

        gustosEN.EyeColor = p_EyeColor;

        gustosEN.HairLength = p_HairLength;

        gustosEN.HairStyle = p_HairStyle;

        gustosEN.BodyType = p_BodyType;

        gustosEN.Ethnicity = p_Ethnicity;

        gustosEN.Smoke = p_Smoke;

        //Call to GustosCAD

        oid = _IGustosCAD.New_ (gustosEN);
        return oid;
}

public void Modify (string p_Gustos_OID, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum p_HairColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum p_EyeColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum p_HairLength, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum p_HairStyle, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum p_BodyType, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum p_Ethnicity, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum p_Smoke)
{
        GustosEN gustosEN = null;

        //Initialized GustosEN
        gustosEN = new GustosEN ();
        gustosEN.Nickname = p_Gustos_OID;
        gustosEN.HairColor = p_HairColor;
        gustosEN.EyeColor = p_EyeColor;
        gustosEN.HairLength = p_HairLength;
        gustosEN.HairStyle = p_HairStyle;
        gustosEN.BodyType = p_BodyType;
        gustosEN.Ethnicity = p_Ethnicity;
        gustosEN.Smoke = p_Smoke;
        //Call to GustosCAD

        _IGustosCAD.Modify (gustosEN);
}

public void Destroy (string Nickname)
{
        _IGustosCAD.Destroy (Nickname);
}

public GustosEN DameGustoPorNickname (string Nickname)
{
        GustosEN gustosEN = null;

        gustosEN = _IGustosCAD.DameGustoPorNickname (Nickname);
        return gustosEN;
}
}
}
