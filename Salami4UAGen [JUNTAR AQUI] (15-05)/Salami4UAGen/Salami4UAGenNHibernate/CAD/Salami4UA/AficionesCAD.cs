
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
public partial class AficionesCAD : BasicCAD, IAficionesCAD
{
public AficionesCAD() : base ()
{
}

public AficionesCAD(ISession sessionAux) : base (sessionAux)
{
}



public AficionesEN ReadOIDDefault (string Name)
{
        AficionesEN aficionesEN = null;

        try
        {
                SessionInitializeTransaction ();
                aficionesEN = (AficionesEN)session.Get (typeof(AficionesEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AficionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aficionesEN;
}


public string New_ (AficionesEN aficiones)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (aficiones);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AficionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aficiones.Name;
}

public void Modify (AficionesEN aficiones)
{
        try
        {
                SessionInitializeTransaction ();
                AficionesEN aficionesEN = (AficionesEN)session.Load (typeof(AficionesEN), aficiones.Name);
                session.Update (aficionesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AficionesCAD.", ex);
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
                AficionesEN aficionesEN = (AficionesEN)session.Load (typeof(AficionesEN), Name);
                session.Delete (aficionesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AficionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> DameTodosLosHobbies ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AficionesEN self where FROM AficionesEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AficionesENdameTodosLosHobbiesHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.AficionesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AficionesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
