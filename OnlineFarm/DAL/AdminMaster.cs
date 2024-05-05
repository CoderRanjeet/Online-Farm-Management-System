using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineFarm.DAL
{
    public class AdminMaster
    {
      public int  AdmId     {get;set;}
      public string  Name      {get;set;}
      public string  MobileNo  {get;set;}
      public string  Email     {get;set;}
      public string  Password  {get;set;}
      public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [AdminMaster]
                                      (
                                       [Name]   
                                      ,[MobileNo]
                                      ,[Email]   
                                      ,[Password]
                                      ,[CreatedDate]
                                       )
                                       values
                                        (
                                         @Name  
                                        ,@MobileNo
                                        ,@Email
                                        ,@Password
                                        ,@CreatedDate                                
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name == null ? (Object)DBNull.Value : Name;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = Password == null ? (Object)DBNull.Value : Password;
                        cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 50).Value = MobileNo == null ? (Object)DBNull.Value : MobileNo;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.ExecuteNonQuery();
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static AdminMaster ValidateUser(string email)
        {
            AdminMaster Apt = new AdminMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select Name,Email,Password from [AdminMaster] where [Email]=@Email";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                Apt.Password = Rd["Password"] == DBNull.Value ? null : Rd["Password"].ToString();
                                Apt.Email = Rd["Email"] == DBNull.Value ? null : Rd["Email"].ToString();
                                Apt.Name = Rd["Name"] == DBNull.Value ? null : Rd["Name"].ToString();
                            }
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return Apt;
        }
    }
}