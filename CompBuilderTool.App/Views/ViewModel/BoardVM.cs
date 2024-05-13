using CompBuilderTool.App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompBuilderTool.App.Views.ViewModel
{
    public class BoardVM : INotifyPropertyChanged
    {
        public BoardVM(Board board)
        {
            _board = board;
        }

        private Board _board;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<BoardUnit> ActiveUnits { get; set; } = [];
         
        public void Load()
        {
            foreach (var unit in _board.BoardPositions) 
            {
                ActiveUnits.Add(new BoardUnit { Position = unit.Key, Unit = unit.Value });
            }
        }


    }
}
