using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class ProductCartControl : UserControl
    {
        public event EventHandler OnAddToCart;

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Image ProductImage { get; set; }

        string resourcesPath = Path.Combine(Application.StartupPath, "Resources");

        public ProductCartControl()
        {
            InitializeComponent();
        }

        // Ürünün bilgilerini güncelle
        public void SetProductInfo(int id, string name, decimal price, Image image)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductImage = image;

            lblProductName.Text = name;
            lblProductPrice.Text = price.ToString("C");
            picProduct.Image = image;
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {

            OnAddToCart?.Invoke(this, EventArgs.Empty);
        }
    }
}
