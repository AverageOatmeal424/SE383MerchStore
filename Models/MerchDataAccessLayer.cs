using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Storefront.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Storefront.Models
{
    public class MerchDataAccessLayer
    {
        string connectionString;

        private readonly IConfiguration _configuration;

        public MerchDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(MerchModel merch)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT Into Items (ItemName, ItemDesc, ItemPrice, ItemQuantity) VALUES (@ItemName, @ItemDesc, @ItemPrice, @ItemQuantity);";

                merch.Feedback = "";

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        command.Parameters.AddWithValue("@ItemName", merch.ItemName);
                        command.Parameters.AddWithValue("@ItemDesc", merch.ItemDesc);
                        command.Parameters.AddWithValue("@ItemPrice", merch.ItemPrice);
                        command.Parameters.AddWithValue("@ItemQuantity", merch.ItemQuantity);

                        connection.Open();

                        merch.Feedback = command.ExecuteNonQuery().ToString() + " Record Added";

                        connection.Close();
                    }
                }
                catch (Exception err)
                {
                    merch.Feedback = "ERROR: " + err.Message;
                }
            }
        }

        public IEnumerable<MerchModel> GetItems()
        {
            List<MerchModel> lstItems = new List<MerchModel>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT * FROM Items ORDER BY Item_ID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        MerchModel merch = new MerchModel();

                        merch.Item_ID = Convert.ToInt32(rdr["Item_ID"]);
                        merch.ItemName = rdr["ItemName"].ToString();
                        merch.ItemDesc = rdr["ItemDesc"].ToString();
                        merch.ItemPrice = rdr["ItemPrice"].ToString();
                        merch.ItemQuantity = rdr["ItemQuantity"].ToString();

                        lstItems.Add(merch);
                    }
                    con.Close();
                }
            }
            catch (Exception err)
            {

            }
            return lstItems;
        }
    }
}
