
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Core db = new Core();
        List<Courses> arrayCourses;
        List<Enrollments> arrayEnrollments;
        int idUser = 0;
        public MainPage()
        {
            InitializeComponent();
            idUser = Properties.Settings.Default.IdClient;
            CoursesBinding();
            //arrayCourses = db.context.Courses.ToList();
            CourseListView.ItemsSource = arrayCourses;
        }
        private void CoursesBinding()
        {
            arrayEnrollments=db.context.Enrollments.Where(x => x.UserId==idUser).ToList();
            foreach (var item in arrayEnrollments)
            {
                var course = db.context.Courses.Where(x=>x.IdCourse==item.CourseId).ToList();
                arrayCourses.AddRange(course);
            }
        }
        private void MyCoursesButton_Click(object sender, RoutedEventArgs e)    
        {

        }

        private void AllCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            AllCoursesButton.Opacity= 1;
            MyCoursesButton.Opacity = 0.75;
            CourseListView.ItemsSource = arrayCourses;
        }
        
        private void DeleteImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image activeElement = sender as Image;
            Courses activeCourses = activeElement.DataContext as Courses;
            int idCourse = activeCourses.IdCourse;
            MessageBoxResult rez = MessageBox.Show($"Вы уверены, что хотите удалить курс \"{activeCourses.CourseName}\"?",
                "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(rez == MessageBoxResult.Yes)
            {
                try
                {
                    CoursesVM newObj = new CoursesVM();
                    newObj.DeleteCourse(idCourse);
                    MessageBox.Show("Данные успешногудалены. \nВозращение на страницу",
                        "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new MainPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Возникла непредвиденная ошибка при удалении курса.\n" +
                        "Возращение на главную страницу", "Удаление", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.NavigationService.Navigate(new MainPage());
                }
            }
        }

        private void EditImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }     
    }
}
