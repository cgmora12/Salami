
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
public partial class CarreraCAD : BasicCAD, ICarreraCAD
{
public CarreraCAD() : base ()
{
}

public CarreraCAD(ISession sessionAux) : base (sessionAux)
{
}



public CarreraEN ReadOIDDefault (string Name)
{
        CarreraEN carreraEN = null;

        try
        {
                SessionInitializeTransaction ();
                carreraEN = (CarreraEN)session.Get (typeof(CarreraEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CarreraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carreraEN;
}


public string New_ (CarreraEN carrera)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (carrera);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CarreraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carrera.Name;
}

public void Modify (CarreraEN carrera)
{
        try
        {
                SessionInitializeTransaction ();
                CarreraEN carreraEN = (CarreraEN)session.Load (typeof(CarreraEN), carrera.Name);
                session.Update (carreraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CarreraCAD.", ex);
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
                CarreraEN carreraEN = (CarreraEN)session.Load (typeof(CarreraEN), Name);
                session.Delete (carreraEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CarreraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN> DameTodasLasCarreras ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CarreraEN self where FROM CarreraEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CarreraENdameTodasLasCarrerasHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.CarreraEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CarreraCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
