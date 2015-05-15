
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
public partial class MusicasCAD : BasicCAD, IMusicasCAD
{
public MusicasCAD() : base ()
{
}

public MusicasCAD(ISession sessionAux) : base (sessionAux)
{
}



public MusicasEN ReadOIDDefault (string Name)
{
        MusicasEN musicasEN = null;

        try
        {
                SessionInitializeTransaction ();
                musicasEN = (MusicasEN)session.Get (typeof(MusicasEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MusicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return musicasEN;
}


public string New_ (MusicasEN musicas)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (musicas);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MusicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return musicas.Name;
}

public void Modify (MusicasEN musicas)
{
        try
        {
                SessionInitializeTransaction ();
                MusicasEN musicasEN = (MusicasEN)session.Load (typeof(MusicasEN), musicas.Name);
                session.Update (musicasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MusicasCAD.", ex);
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
                MusicasEN musicasEN = (MusicasEN)session.Load (typeof(MusicasEN), Name);
                session.Delete (musicasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MusicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN> DameTodosLosGustosMusicales ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MusicasEN self where FROM MusicasEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MusicasENdameTodosLosGustosMusicalesHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.MusicasEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in MusicasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
