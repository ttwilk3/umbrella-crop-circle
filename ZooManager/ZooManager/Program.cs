﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooManager
{
    static class Program
    {
        /// test
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// This is me testing (Jareth)
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
