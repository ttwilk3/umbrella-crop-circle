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
            InitializeComponent();
        }

        public string LoggedIn { get; set; }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoggedIn = "";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            loginCode.Text = "";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            LoggedIn = loginCode.Text;
            this.Close();
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
