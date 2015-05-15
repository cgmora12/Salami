
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using Salami4UAGenNHibernate.EN.Salami4UA;
using Salami4UAGenNHibernate.CAD.Salami4UA;

namespace Salami4UAGenNHibernate.CEN.Salami4UA
{
public partial class UsuarioCEN
{
public bool ValidationUser (string p_oid, string contrasenya)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Usuario_ValidationUser) ENABLED START*/

        // Write here your custom code...

        Boolean ok = false;
        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        if (usuario.Password == contrasenya) {
                ok = true;
        }

        return ok;

        /*PROTECTED REGION END*/
}
}
}
