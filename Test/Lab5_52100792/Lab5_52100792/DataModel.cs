using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_52100792
{
    class DataModel
    {
        SqlConnection conn;
        public DataModel()
        {
            string str = "Data Source = DESKTOP-QK2LSSI\\SQLEXPRESS; Initial Catalog = Lab5; Integrated Security = True; MultipleActiveResultSets=true";
            conn = new SqlConnection(str);
            conn.Open();
        }

        public List<Dictionary<string, string>> FetchAllRow()
        {
            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
            Dictionary<string, string> column;
            string sqlQuery = "SELECT ID, FullName, Dob FROM DocGia";

            SqlCommand command = new SqlCommand(sqlQuery, this.conn);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {    //Every new row will create a new dictionary that holds the columns
                    column = new Dictionary<string, string>();
                    column["ID"] = reader["ID"].ToString();
                    column["FullName"] = reader["FullName"].ToString();
                    column["Dob"] = reader["Dob"].ToString();

                    rows.Add(column); //Place the dictionary into the list
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //If an exception occurs, write it to the console
                Console.WriteLine(ex.ToString());
            }

            return rows;


        }


        public bool AddNewRow(string id, string name, string dob)
        {
            string addCmd = "INSERT INTO DocGia (ID, FullName, Dob) values (@val1, @val2, @val3)";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = addCmd;
                comm.Parameters.AddWithValue("@val1", id);
                comm.Parameters.AddWithValue("@val2", name);
                comm.Parameters.AddWithValue("@val3", dob);
                try
                {
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        public bool RemoveRow(string id)
        {
            string addCmd = "DELETE FROM DocGia where ID = @val1";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = addCmd;
                comm.Parameters.AddWithValue("@val1", id);
                try
                {
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }
        public bool EditRow(string id, string name, string dob, string id2)
        {
            string addCmd = "Update DocGia set ID = @val1,FullName = @val2, Dob = @val3 where ID = @val4";
            using (SqlCommand comm = new SqlCommand())
            {
                comm.Connection = conn;
                comm.CommandText = addCmd;
                comm.Parameters.AddWithValue("@val1", id);
                comm.Parameters.AddWithValue("@val2", name);
                comm.Parameters.AddWithValue("@val3", dob);
                comm.Parameters.AddWithValue("@val4", id2);
                try
                {
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }
    }
}
