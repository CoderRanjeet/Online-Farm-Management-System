using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineFarm.DAL
{
    public class ProductMaster
    {
        public int ProductId        {get;set;}
        public string Category      {get;set;}
        public string Product       {get;set;}
        public decimal? Price       {get;set;}
        public int Qty              {get;set;}
        public string ProductImg   {get;set;}
        public string Description   {get;set;}
        public decimal? Discount { get; set; }
        public string Unit { get; set; }
        public DateTime? CreatedDate{get;set;}
        public bool? IsActive { get; set; }


        public void Add()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"insert into [ProductMaster]
                                      (        
                                       [Category]   
                                     , [Product]    
                                     , [Price]      
                                     , [Qty]        
                                     , [ProductImg]
                                     , [Description]
                                     , [Discount]
                                     , [CreatedDate]
                                     , [IsActive]   
                                     , [Unit]   
                                       )
                                       values
                                        (                 
                                       @Category
                                      ,@Product   
                                      ,@Price     
                                      ,@Qty        
                                      ,@ProductImg
                                      ,@Description
                                      ,@Discount
                                      ,@CreatedDate
                                      ,@IsActive  
                                      ,@Unit                      
                                       );";
                    Sql += "select scope_identity();";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = Category == null ? (Object)DBNull.Value : Category;
                        cmd.Parameters.Add("@Product", SqlDbType.NVarChar, 150).Value = Product == null ? (Object)DBNull.Value : Product;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal, 8).Value = Price == null ? (Object)DBNull.Value : Price;
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty == null ? (Object)DBNull.Value : Qty;
                        cmd.Parameters.Add("@ProductImg", SqlDbType.NVarChar, 50).Value = ProductImg == null ? (Object)DBNull.Value : ProductImg;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description == null ? (Object)DBNull.Value : Description;
                        cmd.Parameters.Add("@Discount", SqlDbType.Decimal, 8).Value = Discount == null ? (Object)DBNull.Value : Discount;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime, 8).Value = CreatedDate == null ? (Object)DBNull.Value : CreatedDate;
                        cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                        cmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 50).Value = Unit == null ? (Object)DBNull.Value : Unit;
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

        public static ProductMaster GetProductInfo(string ProductId)
        {
            ProductMaster CM = new ProductMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [ProductMaster] where [ProductId]=@ProductId";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@ProductId", SqlDbType.Int, 8).Value = ProductId;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                CM.Category = Rd["Category"] == DBNull.Value ? null : Rd["Category"].ToString();
                                CM.Product = Rd["Product"] == DBNull.Value ? null : Rd["Product"].ToString();
                                CM.ProductImg = Rd["ProductImg"] == DBNull.Value ? null : Rd["ProductImg"].ToString();
                                CM.Description = Rd["Description"] == DBNull.Value ? null : Rd["Description"].ToString();
                                CM.Discount = Convert.ToDecimal(Rd["Discount"]);
                                CM.Qty = Convert.ToInt32(Rd["Qty"]);
                                CM.Price = Convert.ToDecimal(Rd["Price"]);
                                CM.Unit = Rd["Unit"] == DBNull.Value ? null : Rd["Unit"].ToString();
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
            return CM;
        }

        public static DataTable GetProduct(int ProductId)
        {
            DataTable Tc = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [ProductMaster] where [ProductId]=@ProductId;";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@ProductId", SqlDbType.BigInt, 8).Value = ProductId;

                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            Tc.Load(Rd);
                          
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return Tc;
        }

        public static DataTable GetCategories(string category)
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [ProductMaster] where [Category]=@Category;";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = category;

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

        public static DataTable GetProducts()
        {
            DataTable Dt = new DataTable();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [ProductMaster]";

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

        public bool Delete(int Id)
        {
            bool IsDelete = false;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"delete [ProductMaster] where [ProductId]=@ProductId";

                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = Id;

                        int Msg = cmd.ExecuteNonQuery();
                        if (Msg > 0)
                        {
                            IsDelete = true;
                        }
                        else
                        {
                            IsDelete = false;
                        }
                    }
                    Con.Close();
                }
            }
            catch (Exception Ex)
            {
                var Msg = Ex.Message;
            }
            return IsDelete;
        }

        public void Update()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [ProductMaster]
                                         SET
                                      [Category]=@Category       
                                     ,[Product]=@Product
                                     ,[Price]=@Price          
                                     ,[Qty]=@Qty      
                                     ,[ProductImg]=@ProductImg      
                                     ,[Description]=@Description
                                     ,[Discount]=@Discount
                                     ,[Unit]=@Unit
                                      where ProductId =@ProductId";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = ProductId;
                        cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = Category == null ? (Object)DBNull.Value : Category;
                        cmd.Parameters.Add("@Product", SqlDbType.NVarChar, 150).Value = Product == null ? (Object)DBNull.Value : Product;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal, 8).Value = Price == null ? (Object)DBNull.Value : Price;
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                        cmd.Parameters.Add("@ProductImg", SqlDbType.NVarChar, 50).Value = ProductImg == null ? (Object)DBNull.Value : ProductImg;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = Description == null ? (Object)DBNull.Value : Description;
                        cmd.Parameters.Add("@Discount", SqlDbType.Decimal,8).Value = Discount == null ? (Object)DBNull.Value : Discount;
                        cmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 50).Value = Unit == null ? (Object)DBNull.Value : Unit;

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

        public static int TotalProducts()
        {
            int records = 0;
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"SELECT COUNT(*) AS RecordCount
                                   FROM ProductMaster;";

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

        public static ProductMaster GetQty(string Product)
        {
            ProductMaster CM = new ProductMaster();
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"select * from [ProductMaster] where [Product]=@Product";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Product", SqlDbType.VarChar, 50).Value = Product;
                        using (SqlDataReader Rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (Rd.Read())
                            {
                                CM.Product = Rd["Product"] == DBNull.Value ? null : Rd["Product"].ToString();
                                CM.Qty = Convert.ToInt32(Rd["Qty"]);
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
            return CM;
        }

        public void UpdateQty()
        {
            try
            {
                string Constr = ConfigurationManager.ConnectionStrings["OnlineFarm"].ConnectionString;
                using (SqlConnection Con = new SqlConnection(Constr))
                {
                    string Sql = @"update [ProductMaster]
                                         SET  [Qty]=@Qty  
                                      where Product =@Product";
                    Con.Open();

                    using (SqlCommand cmd = new SqlCommand(Sql, Con))
                    {
                        cmd.Parameters.Add("@Product", SqlDbType.VarChar,50).Value = Product;
                        cmd.Parameters.Add("@Qty", SqlDbType.Int,8).Value = Qty;

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
    }
}