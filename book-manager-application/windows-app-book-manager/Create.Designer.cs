
namespace WinFormsApp1
{
    partial class Create
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
            this.button2 = new System.Windows.Forms.Button();
            this.isbnArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.descArea = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yearArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authorArea = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bookNameArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(61, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Create";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // isbnArea
            // 
            this.isbnArea.Location = new System.Drawing.Point(155, 236);
            this.isbnArea.Name = "isbnArea";
            this.isbnArea.Size = new System.Drawing.Size(254, 23);
            this.isbnArea.TabIndex = 27;
            this.isbnArea.TextChanged += new System.EventHandler(this.isbnArea_TextChanged);
            this.isbnArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isbnArea_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "ISBN";
            // 
            // descArea
            // 
            this.descArea.Location = new System.Drawing.Point(155, 285);
            this.descArea.Name = "descArea";
            this.descArea.Size = new System.Drawing.Size(254, 82);
            this.descArea.TabIndex = 25;
            this.descArea.Text = "";
            this.descArea.TextChanged += new System.EventHandler(this.descArea_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Description";
            // 
            // yearArea
            // 
            this.yearArea.FormatString = "N0";
            this.yearArea.FormattingEnabled = true;
            this.yearArea.Items.AddRange(new object[] {
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000"});
            this.yearArea.Location = new System.Drawing.Point(155, 187);
            this.yearArea.Name = "yearArea";
            this.yearArea.Size = new System.Drawing.Size(121, 23);
            this.yearArea.TabIndex = 23;
            this.yearArea.SelectedIndexChanged += new System.EventHandler(this.yearArea_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Publish Year";
            // 
            // authorArea
            // 
            this.authorArea.Location = new System.Drawing.Point(155, 138);
            this.authorArea.Name = "authorArea";
            this.authorArea.Size = new System.Drawing.Size(254, 23);
            this.authorArea.TabIndex = 21;
            this.authorArea.TextChanged += new System.EventHandler(this.authorArea_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Author";
            // 
            // bookNameArea
            // 
            this.bookNameArea.Location = new System.Drawing.Point(155, 89);
            this.bookNameArea.Name = "bookNameArea";
            this.bookNameArea.Size = new System.Drawing.Size(254, 23);
            this.bookNameArea.TabIndex = 19;
            this.bookNameArea.TextChanged += new System.EventHandler(this.bookNameArea_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Book Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 45);
            this.label1.TabIndex = 17;
            this.label1.Text = "Create";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(155, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.isbnArea);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.descArea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yearArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.authorArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bookNameArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Create";
            this.Text = "Create";
            this.Load += new System.EventHandler(this.Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox isbnArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox descArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox yearArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox authorArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bookNameArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}