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
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            Logins.Add(new Login("723901", "Dr.Onyeka"));
            Logins.Add(new Login("449123", "Tyler"));
            Logins.Add(new Login("234192", "Robert"));
            Logins.Add(new Login("143232", "Jareth"));
            Logins.Add(new Login("592120", "Morgan"));
            Logins.Add(new Login("712387", "Jordan"));
            InitializeComponent();
        }

        List<Login> Logins = new List<Login>();

        private class Login
        {
            public string pin { get; set; }
            public string Name { get; set; }

            public Login(string _pin, string _Name)
            {
                pin = _pin;
                Name = _Name;
            }
        }

        public string LoggedIn { get; set; }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            loginCode.Text = "";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Login temp = null;

            foreach (Login l in Logins)
            {
                if (l.pin.Equals(loginCode.Text))
                {
                    temp = l;
                }
            }

            if (temp == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter a valid pin.");
            }
            else
            {
                LoggedIn = temp.Name;
                this.Close();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "1";
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "2";
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "3";
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "4";
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "5";
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "6";
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "7";
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "8";
            }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "9";
            }
        }

        private void metroButton0_Click(object sender, EventArgs e)
        {
            if (loginCode.Text.Length < 6)
            {
                loginCode.Text += "0";
            }
        }
    }
}
