using Microsoft.Data.SqlClient;

namespace DALLib
{
    public class DeptDAL
    {
        SqlConnection cn = null;
        public DeptDAL()
        {
             cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CompanyDB;Integrated Security=True;");
        }

        public void InsertDept(DeptBLL data)
        {

        }

        public void DeleteDept(int deptno)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("dbo.sp_DeleteDept",cn);
            cmd.Parameters.AddWithValue("@p_deptno", deptno);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public void UpdateDept(int deptno, DeptBLL newData)
        {

        }

        public List<DeptBLL> ShowAllDept()
        {

        }
    }
}