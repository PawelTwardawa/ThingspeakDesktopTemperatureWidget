
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
            this.pictureBoxNoConn = new System.Windows.Forms.PictureBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConn)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxNoConn
            // 
            this.pictureBoxNoConn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxNoConn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxNoConn.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxNoConn.Image = global::TempetarureWidget.Properties.Resources.noConn2;
            this.pictureBoxNoConn.Location = new System.Drawing.Point(229, 21);
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
            this.Controls.Add(this.buttonSettings);
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

        }

        #endregion
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.PictureBox pictureBoxNoConn;
    }
}

