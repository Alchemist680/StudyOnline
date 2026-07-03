using StudyOnlineBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineBD.ViewModel
{
    public class CoursesVM
    {
        Core db = new Core();
        public void DeleteCourse(int idCourse)
        {
            db.context.Courses.Remove(db.context.Courses.Single(x => x.IdCourse == idCourse));
            db.context.SaveChanges();
        }
    }
}
