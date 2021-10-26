using DaLInfraContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQLDalService
{
    public class SQLParameterAdapter : IParameter
    {
        public SqlParameter Parameter { get; set; }
    }
}
