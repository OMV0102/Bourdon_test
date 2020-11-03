using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Security.Cryptography;

namespace Bourdon_test
{
    public static class global
    {
        //public static string connectionString = "Host=students.ami.nstu.ru;Port=5432;Database=students;User Id=pmi-b6602;Password=ekNonuc1;";
        public static string connectionString = "Host=localhost;Port=5432;Database=students;User Id=pmi-b6602;Password=b6602;"; //Password=ekNonuc1;
        //==============================
        public static int loginCount;
        public static int loginMaxCount;
        public static bool canLogin;
        //===============================
        public static int loginMaxLength = 20;
        //===============================
        public static string searchDefault = "google.ru";
        //===============================
        public static string role_name_limited = "user";
    }
}
