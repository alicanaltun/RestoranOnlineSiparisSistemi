namespace RestaurantApp
{
    partial class CartItemControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItemControl));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.lblProductName = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblProductPrice = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblQuantity = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnIncrease = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnDecrease = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AllowParentOverrides = false;
            this.lblProductName.AutoEllipsis = false;
            this.lblProductName.AutoSize = false;
            this.lblProductName.CursorType = null;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductName.Location = new System.Drawing.Point(74, 21);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProductName.Size = new System.Drawing.Size(149, 18);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Fast Burger";
            this.lblProductName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblProductName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuPanel1.BorderRadius = 25;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.picProduct);
            this.bunifuPanel1.Location = new System.Drawing.Point(12, 10);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(56, 56);
            this.bunifuPanel1.TabIndex = 2;
            // 
            // picProduct
            // 
            this.picProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProduct.Image = global::RestaurantApp.Properties.Resources.whopper_90d608faab;
            this.picProduct.Location = new System.Drawing.Point(0, 0);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(56, 56);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.AllowParentOverrides = false;
            this.lblProductPrice.AutoEllipsis = false;
            this.lblProductPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProductPrice.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblProductPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProductPrice.Location = new System.Drawing.Point(74, 41);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProductPrice.Size = new System.Drawing.Size(48, 15);
            this.lblProductPrice.TabIndex = 3;
            this.lblProductPrice.Text = "150,00 TL";
            this.lblProductPrice.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblProductPrice.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AllowParentOverrides = false;
            this.lblQuantity.AutoEllipsis = false;
            this.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblQuantity.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblQuantity.Location = new System.Drawing.Point(295, 28);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQuantity.Size = new System.Drawing.Size(9, 21);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "0";
            this.lblQuantity.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lblQuantity.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnIncrease
            // 
            this.btnIncrease.AllowAnimations = true;
            this.btnIncrease.AllowMouseEffects = true;
            this.btnIncrease.AllowToggling = false;
            this.btnIncrease.AnimationSpeed = 200;
            this.btnIncrease.AutoGenerateColors = false;
            this.btnIncrease.AutoRoundBorders = false;
            this.btnIncrease.AutoSizeLeftIcon = true;
            this.btnIncrease.AutoSizeRightIcon = true;
            this.btnIncrease.BackColor = System.Drawing.Color.Transparent;
            this.btnIncrease.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnIncrease.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIncrease.BackgroundImage")));
            this.btnIncrease.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnIncrease.ButtonText = "+";
            this.btnIncrease.ButtonTextMarginLeft = 0;
            this.btnIncrease.ColorContrastOnClick = 45;
            this.btnIncrease.ColorContrastOnHover = 45;
            this.btnIncrease.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnIncrease.CustomizableEdges = borderEdges1;
            this.btnIncrease.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnIncrease.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnIncrease.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnIncrease.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnIncrease.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnIncrease.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIncrease.ForeColor = System.Drawing.Color.White;
            this.btnIncrease.IconLeft = null;
            this.btnIncrease.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncrease.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnIncrease.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnIncrease.IconMarginLeft = 11;
            this.btnIncrease.IconPadding = 10;
            this.btnIncrease.IconRight = null;
            this.btnIncrease.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncrease.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnIncrease.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnIncrease.IconSize = 25;
            this.btnIncrease.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnIncrease.IdleBorderRadius = 0;
            this.btnIncrease.IdleBorderThickness = 0;
            this.btnIncrease.IdleFillColor = System.Drawing.Color.Empty;
            this.btnIncrease.IdleIconLeftImage = null;
            this.btnIncrease.IdleIconRightImage = null;
            this.btnIncrease.IndicateFocus = false;
            this.btnIncrease.Location = new System.Drawing.Point(310, 23);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnIncrease.OnDisabledState.BorderRadius = 10;
            this.btnIncrease.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnIncrease.OnDisabledState.BorderThickness = 1;
            this.btnIncrease.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnIncrease.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnIncrease.OnDisabledState.IconLeftImage = null;
            this.btnIncrease.OnDisabledState.IconRightImage = null;
            this.btnIncrease.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(21)))), ((int)(((byte)(62)))));
            this.btnIncrease.onHoverState.BorderRadius = 10;
            this.btnIncrease.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnIncrease.onHoverState.BorderThickness = 1;
            this.btnIncrease.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(21)))), ((int)(((byte)(62)))));
            this.btnIncrease.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnIncrease.onHoverState.IconLeftImage = null;
            this.btnIncrease.onHoverState.IconRightImage = null;
            this.btnIncrease.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(29)))), ((int)(((byte)(77)))));
            this.btnIncrease.OnIdleState.BorderRadius = 10;
            this.btnIncrease.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnIncrease.OnIdleState.BorderThickness = 1;
            this.btnIncrease.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(29)))), ((int)(((byte)(77)))));
            this.btnIncrease.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnIncrease.OnIdleState.IconLeftImage = null;
            this.btnIncrease.OnIdleState.IconRightImage = null;
            this.btnIncrease.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(29)))), ((int)(((byte)(77)))));
            this.btnIncrease.OnPressedState.BorderRadius = 10;
            this.btnIncrease.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnIncrease.OnPressedState.BorderThickness = 1;
            this.btnIncrease.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(29)))), ((int)(((byte)(77)))));
            this.btnIncrease.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnIncrease.OnPressedState.IconLeftImage = null;
            this.btnIncrease.OnPressedState.IconRightImage = null;
            this.btnIncrease.Size = new System.Drawing.Size(30, 30);
            this.btnIncrease.TabIndex = 6;
            this.btnIncrease.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIncrease.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnIncrease.TextMarginLeft = 0;
            this.btnIncrease.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnIncrease.UseDefaultRadiusAndThickness = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click_1);
            // 
            // btnDecrease
            // 
            this.btnDecrease.AllowAnimations = true;
            this.btnDecrease.AllowMouseEffects = true;
            this.btnDecrease.AllowToggling = false;
            this.btnDecrease.AnimationSpeed = 200;
            this.btnDecrease.AutoGenerateColors = false;
            this.btnDecrease.AutoRoundBorders = false;
            this.btnDecrease.AutoSizeLeftIcon = true;
            this.btnDecrease.AutoSizeRightIcon = true;
            this.btnDecrease.BackColor = System.Drawing.Color.Transparent;
            this.btnDecrease.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnDecrease.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDecrease.BackgroundImage")));
            this.btnDecrease.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDecrease.ButtonText = "-";
            this.btnDecrease.ButtonTextMarginLeft = 0;
            this.btnDecrease.ColorContrastOnClick = 45;
            this.btnDecrease.ColorContrastOnHover = 45;
            this.btnDecrease.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnDecrease.CustomizableEdges = borderEdges2;
            this.btnDecrease.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDecrease.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDecrease.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnDecrease.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnDecrease.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnDecrease.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDecrease.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDecrease.IconLeft = null;
            this.btnDecrease.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDecrease.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnDecrease.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnDecrease.IconMarginLeft = 11;
            this.btnDecrease.IconPadding = 10;
            this.btnDecrease.IconRight = null;
            this.btnDecrease.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDecrease.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnDecrease.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnDecrease.IconSize = 25;
            this.btnDecrease.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnDecrease.IdleBorderRadius = 0;
            this.btnDecrease.IdleBorderThickness = 0;
            this.btnDecrease.IdleFillColor = System.Drawing.Color.Empty;
            this.btnDecrease.IdleIconLeftImage = null;
            this.btnDecrease.IdleIconRightImage = null;
            this.btnDecrease.IndicateFocus = false;
            this.btnDecrease.Location = new System.Drawing.Point(259, 23);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnDecrease.OnDisabledState.BorderRadius = 10;
            this.btnDecrease.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDecrease.OnDisabledState.BorderThickness = 1;
            this.btnDecrease.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDecrease.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnDecrease.OnDisabledState.IconLeftImage = null;
            this.btnDecrease.OnDisabledState.IconRightImage = null;
            this.btnDecrease.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnDecrease.onHoverState.BorderRadius = 10;
            this.btnDecrease.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDecrease.onHoverState.BorderThickness = 1;
            this.btnDecrease.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnDecrease.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnDecrease.onHoverState.IconLeftImage = null;
            this.btnDecrease.onHoverState.IconRightImage = null;
            this.btnDecrease.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDecrease.OnIdleState.BorderRadius = 10;
            this.btnDecrease.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDecrease.OnIdleState.BorderThickness = 1;
            this.btnDecrease.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDecrease.OnIdleState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDecrease.OnIdleState.IconLeftImage = null;
            this.btnDecrease.OnIdleState.IconRightImage = null;
            this.btnDecrease.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDecrease.OnPressedState.BorderRadius = 10;
            this.btnDecrease.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnDecrease.OnPressedState.BorderThickness = 1;
            this.btnDecrease.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDecrease.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnDecrease.OnPressedState.IconLeftImage = null;
            this.btnDecrease.OnPressedState.IconRightImage = null;
            this.btnDecrease.Size = new System.Drawing.Size(30, 30);
            this.btnDecrease.TabIndex = 5;
            this.btnDecrease.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDecrease.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDecrease.TextMarginLeft = 0;
            this.btnDecrease.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnDecrease.UseDefaultRadiusAndThickness = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click_1);
            // 
            // CartItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDecrease);
            this.Controls.Add(this.btnIncrease);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProductPrice);
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.lblProductName);
            this.Name = "CartItemControl";
            this.Size = new System.Drawing.Size(360, 75);
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLabel lblProductName;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuLabel lblProductPrice;
        private Bunifu.UI.WinForms.BunifuLabel lblQuantity;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnIncrease;
        private System.Windows.Forms.PictureBox picProduct;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnDecrease;
    }
}
