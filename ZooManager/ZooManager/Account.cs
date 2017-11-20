using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    class Account
    {
        public int PIN { get; set; }
        public string Name { get; set; }

        public int getPIN()
        {
            return PIN;
        }

        public void setPIN(int newPIN)
        {
            PIN = newPIN;
        }

        public string getName()
        {
            return Name;
        }

        public void setName(string newName)
        {
            Name = newName;
        }
    }
}
