using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompBuilderTool.App.Models
{
    public class BoardUnit
    {
        public required string Position { get; set; }

        public Unit? Unit { get; set; }
    }
}
