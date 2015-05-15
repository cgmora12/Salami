
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
public partial class AnimalesCAD : BasicCAD, IAnimalesCAD
{
public AnimalesCAD() : base ()
{
}

public AnimalesCAD(ISession sessionAux) : base (sessionAux)
{
}



public AnimalesEN ReadOIDDefault (string Name)
{
        AnimalesEN animalesEN = null;

        try
        {
                SessionInitializeTransaction ();
                animalesEN = (AnimalesEN)session.Get (typeof(AnimalesEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AnimalesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return animalesEN;
}


public string New_ (AnimalesEN animales)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (animales);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AnimalesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return animales.Name;
}

public void Modify (AnimalesEN animales)
{
        try
        {
                SessionInitializeTransaction ();
                AnimalesEN animalesEN = (AnimalesEN)session.Load (typeof(AnimalesEN), animales.Name);
                session.Update (animalesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AnimalesCAD.", ex);
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
                AnimalesEN animalesEN = (AnimalesEN)session.Load (typeof(AnimalesEN), Name);
                session.Delete (animalesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AnimalesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> DameTodosLosAnimales ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnimalesEN self where FROM AnimalesEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnimalesENdameTodosLosAnimalesHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.AnimalesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AnimalesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
