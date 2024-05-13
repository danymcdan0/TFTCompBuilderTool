using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CompBuilderTool.App.Views
{
    public partial class MenuTabView : UserControl
    {
        public MenuTabView()
        {
            InitializeComponent();
        }

        public void WebComp_OnClick(object sender, RoutedEventArgs e)
        {
            WebTraitButton.Background = Brushes.WhiteSmoke;
            VericalTraitButton.Background = Brushes.Gray;
        }

        public void VertComp_OnClick(object sender, RoutedEventArgs e)
        {
            VericalTraitButton.Background = Brushes.WhiteSmoke;
            WebTraitButton.Background = Brushes.Gray;
        }

        public void BuildComp_OnClick(object sender, RoutedEventArgs e) 
        {
            BuildCompButton.Background =
                BuildCompButton.Background == Brushes.WhiteSmoke
                ? Brushes.Gray
                : Brushes.WhiteSmoke;
        }
        
        public void UnitFocus_OnClick(object sender, RoutedEventArgs e)
        {
            UnitFocusButton.Background =
                UnitFocusButton.Background == Brushes.WhiteSmoke 
                ? Brushes.Gray 
                : Brushes.WhiteSmoke;
        }

        public void UserCompsMenu_Active()
        {
            CompBuilderMenu.Visibility = Visibility.Hidden;
            CompSettingsMenu.Visibility = Visibility.Hidden;
            UserCompsMenu.Visibility = Visibility.Visible;
        }

        public void CompBuilderMenu_Active()
        {
            CompSettingsMenu.Visibility = Visibility.Hidden;
            UserCompsMenu.Visibility = Visibility.Hidden;
            CompBuilderMenu.Visibility = Visibility.Visible;
        }

        public void CompSettingsMenu_Active()
        {
            CompBuilderMenu.Visibility = Visibility.Hidden;
            UserCompsMenu.Visibility = Visibility.Hidden;
            CompSettingsMenu.Visibility = Visibility.Visible;
        }
    }
}
