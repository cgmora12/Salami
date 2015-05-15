
using System;

namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public partial class AnimalesEN
{
/**
 *
 */

private string name;





public virtual string Name {
        get { return name; } set { name = value;  }
}





public AnimalesEN()
{
}



public AnimalesEN(string name)
{
        this.init (name);
}


public AnimalesEN(AnimalesEN animales)
{
        this.init (animales.Name);
}

private void init (string name)
{
        this.Name = Name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AnimalesEN t = obj as AnimalesEN;
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
