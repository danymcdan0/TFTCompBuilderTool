using CompBuilderTool.App.Models.Enums;
using System.Windows;
using System.Windows.Controls;

namespace CompBuilderTool.App.Controls
{
    public partial class HeaderControl : UserControl
    {
        private MainWindow _mainWindow;
        public HeaderControl()
        {
            InitializeComponent();
            _mainWindow = (MainWindow)App.Current.MainWindow;
        }

        private void Settings_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void Account_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void UserComps_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.HandleMenuSwitch(ActiveMenu.UserComps);
        }

        private void CompBuilder_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.HandleMenuSwitch(ActiveMenu.CompBuilder);
        }

        private void CompSettings_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.HandleMenuSwitch(ActiveMenu.CompSettings);
        }

    }
}
