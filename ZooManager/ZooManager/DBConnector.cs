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

        public void updateData(DataTable table)
        {
            try
            {
                string selectCommand = "UPDATE Zoo";
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\ZooManager.mdf";
                //String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lohru\Source\Repos\umbrella-crop-circle\ZooManager\ZooManager\Zoo.mdf;Integrated Security=True";
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder cb;
                cb = new SqlCommandBuilder(dataAdapter);

                //dataAdapter.DeleteCommand = cb.GetDeleteCommand(true);
                dataAdapter.UpdateCommand = cb.GetUpdateCommand(true);
                dataAdapter.InsertCommand = cb.GetInsertCommand(true);

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

                this.Dispose(true);

                return UserName;
            }
            catch (Exception ex)
            {
                return "";
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
