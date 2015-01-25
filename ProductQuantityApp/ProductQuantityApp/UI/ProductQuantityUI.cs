using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductQuantityApp.BLL;
using ProductQuantityApp.DAL.DAO;

namespace ProductQuantityApp
{
    public partial class Form1 : Form
    {
        private ProductManager aProductManager = new ProductManager();

        public Form1()
        {
            InitializeComponent();
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.Code = codeTextBox.Text;
            aProduct.Description = descriptionTextBox.Text;
            aProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
            string msg = aProductManager.Save(aProduct);
            MessageBox.Show(msg);
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();

            List<Product> aList = aProductManager.SearchProduct();
           

            foreach (Product product in aList)
            {
                ListViewItem aListViewItem = new ListViewItem();

               aListViewItem.Text = product.Code.ToString();
                //aListViewItem.SubItems.Add(product.Code).ToString();
                aListViewItem.SubItems.Add(product.Description);
                aListViewItem.SubItems.Add(product.Quantity.ToString());
                aListViewItem.Tag = product;
                listView.Items.Add(aListViewItem);
            }
           totalQuantityTextBox.Text = aProductManager.ShowTotalQuantity().ToString();

        }
        

    }
}
