using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace Singleton
{
    public interface IWriteLog
    {
        void WriteTextLog(string s);
    }

    class WriteLog : IWriteLog
    {
        public void WriteTextLog(string s)
        {
            try
            {
                File.AppendAllText("C:\\Users\\Administrator\\Desktop\\log.txt", s + " | " + DateTime.Now + '\n' + '\n'); // Append text in end file 
            }
            catch (Exception ex)
            {
                Logger.Error(new WriteLog(), ("Error: "+ ex.Message));
                Logger.Debug("Warning: You need to make debug program. Program fell recording in file !!!");
            }
        }
    }

    class WriteConsole : IWriteLog
    {
        public void WriteTextLog(string s)
        {
            Console.WriteLine(s);
        }
    }

    class WriteDataBase : IWriteLog
    {
        public void WriteTextLog(string s)   // testting handler error connection with DB
        
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.ErrorLogWrite", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 360;
                    sqlCommand.Parameters.AddWithValue("@Description", s);

                    sqlCommand.ExecuteReader();
                }
                catch (InvalidOperationException ex)
                {
                    Logger.Error(new WriteLog(), "Error: " + ex.Message);
                    Logger.Debug("Warning: You need to make debug program. Program fell recording in DB !!!");
                }
                catch ( SqlException ex)
                {
                    Logger.Error(new WriteLog(), ("Error: "+ ex.Message));
                    Logger.Debug("Warning: You need to make debug program. Program fell recording in DB !!!");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
