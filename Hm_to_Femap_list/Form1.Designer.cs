namespace Hm_to_Femap_list
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_hm = new System.Windows.Forms.TextBox();
            this.button_convert = new System.Windows.Forms.Button();
            this.textBox_femap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "HM Text";
            // 
            // textBox_hm
            // 
            this.textBox_hm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBox_hm.Location = new System.Drawing.Point(15, 45);
            this.textBox_hm.Multiline = true;
            this.textBox_hm.Name = "textBox_hm";
            this.textBox_hm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_hm.Size = new System.Drawing.Size(374, 475);
            this.textBox_hm.TabIndex = 1;
            // 
            // button_convert
            // 
            this.button_convert.Location = new System.Drawing.Point(354, 526);
            this.button_convert.Name = "button_convert";
            this.button_convert.Size = new System.Drawing.Size(75, 23);
            this.button_convert.TabIndex = 2;
            this.button_convert.Text = "Convert";
            this.button_convert.UseVisualStyleBackColor = true;
            this.button_convert.Click += new System.EventHandler(this.button_convert_Click);
            // 
            // textBox_femap
            // 
            this.textBox_femap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.textBox_femap.Location = new System.Drawing.Point(395, 45);
            this.textBox_femap.Multiline = true;
            this.textBox_femap.Name = "textBox_femap";
            this.textBox_femap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_femap.Size = new System.Drawing.Size(377, 475);
            this.textBox_femap.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Femap Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_femap);
            this.Controls.Add(this.button_convert);
            this.Controls.Add(this.textBox_hm);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "HM Text To Femap Text";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_hm;
        private System.Windows.Forms.Button button_convert;
        private System.Windows.Forms.TextBox textBox_femap;
        private System.Windows.Forms.Label label2;
    }
}

