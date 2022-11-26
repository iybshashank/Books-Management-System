using MiddleTier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Home : Form
    {
        static string s_name { get; set; }
        static bool s_isAdmin { get; set; }
        static readonly string dbstr = ConnectionString.dbstr;


        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (globalVar.s_isAdmin)
            {
                
                label6.Text = globalVar.s_name + "(FullAccess)";
            }
            else
            {
                label3.Hide();
                label2.Hide();
                label6.Text = globalVar.s_name + "(Read-Only)";
            }

            refreshGrid();

        }

        public void refreshGrid()
        {
            DataSet objDataSet = Loader();
            dataGridView1.DataSource = objDataSet.Tables[0];
            dataGridView1.Columns["ID"].Visible = false;
        }
        public DataSet Loader()
        {

            Book obj = new Book(dbstr);
            return obj.Load();
        }
        public DataSet Search(string a)
        {
            Book obj = new Book(dbstr);
            return obj.Load(a);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Create frm = new Create();
            this.Hide();
            frm.Show();
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Modify frm = new Modify();
            this.Close();
            frm.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm();
            this.Close();
            frm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
