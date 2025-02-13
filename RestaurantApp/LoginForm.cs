using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Bunifu.UI.WinForms;
//using EmployeeFormNamespace;
//using ManagerFormNamespace;
using System.Web.Configuration;

namespace RestaurantApp
{
    public partial class LoginForm : Form
    {
        private static LoginForm _instance;
        public static LoginForm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginForm();
                }
                return _instance;
            }
        }

        private Timer progressTimer;
        private int targetValue;
        private bool mailIsValid = false;
        private bool passwordIsValid = false;
        Bunifu.UI.WinForms.BunifuSnackbar bunifuSnackbar1;

        public LoginForm()
        {
            InitializeComponent();

            progressTimer = new Timer();
            progressTimer.Interval = 10; // Her 20 ms'de bir çalışır
            progressTimer.Tick += ProgressTimer_Tick;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += Form1_FormClosed;

            // BunifuSnackbar bileşenini dinamik olarak oluşturun
            bunifuSnackbar1 = new Bunifu.UI.WinForms.BunifuSnackbar();

            // Ayarları özelleştirebilirsiniz (isteğe bağlı)
            bunifuSnackbar1.ShowShadows = true;  // Mesajın gölgesi olsun
            bunifuSnackbar1.ShowCloseIcon = true; // Kapatma butonu olsun
            bunifuSnackbar1.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner; // Mesajın pozisyonu
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelRegister.Visible = false;
        }

        private void btnRegisterForm_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = false;
            panelRegister.Visible = true;
            panelRegister.BringToFront();
            panelRegister.Refresh();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            ResetRegisterForm();
            panelRegister.Visible = false;
            panelLogin.Visible = true;
            panelLogin.BringToFront();
            panelLogin.Refresh();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtbxRegisterName.Text == "" || txtbxRegisterSurname.Text == "" || txtbxRegisterPassword.Text == "" ||
                txtbxRegisterMail.Text == "" || txtbxRegisterRePassword.Text == "" || txtbxRegisterPhone.Text == "" ||
                txtbxRegisterCity.Text == "" || txtbxRegisterDistrict.Text == "" || txtbxRegisterAdress.Text == "")
            {
                bunifuSnackbar1.Show(this, "Tüm alanları eksiksiz doldurunuz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                if (!mailIsValid)
                {
                    bunifuSnackbar1.Show(this, "Geçerli bir mail adresi giriniz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else if (!passwordIsValid)
                {
                    bunifuSnackbar1.Show(this, "Şifre en az 8 karakter olmalı ve en az 1 büyük harf, 1 küçük harf ve 1 rakam içermelidir", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else if (txtbxRegisterPassword.Text != txtbxRegisterRePassword.Text)
                {
                    bunifuSnackbar1.Show(this, "Şifreler uyuşmuyor", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else if (txtbxRegisterPhone.Text.Trim().Replace(" ", "").Length != 10)
                {
                    bunifuSnackbar1.Show(this, "Geçerli bir telefon numarası giriniz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else
                {
                    // Kullanıcı bilgilerini al
                    string Name = txtbxRegisterName.Text.Trim();
                    string Surname = txtbxRegisterSurname.Text.Trim();
                    string Mail = txtbxRegisterMail.Text.Trim();
                    string Password = txtbxRegisterPassword.Text.Trim();
                    string Phone = txtbxRegisterPhone.Text.Trim().Replace(" ", "");
                    string City = txtbxRegisterCity.Text.Trim();
                    string District = txtbxRegisterDistrict.Text.Trim();
                    string Address = City + " " + District + " " + txtbxRegisterAdress.Text.Trim();
                    string HashedPassword = HashPassword(Password);
                    DateTime RegisterDate = DateTime.Now;

                    string connectionString = @"Data Source=DESKTOP-AA1A8AU\SQLEXPRESS;Initial Catalog=fastburger;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                    string query = "INSERT INTO kullanicilar (ad, soyad, email, sifre_hash, telefon, adres, kayit_tarihi) VALUES (@Name, @Surname, @Mail, @HashedPassword, @Phone, @Adress, @RegisterDate)";

                    SqlConnection connection = null;
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Surname", Surname);
                        command.Parameters.AddWithValue("@Mail", Mail);
                        command.Parameters.AddWithValue("@HashedPassword", HashedPassword);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Adress", Address);
                        command.Parameters.AddWithValue("@RegisterDate", RegisterDate);

                        command.ExecuteNonQuery();
                        bunifuSnackbar1.Show(this, "Kayıt başarılı", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    }
                    catch (Exception ex)
                    {
                        bunifuSnackbar1.Show(this, "Kayıt başarısız: " + ex.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    }
                    finally
                    {
                        btnBackToLogin.PerformClick();
                        connection?.Close();
                    }
                }
            }
        }

        private void chckbxRegisterAgreement_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chckbxRegisterAgreement.Checked == true)
            {
                btnRegister.Enabled = true;
            }
            else
            {
                btnRegister.Enabled = false;
            }
        }

        //Regex ile mail kontrolü yapılabilir



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

        private void txtbxRegisterPassword_TextChange(object sender, EventArgs e)
        {
            string password = txtbxRegisterPassword.Text;

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

            // Timer'ı başlat
            progressTimer.Start();
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

        private void txtbxRegisterMail_TextChange(object sender, EventArgs e)
        {
            if (txtbxRegisterMail.Text.Contains("@") && txtbxRegisterMail.Text.Contains(".com"))
            {
                mailIsValid = true;
            }
            else
            {
                mailIsValid = false;
            }
        }

        private void ResetRegisterForm()
        {
            txtbxRegisterName.Text = "";
            txtbxRegisterSurname.Text = "";
            txtbxRegisterMail.Text = "";
            txtbxRegisterPassword.Text = "";
            txtbxRegisterRePassword.Text = "";
            txtbxRegisterPhone.Text = "";
            txtbxRegisterCity.Text = "";
            txtbxRegisterDistrict.Text = "";
            txtbxRegisterAdress.Text = "";
            chckbxRegisterAgreement.Checked = false;
        }

        private void resetLogin()
        {
            txtbxLoginMail.Text = "";
            txtbxLoginPassword.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtbxLoginMail.Text == "" || txtbxLoginPassword.Text == "")
            {
                bunifuSnackbar1.Show(this, "Tüm alanları eksiksiz doldurunuz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
            }
            else
            {
                if (!txtbxLoginMail.Text.Contains("@") || !txtbxLoginMail.Text.Contains(".com"))
                {
                    bunifuSnackbar1.Show(this, "Geçerli bir mail adresi giriniz", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                }
                else
                {
                    string Mail = txtbxLoginMail.Text.Trim();
                    string Password = txtbxLoginPassword.Text.Trim();
                    string HashedPassword = HashPassword(Password);
                    DateTime dateTime = DateTime.Now;
                    int user_id = -1;

                    string connectionString = @"Data Source=.......\SQLEXPRESS;Initial Catalog=fastburger;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                    string query = "SELECT * FROM kullanicilar WHERE email = @Mail AND sifre_hash = @HashedPassword";
                    string query2 = "UPDATE kullanicilar SET son_oturum_tarihi = @dateTime WHERE kullanici_id = @user_id";
                    string query3 = "SELECT * FROM kullanicilar WHERE kullanici_id = @user_id";
                    string query4 = "SELECT * FROM yoneticiler WHERE calisan_id = @user_id";  // Yönetici sorgusu
                    string query5 = "SELECT * FROM calisanlar WHERE kullanici_id = @user_id";  // Çalışan sorgusu

                    SqlConnection connection = null;
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Mail", Mail);
                        command.Parameters.AddWithValue("@HashedPassword", HashedPassword);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            user_id = reader.GetInt32(0);
                            reader.Close();

                            SqlCommand command2 = new SqlCommand(query2, connection);
                            command2.Parameters.AddWithValue("@dateTime", dateTime);
                            command2.Parameters.AddWithValue("@user_id", user_id);
                            command2.ExecuteNonQuery();

                            SqlCommand command3 = new SqlCommand(query3, connection);
                            command3.Parameters.AddWithValue("@user_id", user_id);
                            SqlDataReader reader2 = command3.ExecuteReader();
                            if (reader2.Read())
                            {
                                // Kullanıcı bilgilerini UserSession'a aktar
                                UserSession.UserId = reader2.GetInt32(0);
                                UserSession.UserName = reader2.GetString(3) + " " + reader2.GetString(4);
                                UserSession.UserEmail = reader2.GetString(1);
                                reader2.Close();

                                // Yönetici sorgusu
                                SqlCommand command4 = new SqlCommand(query4, connection);
                                command4.Parameters.AddWithValue("@user_id", user_id);
                                SqlDataReader reader3 = command4.ExecuteReader();
                                if (reader3.Read())
                                {
                                    // Yönetici sayfasını aç
                                    /*
                                    ManagerForm managerForm = new ManagerForm();
                                    managerForm.Show();
                                    this.Hide();
                                    bunifuSnackbar1.Show(this, $"Hoşgeldiniz Yönetici {UserSession.UserName}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                                    reader3.Close();
                                    return;
                                    */
                                }
                                reader3.Close();

                                // Çalışan sorgusu
                                SqlCommand command5 = new SqlCommand(query5, connection);
                                command5.Parameters.AddWithValue("@user_id", user_id);
                                SqlDataReader reader4 = command5.ExecuteReader();
                                if (reader4.Read())
                                {

                                    // Çalışan sayfasını aç
                                    /*
                                    EmployeeForm employeeForm = new EmployeeForm();
                                    employeeForm.Show();
                                    this.Hide();
                                    bunifuSnackbar1.Show(this, $"Hoşgeldiniz Çalışan {UserSession.UserName}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                                    reader4.Close();
                                    return;
                                    */
                                }
                                reader4.Close();

                                // Eğer ne yönetici ne de çalışan ise müşteri sayfası
                                CustomerForm customerForm = new CustomerForm();
                                customerForm.Show();
                                this.Hide();
                                bunifuSnackbar1.Show(this, $"Hoşgeldiniz {UserSession.UserName}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                            }
                            else
                            {
                                bunifuSnackbar1.Show(this, "Kullanıcı bilgileri alınamadı", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                            }
                        }
                        else
                        {
                            txtbxLoginPassword.Text = "";
                            bunifuSnackbar1.Show(this, "Bilgileriniz uyuşmuyor!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        bunifuSnackbar1.Show(this, "Giriş başarısız: " + ex.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    }
                    finally
                    {
                        if (user_id != -1)
                        {
                            resetLogin();
                        }
                        connection?.Close();
                    }
                }
            }
        }


        private void txtbxRegisterPhone_TextChange(object sender, EventArgs e)
        {
            string phoneNumber = txtbxRegisterPhone.Text;

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
            txtbxRegisterPhone.Text = digits;

            // Cursor'ı metnin sonuna taşı
            txtbxRegisterPhone.SelectionStart = txtbxRegisterPhone.Text.Length;
            txtbxRegisterPhone.SelectionLength = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
