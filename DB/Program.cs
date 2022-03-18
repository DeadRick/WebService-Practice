using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = ExecuteSQL_DataTable
        }
        private static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(SQL, con))
                {
                    cmd.CommandType = CommandType.Text;
                    foreach (var tuple in parameters)
                        cmd.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));
                    con.Open();
                    SqliteDataReader reader = cmd.ExecuteReader();
                    for (int i = 0; i < reader.FieldCount; i++)
                        dt.Columns.Add(new DataColumn(reader.GetName(i)));

                    int rowIndex = 0;
                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        dt.Rows.Add(row);
                        for (int i = 0; i < reader.FieldCount; i++)
                            dt.Rows[rowIndex][i] = (reader.GetValue(i));
                        rowIndex++;
                    }
                }
            }
            return dt;
        }
    }
}
