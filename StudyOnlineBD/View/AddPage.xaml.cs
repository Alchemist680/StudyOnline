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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        Core db = new Core();
        List<Courses> arrayCourses;
        List<Users> arrayUsers;
        int selectedFIO = 0;
        string FIO;
        int idTeacher = 0;
        public AddPage(int idUser, int idRole)
        {
            InitializeComponent();
            if (idRole == 1)
            {
                FIOTextBox.Visibility = Visibility.Collapsed;
                FIOComboBox.Visibility = Visibility.Visible;
            }
            if (idRole == 2)
            {
                FIOTextBox.Visibility = Visibility.Visible;
                FIOComboBox.Visibility = Visibility.Collapsed;
            }
            idTeacher = idUser;
            arrayUsers = db.context.Users.Where(x => x.IdRole == 1 || x.IdRole == 2).ToList();
            FIOComboBox.ItemsSource = arrayUsers;
            FIOComboBox.DisplayMemberPath = "FIO";
            FIOComboBox.SelectedValuePath = "IdUser";
            FIOComboBox.SelectedValue = idTeacher;
            FIO = arrayUsers.FirstOrDefault(x => x.IdUser == idUser).FIO.ToString();
            FIOTextBox.Text = FIO;
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                selectedFIO = Convert.ToInt32(FIOComboBox.SelectedValue);
                string titleCourse = TitleTextBox.Text;
                ViewModelClass newCourse = new ViewModelClass();
                bool result = newCourse.CheckAddCourse(titleCourse, FIO, idTeacher);
                if (result)
                {                  
                    newCourse.AddCourse(titleCourse, selectedFIO);
                    MessageBox.Show("Вы успешно длбавили курс. Возращение к списку курсов.");
                    this.NavigationService.Navigate(new MainPage());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
