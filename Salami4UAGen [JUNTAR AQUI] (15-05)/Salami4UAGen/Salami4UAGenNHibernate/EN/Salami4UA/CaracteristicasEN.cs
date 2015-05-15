
using System;

namespace Salami4UAGenNHibernate.EN.Salami4UA
{
public partial class CaracteristicasEN
{
/**
 *
 */

private string name;





public virtual string Name {
        get { return name; } set { name = value;  }
}





public CaracteristicasEN()
{
}



public CaracteristicasEN(string name)
{
        this.init (name);
}


public CaracteristicasEN(CaracteristicasEN caracteristicas)
{
        this.init (caracteristicas.Name);
}

private void init (string name)
{
        this.Name = Name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CaracteristicasEN t = obj as CaracteristicasEN;
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
