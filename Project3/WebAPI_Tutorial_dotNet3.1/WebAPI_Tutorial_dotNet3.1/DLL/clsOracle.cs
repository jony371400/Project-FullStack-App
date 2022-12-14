using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace WebAPI_Tutorial_dotNet3._1.DLL
{
    public class clsOracle
    {
        public OracleConnection mConnection = new OracleConnection();
        public OracleCommand mOracleCommand = new OracleCommand();
        public OracleDataAdapter mAdapter;
        DataTable dtResult = new DataTable();
        DataSet dsResult = new DataSet();

        public clsOracle()
        {
        }

        public void Open(string strConn)
        {
            try
            {
                mConnection.ConnectionString = strConn;
                mConnection.Open();
                Console.WriteLine("DB Connect Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Connect Fail : " + ex.Message.ToString());
            }
        }

        public void Close()
        {
            try
            {
                mConnection.Close();
                Console.WriteLine("DB Connect Close");
            }
            catch (Exception ex)
            {
                Console.WriteLine("DB Connect Close Fail : " + ex.Message.ToString());
            }

        }

        public DataTable ExecSQL(string sql)
        {
            try
            {
                mOracleCommand.Connection = mConnection;
                mOracleCommand.CommandType = CommandType.Text;
                mOracleCommand.CommandText = sql;
                mOracleCommand.Parameters.Clear();

                mAdapter = new OracleDataAdapter(mOracleCommand);
                mAdapter.Fill(dsResult);
                dtResult = dsResult.Tables[0];

                //var value = dtResult.Rows[0][0].ToString() + " | " + dtResult.Rows[0][1].ToString();
                //Console.WriteLine("Data : " + value.ToString());
                Console.WriteLine("Exec Sql Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exec Sql Error : " + ex.Message.ToString());
            }

            return dtResult;
        }
    }
}