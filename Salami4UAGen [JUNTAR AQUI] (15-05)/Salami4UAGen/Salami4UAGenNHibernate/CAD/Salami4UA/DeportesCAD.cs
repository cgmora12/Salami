
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
public partial class DeportesCAD : BasicCAD, IDeportesCAD
{
public DeportesCAD() : base ()
{
}

public DeportesCAD(ISession sessionAux) : base (sessionAux)
{
}



public DeportesEN ReadOIDDefault (string Name)
{
        DeportesEN deportesEN = null;

        try
        {
                SessionInitializeTransaction ();
                deportesEN = (DeportesEN)session.Get (typeof(DeportesEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in DeportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return deportesEN;
}


public string New_ (DeportesEN deportes)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (deportes);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in DeportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return deportes.Name;
}

public void Modify (DeportesEN deportes)
{
        try
        {
                SessionInitializeTransaction ();
                DeportesEN deportesEN = (DeportesEN)session.Load (typeof(DeportesEN), deportes.Name);
                session.Update (deportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in DeportesCAD.", ex);
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
                DeportesEN deportesEN = (DeportesEN)session.Load (typeof(DeportesEN), Name);
                session.Delete (deportesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in DeportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> DameTodosLosDeportes ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM DeportesEN self where FROM DeportesEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("DeportesENdameTodosLosDeportesHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.DeportesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in DeportesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
