using System.Windows;
using System.Windows.Input;

namespace uTest
{
    /// <summary>
    /// Interaction logic for ExitConfirmation.xaml
    /// </summary>
    public partial class ErrorNotification : Window
    {
        public MainWindow OwningWindow { get; set; }

        public ErrorNotification()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            OwningWindow.IsEnabled = true;
            OwningWindow.MouseDown += OwningWindow.Window_MouseDown;
            //OwningWindow.mainFrame.Content = OwningWindow.GetHistory();
            //OwningWindow.SetActiveMenuDecoration("history");
        }

        private void ExitConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                OwningWindow.IsEnabled = true;
                //OwningWindow.mainFrame.Content = OwningWindow.GetHistory();
                //OwningWindow.SetActiveMenuDecoration("history");
                this.Close();
            }
        }

    }
}
