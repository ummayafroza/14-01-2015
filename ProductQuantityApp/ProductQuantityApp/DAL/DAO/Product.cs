using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductQuantityApp.DAL.DAO
{
     public class Product
    {
         public int Id { set; get; }
         public string Code { set; get; }
         public string Description { set; get; }
         public int  Quantity { set; get; }

    }
}
