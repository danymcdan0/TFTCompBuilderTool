using CompBuilderTool.App.Data;
using CompBuilderTool.App.Models;
using CompBuilderTool.App.Views.ViewModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CompBuilderTool.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitVM _unitViewModel;
        private TextBlock[]? _boardBlocks;
        private Board _currentBoard;

        public MainWindow()
        {
            InitializeComponent();
            _unitViewModel = new UnitVM(new UnitDataProvider());
            InitializeSearchMenu();
            _currentBoard = new Board();
            InitializeBoardObjects();
        }

        private void InitializeSearchMenu()
        {
            UnitListView.ItemsSource = _unitViewModel.Units;
            UnitListView.AllowDrop = true;
            UnitListView.DisplayMemberPath = "Name";
            Loaded += UnitView_Loaded;
            UnitListView.MouseMove += DragListItemChosenUnit;
            InitializeSearchBox();
        }

        private void InitializeSearchBox()
        {
            SearchBox.TextChanged += FilterCheck;
        }

        private void InitializeBoardObjects()
        {
            BoardView.DataContext = _currentBoard;
            _boardBlocks = BoardView.Children.OfType<TextBlock>().ToArray();
        }

        private async void FilterCheck(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Length > 0)
            {
                await _unitViewModel.FilteredLoad(SearchBox.Text);
            }
            else
            {
                await _unitViewModel.Load();
            }
        }

        private void SwapSearchView_Button(object sender, RoutedEventArgs e)
        {
            var traitsColumn = ActiveTraitsView.GetValue(Grid.ColumnProperty);
            var traitsRow = ActiveTraitsView.GetValue(Grid.RowProperty);
            var traitsRowSpan = ActiveTraitsView.GetValue(Grid.RowSpanProperty);

            var searchColumn = UnitSearchView.GetValue(Grid.ColumnProperty);
            var searchRow = UnitSearchView.GetValue(Grid.RowProperty);
            var searchRowSpan = UnitSearchView.GetValue(Grid.RowSpanProperty);

            ActiveTraitsView.SetValue(Grid.ColumnProperty, searchColumn);
            ActiveTraitsView.SetValue(Grid.RowProperty, searchRow);
            ActiveTraitsView.SetValue(Grid.RowSpanProperty, searchRowSpan);

            UnitSearchView.SetValue(Grid.ColumnProperty, traitsColumn);
            UnitSearchView.SetValue(Grid.RowProperty, traitsRow);
            UnitSearchView.SetValue(Grid.RowSpanProperty, traitsRowSpan);
        }

        private async void UnitView_Loaded(object sender, RoutedEventArgs e)
        {
            await _unitViewModel.Load();
        }

        private void DragListItemChosenUnit(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(UnitListView, UnitListView.SelectedItem.ToString(), DragDropEffects.All);
            }
        }

        private void BoardDrop(object sender, DragEventArgs e)
        {
            var unitName = e.Data.GetData(DataFormats.StringFormat).ToString();
            if (unitName == null) 
            {
                return; 
            }

            UpdateBoard((TextBlock)sender, unitName);
        }

        private void BoardDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        private void UpdateBoard(TextBlock textBlock, string unitName)
        {
            if (textBlock.Text == unitName)
            {
                return;
            }

            var unit = _unitViewModel.Units.FirstOrDefault(x => x.Name == unitName);
            if (unit == null)
            {
                return;
            }

            var boardPos = textBlock.Name;
            _currentBoard.BoardPositions[boardPos] = unit;

            var targetBlock = _boardBlocks.FirstOrDefault(x => x.Name == boardPos);
            if (targetBlock == null) 
            { 
                return; 
            }

            targetBlock.Text = unit.Name;
        }
    }
}