using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CS468
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

       
        
    }

    class Database
    {
        public static DataSet ExecuteQuery(SqlConnection sqlConnection, string commandText, string connectionString,
        CommandType commandType, params SqlParameter[] parameters)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, sqlConnection))
                {

                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (parameter.Value == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }
                        command.Parameters.AddRange(parameters);
                    }


                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    DataSet dataset = new DataSet();

                    sqlDataAdapter.Fill(dataset);

                    sqlConnection.Close();
                    return dataset;
                }
            }
        }

        public static Int32 ExecuteNonQuery(String connectionString, String commandText,
          CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {

                    Int32 rowaffected = -1;
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (parameter.Value == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }
                        command.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

    }
}
