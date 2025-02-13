namespace RestaurantApp
{
    partial class ProductCartControl
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCartControl));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.lblProductPrice = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnAddToCart = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblProductName = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AllowParentOverrides = false;
            this.lblProductPrice.AutoEllipsis = false;
            this.lblProductPrice.AutoSize = false;
            this.lblProductPrice.CursorType = null;
            this.lblProductPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductPrice.Location = new System.Drawing.Point(13, 177);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProductPrice.Size = new System.Drawing.Size(78, 21);
            this.lblProductPrice.TabIndex = 9;
            this.lblProductPrice.Text = "150,00 TL";
            this.lblProductPrice.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblProductPrice.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.AllowAnimations = true;
            this.btnAddToCart.AllowMouseEffects = true;
            this.btnAddToCart.AllowToggling = false;
            this.btnAddToCart.AnimationSpeed = 200;
            this.btnAddToCart.AutoGenerateColors = false;
            this.btnAddToCart.AutoRoundBorders = true;
            this.btnAddToCart.AutoSizeLeftIcon = true;
            this.btnAddToCart.AutoSizeRightIcon = true;
            this.btnAddToCart.BackColor = System.Drawing.Color.Transparent;
            this.btnAddToCart.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAddToCart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddToCart.BackgroundImage")));
            this.btnAddToCart.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddToCart.ButtonText = "Sepete Ekle";
            this.btnAddToCart.ButtonTextMarginLeft = 0;
            this.btnAddToCart.ColorContrastOnClick = 45;
            this.btnAddToCart.ColorContrastOnHover = 45;
            this.btnAddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnAddToCart.CustomizableEdges = borderEdges1;
            this.btnAddToCart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddToCart.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddToCart.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnAddToCart.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnAddToCart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddToCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnAddToCart.IconLeft = null;
            this.btnAddToCart.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddToCart.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddToCart.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAddToCart.IconMarginLeft = 11;
            this.btnAddToCart.IconPadding = 10;
            this.btnAddToCart.IconRight = null;
            this.btnAddToCart.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddToCart.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAddToCart.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAddToCart.IconSize = 25;
            this.btnAddToCart.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnAddToCart.IdleBorderRadius = 0;
            this.btnAddToCart.IdleBorderThickness = 0;
            this.btnAddToCart.IdleFillColor = System.Drawing.Color.Empty;
            this.btnAddToCart.IdleIconLeftImage = null;
            this.btnAddToCart.IdleIconRightImage = null;
            this.btnAddToCart.IndicateFocus = false;
            this.btnAddToCart.Location = new System.Drawing.Point(223, 168);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAddToCart.OnDisabledState.BorderRadius = 39;
            this.btnAddToCart.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddToCart.OnDisabledState.BorderThickness = 1;
            this.btnAddToCart.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddToCart.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddToCart.OnDisabledState.IconLeftImage = null;
            this.btnAddToCart.OnDisabledState.IconRightImage = null;
            this.btnAddToCart.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(29)))), ((int)(((byte)(77)))));
            this.btnAddToCart.onHoverState.BorderRadius = 39;
            this.btnAddToCart.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddToCart.onHoverState.BorderThickness = 1;
            this.btnAddToCart.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(29)))), ((int)(((byte)(77)))));
            this.btnAddToCart.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.onHoverState.IconLeftImage = null;
            this.btnAddToCart.onHoverState.IconRightImage = null;
            this.btnAddToCart.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnAddToCart.OnIdleState.BorderRadius = 39;
            this.btnAddToCart.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddToCart.OnIdleState.BorderThickness = 1;
            this.btnAddToCart.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnAddToCart.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnAddToCart.OnIdleState.IconLeftImage = null;
            this.btnAddToCart.OnIdleState.IconRightImage = null;
            this.btnAddToCart.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(21)))), ((int)(((byte)(62)))));
            this.btnAddToCart.OnPressedState.BorderRadius = 39;
            this.btnAddToCart.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddToCart.OnPressedState.BorderThickness = 1;
            this.btnAddToCart.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(21)))), ((int)(((byte)(62)))));
            this.btnAddToCart.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.OnPressedState.IconLeftImage = null;
            this.btnAddToCart.OnPressedState.IconRightImage = null;
            this.btnAddToCart.Size = new System.Drawing.Size(115, 39);
            this.btnAddToCart.TabIndex = 8;
            this.btnAddToCart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddToCart.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAddToCart.TextMarginLeft = 0;
            this.btnAddToCart.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAddToCart.UseDefaultRadiusAndThickness = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click_1);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuPanel1.BorderRadius = 35;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.picProduct);
            this.bunifuPanel1.Controls.Add(this.lblProductName);
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(354, 221);
            this.bunifuPanel1.TabIndex = 10;
            // 
            // picProduct
            // 
            this.picProduct.Image = global::RestaurantApp.Properties.Resources.whopper_90d608faab;
            this.picProduct.Location = new System.Drawing.Point(42, 43);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(250, 118);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AllowParentOverrides = false;
            this.lblProductName.AutoEllipsis = false;
            this.lblProductName.AutoSize = false;
            this.lblProductName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProductName.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName.Location = new System.Drawing.Point(42, 13);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProductName.Size = new System.Drawing.Size(250, 24);
            this.lblProductName.TabIndex = 8;
            this.lblProductName.Text = "FastBurger";
            this.lblProductName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProductName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ProductCartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "ProductCartControl";
            this.Size = new System.Drawing.Size(354, 221);
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picProduct;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAddToCart;
        private Bunifu.UI.WinForms.BunifuLabel lblProductName;
        private Bunifu.UI.WinForms.BunifuLabel lblProductPrice;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
    }
}
