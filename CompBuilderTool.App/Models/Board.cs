using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompBuilderTool.App.Models
{
    public class Board
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public Dictionary<string, Unit?> BoardPositions { get; set; } = new () 
        {
            {"A1", null}, {"A2", null}, {"A3", null}, {"A4", null}, {"A5", null}, {"A6", null}, {"A7", null},
            {"B1", null}, {"B2", null}, {"B3", null}, {"B4", null}, {"B5", null}, {"B6", null}, {"B7", null},
            {"C1", null}, {"C2", null}, {"C3", null}, {"C4", null}, {"C5", null}, {"C6", null}, {"C7", null},
            {"D1", null}, {"D2", null}, {"D3", null}, {"D4", null}, {"D5", null}, {"D6", null}, {"D7", null},
        };
    }
}
