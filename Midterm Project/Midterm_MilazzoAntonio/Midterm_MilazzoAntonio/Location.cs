using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_MilazzoAntonio
{
    internal class Location
    {
        public string LocationName
        { get; }

        public string LocationDescription
        { get; }
        public Location(string name, string description) 
        {
            LocationName = name;
            LocationDescription = description;
        }
    }
}
