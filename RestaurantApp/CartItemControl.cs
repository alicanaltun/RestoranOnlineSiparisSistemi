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
    public partial class CartItemControl : UserControl
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Image ProductImage { get; set; }
        public int Quantity { get; set; }

        string resourcesPath = Path.Combine(Application.StartupPath, "Resources");


        public event EventHandler OnRemoveFromCart;
        public event EventHandler OnQuantityChanged;

        public CartItemControl()
        {
            InitializeComponent();
        }

        public void SetProductInfo(int id, string name, decimal price, Image image, int quantity)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductImage = image;
            Quantity = quantity;

            lblProductName.Text = name;
            lblProductPrice.Text = price.ToString("C");
            picProduct.Image = image;
            lblQuantity.Text = quantity.ToString();
        }

        private void btnIncrease_Click_1(object sender, EventArgs e)
        {
            Quantity++;
            lblQuantity.Text = Quantity.ToString();
            OnQuantityChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnDecrease_Click_1(object sender, EventArgs e)
        {
            if (Quantity > 1)
            {
                Quantity--;
                lblQuantity.Text = Quantity.ToString();
                OnQuantityChanged?.Invoke(this, EventArgs.Empty);
            }
            else if (Quantity == 1)
            {
                OnRemoveFromCart?.Invoke(this, EventArgs.Empty);
            }

        }

        public void UpdateQuantityLabel()
        {
            lblQuantity.Text = Quantity.ToString(); // Label kontrolü miktarı güncellemek için
        }
    }
}
