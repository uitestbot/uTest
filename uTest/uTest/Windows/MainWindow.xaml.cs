using System;
using System.Windows;
using System.Windows.Input;
using ProfileManager;
using uTest.Pages;

namespace uTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Dashboard dashboard = null;
        private static History history = null;
        private static Implement implement = null;
        private static Settings settings = null;

        public Size size;
        public Point origin;

        public MainWindow()
        {
            InitializeComponent();
            InitializePosition();
            SetVersionLabel();
            ProfileManager.ProfileManager.InitProfile();
            SetStartingPageInMainFrame();
        }

        #region initializations
        private void InitializePosition()
        {
            SetCurrentPosition();
        }

        private void SetCurrentPosition()
        {
            size = new Size(this.Width, this.Height);
            origin = new Point(this.Left, this.Top);

            this.topDecoration.Width = size.Width - 20;

            //testPosition.Content = String.Format("Size: [{0} x {1}], TopLeft: [{2} : {3}]", size.Width, size.Height, origin.X, origin.Y);
        }

        private void SetCurrentPosition(Size _size)
        {
            size = _size;
            origin = new Point(0.0, 0.0);

            //testPosition.Content = String.Format("Size: [{0} x {1}], TopLeft: [{2} : {3}]", size.Width, size.Height, origin.X, origin.Y);
        }

        private void SetVersionLabel()
        {
            try
            {
                versionLabel.Content = String.Format("v.{0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void SetStartingPageInMainFrame()
        {
            if (dashboard == null)
            {
                dashboard = new Dashboard();
            }
            mainFrame.Content = dashboard;
        }
        #endregion

        #region NAVIGATION EVENTS
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            ExitConfirmation exitConfirmation = new ExitConfirmation();
            exitConfirmation.OwningWindow = this;
            exitConfirmation.Show();

            this.MouseDown -= Window_MouseDown;

            exitConfirmation.Left = origin.X + (size.Width - exitConfirmation.ActualWidth) / 2;
            exitConfirmation.Top = origin.Y + (size.Height - exitConfirmation.ActualHeight) / 2;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            this.maximizeButton.Click -= MaximizeButton_Click;
            this.maximizeButton.Click += RestoreButton_Click;
            this.maximizeButton.Content = "◱";
            this.maximizeButton.FontSize = 13;
            SetCurrentPosition(new Size(this.Width, this.Height));
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.maximizeButton.Click += MaximizeButton_Click;
            this.maximizeButton.Click -= RestoreButton_Click;
            this.maximizeButton.Content = "□";
            this.maximizeButton.FontSize = 16;

            SetCurrentPosition();
        }

        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized) return;
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

            SetCurrentPosition();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.topDecoration.Width = size.Width - 20;
            SetCurrentPosition();
        }
        #endregion
        #region MENU EVENTS
        private void settingsMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (settings == null)
            {
                settings = new Settings();
            }
            mainFrame.Content = settings;

            this.topDecoration_curentPage.Content = "SETTINGS";
        }

        private void implementMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (implement == null)
            {
                implement = new Implement();
            }
            mainFrame.Content = implement;

            this.topDecoration_curentPage.Content = "IMPLEMENT";
        }

        private void historyLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (history == null)
            {
                history = new History();
            }
            mainFrame.Content = history;

            this.topDecoration_curentPage.Content = "HISTORY";
        }

        private void dashboardMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.topDecoration_curentPage.Content = "DASHBOARD";

            if (dashboard == null)
            {
                dashboard = new Dashboard();
            }
            mainFrame.Content = dashboard;
        }
        #endregion
        #region EXCEPTION HANDLING
        private void HandleException(Exception ex)
        {
            ShowErrorNotificationWindow(this);
        }

        public void ShowErrorNotificationWindow(Window window)
        {
            this.IsEnabled = false;

            ErrorNotification errorNotification = new ErrorNotification();
            errorNotification.OwningWindow = this;
            errorNotification.Show();
            this.MouseDown -= Window_MouseDown;

            errorNotification.Left = origin.X + (size.Width - errorNotification.ActualWidth) / 2;
            errorNotification.Top = origin.Y + (size.Height - errorNotification.ActualHeight) / 2;
        }
        #endregion
    }
}
