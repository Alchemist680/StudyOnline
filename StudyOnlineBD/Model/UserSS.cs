using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineBD.Model
{
    public partial class UserSS
    {
        public string FIO => LastName + " " + FirstName[0] + ". " + Patronymic[0] + ". ";
    }
}
