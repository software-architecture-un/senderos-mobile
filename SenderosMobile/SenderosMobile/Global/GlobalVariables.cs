using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SenderosMobile
{
    class GlobalVariables
    {
        //public string CloudIP = "http://35.196.16.91/";
        public string CloudIP = "http://34.94.104.0/";

        public int MinLengthPassword = 6;

        public Regex EmailFormat = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public GlobalVariables()
        {
        }
    }
}
