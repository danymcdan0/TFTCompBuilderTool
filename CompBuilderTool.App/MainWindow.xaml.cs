using CompBuilderTool.App.Models.Enums;
using CompBuilderTool.App.Views;
using CompBuilderTool.App.Views.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CompBuilderTool.App
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwapUnitView_Button(object sender, RoutedEventArgs e)
        {
            var traitsColumn = ActiveTraitsView.GetValue(Grid.ColumnProperty);
            var traitsRow = ActiveTraitsView.GetValue(Grid.RowProperty);
            var traitsRowSpan = ActiveTraitsView.GetValue(Grid.RowSpanProperty);

            var searchColumn = UnitsView.GetValue(Grid.ColumnProperty);
            var searchRow = UnitsView.GetValue(Grid.RowProperty);
            var searchRowSpan = UnitsView.GetValue(Grid.RowSpanProperty);

            ActiveTraitsView.SetValue(Grid.ColumnProperty, searchColumn);
            ActiveTraitsView.SetValue(Grid.RowProperty, searchRow);
            ActiveTraitsView.SetValue(Grid.RowSpanProperty, searchRowSpan);

            UnitsView.SetValue(Grid.ColumnProperty, traitsColumn);
            UnitsView.SetValue(Grid.RowProperty, traitsRow);
            UnitsView.SetValue(Grid.RowSpanProperty, traitsRowSpan);
        }

        public void HandleDrop(TextBlock textBlock, string unitName)
        {
            var unitContext = (UnitVM)UnitsView.DataContext;
            var boardContext = (BoardVM)ActiveBoard.DataContext;

            if (textBlock.Text == unitName)
            {
                return;
            }

            var unit = unitContext.Units.FirstOrDefault(x => x.Name == unitName);
            if (unit == null)
            {
                return;
            }

            var boardPos = textBlock.Name;
            ActiveBoard._currentBoard.BoardPositions[boardPos] = unit;

            var targetBlock = ActiveBoard._boardBlocks?.FirstOrDefault(x => x.Name == boardPos);
            if (targetBlock == null)
            {
                return;
            }

            targetBlock.Text = unit.Name;
        }

        public void HandleMenuSwitch(ActiveMenu activeMenu) 
        {
            switch (activeMenu)
            {
                case ActiveMenu.CompBuilder:
                    TabViews.CompBuilderMenu_Active();
                    break;
                case ActiveMenu.CompSettings:
                    TabViews.CompSettingsMenu_Active();
                    break;
                case ActiveMenu.UserComps:
                    TabViews.UserCompsMenu_Active();
                    break;
                case ActiveMenu.UserAccount:
                    break;
                case ActiveMenu.Settings:
                    break;
                default:
                    break;
            }
        }
    }
}