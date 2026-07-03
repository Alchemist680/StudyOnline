using StudyOnlineBD.Model;
using StudyOnlineBD.ViewModel;
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

namespace StudyOnlineBD.View
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            UsersVM newObject = new UsersVM();
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool result = UsersVM.CheckAuth(TBoxLogin.Text, PBoxPassword.Password);
            if (!String.IsNullOrEmpty(TBoxLogin.Text) || !String.IsNullOrEmpty(PBoxPassword.Password))
            {
                if (result)
                {
                    foreach (var user in db.context.Users.ToList().Where(x => x.Login == TBoxLogin.Text && x.Password == PBoxPassword.Password))
                    {
                        Properties.Settings.Default.IdClient = user.IdUser;
                        Properties.Settings.Default.IdRole =(int)user.IdRole;
                        Properties.Settings.Default.Save();
                    }
                    this.NavigationService.Navigate(new AuthPage());
                }
                else
                    MessageBox.Show("Пользователь не найден");
            }
            else
                MessageBox.Show("Данные не введены");
        }
    }
}
