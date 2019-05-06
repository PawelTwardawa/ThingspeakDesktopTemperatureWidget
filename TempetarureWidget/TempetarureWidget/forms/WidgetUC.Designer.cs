namespace TempetarureWidget.forms
{
    partial class WidgetUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelUpdateDate = new System.Windows.Forms.Label();
            this.labelTemp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelName.Location = new System.Drawing.Point(0, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(241, 25);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Channel name Field name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseDown);
            this.labelName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseMove);
            this.labelName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseUp);
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
            this.labelUpdateDate.TabIndex = 7;
            this.labelUpdateDate.Text = "2019-02-27T10:20:57Z";
            this.labelUpdateDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUpdateDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseDown);
            this.labelUpdateDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseMove);
            this.labelUpdateDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseUp);
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.BackColor = System.Drawing.Color.Transparent;
            this.labelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTemp.Location = new System.Drawing.Point(0, 25);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(249, 63);
            this.labelTemp.TabIndex = 6;
            this.labelTemp.Text = "-00.00 °F";
            this.labelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseDown);
            this.labelTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseMove);
            this.labelTemp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseUp);
            // 
            // WidgetUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUpdateDate);
            this.Controls.Add(this.labelTemp);
            this.Name = "WidgetUC";
            this.Size = new System.Drawing.Size(249, 113);
            this.Load += new System.EventHandler(this.WidgetUC_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WidgetUC_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelUpdateDate;
        public System.Windows.Forms.Label labelTemp;
    }
}
