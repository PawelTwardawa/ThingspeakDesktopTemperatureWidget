
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
            this.labelTemp = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labelUpdateDate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::TempetarureWidget.Properties.Resources.settingIcon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(229, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.buttonOpenSettingsForm_Click);
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
            // WidgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(249, 113);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUpdateDate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelTemp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "WidgetForm";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label labelUpdateDate;
        public System.Windows.Forms.Label labelName;
    }
}

