
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
public partial class CinesCAD : BasicCAD, ICinesCAD
{
public CinesCAD() : base ()
{
}

public CinesCAD(ISession sessionAux) : base (sessionAux)
{
}



public CinesEN ReadOIDDefault (string Name)
{
        CinesEN cinesEN = null;

        try
        {
                SessionInitializeTransaction ();
                cinesEN = (CinesEN)session.Get (typeof(CinesEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CinesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cinesEN;
}


public string New_ (CinesEN cines)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cines);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CinesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cines.Name;
}

public void Modify (CinesEN cines)
{
        try
        {
                SessionInitializeTransaction ();
                CinesEN cinesEN = (CinesEN)session.Load (typeof(CinesEN), cines.Name);
                session.Update (cinesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CinesCAD.", ex);
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
                CinesEN cinesEN = (CinesEN)session.Load (typeof(CinesEN), Name);
                session.Delete (cinesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CinesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> DameTodosLosGenerosCine ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CinesEN self where FROM CinesEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CinesENdameTodosLosGenerosCineHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.CinesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in CinesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
