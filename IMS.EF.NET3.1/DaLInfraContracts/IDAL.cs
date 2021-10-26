using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DaLInfraContracts
{
    public interface IDAL
    {
        public void ExecuteNonQuery(string spName, params IParameter[] parameters);
        public DataSet ExecuteQuery(string spName, params IParameter[] parameters);
        public IParameter CreateParameter(string paramName, object value);
        public SqlCommand GetCommand(string spName, params IParameter[] parameters);
        public bool DataSetIsEmpty(DataSet dataSet);
    }
}
