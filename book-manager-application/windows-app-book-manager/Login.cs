using Microsoft.AspNetCore.Http;
using MiddleTier;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            string uName = username.Text;
            string paswd = password.Text;
            //add sql connection string here

            
            Users obj = new Users(ConnectionString.dbstr);
            obj.user = uName;
            obj.password = paswd;



            if (obj.getUser())
            {

                setVal(obj.user, obj.isAdmin);
                Home frm = new Home();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Credentials invalid");
            }



        }

        private void setVal(string user, bool isAdmin)
        {
           
            globalVar.s_name = user;
            globalVar.s_isAdmin = isAdmin;
            
        }
    }
}
