﻿
namespace TempetarureWidget
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTemp.Location = new System.Drawing.Point(152, 40);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(109, 46);
            this.labelTemp.TabIndex = 2;
            this.labelTemp.Text = "none";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelUpdateDate
            // 
            this.labelUpdateDate.AutoSize = true;
            this.labelUpdateDate.Location = new System.Drawing.Point(173, 209);
            this.labelUpdateDate.Name = "labelUpdateDate";
            this.labelUpdateDate.Size = new System.Drawing.Size(31, 13);
            this.labelUpdateDate.TabIndex = 4;
            this.labelUpdateDate.Text = "none";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(426, 307);
            this.Controls.Add(this.labelUpdateDate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelTemp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label labelUpdateDate;
    }
}

