using CompBuilderTool.App.Data;
using CompBuilderTool.App.Views.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CompBuilderTool.App.Views
{
    public partial class UnitsView : UserControl
    {
        private UnitVM _unitViewModel;

        public UnitsView()
        {
            InitializeComponent();
            _unitViewModel = new UnitVM(new UnitDataProvider());
            DataContext = _unitViewModel;
            Loaded += UnitView_Loaded;
            UnitListView.MouseMove += DragListItemChosenUnit;
            SearchBox.TextChanged += FilterCheck;
        }

        private void FilterCheck(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Length > 0)
            {
                _unitViewModel.FilteredLoad(SearchBox.Text);
            }
            else
            {
                _unitViewModel.StandardLoad();
            }
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
    }
}
