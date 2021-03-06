﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    class LoginController : IDisposable
    {
        public int UserPIN { get; set; }
        public string UserName { get; set; }
        public void openLoginForm()
        {
            using (LoginForm frm = new LoginForm())
            {
                frm.ShowDialog();
                if (frm.LoggedIn.Length == 6)
                {
                    using (DBConnector dbCon = new DBConnector())
                    {
                        string PIN = frm.LoggedIn;
                        UserName = dbCon.verifyAccountPin(PIN);
                        UserPIN = dbCon.UserPIN;
                        dbCon.log(UserPIN, DateTime.Now.ToString("h:mm:ss tt"), "Login");
                    }
                }
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
        // ~LoginController() {
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
