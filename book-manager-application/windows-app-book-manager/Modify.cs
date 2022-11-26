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
    public partial class Modify : Form
    {
        public Modify()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Modify_Load(object sender, EventArgs e)
        {
            gridLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookNameA.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            authorA.Text  = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            yearA.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            isbnA.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            lHidden.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string name = bookNameA.Text;
                string author = authorA.Text;
                int year = Convert.ToInt32(yearA.Text);
                string desc = richTextBox1.Text;
                int isbn = Convert.ToInt32(isbnA.Text);
                int id = Convert.ToInt32(lHidden.Text);

                //add sql connection string here
                Book book = new Book(ConnectionString.dbstr,id,name,author,year,desc,isbn);
                book.Update();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("No row selected");
            }
            catch (Exception ex)
            {
                MessageBox.Show("some error occured \n\n\t"+ex.Message);
            }
            finally
            {
               // MessageBox.Show("Successfully Updated");
                clearEntry();
                gridLoad();
            }

            
            
        }

        private void clearEntry()
        {
            bookNameA.Text = "";
            authorA.Text = "";
            yearA.SelectedIndex = -1;
            richTextBox1.Text = "";
            isbnA.Text = "";
        }

        private void gridLoad()
        {
            Home ls = new Home();
            DataSet objDataSet = ls.Loader();
            dataGridView1.DataSource = objDataSet.Tables[0];
            dataGridView1.Columns["ID"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(lHidden.Text);

                Book book = new Book(ConnectionString.dbstr);
                book.Delete(id);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("No row selected");
            }
            catch (Exception ex)
            {
                MessageBox.Show("some error occured");
            }
            finally
            {
                //MessageBox.Show("Successfully Deleted");
                clearEntry();
                gridLoad();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Home frm = new Home();
            frm.Show();
        }
    }
}
