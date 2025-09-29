namespace Windows1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtid = new TextBox();
            txtname = new TextBox();
            txtprice = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(513, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(621, 335);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(175, 326);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Display";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 36);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 2;
            label1.Text = "Car ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 94);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 3;
            label2.Text = "Car Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 154);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 4;
            label3.Text = "Car Price ";
            // 
            // txtid
            // 
            txtid.Location = new Point(152, 36);
            txtid.Name = "txtid";
            txtid.Size = new Size(150, 31);
            txtid.TabIndex = 5;
            txtid.TextChanged += textBox1_TextChanged;
            // 
            // txtname
            // 
            txtname.Location = new Point(153, 94);
            txtname.Name = "txtname";
            txtname.Size = new Size(150, 31);
            txtname.TabIndex = 6;
            // 
            // txtprice
            // 
            txtprice.Location = new Point(152, 154);
            txtprice.Name = "txtprice";
            txtprice.Size = new Size(150, 31);
            txtprice.TabIndex = 7;
            // 
            // button2
            // 
            button2.Location = new Point(12, 326);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 8;
            button2.Text = "Count";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 227);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 9;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(175, 227);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 10;
            button4.Text = "Update";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(353, 227);
            button5.Name = "button5";
            button5.Size = new Size(112, 34);
            button5.TabIndex = 11;
            button5.Text = "Find";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(353, 326);
            button6.Name = "button6";
            button6.Size = new Size(112, 34);
            button6.TabIndex = 12;
            button6.Text = "Delete";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 573);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtprice);
            Controls.Add(txtname);
            Controls.Add(txtid);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtid;
        private TextBox txtname;
        private TextBox txtprice;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
