
namespace TempetarureWidget
{
    partial class WidgetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WidgetForm));
            this.labelTemp = new System.Windows.Forms.Label();
            this.labelUpdateDate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxNoConn = new System.Windows.Forms.PictureBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConn)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.BackColor = System.Drawing.Color.Transparent;
            this.labelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTemp.Location = new System.Drawing.Point(0, 25);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(249, 63);
            this.labelTemp.TabIndex = 2;
            this.labelTemp.Text = "-00.00 °F";
            this.labelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.labelTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.labelTemp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetForm_MouseUp);
            // 
            // labelUpdateDate
            // 
            this.labelUpdateDate.AutoSize = true;
            this.labelUpdateDate.BackColor = System.Drawing.Color.Transparent;
            this.labelUpdateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUpdateDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUpdateDate.Location = new System.Drawing.Point(18, 88);
            this.labelUpdateDate.Name = "labelUpdateDate";
            this.labelUpdateDate.Size = new System.Drawing.Size(217, 25);
            this.labelUpdateDate.TabIndex = 4;
            this.labelUpdateDate.Text = "2019-02-27T10:20:57Z";
            this.labelUpdateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUpdateDate.Visible = false;
            this.labelUpdateDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.labelUpdateDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.labelUpdateDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetForm_MouseUp);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelName.Location = new System.Drawing.Point(39, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(156, 25);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Temperature out";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelName.Visible = false;
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.labelName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.labelName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetForm_MouseUp);
            // 
            // pictureBoxNoConn
            // 
            this.pictureBoxNoConn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxNoConn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxNoConn.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxNoConn.Image = global::TempetarureWidget.Properties.Resources.noConn2;
            this.pictureBoxNoConn.Location = new System.Drawing.Point(229, 20);
            this.pictureBoxNoConn.Name = "pictureBoxNoConn";
            this.pictureBoxNoConn.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxNoConn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNoConn.TabIndex = 6;
            this.pictureBoxNoConn.TabStop = false;
            this.pictureBoxNoConn.Visible = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.BackgroundImage = global::TempetarureWidget.Properties.Resources.settingIcon;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Location = new System.Drawing.Point(229, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(20, 20);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.TabStop = false;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonOpenSettingsForm_Click);
            // 
            // WidgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(249, 113);
            this.Controls.Add(this.pictureBoxNoConn);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUpdateDate);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.labelTemp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WidgetForm";
            this.ShowInTaskbar = false;
            this.Text = "Widget";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Button buttonSettings;
        public System.Windows.Forms.Label labelUpdateDate;
        public System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBoxNoConn;
    }
}

