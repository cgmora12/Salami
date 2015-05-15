
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
public partial class AlturaCAD : BasicCAD, IAlturaCAD
{
public AlturaCAD() : base ()
{
}

public AlturaCAD(ISession sessionAux) : base (sessionAux)
{
}



public AlturaEN ReadOIDDefault (int height)
{
        AlturaEN alturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                alturaEN = (AlturaEN)session.Get (typeof(AlturaEN), height);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AlturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alturaEN;
}


public int New_ (AlturaEN altura)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (altura);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AlturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return altura.Height;
}

public void Modify (AlturaEN altura)
{
        try
        {
                SessionInitializeTransaction ();
                AlturaEN alturaEN = (AlturaEN)session.Load (typeof(AlturaEN), altura.Height);
                session.Update (alturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AlturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int height)
{
        try
        {
                SessionInitializeTransaction ();
                AlturaEN alturaEN = (AlturaEN)session.Load (typeof(AlturaEN), height);
                session.Delete (alturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AlturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AlturaEN> DameTodaslasAlturas ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.AlturaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AlturaEN self where FROM AlturaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AlturaENdameTodaslasAlturasHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.AlturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in AlturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
