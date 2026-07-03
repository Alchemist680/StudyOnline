using StudyOnlineBD.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudyOnlineBD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.IdClient == 0)
                CabinetButton.Visibility = Visibility.Collapsed;
            else
                CabinetButton.Visibility = Visibility.Visible;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.IdClient = 0;
            Properties.Settings.Default.IdRole = 0;
            Properties.Settings.Default.Save();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Window_Closed(sender, e);
            MainFrame.Navigate(new AuthPage());
        }

        private void CabinetButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
