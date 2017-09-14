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
using System.Data.SqlClient;

namespace ZooManager
{
    public partial class ZooManager : MetroForm
    {
        SqlDataAdapter dataAdapter = null;
        DataTable table = new DataTable();
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
            Console.WriteLine(DateTime.Now);
            metroGrid1.DataSource = bindingSource1;
            GetData("select * from Animals");
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

                metroGrid1.ReadOnly = false;
                metroGrid1.AllowUserToAddRows = true;
                metroGrid1.AllowUserToDeleteRows = true;
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

            metroGrid1.ReadOnly = true;
            metroGrid1.AllowUserToAddRows = false;
            metroGrid1.AllowUserToDeleteRows = false;
        }

        private void GetData(string selectCommand)
        {
            try
            {
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                dataAdapter.Fill(table);

                bindingSource1.DataSource = table;

                //table.Columns.RemoveAt(0);

                metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0)
            {
                if (searchBox.Text.Contains(','))
                {
                    string query = "SELECT * FROM Animals WHERE ";
                    string[] temp = searchBox.Text.Split(',');
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = temp[i].Replace(" ", string.Empty);
                        if (i == 0)
                            query += "AnimalName = '" + temp[i] + "'";
                        else
                            query += " OR AnimalName = '" + temp[i] + "'";
                    }
                    table.Clear();
                    GetData(query);
                }
                else
                {
                    table.Clear();
                    GetData("SELECT * FROM Animals WHERE AnimalName = '" + searchBox.Text + "'");
                }
            }
            else
            {
                table.Clear();
                GetData("SELECT * FROM Animals");
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            DataRow newRow = table.NewRow();

            table.Rows.Add(newRow);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in metroGrid1.SelectedRows)
            {
                metroGrid1.Rows.RemoveAt(item.Index);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                metroGrid1.EndEdit();
                dataAdapter.Update(table);
                MetroFramework.MetroMessageBox.Show(this, "Updated Database");
                table.Clear();
                GetData("select * from Animals");
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
    }
}
