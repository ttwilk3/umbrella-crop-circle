using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Drawing;

namespace ZooManager
{
    public partial class ZooManager : MetroForm
    {
        public ZooManager()
        {
            InitializeComponent();
            List<Zoo> myZoo = new List<Zoo>();
        }

        private class Zoo
        {
            int numOfAn { get; set; }
            int numOfFedAn { get; set; }

            public Zoo(int first, int second)
            {
                numOfAn = first;
                numOfFedAn = second;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (LoginForm frm = new LoginForm())
            {
                frm.ShowDialog(this);
                loggedInLabel.Text = "Welcome " + frm.LoggedIn;
            }

            if (loggedInLabel.Text.Length > 0)
            {
                loggedInLabel.Visible = true;
                loginButton.Visible = false;

                insertButton.Visible = true;
                deleteButton.Visible = true;
                updateButton.Visible = true;
            }
            
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            loggedInLabel.Text = "";
            loggedInLabel.Visible = false;
            loginButton.Visible = true;

            insertButton.Visible = false;
            deleteButton.Visible = false;
            updateButton.Visible = false;
        }
    }
}
