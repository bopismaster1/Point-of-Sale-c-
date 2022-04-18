using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace Point_of_Sale
{
    internal class connection
    {
        

        public static String insert_update_delete(String query)
        {
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var DBPath = GetDirectory + "\\store.mdb";
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBPath;
            OleDbCommand cmd = new OleDbCommand(query);
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {


                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "success";
                }
                catch (OleDbException ex)
                {
                    conn.Close();
                    return ex.ToString();
                }
            }
            else
            {
                return "Connection Failed";
            }
        }
        public static DataTable selectData(String Query)
        {
            var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var DBPath = GetDirectory + "\\store.mdb";

            DataTable dataTableRes = new DataTable();
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBPath;
           
                OleDbCommand cmd = new OleDbCommand(Query, conn);

                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(dataTableRes);
            return dataTableRes;


        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //return Convert.ToHexString(hashBytes); 
                // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                 StringBuilder sb = new System.Text.StringBuilder();
                 for (int i = 0; i < hashBytes.Length; i++)
                 {
                     sb.Append(hashBytes[i].ToString("X2"));
                 }
                return sb.ToString();
            }
        }
    }
}
