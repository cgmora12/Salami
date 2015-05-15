
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
public partial class GustosCAD : BasicCAD, IGustosCAD
{
public GustosCAD() : base ()
{
}

public GustosCAD(ISession sessionAux) : base (sessionAux)
{
}



public GustosEN ReadOIDDefault (string Nickname)
{
        GustosEN gustosEN = null;

        try
        {
                SessionInitializeTransaction ();
                gustosEN = (GustosEN)session.Get (typeof(GustosEN), Nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gustosEN;
}


public string New_ (GustosEN gustos)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (gustos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gustos.Nickname;
}

public void Modify (GustosEN gustos)
{
        try
        {
                SessionInitializeTransaction ();
                GustosEN gustosEN = (GustosEN)session.Load (typeof(GustosEN), gustos.Nickname);

                gustosEN.HairColor = gustos.HairColor;


                gustosEN.EyeColor = gustos.EyeColor;


                gustosEN.HairLength = gustos.HairLength;


                gustosEN.HairStyle = gustos.HairStyle;


                gustosEN.BodyType = gustos.BodyType;


                gustosEN.Ethnicity = gustos.Ethnicity;


                gustosEN.Smoke = gustos.Smoke;

                session.Update (gustosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string Nickname)
{
        try
        {
                SessionInitializeTransaction ();
                GustosEN gustosEN = (GustosEN)session.Load (typeof(GustosEN), Nickname);
                session.Delete (gustosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public GustosEN DameGustoPorNickname (string Nickname)
{
        GustosEN gustosEN = null;

        try
        {
                SessionInitializeTransaction ();
                gustosEN = (GustosEN)session.Get (typeof(GustosEN), Nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Salami4UAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new Salami4UAGenNHibernate.Exceptions.DataLayerException ("Error in GustosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return gustosEN;
}
}
}
