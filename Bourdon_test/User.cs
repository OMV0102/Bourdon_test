using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourdon_test
{
    public class User
    {
        // ПОля класса и дефолтные значения
        public Guid id = Guid.Empty;
        public string login = string.Empty;
        public string surname = string.Empty;
        public string name = string.Empty;
        public string patronymic = string.Empty;
        public DateTime birthday = DateTime.Parse("01.01.1970");
        public bool sex = true;
        public string role = "user";
        public string email = string.Empty;
        public string organization = "user";

    }
}
