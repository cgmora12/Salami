
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
public void AddValidation (string nombre, string validationCode)
{
        /*PROTECTED REGION ID(Salami4UAGenNHibernate.CEN.Salami4UA_Usuario_addValidation) ENABLED START*/

        // Write here your custom code...

        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (nombre);

        usuario.ValidationCode = validationCode;

        _IUsuarioCAD.Modify (usuario);

        /*PROTECTED REGION END*/
}
}
}
