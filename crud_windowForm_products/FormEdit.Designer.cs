namespace ProductManagment
{
    partial class FormEdit
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
            this.Save_edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.createTimeV = new System.Windows.Forms.DateTimePicker();
            this.idV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.discV = new System.Windows.Forms.TextBox();
            this.quantityV = new System.Windows.Forms.TextBox();
            this.priceV = new System.Windows.Forms.TextBox();
            this.unitV = new System.Windows.Forms.TextBox();
            this.nameV = new System.Windows.Forms.TextBox();
            this.categV = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Save_edit
            // 
            this.Save_edit.Location = new System.Drawing.Point(250, 582);
            this.Save_edit.Name = "Save_edit";
            this.Save_edit.Size = new System.Drawing.Size(150, 46);
            this.Save_edit.TabIndex = 0;
            this.Save_edit.Text = "Save";
            this.Save_edit.UseVisualStyleBackColor = true;
            this.Save_edit.Click += new System.EventHandler(this.Save_edit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "ProductId";
            // 
            // createTimeV
            // 
            this.createTimeV.CustomFormat = "yyyy-MM-dd";
            this.createTimeV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.createTimeV.Location = new System.Drawing.Point(250, 492);
            this.createTimeV.Name = "createTimeV";
            this.createTimeV.Size = new System.Drawing.Size(400, 39);
            this.createTimeV.TabIndex = 2;
            // 
            // idV
            // 
            this.idV.Location = new System.Drawing.Point(250, 18);
            this.idV.Name = "idV";
            this.idV.ReadOnly = true;
            this.idV.Size = new System.Drawing.Size(200, 39);
            this.idV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "ProductName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 32);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 355);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 32);
            this.label6.TabIndex = 8;
            this.label6.Text = "Discontinued";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 32);
            this.label7.TabIndex = 9;
            this.label7.Text = "Categoty";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 492);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 32);
            this.label8.TabIndex = 10;
            this.label8.Text = "CreateDate";
            // 
            // discV
            // 
            this.discV.Location = new System.Drawing.Point(250, 352);
            this.discV.Name = "discV";
            this.discV.Size = new System.Drawing.Size(200, 39);
            this.discV.TabIndex = 12;
            // 
            // quantityV
            // 
            this.quantityV.Location = new System.Drawing.Point(250, 288);
            this.quantityV.Name = "quantityV";
            this.quantityV.Size = new System.Drawing.Size(200, 39);
            this.quantityV.TabIndex = 13;
            // 
            // priceV
            // 
            this.priceV.Location = new System.Drawing.Point(250, 218);
            this.priceV.Name = "priceV";
            this.priceV.Size = new System.Drawing.Size(200, 39);
            this.priceV.TabIndex = 14;
            // 
            // unitV
            // 
            this.unitV.Location = new System.Drawing.Point(250, 151);
            this.unitV.Name = "unitV";
            this.unitV.Size = new System.Drawing.Size(200, 39);
            this.unitV.TabIndex = 15;
            // 
            // nameV
            // 
            this.nameV.Location = new System.Drawing.Point(250, 84);
            this.nameV.Name = "nameV";
            this.nameV.Size = new System.Drawing.Size(200, 39);
            this.nameV.TabIndex = 16;
            // 
            // categV
            // 
            this.categV.FormattingEnabled = true;
            this.categV.Location = new System.Drawing.Point(250, 426);
            this.categV.Name = "categV";
            this.categV.Size = new System.Drawing.Size(242, 40);
            this.categV.TabIndex = 17;
            this.categV.UseWaitCursor = true;
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 696);
            this.Controls.Add(this.categV);
            this.Controls.Add(this.nameV);
            this.Controls.Add(this.unitV);
            this.Controls.Add(this.priceV);
            this.Controls.Add(this.quantityV);
            this.Controls.Add(this.discV);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idV);
            this.Controls.Add(this.createTimeV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save_edit);
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.Load += new System.EventHandler(this.FormEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save_edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker createTimeV;
        private System.Windows.Forms.TextBox idV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox discV;
        private System.Windows.Forms.TextBox quantityV;
        private System.Windows.Forms.TextBox priceV;
        private System.Windows.Forms.TextBox unitV;
        private System.Windows.Forms.TextBox nameV;
        private System.Windows.Forms.ComboBox categV;
    }
}