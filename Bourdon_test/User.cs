using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourdon_test
{
    public class User
    {
        // Поля класса и дефолтные значения
        public Guid id = Guid.Empty;
        public string login = string.Empty;
        public string surname = string.Empty;
        public string name = string.Empty;
        public string patronymic = string.Empty;
        public DateTime birthday = DateTime.Parse("01.01.1970");
        public bool gender = true;
        public string role = "user";
        public string email = string.Empty;
        public string passwordHash = String.Empty;
        public string position = String.Empty;
        public string organization = String.Empty;
        public Guid createdBy = Guid.Empty;

        public User() { }

        public User(Guid idCreatedBy)
        {
            this.createdBy = idCreatedBy;
        }
    }
}
