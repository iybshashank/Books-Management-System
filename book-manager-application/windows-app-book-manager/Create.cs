using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MiddleTier;

namespace WinFormsApp1
{
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void descArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void isbnArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void yearArea_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void authorArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void bookNameArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (bookNameArea.Text.Length == 0)
            {
                MessageBox.Show("Book name is Mandatory");
                return;
            }
            
            string name = bookNameArea.Text;
            string author = authorArea.Text;
            int year =Convert.ToInt32(yearArea.Text);
            string desc = descArea.Text;
            int isbn = Convert.ToInt32(isbnArea.Text);
            //add sql connection string here

            Book book = new Book(ConnectionString.dbstr, name,author,year,desc,isbn);

            try
            {
                book.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("some error occured");
            }
            finally
            {
                MessageBox.Show("Successfully created");
                
            }
            
            this.Close();
            Home frm = new Home();
            frm.Show();
            
        }

        private void Create_Load(object sender, EventArgs e)
        {
            yearArea.SelectedIndex = 0;
            
            isbnArea.Text = "0";
        }

        private void isbnArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Home frm = new Home();
            frm.Show();
        }
    }
}
