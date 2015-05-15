using System;
using System.Collections.Generic;
namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public class MessagesEN_OID
{
private TimeSpan date;
public virtual TimeSpan Date {
        get { return date; } set { date = value;  }
}
private int id;
public virtual int Id {
        get { return id; } set { id = value;  }
}

public MessagesEN_OID()
{
}
public MessagesEN_OID(TimeSpan Date, int Id)
{
        this.Date = Date;
        this.Id = Id;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MessagesEN_OID t = obj as MessagesEN_OID;
        if (t == null)
                return false;
        if (this.date == t.Date && this.id == t.Id)
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash = hash +
               (null == date ? 0 : this.date.GetHashCode ());
        hash = hash +
               (null == id ? 0 : this.id.GetHashCode ());
        return hash;
}
}
}
