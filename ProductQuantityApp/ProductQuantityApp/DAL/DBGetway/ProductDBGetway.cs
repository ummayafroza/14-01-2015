using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductQuantityApp.DAL.DAO;

namespace ProductQuantityApp.DAL.DBGetway
{
    public class ProductDBGetway
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["ConnetionStringForProductQuantityDB"].ConnectionString;

        private SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;

        public ProductDBGetway()
        {
            aSqlConnection = new SqlConnection(connectionString);
        }

        public void Save(Product aProduct)
        {
            string query = "INSERT INTO tbl_Product VALUES ('"+ aProduct.Code +"', '"+ aProduct.Description +"', '"+aProduct.Quantity +"')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query,aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }

        public Product Find(string code)
        {
            string query = "SELECT * FROM tbl_Product WHERE Code = '"+code+"' ";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Product aProduct;

            if (aDataReader.HasRows)
            {
                aProduct = new Product();
                aDataReader.Read();
                aProduct.Id = Convert.ToInt32(aDataReader["Id"]);
                aProduct.Code = aDataReader["Code"].ToString();
                aProduct.Description = aDataReader["Description"].ToString();
                aProduct.Quantity = Convert.ToInt32(aDataReader["Quantity"]);
                aDataReader.Close();
                aSqlConnection.Close();
                return aProduct;
            }
            else
            {
                aDataReader.Close();
                aSqlConnection.Close();
                return null;
            }
        }
        public List<Product> SearchProduct()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM tbl_Product";
            aSqlConnection.Open();
            Product product;
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();


            while (aDataReader.Read())
            {
                product = new Product();
                product.Id = Convert.ToInt32(aDataReader["Id"]);
                product.Code = aDataReader["Code"].ToString();
                product.Description = aDataReader["Description"].ToString();
                product.Quantity = Convert.ToInt32(aDataReader["Quantity"]);
                products.Add(product);
            }

            aDataReader.Close();
            aSqlConnection.Close();
            return products;

        }


        public int Update(Product aProduct)
        {
            string query = "UPDATE tbl_Product SET Quantity = '" + aProduct.Quantity + "' WHERE Code = '" + aProduct.Code + "'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            int rowAffected = aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
            return rowAffected;
        }

        public int ShowTotalQuantity()
        {
            int totalQuantity = 0;
            string query = "SELECT SUM(Quantity) AS TotalQuantity FROM tbl_Product";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            aSqlDataReader.Read();

            if (aSqlDataReader.HasRows)
            {
                totalQuantity = (int)aSqlDataReader["TotalQuantity"];
            }

            aSqlConnection.Close();
            return totalQuantity;
        }
    }
}
