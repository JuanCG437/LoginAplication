using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio
{
    public class Class1
    {
        Datos.Class1 objD = new Datos.Class1();

        public DataTable negocLogin(Entidades.Class1 objE)
        {
            return objD.tblUsers(objE);
        }
    }
}
