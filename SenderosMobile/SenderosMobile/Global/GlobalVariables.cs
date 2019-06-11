using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SenderosMobile
{
    class GlobalVariables
    {
        public string CloudIP = "http://35.232.93.124:5500/";

        public int MinLengthPassword = 6;

        public Regex EmailFormat = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public GlobalVariables()
        {
        }
    }
}
