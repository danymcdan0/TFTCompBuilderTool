using CompBuilderTool.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompBuilderTool.App.Models
{
    public class Composition
    {
        public required string Label { get; set; }

        public required Unit[] Units { get; set; }

        public required CompType[] CompType { get; set; }
    }
}
