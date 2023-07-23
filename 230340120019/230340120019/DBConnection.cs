using _230340120019.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _230340120019
{
    public class DBConnection
    {
        SqlConnection cn;
        public DBConnection()
        {
            cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EMS;Integrated Security=True;");
        }

        //[dbo].Employees

        public void InsertEmployee(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("[dbo].InsertEmployee",cn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public List<Employee> ShowAllEmp()
        {
            List<Employee> list = new List<Employee>();
            SqlCommand cmd = new SqlCommand("select * from [dbo].Employees ", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.Id = (int)dt.Rows[i]["Id"];
                    emp.Name = dt.Rows[i]["Name"].ToString();
                    emp.City = dt.Rows[i]["City"].ToString();
                    emp.Address = dt.Rows[i]["Address"].ToString();
                    list.Add(emp);
                }
            }
            cn.Close();
            cn.Dispose( );
            return list;
        }

        public Employee GetEmployee(int Id)
        {
            Employee emp = new Employee();
            SqlCommand cmd = new SqlCommand("select * from [dbo].Employees where Id=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.CommandType = System.Data.CommandType.Text;
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                reader.Read();
                emp.Id = (int)reader["Id"];
                emp.Name = reader["Name"].ToString();
                emp.City = reader["City"].ToString();
                emp.Address = reader["Address"].ToString();
            }
            cn.Close(); cn.Dispose();
            return emp;
        }

        public void UpdateEmployee(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("[dbo].UpdateEmp", cn);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        internal void DeleteEmp(int id)
        {
            SqlCommand cmd = new SqlCommand("delete [dbo].Employees where Id=@Id", cn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }
    }
}
