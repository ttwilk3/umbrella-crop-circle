using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    class DBConnector : IDisposable
    {

        public int UserPIN { get; set; }

        public void updateData(ref DataTable table, ref SqlDataAdapter dataAdapter)
        {
            try
            {
                string selectCommand = "SELECT * FROM Zoo";
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder cb;
                cb = new SqlCommandBuilder(dataAdapter);

                //dataAdapter.DeleteCommand = cb.GetDeleteCommand(true);
                //dataAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                //dataAdapter.InsertCommand = cb.GetInsertCommand(true);

                dataAdapter.Update(table);
            }
            catch (Exception ex)
            {
            }
        }

        public string verifyAccountPin(string PIN)
        {
            DataTable table = new DataTable();
            try
            {
                string selectCommand = "SELECT Name FROM ZooAdmin WHERE PIN='" + PIN + "'";
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                dataAdapter.Fill(table);

                string UserName = table.Rows[0][0].ToString();

                UserPIN = Int32.Parse(PIN);

                this.Dispose(true);

                return UserName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public void queryDatabase(string searchTerm, ref DataTable table)
        {
            try
            {
                string selectCommand = "";
                if (searchTerm.Equals("ALL"))
                    selectCommand = "SELECT AnimalName, NumberOfAnimal, NumberOfSickAnimal, NumberOfFedAnimal, FeedingTime FROM Zoo";
                else    
                    selectCommand = "SELECT AnimalName, NumberOfAnimal, NumberOfSickAnimal, NumberOfFedAnimal, FeedingTime FROM Zoo WHERE AnimalName='" + searchTerm + "'";
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                table.Locale = System.Globalization.CultureInfo.InvariantCulture;

                table.Clear();

                dataAdapter.Fill(table);
            }
            catch (Exception ex)
            {
            }
        }

        public void log(int PIN, string Time, string Action)
        {
            try
            {
                string insertCommand = "INSERT INTO UserLogin (PIN, Time, Action) VALUES (" + PIN + ", '" + Time + "', '" + Action + "')";

                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";

                SqlCommand ins = new SqlCommand(insertCommand);

                ins.Connection = new SqlConnection(connectionString);

                ins.Connection.Open();

                ins.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DBConnector() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
