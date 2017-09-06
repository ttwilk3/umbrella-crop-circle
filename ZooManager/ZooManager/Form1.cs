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
            metroLabel1.Visible = true;
            logoutButton.Visible = false;
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            metroLabel1.Visible = false;
            logoutButton.Visible = true;
        }
    }
}
