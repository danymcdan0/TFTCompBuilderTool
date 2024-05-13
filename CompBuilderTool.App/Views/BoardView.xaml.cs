using CompBuilderTool.App.Models;
using CompBuilderTool.App.Views.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CompBuilderTool.App.Views
{
    public partial class BoardView : UserControl
    {
        private BoardVM _boardViewModel;
        public TextBlock[]? _boardBlocks;
        public Board _currentBoard;

        public BoardView()
        {
            InitializeComponent();
            _currentBoard = new Board();
            _boardViewModel = new BoardVM(_currentBoard);
            DataContext = _boardViewModel;
            _boardBlocks = ParentGrid.Children.OfType<TextBlock>().ToArray();
        }

        private void BoardDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        private void BoardDrop(object sender, DragEventArgs e)
        {
            var unitName = e.Data.GetData(DataFormats.StringFormat).ToString();
            if (unitName == null)
            {
                return;
            }

            var mainContext = (MainWindow)Application.Current.MainWindow;
            mainContext.HandleDrop((TextBlock)sender, unitName);
        }
    }
}
