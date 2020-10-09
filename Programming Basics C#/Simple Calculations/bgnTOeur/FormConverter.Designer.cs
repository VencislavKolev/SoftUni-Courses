namespace bgnTOeur
{
    partial class FormConverter
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
            this.labelChange = new System.Windows.Forms.Label();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.labelbgn2eur = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChange
            // 
            this.labelChange.AutoSize = true;
            this.labelChange.Location = new System.Drawing.Point(40, 33);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(50, 17);
            this.labelChange.TabIndex = 0;
            this.labelChange.Text = "Смени";
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.DecimalPlaces = 2;
            this.numericUpDownAmount.Location = new System.Drawing.Point(136, 29);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAmount.TabIndex = 1;
            this.numericUpDownAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAmount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelbgn2eur
            // 
            this.labelbgn2eur.AutoSize = true;
            this.labelbgn2eur.Location = new System.Drawing.Point(282, 33);
            this.labelbgn2eur.Name = "labelbgn2eur";
            this.labelbgn2eur.Size = new System.Drawing.Size(85, 17);
            this.labelbgn2eur.TabIndex = 2;
            this.labelbgn2eur.Text = "лева в евро";
            // 
            // labelResult
            // 
            this.labelResult.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.labelResult.Location = new System.Drawing.Point(40, 69);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(288, 44);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "100 лева=2000 евро";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResult.Click += new System.EventHandler(this.labelResult_Click);
            // 
            // FormConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 237);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelbgn2eur);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.labelChange);
            this.Name = "FormConverter";
            this.Text = "Левосменячка";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Label labelbgn2eur;
        private System.Windows.Forms.Label labelResult;
    }
}

