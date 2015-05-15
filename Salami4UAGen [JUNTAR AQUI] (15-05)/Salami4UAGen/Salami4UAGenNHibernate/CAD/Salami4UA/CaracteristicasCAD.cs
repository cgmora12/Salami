
using System;
using System.Text;
using Salami4UAGenNHibernate.CEN.Salami4UA;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.Exceptions;

namespace Salami4UAGenNHibernate.CAD.Salami4UA
{
public partial class CaracteristicasCAD : BasicCAD, ICaracteristicasCAD
{
public CaracteristicasCAD() : base ()
{
}

public CaracteristicasCAD(ISession sessionAux) : base (sessionAux)
{
}



public CaracteristicasEN ReadOIDDefault (string Name)
{
        CaracteristicasEN caracteristicasEN = null;

        try
        {
                SessionInitializeTransaction ();
                caracteristicasEN = (CaracteristicasEN)session.Get (typeof(CaracteristicasEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caracteristicasEN;
}


public string New_ (CaracteristicasEN caracteristicas)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (caracteristicas);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caracteristicas.Name;
}

public void Modify (CaracteristicasEN caracteristicas)
{
        try
        {
                SessionInitializeTransaction ();
                CaracteristicasEN caracteristicasEN = (CaracteristicasEN)session.Load (typeof(CaracteristicasEN), caracteristicas.Name);
                session.Update (caracteristicasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string Name)
{
        try
        {
                SessionInitializeTransaction ();
                CaracteristicasEN caracteristicasEN = (CaracteristicasEN)session.Load (typeof(CaracteristicasEN), Name);
                session.Delete (caracteristicasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> DameTodasLasCaracteristicas ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CaracteristicasEN self where FROM CaracteristicasEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CaracteristicasENdameTodasLasCaracteristicasHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.CaracteristicasEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CaracteristicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
