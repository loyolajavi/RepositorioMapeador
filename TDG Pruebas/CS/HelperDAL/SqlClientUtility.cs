using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Configuration;

namespace TFI.HelperDAL
{
    /// <summary>
    /// INTERNAL??????????????????????
    /// </summary>
    public static class SqlClientUtility
    {
        //public static string connectionStringName = ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString;
        private static SqlTransaction tr;
        private static SqlCommand command;
        private static SqlConnection connection;
        private static DataTable datatable;


        /// <summary>
        /// Trae los Datos de la Base y lo pone en un DataTable.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string connectionStringName, CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            DataTable result;
            
            
            try
            {
                
                //string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                connection = new SqlConnection(connectionStringName);

                connection.Open();
                
                tr = connection.BeginTransaction();

                using (command = CreateCommand(connection, commandType, commandText, parameters))
                {

                    //command.ExecuteNonQuery();
                    result = CreateDataTable(command);
                    //tr.Commit();
                    return result;
                }
                
            }
            catch (Exception)
            {
                tr.Rollback();   
                throw;
            }
            finally
            {
                connection.Close();
            }
            

        }


        /// <summary>
        /// Creates the command.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
       private static SqlCommand CreateCommand(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] parameters)
        {
            //if (connection != null && connection.State == ConnectionState.Closed)
            //{
            //    connection.Open();
            //}
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = tr;
           
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    SqlParameter parameter = parameters[i];
                    parameter.Value = ChequearNulo(parameter.Value);
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }



       private static DataTable CreateDataTable(SqlCommand command)
       {
           DataTable result;
           using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
           {
               DataTable dataTable = new DataTable();
               dataAdapter.Fill(dataTable);
               result = dataTable;
           }
           return result;
       }


       private static object ChequearNulo(object value)
       {
           object result;
           if (value == null)
           {
               result = DBNull.Value;
           }
           else
           {
               result = value;
           }
           return result;
       }


       public static void ExecuteNonQuery(string connectionStringName, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
           try
           {

               connection = new SqlConnection(connectionStringName);

               connection.Open();

               tr = connection.BeginTransaction();

               using (command = CreateCommand(connection, commandType, commandText, parameters))
               {
                   command.ExecuteNonQuery();
               }

           }
           catch (Exception)
           {
               tr.Rollback();
               throw;
           }
           finally
           {
               connection.Close();
           }
       }




       public static object ExecuteScalar(string connectionStringName, CommandType commandType, string commandText, params SqlParameter[] parameters)
       {
          
           object result;
          
           try
           {

               connection = new SqlConnection(connectionStringName);

               connection.Open();

               tr = connection.BeginTransaction();

               using (command = CreateCommand(connection, commandType, commandText, parameters))
               {
                   result = command.ExecuteScalar();
                   return result;
               }

           }
           catch (Exception)
           {
               tr.Rollback();
               throw;
           }
           finally
           {
               connection.Close();
           }

       }



    }
}
