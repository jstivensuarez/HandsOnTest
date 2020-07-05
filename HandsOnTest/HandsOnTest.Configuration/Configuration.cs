using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Configuration
{
    public class Configuration
    {
        public Host Host { get; set; }
        public Path Path { get; set; }
    }

    public class Host
    {
        public string Masglobal { get; set; }
    }

    public class Path
    {
        public string Employees { get; set; }
    }
}
