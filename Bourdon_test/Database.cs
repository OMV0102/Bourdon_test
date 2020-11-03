using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;

namespace Bourdon_test
{
    public class Database
    {
        public static string connectionString = "Host=localhost;Port=5432;Database=bourdon_test;User Id=analyst;Password=123123;";

        // получение хэша SHA256 от строки
        public static string getHash(string str)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToLower();
        }
    }
}
