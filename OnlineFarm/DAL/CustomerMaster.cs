using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineFarm.DAL
{
    public class CustomerMaster
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string BuildingNo { get; set; }
        public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [CustomerMaster]
                                      (   
                                       [Name]       
                                     , [Email]      
                                     , [MobileNo]      
                                     , [AltMobileNo]
                                     , [Address]    
                                     , [City]       
                                     , [State]       
                                     , [ZipCode]    
                                     , [BuildingNo]    
                                     , [CreatedDate]
                                       )
                                       values
                                        (                                   
                                       @Name    
                                     , @Email     
                                     , @MobileNo     
                                     , @AltMobileNo   
                                     , @Address  
                                     , @City  
                                     , @State  
                                     , @ZipCode  
                                     , @BuildingNo  
                                     , @CreatedDate
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name == null ? (Object)DBNull.Value : Name;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email == null ? (Object)DBNull.Value : Email;
                        cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 20).Value = MobileNo == null ? (Object)DBNull.Value : MobileNo;
                        cmd.Parameters.Add("@AltMobileNo", SqlDbType.NVarChar, 20).Value = AltMobileNo == null ? (Object)DBNull.Value : AltMobileNo;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value = Address == null ? (Object)DBNull.Value : Address;
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = City == null ? (Object)DBNull.Value : City;
                        cmd.Parameters.Add("@State", SqlDbType.NVarChar, 50).Value = State == null ? (Object)DBNull.Value : State;
                        cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 50).Value = ZipCode == null ? (Object)DBNull.Value : ZipCode;
                        cmd.Parameters.Add("@BuildingNo", SqlDbType.NVarChar, 50).Value = BuildingNo == null ? (Object)DBNull.Value : BuildingNo;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        CustomerId = Convert.ToInt32(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static int TotalCustomers()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["CarRent"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM CarMaster;";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                                records = Convert.ToInt32(Rd["RecordCount"]);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return records;
        }
    }
}