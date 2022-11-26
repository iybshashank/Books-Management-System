using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MiddleTier;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Home ls = new Home();
            DataSet objDataSet = ls.Loader();
            dataGridView1.DataSource = objDataSet.Tables[0];
            dataGridView1.Columns["ID"].Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Home ls = new Home(); 
            DataSet objDataSet;
            if(textBox1.Text.Length==0)
                objDataSet = ls.Loader();
            else
                objDataSet = ls.Search(textBox1.Text);
            dataGridView1.DataSource = objDataSet.Tables[0];

        }

       

        

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Home frm = new Home();
            frm.Show();
        }

       

        
    }
}
