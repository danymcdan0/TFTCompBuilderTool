using CompBuilderTool.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompBuilderTool.App.Models
{
    public class Unit
    {
        public required string Name { get; set; }

        public required Class[] classes { get; set; }

        public required Origin[] origins { get; set; }

        public UnitType UnitType { get; set; }
    }
}
