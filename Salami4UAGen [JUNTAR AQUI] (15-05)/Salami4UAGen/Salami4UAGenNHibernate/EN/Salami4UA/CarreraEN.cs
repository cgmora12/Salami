
using System;

namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public partial class CarreraEN
{
/**
 *
 */

private string name;





public virtual string Name {
        get { return name; } set { name = value;  }
}





public CarreraEN()
{
}



public CarreraEN(string name)
{
        this.init (name);
}


public CarreraEN(CarreraEN carrera)
{
        this.init (carrera.Name);
}

private void init (string name)
{
        this.Name = Name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CarreraEN t = obj as CarreraEN;
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
