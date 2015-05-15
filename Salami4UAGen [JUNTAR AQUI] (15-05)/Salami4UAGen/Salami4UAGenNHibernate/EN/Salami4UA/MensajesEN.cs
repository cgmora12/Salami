
using System;

namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public partial class MensajesEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string message;

/**
 *
 */

private string nicknameOrigen;

/**
 *
 */

private string nicknameDestino;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Message {
        get { return message; } set { message = value;  }
}


public virtual string NicknameOrigen {
        get { return nicknameOrigen; } set { nicknameOrigen = value;  }
}


public virtual string NicknameDestino {
        get { return nicknameDestino; } set { nicknameDestino = value;  }
}





public MensajesEN()
{
}



public MensajesEN(int id, string message, string nicknameOrigen, string nicknameDestino)
{
        this.init (id, message, nicknameOrigen, nicknameDestino);
}


public MensajesEN(MensajesEN mensajes)
{
        this.init (mensajes.Id, mensajes.Message, mensajes.NicknameOrigen, mensajes.NicknameDestino);
}

private void init (int id, string message, string nicknameOrigen, string nicknameDestino)
{
        this.Id = Id;


        this.Message = message;

        this.NicknameOrigen = nicknameOrigen;

        this.NicknameDestino = nicknameDestino;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajesEN t = obj as MensajesEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
