
using System;

namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public partial class DeportesEN
{
/**
 *
 */

private string name;





public virtual string Name {
        get { return name; } set { name = value;  }
}





public DeportesEN()
{
}



public DeportesEN(string name)
{
        this.init (name);
}


public DeportesEN(DeportesEN deportes)
{
        this.init (deportes.Name);
}

private void init (string name)
{
        this.Name = Name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DeportesEN t = obj as DeportesEN;
        if (t == null)
                return false;
        if (Name.Equals (t.Name))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Name.GetHashCode ();
        return hash;
}
}
}
