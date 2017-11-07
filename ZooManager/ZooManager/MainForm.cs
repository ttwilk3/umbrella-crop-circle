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
using System.Data;
using System.Data.SqlClient;
using MetroFramework;

namespace ZooManager
{
    public partial class MainForm : MetroForm
    {
        Timer myTime = new Timer();

        DataTable table = new DataTable();

        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public bool LoggedIn { get; set; }

        public int UserPIN { get; set; }
        public MainForm()
        {
            InitializeComponent();

            LoggedIn = false;

            loginLabel.Visible = false;
            loginButton.Visible = true;
            logoutButton.Visible = false;

            insertButton.Visible = false;
            deleteButton.Visible = false;
            updateButton.Visible = false;

            metroGrid1.ReadOnly = true;
            metroGrid1.AllowUserToAddRows = false;
            metroGrid1.AllowUserToDeleteRows = false;

            myTime.Tick += new EventHandler(setTime);
            myTime.Interval = 1000;
            myTime.Start();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            metroGrid1.DataSource = bindingSource1;
            searchComboBox.DataSource = bindingSource2;
            GetData();
            PopulateSearchBox();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (LoginController logCont = new LoginController())
            {
                logCont.openLoginForm();

                UserPIN = logCont.UserPIN;

                if (logCont.UserName != null && logCont.UserName.Length > 0)
                {
                    string welcomeMessage = "Welcome " + logCont.UserName;

                    Display(welcomeMessage);

                    LoggedIn = true;

                    loginLabel.Visible = true;
                    loginButton.Visible = false;
                    logoutButton.Visible = true;

                    insertButton.Visible = true;
                    deleteButton.Visible = true;
                    updateButton.Visible = true;

                    metroGrid1.ReadOnly = false;
                    metroGrid1.AllowUserToAddRows = true;
                    metroGrid1.AllowUserToDeleteRows = true;
                }
                else
                {
                    MetroMessageBox.Show(this, "Please enter a valid PIN.");
                }
            }
        }

        private void Display(string welcomeMessage)
        {
            loginLabel.Text = welcomeMessage;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            using (LogoutController logoutCont = new LogoutController())
            {
                logoutCont.Logout(UserPIN);

                LoggedIn = false;

                loginLabel.Visible = false;
                loginButton.Visible = true;
                logoutButton.Visible = false;

                insertButton.Visible = false;
                deleteButton.Visible = false;
                updateButton.Visible = false;

                metroGrid1.ReadOnly = true;
                metroGrid1.AllowUserToAddRows = false;
                metroGrid1.AllowUserToDeleteRows = false;
            }
        }

        private void setTime(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            timeLabel.Text = "Current Time: " + time;
        }

        private void GetData()
        {
            string selectCommand = "SELECT AnimalName, NumberOfAnimal, NumberOfSickAnimal, NumberOfFedAnimal, FeedingTime FROM Zoo";
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                dataAdapter.Fill(table);

                bindingSource1.DataSource = table;

                //table.Columns.RemoveAt(0);

                metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void PopulateSearchBox()
        {
            string selectCommand = "SELECT AnimalName FROM Zoo";
            DataTable table = new DataTable();
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                dataAdapter.Fill(table);

                List<string> Animals = new List<string>();

                Animals.Add("ALL");

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Animals.Add(table.Rows[i][0].ToString());
                }

                bindingSource2.DataSource = Animals;

                //table.Columns.RemoveAt(0);

                metroGrid1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            metroGrid1.EndEdit();

            using (DataTableController dtCont = new DataTableController())
            {
                dtCont.update(ref table, ref dataAdapter);
            }

            //MetroFramework.MetroMessageBox.Show(this, "Updated Database");
            table.Clear();
            GetData();
            PopulateSearchBox();
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

        private void filterButton_Click(object sender, EventArgs e)
        {
            using (SearchController sCont = new SearchController())
            {
                string searchTerm = searchComboBox.SelectedItem.ToString();
                sCont.filterData(searchTerm, ref table);
            }
        }
    }
}
