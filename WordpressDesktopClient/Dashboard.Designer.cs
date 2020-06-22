namespace WordpressDesktopClient
{
    partial class Dashboard
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.PanelTop = new System.Windows.Forms.Panel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LogoImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.RichTextBox();
            this.treeViewCategories = new System.Windows.Forms.TreeView();
            this.numberLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.actionButton = new System.Windows.Forms.Button();
            this.entryListControl = new WordpressDesktopClient.EntryListControl();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTop
            // 
            this.PanelTop.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PanelTop.Controls.Add(this.MinimizeButton);
            this.PanelTop.Controls.Add(this.ExitButton);
            this.PanelTop.Controls.Add(this.LogoImage);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Margin = new System.Windows.Forms.Padding(2);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(800, 80);
            this.PanelTop.TabIndex = 0;
            this.PanelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveWindow);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("FrizQuadrata BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeButton.ForeColor = System.Drawing.Color.Black;
            this.MinimizeButton.Location = new System.Drawing.Point(741, 9);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(20, 20);
            this.MinimizeButton.TabIndex = 0;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MinimizeButton.UseCompatibleTextRendering = true;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            this.MinimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Firebrick;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Consolas", 14F);
            this.ExitButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ExitButton.Location = new System.Drawing.Point(771, 9);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(20, 20);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "x";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.ExitButton.UseCompatibleTextRendering = true;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // LogoImage
            // 
            this.LogoImage.BackColor = System.Drawing.Color.Transparent;
            this.LogoImage.Image = ((System.Drawing.Image)(resources.GetObject("LogoImage.Image")));
            this.LogoImage.Location = new System.Drawing.Point(7, 11);
            this.LogoImage.Margin = new System.Windows.Forms.Padding(0);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(266, 58);
            this.LogoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoImage.TabIndex = 1;
            this.LogoImage.TabStop = false;
            this.LogoImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveWindow);
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(185, 84);
            this.pictureBoxThumbnail.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(255, 164);
            this.pictureBoxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxThumbnail.TabIndex = 2;
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTitle.Location = new System.Drawing.Point(185, 267);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(362, 26);
            this.textBoxTitle.TabIndex = 3;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescription.Location = new System.Drawing.Point(185, 308);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(362, 281);
            this.textBoxDescription.TabIndex = 4;
            this.textBoxDescription.Text = "";
            this.textBoxDescription.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // treeViewCategories
            // 
            this.treeViewCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewCategories.CheckBoxes = true;
            this.treeViewCategories.Location = new System.Drawing.Point(560, 267);
            this.treeViewCategories.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewCategories.Name = "treeViewCategories";
            this.treeViewCategories.Size = new System.Drawing.Size(229, 322);
            this.treeViewCategories.TabIndex = 5;
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.BackColor = System.Drawing.Color.White;
            this.numberLabel.Font = new System.Drawing.Font("Times New Roman", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numberLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numberLabel.Location = new System.Drawing.Point(185, 248);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(0, 17);
            this.numberLabel.TabIndex = 6;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Times New Roman", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel.Location = new System.Drawing.Point(312, 146);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(273, 21);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Aby rozpocząć wybierz film z listy.";
            // 
            // actionButton
            // 
            this.actionButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.actionButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actionButton.Location = new System.Drawing.Point(601, 129);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(144, 80);
            this.actionButton.TabIndex = 8;
            this.actionButton.Text = "Opublikuj";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Visible = false;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // entryListControl
            // 
            this.entryListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.entryListControl.Location = new System.Drawing.Point(0, 80);
            this.entryListControl.Margin = new System.Windows.Forms.Padding(0);
            this.entryListControl.Name = "entryListControl";
            this.entryListControl.Size = new System.Drawing.Size(180, 520);
            this.entryListControl.TabIndex = 8;
            this.entryListControl.OnPanelSelected += new System.EventHandler(this.handlePanelSelection);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.entryListControl);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.pictureBoxThumbnail);
            this.Controls.Add(this.treeViewCategories);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.PanelTop);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordpressClient";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.PictureBox LogoImage;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.RichTextBox textBoxDescription;
        private System.Windows.Forms.TreeView treeViewCategories;
        private EntryListControl entryListControl;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button actionButton;
    }
}

