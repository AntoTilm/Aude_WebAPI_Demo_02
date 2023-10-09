using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.Tools.Utils
{
    public static class AddSqlParamter
    {
        public static void AddParamWithValue(this DbCommand cmd, string paramName, Object? paramValue)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue ?? DBNull.Value; //Si paramValue est nulle, on ajoute la valeur db NULL (pas pareil que notre type null en C#)
            cmd.Parameters.Add(param);
        }


    }
}
