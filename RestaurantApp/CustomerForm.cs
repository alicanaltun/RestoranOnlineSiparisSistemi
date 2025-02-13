using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bunifu.UI.WinForms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace RestaurantApp
{
    public partial class CustomerForm : Form
    {

        public string connectionString = @"Data Source=.......\SQLEXPRESS;Initial Catalog=fastburger;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        // get set
        private string resourcesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources");

        private List<CartItem> cartItems = new List<CartItem>(); // Sepet öğeleri

        Bunifu.UI.WinForms.BunifuSnackbar bunifuSnackbar2;

        private string currentPage = "MenuPage";
        private Timer progressTimer;
        private int targetValue;
        private bool passwordIsValid = false;


        public CustomerForm()
        {
            InitializeComponent();
            this.FormClosed += CustomerForm_FormClosed;
            LoadProducts(1);
            pageController.SetPage("MenuPage"); // Menü sayfasını yükle
            // BunifuSnackbar bileşenini dinamik olarak oluşturun
            bunifuSnackbar2 = new Bunifu.UI.WinForms.BunifuSnackbar();

            progressTimer = new Timer();
            progressTimer.Interval = 10; // Her 20 ms'de bir çalışır
            progressTimer.Tick += ProgressTimer_Tick;

            // Ayarları özelleştirebilirsiniz (isteğe bağlı)
            bunifuSnackbar2.ShowShadows = true;  // Mesajın gölgesi olsun
            bunifuSnackbar2.ShowCloseIcon = true; // Kapatma butonu olsun
            bunifuSnackbar2.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;

            UpdateCartTotal();
        }
        // Veritabanı bağlantısı ve sorgu için örnek kod
        public DataTable GetProducts(int category_id, string search = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT urun_id, urun_adi, urun_fiyat, urun_img, kategori_id FROM urunler WHERE kategori_id = @CategoryID";

                if (!string.IsNullOrEmpty(search))
                {
                    query += " AND urun_adi LIKE @Search";  // Arama ekleniyor
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", category_id);

                if (!string.IsNullOrEmpty(search))
                {
                    cmd.Parameters.AddWithValue("@Search", $"%{search}%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }



        private void LoadProducts(int category_id, string search = null)
        {
            if (category_id == 1)
            {
                flowLayoutPanel1.Controls.Clear();  // Paneli temizle
            }
            else if (category_id == 2)
            {
                flowLayoutPanel2.Controls.Clear();
            }
            else if (category_id == 3)
            {
                flowLayoutPanel3.Controls.Clear();

            }
            else if (category_id == 4)
            {
                flowLayoutPanel4.Controls.Clear();

            }
            else if (category_id == 5)
            {
                flowLayoutPanel5.Controls.Clear();

            }



            DataTable products = GetProducts(category_id, search);

            string fullPath = Path.Combine(resourcesPath, "no-image.png");

            foreach (DataRow row in products.Rows)
            {
                ProductCartControl card = new ProductCartControl();

                fullPath = Path.Combine(resourcesPath, row["urun_img"].ToString());

                // Ürünün bilgilerini al ve card'a aktar
                card.SetProductInfo(
                    Convert.ToInt32(row["urun_id"]),
                    row["urun_adi"].ToString(),
                    Convert.ToDecimal(row["urun_fiyat"]),
                    Image.FromFile(fullPath)  // Resim yolunu buradan alıyoruz
                );

                // Sepete ekleme olayını bağla
                card.OnAddToCart += Card_OnAddToCart;

                // FlowLayoutPanel'e ekle
                if (category_id == 1)
                {
                    flowLayoutPanel1.Controls.Add(card);
                }
                else if (category_id == 2)
                {
                    flowLayoutPanel2.Controls.Add(card);
                }
                else if (category_id == 3)
                {
                    flowLayoutPanel3.Controls.Add(card);
                }
                else if (category_id == 4)
                {
                    flowLayoutPanel4.Controls.Add(card);
                }
                else if (category_id == 5)
                {
                    flowLayoutPanel5.Controls.Add(card);
                }

            }
        }





        private void btnMenu_Click(object sender, EventArgs e)
        {
            transitionController.HideSync(leftSidetBar); // Animasyonla kaybol
            pageController.SetPage("MenuPage");
            leftSidetBar.Location = new Point(leftSidetBar.Location.X, btnMenu.Location.Y);
            LoadProducts(1); // Menü sayfasını yükle
            currentPage = "MenuPage";
            transitionController.ShowSync(leftSidetBar); // Animasyonla geri gel
            txtboxSearch.Enabled = true;
        }

        private void btnBurgers_Click(object sender, EventArgs e)
        {
            transitionController.HideSync(leftSidetBar);
            pageController.SetPage("BurgersPage");
            leftSidetBar.Location = new Point(leftSidetBar.Location.X, btnBurgers.Location.Y);
            LoadProducts(2); // Burger sayfasını yükle
            currentPage = "BurgersPage";
            transitionController.ShowSync(leftSidetBar);
            txtboxSearch.Enabled = true;
        }

        private void btnSnacks_Click(object sender, EventArgs e)
        {
            transitionController.HideSync(leftSidetBar);
            pageController.SetPage("SnacksPage");
            leftSidetBar.Location = new Point(leftSidetBar.Location.X, btnSnacks.Location.Y);
            LoadProducts(3); // Snack sayfasını yükle
            currentPage = "SnacksPage";
            transitionController.ShowSync(leftSidetBar);
            txtboxSearch.Enabled = true;
        }

        private void btnDessert_Click(object sender, EventArgs e)
        {
            transitionController.HideSync(leftSidetBar);
            pageController.SetPage("DessertPage");
            leftSidetBar.Location = new Point(leftSidetBar.Location.X, btnDessert.Location.Y);
            LoadProducts(4);// Tatlı sayfasını yükle
            currentPage = "DessertPage";
            transitionController.ShowSync(leftSidetBar);
            txtboxSearch.Enabled = true;
        }

        private void btnBeverages_Click(object sender, EventArgs e)
        {
            transitionController.HideSync(leftSidetBar);
            pageController.SetPage("BeveragesPage");
            leftSidetBar.Location = new Point(leftSidetBar.Location.X, btnBeverages.Location.Y);
            LoadProducts(5); // İçecek sayfasını yükle
            currentPage = "BeveragesPage";
            transitionController.ShowSync(leftSidetBar);
            txtboxSearch.Enabled = true;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            pageController.SetPage("OrdersPage");
            LoadSales();
            currentPage = "OrdersPage";
            txtboxSearch.Enabled = false;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            cartPanel.BringToFront();
            slideTransitionController.ShowSync(cartPanel);
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            pageController.SetPage("AccountInfoPage");
            currentPage = "AccountInfoPage";
            LoadAccountInfo();
            txtboxSearch.Enabled = false;
        }

        private void btnCloseCart_Click(object sender, EventArgs e)
        {
            slideTransitionController.HideSync(cartPanel);
        }

        //sepet işlemleri

        private void Card_OnAddToCart(object sender, EventArgs e)
        {
            var card = (ProductCartControl)sender;
            AddToCart(card.ProductID, card.ProductName, card.ProductPrice, 1, card.ProductImage);
        }

        private void CartItem_OnQuantityChanged(object sender, EventArgs e)
        {
            // Miktar değişikliği işlemi
            var cartItem = (CartItemControl)sender;
            // Miktar artırma/azaltma işlemleri burada yapılabilir
            UpdateCartTotal();
        }

        private void CartItem_OnRemove(object sender, EventArgs e)
        {
            // Ürün silme işlemi
            var cartItem = (CartItemControl)sender;

            flowLayoutPanelCart.Controls.Remove(cartItem);
            UpdateCartTotal();

        }

        private void AddToCart(int productId, string productName, decimal price, int quantity, Image image)
        {
            // Mevcut ürünü kontrol et
            var existingItem = flowLayoutPanelCart.Controls
                .OfType<CartItemControl>()
                .FirstOrDefault(item => item.ProductID == productId);

            if (existingItem != null)
            {
                // Eğer ürün zaten varsa, miktarı artır
                existingItem.Quantity += quantity;
                existingItem.UpdateQuantityLabel(); // Yeni miktarı göstermek için bir metod
            }
            else
            {
                // Yeni ürün ekle
                var cartItem = new CartItemControl();
                cartItem.SetProductInfo(productId, productName, price, image, quantity);

                // Miktar değişikliklerini takip et
                cartItem.OnQuantityChanged += CartItem_OnQuantityChanged;

                // Silme olayını bağla
                cartItem.OnRemoveFromCart += CartItem_OnRemove;

                // FlowLayoutPanel'e ekle
                flowLayoutPanelCart.Controls.Add(cartItem);
            }
            bunifuSnackbar2.Show(this, "Ürün sepete eklendi", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            UpdateCartTotal();
        }


        public void UpdateCartTotal()
        {
            decimal total = 0;
            foreach (var item in flowLayoutPanelCart.Controls.OfType<CartItemControl>())
            {
                total += item.ProductPrice * item.Quantity;
            }
            lblTotal.Text = total.ToString("C");
            lblFullTotal.Text = total.ToString("C");
            lblTax.Text = (total * 0.18m).ToString("C");
            lblAmount.Text = total.ToString("C");

            if (total > 0)
            {
                txtbxOrderNote.Visible = true;
                txtbxOrderNote.Enabled = true;
                cartTotalPanel.Visible = true;
                cartTotalPanel.Enabled = true;
                btnCheckout.Visible = true;
                btnCheckout.Enabled = true;
                bunifuLabel21.Visible = false;
                bunifuShapes4.Visible = false;
                if (currentPage == "CheckoutPage")
                {
                    PaymentPageController.SetPage("CartNotNullPage");
                }
            }
            else
            {
                txtbxOrderNote.Visible = false;
                txtbxOrderNote.Enabled = false;
                cartTotalPanel.Visible = false;
                cartTotalPanel.Enabled = false;
                btnCheckout.Visible = false;
                btnCheckout.Enabled = false;
                bunifuLabel21.Visible = true;
                bunifuShapes4.Visible = true;
                slideTransitionController.HideSync(cartPanel);
                if (currentPage == "CheckoutPage")
                {
                    PaymentPageController.SetPage("CartNullPage");
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            pageController.SetPage("CheckoutPage");
            slideTransitionController.HideSync(cartPanel);
            PaymentPageController.SetPage("CartNotNullPage");
            currentPage = "CheckoutPage";
            txtboxSearch.Enabled = false;
        }

        private void txtbxCardNumber_TextChange(object sender, EventArgs e)
        {
            // Geçici olarak TextChanged olayını devre dışı bırak
            txtbxCardNumber.TextChanged -= txtbxCardNumber_TextChange;

            // Mevcut metni al
            string cardNumber = txtbxCardNumber.Text;

            // Sadece rakamları al
            string digits = new string(cardNumber.Where(char.IsDigit).ToArray());

            if (digits.Length > 16)
            {
                digits = digits.Substring(0, 16); // 16 karakterden sonrasını kes
            }

            // Yeni bir formatlı metin oluştur
            string formatted = string.Empty;
            for (int i = 0; i < digits.Length; i++)
            {
                formatted += digits[i];

                // Her 4 karakterde bir boşluk ekle, son karaktere boşluk ekleme
                if ((i + 1) % 4 == 0 && i + 1 != digits.Length)
                {
                    formatted += " ";
                }
            }

            // Formatlanmış metni textbox'a yaz
            txtbxCardNumber.Text = formatted;

            // İmleci metnin sonuna taşı
            txtbxCardNumber.SelectionStart = txtbxCardNumber.Text.Length;

            // Olayı tekrar bağla
            txtbxCardNumber.TextChanged += txtbxCardNumber_TextChange;
        }

        private void txtbxCVV_TextChange(object sender, EventArgs e)
        {
            string cvv = txtbxCVV.Text;

            // Yalnızca sayıları al
            string digits = new string(cvv.Where(char.IsDigit).ToArray());

            // Karakter sayısı 3'ü geçerse, ilk 3 karakteri al
            if (digits.Length > 3)
            {
                digits = digits.Substring(0, 3);
            }

            // Seçili metni değiştirmemek için Cursor'ı doğru yere ayarlayalım
            int cursorPosition = txtbxCVV.SelectionStart;

            txtbxCVV.Text = digits;

            // Cursor'ı metnin sonuna ayarla
            txtbxCVV.SelectionStart = cursorPosition;
            txtbxCVV.SelectionLength = 0;
        }

        private void txtbxExpirationDate_TextChange(object sender, EventArgs e)
        {
            string expirationDate = txtbxExpirationDate.Text;

            // Sadece rakamları al
            string digits = new string(expirationDate.Where(char.IsDigit).ToArray());

            // Eğer 4 karakterden fazla varsa, sadece ilk 4 karakteri al
            if (digits.Length > 4)
            {
                digits = digits.Substring(0, 4);
            }

            // 2. karakterden sonra '/' ekle
            if (digits.Length > 2)
            {
                digits = digits.Insert(2, "/");
            }

            // Sonuçları TextBox'a geri yaz
            txtbxExpirationDate.Text = digits;

            // İmleci sonunda tutmak için
            txtbxExpirationDate.SelectionStart = txtbxExpirationDate.Text.Length;
            txtbxExpirationDate.SelectionLength = 0;
        }

        private void chckbxSalesAgreement_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chckbxSalesAgreement.Checked == true)
            {
                btnPay.Enabled = true;
            }
            else
            {
                btnPay.Enabled = false;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxCardNumber.Text) || string.IsNullOrEmpty(txtbxExpirationDate.Text) || string.IsNullOrEmpty(txtbxCVV.Text))
            {
                bunifuSnackbar2.Show(this, "Lütfen tüm alanları doldurun", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                if (txtbxCardNumber.Text.Length < 19)
                {
                    bunifuSnackbar2.Show(this, "Kart numarası eksik", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else if (txtbxExpirationDate.Text.Length < 5)
                {
                    bunifuSnackbar2.Show(this, "Son kullanma tarihi eksik", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else if (txtbxCVV.Text.Length < 3)
                {
                    bunifuSnackbar2.Show(this, "CVV eksik", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else
                {
                    // Sipariş oluştur ve veritabanına işle
                    string orderNote = txtbxOrderNote.Text;
                    decimal totalAmount = decimal.Parse(lblAmount.Text, System.Globalization.NumberStyles.Currency);
                    string orderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int userID = UserSession.UserId;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Sipariş kaydı ekle ve sipariş ID'sini al
                        string query = "INSERT INTO satislar (kullanici_id, toplam_tutar, siparis_notu, siparis_durum_kodu, satis_tarihi) OUTPUT INSERTED.satis_id VALUES (@UserID, @TotalAmount, @OrderNote, @Status, @OrderDate)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        cmd.Parameters.AddWithValue("@OrderNote", orderNote);
                        cmd.Parameters.AddWithValue("@Status", 0);
                        cmd.Parameters.AddWithValue("@OrderDate", orderDate);

                        int orderId = Convert.ToInt32(cmd.ExecuteScalar());

                        // Her ürün için sipariş detayını ekle
                        foreach (var item in flowLayoutPanelCart.Controls.OfType<CartItemControl>())
                        {
                            string insertQuery = "INSERT INTO satis_detaylari (satis_id, urun_id, adet) VALUES (@OrderID, @ProductID, @Quantity)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@OrderID", orderId);
                            insertCmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                            insertCmd.Parameters.AddWithValue("@Quantity", item.Quantity);

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    bunifuSnackbar2.Show(this, "Ödeme başarılı", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    flowLayoutPanelCart.Controls.Clear();
                    UpdateCartTotal();
                    PaymentPageController.SetPage("CartNullPage");
                    pageController.SetPage("OrdersPage");
                    LoadSales();
                    //EmployeeFormNamespace.EmployeeForm.ActiveForm.Refresh();
                    txtboxSearch.Enabled = false;
                }
            }
        }

        private void LoadSales()
        {
            DataTable dt = GetSalesData();  // satislar tablosundan verileri çekiyoruz
            bunifuDataGridView1.DataSource = dt;

            // Detaylar sütununun daha önce eklenip eklenmediğini kontrol et
            if (!bunifuDataGridView1.Columns.Contains("Detaylar"))
            {
                // Detaylar sütununu ekle (Text sütunu olarak)
                DataGridViewTextBoxColumn detailsColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Detaylar",
                    HeaderText = "Detaylar",
                    ReadOnly = true // Düzenlenemez yap
                };
                bunifuDataGridView1.Columns.Add(detailsColumn);
            }
            // Detaylar sütununu doldur
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                row.Cells["Detaylar"].Value = "Detayları Göster";
            }

            // Olayları bağla
            bunifuDataGridView1.CellMouseEnter += BunifuDataGridView1_CellMouseEnter;
            bunifuDataGridView1.CellMouseLeave += BunifuDataGridView1_CellMouseLeave;
            bunifuDataGridView1.CellClick += BunifuDataGridView1_CellClick;
        }



        private void BunifuDataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == bunifuDataGridView1.Columns["Detaylar"].Index)
            {
                bunifuDataGridView1.Cursor = Cursors.Hand;
            }
        }

        private void BunifuDataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == bunifuDataGridView1.Columns["Detaylar"].Index)
            {
                bunifuDataGridView1.Cursor = Cursors.Default;
            }
        }

        // Tıklama işlemini kontrol et
        private void BunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == bunifuDataGridView1.Columns["Detaylar"].Index)
            {
                int satisId = Convert.ToInt32(bunifuDataGridView1.Rows[e.RowIndex].Cells["Sipariş Numarası"].Value);
                LoadSaleDetails(satisId); // Detay sayfasına yönlendir
            }
        }

        // Detay sayfası
        private void LoadSaleDetails(int satisId)
        {
            bunifuDataGridView2.Visible = true;
            bunifuDataGridView2.BringToFront();
            bunifuDataGridView1.Visible = false;
            btnBackToOrders.Visible = true;
            lblOrdersHeader.Text = "Sipariş Detayları";

            DataTable dtDetails = GetSaleDetails(satisId); // Detaylar tablosu
            bunifuDataGridView2.DataSource = dtDetails;
        }

        // Satışları veritabanından al
        private DataTable GetSalesData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                satis_id AS [Sipariş Numarası],
                satis_tarihi AS [Sipariş Tarihi],
                toplam_tutar AS [Toplam Tutar],
                siparis_notu AS [Sipariş Notu],
                CASE 
                    WHEN siparis_durum_kodu = 0 THEN 'Sipariş Alındı'
                    WHEN siparis_durum_kodu = 1 THEN 'Hazırlanıyor' 
                    WHEN siparis_durum_kodu = 2 THEN 'Yolda'
                    WHEN siparis_durum_kodu = 3 THEN 'Teslim Edildi'
                    WHEN siparis_durum_kodu = 4 THEN 'İptal Edildi'
                    ELSE 'Bilinmeyen'
                END AS [Sipariş Durumu]
            FROM satislar
            WHERE kullanici_id = @UserId
            ORDER BY satis_tarihi DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", UserSession.UserId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Satış detaylarını veritabanından al
        private DataTable GetSaleDetails(int satisId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                u.urun_adi AS [Ürün Adı],
                sd.adet AS [Adet],
                u.urun_fiyat AS [Ürün Birim Fiyatı]
            FROM satis_detaylari sd
            INNER JOIN urunler u ON sd.urun_id = u.urun_id
            WHERE sd.satis_id = @SatisId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SatisId", satisId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        private void btnBackToOrders_Click(object sender, EventArgs e)
        {
            bunifuDataGridView2.Visible = false;
            bunifuDataGridView1.BringToFront();
            bunifuDataGridView1.Visible = true;
            btnBackToOrders.Visible = false;
            LoadSales();
            lblOrdersHeader.Text = "Siparişlerim";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = LoginForm.Instance;
            loginForm.Show();
            this.Hide();
            UserSession.UserId = 0;
            UserSession.UserName = string.Empty;
            UserSession.UserEmail = string.Empty;
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            // ProgressBar'ı hedef değere doğru yavaş yavaş artır veya azalt
            if (passwordProgressBar.Value < targetValue)
            {
                passwordProgressBar.Value += 1;
            }
            else if (passwordProgressBar.Value > targetValue)
            {
                passwordProgressBar.Value -= 1;
            }
            else
            {
                // Hedefe ulaşıldığında Timer durdurulur
                progressTimer.Stop();
            }
        }

        //Veritabanı ile veri çekerek kullanıcı bilgilerini doldur
        private void LoadAccountInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM kullanicilar WHERE kullanici_id = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtbxCurrentName.Text = reader["ad"].ToString();
                    txtbxCurrentSurname.Text = reader["soyad"].ToString();
                    txtbxCurrentMail.Text = reader["email"].ToString();
                    txtbxCurrentPhone.Text = reader["telefon"].ToString();
                    txtbxCurrentAdress.Text = reader["adres"].ToString();
                    UserSession.HashedPassword = reader["sifre_hash"].ToString();
                }
            }

        }

        static string HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                byte[] hashBytes = sha512.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte item in hashBytes)
                {
                    sb.Append(item.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private void txtbxNewPassword_TextChange(object sender, EventArgs e)
        {
            string password = txtbxNewPassword.Text;

            if (password.Length == 0)
            {
                targetValue = 0;
                passwordProgressBar.ProgressColorLeft = Color.Gray;
                passwordProgressBar.ProgressColorRight = Color.Gray;
                lblPasswordStrength.Text = "";
                passwordProgressBar.Visible = false;
                passwordIsValid = false;
            }
            else
            {
                passwordProgressBar.Visible = true;
                lblPasswordStrength.Visible = true;
                if (password.Length < 8)
                {
                    targetValue = 20;
                    passwordProgressBar.ProgressColorLeft = Color.Red;
                    passwordProgressBar.ProgressColorRight = Color.Red;
                    lblPasswordStrength.Text = "Şifre çok zayıf";
                    passwordIsValid = false;
                }
                else if (Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                {
                    targetValue = 100;
                    passwordProgressBar.ProgressColorLeft = Color.Green;
                    passwordProgressBar.ProgressColorRight = Color.Green;
                    lblPasswordStrength.Text = "Şifre güçlü";
                    passwordIsValid = true;
                }
                else
                {
                    targetValue = 50;
                    passwordProgressBar.ProgressColorLeft = Color.Orange;
                    passwordProgressBar.ProgressColorRight = Color.Orange;
                    lblPasswordStrength.Text = "Şifre orta";
                    passwordIsValid = false;
                }
            }
            progressTimer.Start();
        }

        private void btnChangeAccountInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxCurrentName.Text) || string.IsNullOrEmpty(txtbxCurrentSurname.Text) || string.IsNullOrEmpty(txtbxCurrentPhone.Text) || string.IsNullOrEmpty(txtbxCurrentAdress.Text))
            {
                bunifuSnackbar2.Show(this, "Lütfen tüm alanları doldurun", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            else
            {
                if (txtbxCurrentPhone.Text.Trim().Replace(" ", "").Length != 10)
                {
                    bunifuSnackbar2.Show(this, "Telofon numarası en az 10 haneli olmalıdır", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtbxCurrentPassword.Text))
                    {
                        string currentPassword = txtbxCurrentPassword.Text.Trim();
                        string currentHashedPassword = HashPassword(currentPassword);
                        string newPassword = txtbxNewPassword.Text.Trim();
                        string newPasswordConfirm = txtbxNewPasswordConfirm.Text.Trim();
                        string newHashedPassword = HashPassword(newPassword);
                        if (txtbxNewPassword.Text.Length == 0)
                        {
                            bunifuSnackbar2.Show(this, "Yeni şifre alanı boş bırakılamaz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                            return;
                        }
                        else if (!passwordIsValid)
                        {
                            bunifuSnackbar2.Show(this, "Şifre en az 8 karakter olmalı ve en az 1 büyük harf, 1 küçük harf ve 1 rakam içermelidir", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                            return;
                        }
                        else if (newPassword != newPasswordConfirm)
                        {
                            bunifuSnackbar2.Show(this, "Şifreler uyuşmuyor", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                            return;
                        }
                        else if (currentHashedPassword != UserSession.HashedPassword)
                        {
                            bunifuSnackbar2.Show(this, "Mevcut şifrenizi yanlış girdiniz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                            return;
                        }
                        else
                        {
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                conn.Open();
                                string query = "UPDATE kullanicilar SET ad = @Name, soyad = @Surname, email = @Email, telefon = @Phone, adres = @Adress, sifre_hash = @Password WHERE kullanici_id = @UserID";
                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@Name", txtbxCurrentName.Text);
                                cmd.Parameters.AddWithValue("@Surname", txtbxCurrentSurname.Text);
                                cmd.Parameters.AddWithValue("@Email", txtbxCurrentMail.Text);
                                cmd.Parameters.AddWithValue("@Phone", txtbxCurrentPhone.Text);
                                cmd.Parameters.AddWithValue("@Adress", txtbxCurrentAdress.Text);
                                cmd.Parameters.AddWithValue("@Password", newHashedPassword);
                                cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);

                                cmd.ExecuteNonQuery();
                            }
                            bunifuSnackbar2.Show(this, "Bilgileriniz güncellendi", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                            txtbxCurrentPassword.Text = "";
                            txtbxNewPassword.Text = "";
                            txtbxNewPasswordConfirm.Text = "";
                            LoadAccountInfo();
                            return;
                        }

                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "UPDATE kullanicilar SET ad = @Name, soyad = @Surname, email = @Email, telefon = @Phone, adres = @Adress WHERE kullanici_id = @UserID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@Name", txtbxCurrentName.Text);
                            cmd.Parameters.AddWithValue("@Surname", txtbxCurrentSurname.Text);
                            cmd.Parameters.AddWithValue("@Email", txtbxCurrentMail.Text);
                            cmd.Parameters.AddWithValue("@Phone", txtbxCurrentPhone.Text);
                            cmd.Parameters.AddWithValue("@Adress", txtbxCurrentAdress.Text);
                            cmd.Parameters.AddWithValue("@UserID", UserSession.UserId);

                            cmd.ExecuteNonQuery();
                        }
                        bunifuSnackbar2.Show(this, "Bilgileriniz güncellendi", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadAccountInfo();
                        return;

                    }

                }

            }

        }

        private void txtbxCurrentPhone_TextChange(object sender, EventArgs e)
        {
            string phoneNumber = txtbxCurrentPhone.Text;

            // Sadece rakamları al
            string digits = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Formatı uygula
            if (digits.Length > 3 && digits.Length <= 6)
            {
                digits = digits.Insert(3, " ");
            }
            else if (digits.Length > 6)
            {
                digits = digits.Insert(3, " ").Insert(7, " ");
            }

            // TextBox'a formatlanmış metni yaz
            txtbxCurrentPhone.Text = digits;

            // Cursor'ı metnin sonuna taşı
            txtbxCurrentPhone.SelectionStart = txtbxCurrentPhone.Text.Length;
            txtbxCurrentPhone.SelectionLength = 0;
        }

        private void txtboxSearch_TextChange(object sender, EventArgs e)
        {
            string search = txtboxSearch.Text;
            if (currentPage == "MenuPage")
            {
                LoadProducts(1, search);
            }
            else if (currentPage == "BurgersPage")
            {
                LoadProducts(2, search);
            }
            else if (currentPage == "SnacksPage")
            {
                LoadProducts(3, search);
            }
            else if (currentPage == "DessertPage")
            {
                LoadProducts(4, search);
            }
            else if (currentPage == "BeveragesPage")
            {
                LoadProducts(5, search);
            }
        }


        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Uygulama tamamen sonlanır
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public CartItem(int productId, string productName, decimal price, int quantity, string imageUrl)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            ImageUrl = imageUrl;
        }
    }

}
