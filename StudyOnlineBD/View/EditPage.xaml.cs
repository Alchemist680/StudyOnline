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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public void EditCourse(int idCourse, string title, int idUser)
        {

            var objCourse = db.context.Course.Where(x => x.IdCourse == idCourse).FirstOrDefault();
            objCourse.Title = title;
            var objEnrollments = db.context.Enrollments.Where(x => x.CourseId == idCourse).FirstOrDefault();
            objEnrollments.UserId = idUser;
            db.context.SaveChanges();
        }
    }
}
 