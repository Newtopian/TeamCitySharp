using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class Triggered
    {
        public string Type { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return "triggered";
        }
    }
}
