namespace WordpressDesktopClient
{
    partial class EntryPresenter
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

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.ThumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.Panel();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.ThumbnailPictureBox);
            this.groupBox.Controls.Add(this.TitleLabel);
            this.groupBox.Controls.Add(this.StatusBar);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox.Location = new System.Drawing.Point(6, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(152, 113);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            // 
            // ThumbnailPictureBox
            // 
            this.ThumbnailPictureBox.Location = new System.Drawing.Point(12, 16);
            this.ThumbnailPictureBox.Name = "ThumbnailPictureBox";
            this.ThumbnailPictureBox.Size = new System.Drawing.Size(129, 72);
            this.ThumbnailPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ThumbnailPictureBox.TabIndex = 3;
            this.ThumbnailPictureBox.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleLabel.Location = new System.Drawing.Point(6, 91);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(142, 18);
            this.TitleLabel.TabIndex = 2;
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.Color.Lime;
            this.StatusBar.Location = new System.Drawing.Point(9, 16);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(12, 72);
            this.StatusBar.TabIndex = 1;
            // 
            // EntryPresenter
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EntryPresenter";
            this.Size = new System.Drawing.Size(158, 119);
            this.Load += new System.EventHandler(this.EntryPresenter_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EntryPresenter_Paint);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel StatusBar;
        private System.Windows.Forms.PictureBox ThumbnailPictureBox;
        }
}
