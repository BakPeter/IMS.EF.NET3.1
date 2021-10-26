using DaLInfraContracts;
using DynamicLoaderService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SQLDalService
{
    [LoaderAttribute(typeof(IDAL), typeof(SQLDalServiceImpl), Policy.Transient)]
    public class SQLDalServiceImpl : IDAL
    {
        public void ExecuteNonQuery(string spName, params IParameter[] parameters)
        {
            var commandSP = GetCommand(spName, parameters);
            commandSP.ExecuteNonQuery();
            commandSP.Connection.Close();
        }

        public DataSet ExecuteQuery(string spName, params IParameter[] parameters)
        {
            var commandSP = GetCommand(spName, parameters);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandSP);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);
            commandSP.Connection.Close();

            return dataSet;
        }

        public IParameter CreateParameter(string paramName, object value)
        {
            SQLParameterAdapter retVal = new SQLParameterAdapter
            {
                Parameter = new SqlParameter(paramName, value)
            };
            return retVal as IParameter;
        }

        public SqlCommand GetCommand(string spName, params IParameter[] parameters)
        {
            var connection = new SqlConnection(GetConnectionString());
            connection.Open();
            SqlCommand commandSP = new SqlCommand
            {
                CommandText = spName,
                CommandType = CommandType.StoredProcedure
            };
            foreach (var parameter in parameters)
            {
                commandSP.Parameters.Add((parameter as SQLParameterAdapter).Parameter);
            }
            commandSP.Connection = connection;

            return commandSP;
        }

        private string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public bool DataSetIsEmpty(DataSet dataSet)
        {
            return dataSet.Tables[0].Rows.Count == 0;
        }

    }
}
