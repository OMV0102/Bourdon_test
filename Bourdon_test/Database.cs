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
        // Строка подключения к БД
        private static string connectionString = "Host=localhost;Port=5432;Database=bourdon_test;User Id=analyst;Password=123123;";

        // получение хэша SHA256 от строки
        private string getHash(string str)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToLower();
        }

        // Открыть соединение к БД (строка подключения)
        private NpgsqlConnection openConnection(string connString, out string errorMessage) 
        {
            NpgsqlConnection conn = null;
            errorMessage = "";
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                if (conn.FullState != ConnectionState.Open) throw new Exception();
            }
            catch (Exception)
            {
                errorMessage = "Не удалось установить соединение с базой данных!\nПожалуйста, повторите попытку позже...";
            }
            return conn;
        }

        public int authorization(string login, string password, out string errorMessage, out User userObject) 
        {

            Guid user_id = Guid.Empty;
            string user_login = string.Empty;
            string password_table = string.Empty;
            string user_role = string.Empty;
            errorMessage = "";
            userObject = null;

            try
            {
                NpgsqlConnection conn = this.openConnection(Database.connectionString, out errorMessage);
                if (conn.FullState != ConnectionState.Open)
                {
                    throw new Exception(errorMessage);
                }

                NpgsqlCommand query = new NpgsqlCommand("SELECT id, TRIM(login), TRIM(password), TRIM(role), canlogin FROM pmib6602.users WHERE TRIM(login) = TRIM(@login);", conn);

                query.Parameters.AddWithValue("login", login);

                var sqlReader = query.ExecuteReader();

                if (sqlReader.Read() == false) // если введенный пользователь не найден
                {

                    conn.Close();

                }
                user_id = sqlReader.GetGuid(0);
                user_login = sqlReader.GetString(1).ToLower();
                password_table = sqlReader.GetString(2).ToLower();
                user_role = sqlReader.GetString(3).ToLower();

                conn.Close();
            }
            catch(Exception error)
            {
                errorMessage = error.Message;
                return 0;
            }
            
            return 0;
        }
    }
}
