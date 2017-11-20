using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager
{
    class Clock
    {
        public string CurrentTime { get; set; }
        public string getCurrentTime()
        {
            CurrentTime = DateTime.Now.ToString("h:mm:ss tt");
            return CurrentTime;
        }
    }
}
