using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudentMVVM18112019.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButton2_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(CreateStudentPage));
        }

        private void MenuButton1_OnClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(OverviewPage));
        }
    }
}
