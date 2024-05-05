using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineFarm.DAL
{
    public class BillingMaster
    {
        public int BillingId { get; set; }
        public string OrderId { get; set; }
        public decimal? Total { get; set; }
        public decimal? Discount { get; set; }
        public decimal? FinalAmt { get; set; }
        public int CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [BillingMaster]
                                      (        
                                       [OrderId]      
                                     , [Total]
                                     , [Discount]
                                     , [FinalAmt]
                                     , [CustomerId]
                                     , [CreatedDate]
                                       )
                                       values
                                        (                 
                                       @OrderId    
                                      ,@Total
                                      ,@Discount
                                      ,@FinalAmt
                                      ,@CustomerId
                                      ,@CreatedDate          
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@OrderId", SqlDbType.NVarChar, 50).Value = OrderId == null ? (Object)DBNull.Value : OrderId;
                        cmd.Parameters.Add("@Total", SqlDbType.Decimal, 8).Value = Total == null ? (Object)DBNull.Value : Total;
                        cmd.Parameters.Add("@Discount", SqlDbType.Decimal, 8).Value = Discount == null ? (Object)DBNull.Value : Discount;
                        cmd.Parameters.Add("@FinalAmt", SqlDbType.Decimal, 8).Value = FinalAmt == null ? (Object)DBNull.Value : FinalAmt;
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId;
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

        public static DataTable GetBillings()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT BM.BillingId,BM.OrderId,CM.Name,BM.Total,BM.Discount,BM.FinalAmt,BM.CreatedDate
                                    FROM BillingMaster BM
                                    LEFT JOIN CustomerMaster CM ON BM.CustomerId = CM.CustomerId";

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

        public static int TotalBillingRecords()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM BillingMaster;";

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

        public static decimal? TotalRevenue()
        {
            decimal? TotalAmt = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT SUM(FinalAmt) AS TotalRevenue FROM BillingMaster;";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                                TotalAmt = Convert.ToDecimal(Rd["TotalRevenue"]);
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return TotalAmt;
        }
    }
}