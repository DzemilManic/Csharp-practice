using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace z4
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
    public class DB
    {
        private OleDbConnection conn = new OleDbConnection();
        private OleDbCommand cmd;
        public DB() {
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:data;Persist Security Info=False;";
            cmd = conn.CreateCommand();
        }
        public void Create(Person p)
        {
            try
            {
                conn.Open();
                string query = $"INSERT INTO Table1 VALUE ({p.FirstName}, {p.LastName}, {p.PhoneNumber}, {p.Email})";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                if(conn!= null)
                   conn.Close(); 
            }
        }
        public DataTable GetAll()
        {
            
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Table1";
                cmd.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return dt;

        }
        public void Update(Person p) { }
        public void Delete(Person p) { }

    }
}
