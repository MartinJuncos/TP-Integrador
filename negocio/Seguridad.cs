using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;
            if (user != null && user.Id != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;
            if (user != null && user.Admin == true)
                return true;
            else
                return false;
        }
    }
}
