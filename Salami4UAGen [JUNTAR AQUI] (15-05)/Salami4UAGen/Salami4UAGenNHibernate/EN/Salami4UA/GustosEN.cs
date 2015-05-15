
using System;

namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public partial class GustosEN
{
/**
 *
 */

private string nickname;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum hairColor;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum eyeColor;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum hairLength;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum hairStyle;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum bodyType;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum ethnicity;

/**
 *
 */

private Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum smoke;

/**
 *
 */

private Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN usuario;





public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum HairColor {
        get { return hairColor; } set { hairColor = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum EyeColor {
        get { return eyeColor; } set { eyeColor = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum HairLength {
        get { return hairLength; } set { hairLength = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum HairStyle {
        get { return hairStyle; } set { hairStyle = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum BodyType {
        get { return bodyType; } set { bodyType = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum Ethnicity {
        get { return ethnicity; } set { ethnicity = value;  }
}


public virtual Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum Smoke {
        get { return smoke; } set { smoke = value;  }
}


public virtual Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public GustosEN()
{
}



public GustosEN(string nickname, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum hairColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum eyeColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum hairLength, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum hairStyle, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum bodyType, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum ethnicity, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum smoke, Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN usuario)
{
        this.init (nickname, hairColor, eyeColor, hairLength, hairStyle, bodyType, ethnicity, smoke, usuario);
}


public GustosEN(GustosEN gustos)
{
        this.init (gustos.Nickname, gustos.HairColor, gustos.EyeColor, gustos.HairLength, gustos.HairStyle, gustos.BodyType, gustos.Ethnicity, gustos.Smoke, gustos.Usuario);
}

private void init (string nickname, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairColorEnum hairColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.EyeColorEnum eyeColor, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairLengthEnum hairLength, Salami4UAGenNHibernate.Enumerated.Salami4UA.HairStyleEnum hairStyle, Salami4UAGenNHibernate.Enumerated.Salami4UA.BodyTypeEnum bodyType, Salami4UAGenNHibernate.Enumerated.Salami4UA.EthnicityEnum ethnicity, Salami4UAGenNHibernate.Enumerated.Salami4UA.SmokeEnum smoke, Salami4UAGenNHibernate.EN.Salami4UA.UsuarioEN usuario)
{
        this.Nickname = Nickname;


        this.HairColor = hairColor;

        this.EyeColor = eyeColor;

        this.HairLength = hairLength;

        this.HairStyle = hairStyle;

        this.BodyType = bodyType;

        this.Ethnicity = ethnicity;

        this.Smoke = smoke;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GustosEN t = obj as GustosEN;
        if (t == null)
                return false;
        if (Nickname.Equals (t.Nickname))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nickname.GetHashCode ();
        return hash;
}
}
}
