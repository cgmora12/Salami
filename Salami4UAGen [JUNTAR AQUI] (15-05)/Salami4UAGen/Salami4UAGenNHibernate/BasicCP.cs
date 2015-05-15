using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Salami4UAGenNHibernate.CAD.Salami4UA;

namespace Salami4UAGenNHibernate
{
    class BasicCP
    {
        public ISession session;

        public bool sessionStarted;

        public ITransaction tx;

        public BasicCP()
        {
            sessionStarted = true;
        }

        public BasicCP(ISession sessionAux)
        {
            session = sessionAux;
            sessionStarted = false;
        }

        public void SessionInitializeTransaction()
        {
            if (session == null && sessionStarted == true)
            {
                session = NHibernateHelper.OpenSession();
                tx = session.BeginTransaction();
            }
        }

        public void SessionCommit()
        {
            if (sessionStarted && session != null)
                tx.Commit();
        }

        public void SessionRollBack()
        {
            if (sessionStarted && session != null && session.IsOpen)
                tx.Rollback();
        }

        public void SessionClose()
        {
            if (sessionStarted && session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
                session = null;
            }
        }

    }
}
