using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductQuantityApp.DAL.DAO;
using ProductQuantityApp.DAL.DBGetway;

namespace ProductQuantityApp.BLL
{
    public class ProductManager
    {
        private const int MIN_LENGTH_OF_CODE = 3;
        ProductDBGetway aProductDbGetway = new ProductDBGetway();
        
        public string Save(Product aProduct)
        {
            if (aProduct.Code.Length < MIN_LENGTH_OF_CODE)
            {
                return "Code length must be more than " + MIN_LENGTH_OF_CODE + " characters.";
            }
            else
            {
                if (aProduct.Quantity > 0)
                {
                    Product product = aProductDbGetway.Find(aProduct.Code);
                    if (product == null)
                    {
                        aProductDbGetway.Save(aProduct);
                        return "Saved.";
                    }
                    else
                    {
                        aProduct.Quantity += product.Quantity;
                        int rowAffected = aProductDbGetway.Update(aProduct);
                        return rowAffected + " Quantity updated.";
                    }

                }
                else
                {
                    return "Please Enter Positove Quantity";
                }
            }

        }


        public List<Product> SearchProduct()
        {
            return aProductDbGetway.SearchProduct();
        }
        public int ShowTotalQuantity()
        {
            return aProductDbGetway.ShowTotalQuantity();
        }
    }
}
