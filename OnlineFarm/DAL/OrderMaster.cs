using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineFarm.DAL
{
    public class OrderMaster
    {
       public int OrderId    {get;set;}
       public string ProductName {get;set;}
       public int Quantity   {get;set;}
       public decimal? Price      {get;set;}
       public decimal? TotalPrice {get;set;}
        public string OrderStatus { get; set; }
        public int CustomerId {get;set;}
       public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [OrderMaster]
                                      (        
                                       [ProductName]   
                                     , [Price]      
                                     , [Quantity]        
                                     , [TotalPrice]
                                     , [OrderStatus]
                                     , [CustomerId]
                                     , [CreatedDate]
                                       )
                                       values
                                        (                 
                                       @ProductName
                                      ,@Price     
                                      ,@Quantity        
                                      ,@TotalPrice
                                      ,@OrderStatus
                                      ,@CustomerId
                                      ,@CreatedDate          
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50).Value = ProductName == null ? (Object)DBNull.Value : ProductName;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal, 8).Value = Price == null ? (Object)DBNull.Value : Price;
                        cmd.Parameters.Add("@TotalPrice", SqlDbType.Decimal, 8).Value = TotalPrice == null ? (Object)DBNull.Value : TotalPrice;
                        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId;
                        cmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar, 50).Value = OrderStatus == null ? (Object)DBNull.Value : OrderStatus;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        OrderId= Convert.ToInt32(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static DataTable GetOrders()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT OM.OrderId,CM.Name,om.ProductName,om.Quantity,OM.Price,OM.TotalPrice,OM.OrderStatus,OM.CreatedDate
                                   FROM OrderMaster OM
                                   LEFT JOIN CustomerMaster CM ON OM.CustomerId = CM.CustomerId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            Dt.Load(Rd);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return Dt;
        }

        public static int TotalOrderRecords()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM OrderMaster;";

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

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [OrderMaster] SET
                                      [OrderStatus]=@OrderStatus
                                       where OrderId =@OrderId";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@OrderStatus", SqlDbType.NVarChar, 50).Value = OrderStatus == null ? (Object)DBNull.Value : OrderStatus;
                        cmd.Parameters.Add("@OrderId", SqlDbType.BigInt, 8).Value = OrderId;

                        int msg = Convert.ToInt32(cmd.ExecuteScalar());
                        Con.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
        }

        public static DataTable GetOrders(string Email)
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT OM.OrderId,CM.Name,om.ProductName,om.Quantity,OM.Price,OM.TotalPrice,OM.OrderStatus,OM.CreatedDate
                                   FROM OrderMaster OM
                                   LEFT JOIN CustomerMaster CM ON OM.CustomerId = CM.CustomerId
                                    where CM.Email = @Email";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = Email;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            Dt.Load(Rd);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return Dt;
        }

    }
}