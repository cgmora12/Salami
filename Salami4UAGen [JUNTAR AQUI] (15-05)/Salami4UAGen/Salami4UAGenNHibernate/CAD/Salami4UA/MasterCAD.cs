
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
public partial class MasterCAD : BasicCAD, IMasterCAD
{
public MasterCAD() : base ()
{
}

public MasterCAD(ISession sessionAux) : base (sessionAux)
{
}



public MasterEN ReadOIDDefault (string Name)
{
        MasterEN masterEN = null;

        try
        {
                SessionInitializeTransaction ();
                masterEN = (MasterEN)session.Get (typeof(MasterEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MasterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return masterEN;
}


public string New_ (MasterEN master)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (master);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MasterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return master.Name;
}

public void Modify (MasterEN master)
{
        try
        {
                SessionInitializeTransaction ();
                MasterEN masterEN = (MasterEN)session.Load (typeof(MasterEN), master.Name);
                session.Update (masterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MasterCAD.", ex);
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
                MasterEN masterEN = (MasterEN)session.Load (typeof(MasterEN), Name);
                session.Delete (masterEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MasterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MasterEN> DameTodosLosMasters ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MasterEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MasterEN self where FROM MasterEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MasterENdameTodosLosMastersHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.MasterEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MasterCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
