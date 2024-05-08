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
        public int Id { get; set; }    

        public required string Name { get; set; }

        public Class[]? classes { get; set; }

        public Origin[]? origins { get; set; }

        public UnitType UnitType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
