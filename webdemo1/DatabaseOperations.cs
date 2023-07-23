using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;
using webdemo1.Models;

namespace webdemo1
{
    public class DatabaseOperations
    {
        SqlConnection cn = null;
        public DatabaseOperations()
        {
            cn=new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=ActsJune23;Integrated Security=True;");

        }

        public void InsertUser(CreateUser user)
        {
            SqlCommand cmd = new SqlCommand("[dbo].sp_AddUserData", cn);
            cmd.Parameters.AddWithValue("@p_Aadharid", user.AadharId);
            cmd.Parameters.AddWithValue("@p_Email", user.Email);
            cmd.Parameters.AddWithValue("@p_Name", user.Name);
            cmd.Parameters.AddWithValue("@p_Password", user.Password);


            cmd.CommandType=System.Data.CommandType.StoredProcedure;

            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }

        public List<CreateUser> GetUsers()
        {
            //[dbo].getAllUsers
            SqlCommand cmd = new SqlCommand("select * from [dbo].getAllUsers()", cn);
            cn.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            List<CreateUser> users = new List<CreateUser>();
            if (dr != null)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CreateUser user = new CreateUser();
                    user.AadharId = dt.Rows[i]["AadharID"].ToString();
                    
                    user.Email = dt.Rows[i]["Email"].ToString();
                    user.Name = dt.Rows[i]["Name"].ToString();

                    user.Password = dt.Rows[i]["Password"].ToString();
                    users.Add(user);
                }
              
            }
            cn.Close();
            cn.Dispose();
            return users;
        }

        public bool ValidatedUser(UserData user)
        {
            SqlCommand cmd = new SqlCommand("select * from NewUsers where Name=@p_UserName and Password=@p_Pass;",cn);
            cmd.Parameters.AddWithValue("@p_UserName",user.UserName);
            cmd.Parameters.AddWithValue("@p_Pass", user.Password);
            cmd.CommandType = System.Data.CommandType.Text;
        
            cn.Open();
            SqlDataReader result = cmd.ExecuteReader();
            if(result.HasRows)
            {
                return true;
            }
            return false;

            cn.Close();
            cn.Dispose();
        }

        //public List<CreateUser> GetUser()
        //{

        //}

        public CreateUser GetSingleUser(string userid) 
        {
            SqlCommand cmd = new SqlCommand("select * from [dbo].FindUser(@p_Aadharid)",cn);
            cn.Open();
            cmd.Parameters.AddWithValue ("@p_Aadharid", userid);
            SqlDataReader dr = cmd.ExecuteReader();
            CreateUser user = new CreateUser();
            if (dr != null)
            {
                dr.Read();
                user.AadharId = dr["AadharId"].ToString();
                user.Name = dr["Name"].ToString();
                user.Email = dr["Email"].ToString();
                user.Password = dr["Password"].ToString();
            }
            
            cn.Close ();
            cn.Dispose ();
            return user;
            
        }

        public int DeleteUser(string userid)
        {
            SqlCommand cmd = new SqlCommand("[dbo].DeleteUserData", cn);
            
            cmd.Parameters.AddWithValue("@p_AadharID", userid);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cn.Open();
            int dr = cmd.ExecuteNonQuery();
            return dr;
        }

        public void UpdateUser(string id,CreateUser user)
        {
            SqlCommand cmd = new SqlCommand("[dbo].UpdateUserData", cn);
            cmd.Parameters.AddWithValue("@p_AadharID", user.AadharId);
            cmd.Parameters.AddWithValue("@p_Email", user.Email);
            cmd.Parameters.AddWithValue("@p_Name", user.Name);
            cmd.Parameters.AddWithValue("@p_Password", user.Password);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cn.Open();
            cmd.ExecuteNonQuery();

            cn.Close();
            cn.Dispose();
        }
    }
}
