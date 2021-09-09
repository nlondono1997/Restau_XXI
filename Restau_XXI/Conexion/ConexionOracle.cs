using System;
using Oracle.ManagedDataAccess.Client;

namespace Conexion
{
    public abstract class ConexionOracle
    {
        private readonly string connectionString;
        public ConexionOracle()
        {
            connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LAPTOP-JDF9RLJR)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id=nico;Password=nico;";
        }
        protected OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }
    }
}
