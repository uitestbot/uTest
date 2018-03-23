using System.Windows;
using System.Windows.Input;

namespace uTest
{
    /// <summary>
    /// Interaction logic for ExitConfirmation.xaml
    /// </summary>
    public partial class ExitConfirmation : Window
    {
        public MainWindow OwningWindow { get; set; }

        public ExitConfirmation()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (OwningWindow != null)
                OwningWindow.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            OwningWindow.IsEnabled = true;
            OwningWindow.MouseDown += OwningWindow.Window_MouseDown;
        }

        private void ExitConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Y)
            {
                this.Close();
                if (OwningWindow != null)
                    OwningWindow.Close();
            }
            else if (e.Key == Key.N)
            {
                OwningWindow.IsEnabled = true;
                this.Close();
            }
        }

    }
}
