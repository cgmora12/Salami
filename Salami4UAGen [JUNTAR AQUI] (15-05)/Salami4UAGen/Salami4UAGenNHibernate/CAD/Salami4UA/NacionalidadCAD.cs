
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
public partial class NacionalidadCAD : BasicCAD, INacionalidadCAD
{
public NacionalidadCAD() : base ()
{
}

public NacionalidadCAD(ISession sessionAux) : base (sessionAux)
{
}



public NacionalidadEN ReadOIDDefault (string Name)
{
        NacionalidadEN nacionalidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                nacionalidadEN = (NacionalidadEN)session.Get (typeof(NacionalidadEN), Name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in NacionalidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return nacionalidadEN;
}


public string New_ (NacionalidadEN nacionalidad)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (nacionalidad);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in NacionalidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return nacionalidad.Name;
}

public void Modify (NacionalidadEN nacionalidad)
{
        try
        {
                SessionInitializeTransaction ();
                NacionalidadEN nacionalidadEN = (NacionalidadEN)session.Load (typeof(NacionalidadEN), nacionalidad.Name);
                session.Update (nacionalidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in NacionalidadCAD.", ex);
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
                NacionalidadEN nacionalidadEN = (NacionalidadEN)session.Load (typeof(NacionalidadEN), Name);
                session.Delete (nacionalidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in NacionalidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.NacionalidadEN> DameTodaslasNacionalidades ()
{
        System.Collections.Generic.IList<Salami4UAGenNHibernate.EN.Salami4UA.NacionalidadEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NacionalidadEN self where FROM NacionalidadEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NacionalidadENdameTodaslasNacionalidadesHQL");

                result = query.List<Salami4UAGenNHibernate.EN.Salami4UA.NacionalidadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in NacionalidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
