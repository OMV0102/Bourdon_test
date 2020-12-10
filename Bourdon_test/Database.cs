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
        public string getHash(string str)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToLower();
        }

        // Открыть соединение к БД (строка подключения)
        // Возвращается false
        private bool openConnection(string connString, out NpgsqlConnection conn, out string errorMessage) 
        {
            conn = null;
            errorMessage = string.Empty;
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                if (conn == null || conn.FullState != ConnectionState.Open)
                    throw new Exception();
                else return true;
            }
            catch (Exception)
            {
                errorMessage = "Не удалось установить соединение с базой данных!\nПожалуйста, повторите попытку позже...";
                return false;
            }
        }

        // Авторизация по логину и паролю
        public int authorization(string login, string password, out string errorMessage, out User userObject) 
        {
            errorMessage = "";
            userObject = null;
            NpgsqlConnection conn = null;

            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, login, surname, name, patronymic, birthday, gender, role, email, password, organization, position FROM public.users WHERE TRIM(login) = TRIM(@login);", conn);
                    query.Parameters.AddWithValue("login", login);
                    sqlReader = query.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных!\nПожалуйста, повторите попытку позже...");
                }

                if (sqlReader.Read() == false) // если введенный логин не найден
                {
                    throw new Exception("Неверные логин или пароль!");
                }
                else
                    try
                    {
                        if (this.getHash(password) != sqlReader.GetString(9).ToLower()) // если введенный пароль не совпал
                        {
                            throw new Exception("Неверные логин или пароль!");
                        }
                        else
                        {
                            userObject = new User();
                            userObject.id = sqlReader.GetGuid(0);
                            userObject.login = login;
                            userObject.surname = sqlReader.GetString(2);
                            userObject.name = sqlReader.GetString(3);
                            userObject.patronymic = sqlReader.GetString(4);
                            userObject.birthday = sqlReader.GetDateTime(5);
                            userObject.gender = sqlReader.GetBoolean(6);
                            userObject.role = sqlReader.GetString(7);
                            userObject.email = sqlReader.GetString(8);
                            userObject.passwordHash = sqlReader.GetString(9);
                            userObject.organization = sqlReader.GetString(10);
                            userObject.position = sqlReader.GetString(11);

                            if (conn != null) conn.Close();

                            if (userObject.role == "user")
                                return 1;

                            if (userObject.role == "admin")
                                return 2;
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Ошибка получения данных из базы данных!\nПожалуйста, повторите попытку позже...");
                    }
            }
            catch(Exception error)
            {
                if(conn != null) conn.Close();
                errorMessage = error.Message;
                return 0;
            }
            
            return 0;
        }

        // Считывание всех пользователей в список
        public bool loadAllUsers(out List<User> listUsers, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;
            listUsers = new List<User>();
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, login, surname, name, patronymic, birthday, gender, role, email, password, organization, position, created_date, created_by FROM public.users ORDER BY surname, name, patronymic;", conn);
                    sqlReader = query.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }

                try // считка пользователей
                {
                    while (sqlReader.Read() == true)
                    {
                        User user = new User();

                        user.id = sqlReader.GetGuid(0);
                        user.login = sqlReader.GetString(1);
                        user.surname = sqlReader.GetString(2);
                        user.name = sqlReader.GetString(3);
                        user.patronymic = sqlReader.GetString(4);
                        user.birthday = sqlReader.GetDateTime(5);
                        user.gender = sqlReader.GetBoolean(6);
                        user.role = sqlReader.GetString(7);
                        user.email = sqlReader.GetString(8);
                        user.passwordHash = sqlReader.GetString(9);
                        user.organization = sqlReader.GetString(10);
                        user.position = sqlReader.GetString(11);
                        user.createdDate = sqlReader.GetDateTime(12);
                        user.createdBy = sqlReader.GetGuid(13);

                        listUsers.Add(user);
                    }
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Добавление нового пользователя
        public bool registerNewUser(User user, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;

            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;
                try
                {
                    if (user.passwordHash == "")
                        user.passwordHash =  this.getHash(user.login);

                    query = new NpgsqlCommand("INSERT INTO public.users (id, login, surname, name, patronymic, birthday, gender, email, password, position, organization, created_by, role) VALUES (@id::uuid, @login, @surname, @name, @patronymic, @birthday::timestamp, @gender::boolean, @email, @password, @position, @organization, @created_by::uuid, @role);", conn);
                    query.Parameters.AddWithValue("id", user.id);
                    query.Parameters.AddWithValue("login", user.login);
                    query.Parameters.AddWithValue("surname", user.surname);
                    query.Parameters.AddWithValue("name", user.name);
                    query.Parameters.AddWithValue("patronymic", user.patronymic);
                    query.Parameters.AddWithValue("birthday", user.birthday.ToString());
                    query.Parameters.AddWithValue("gender", user.gender);
                    query.Parameters.AddWithValue("email", user.email);
                    query.Parameters.AddWithValue("password", user.passwordHash);
                    query.Parameters.AddWithValue("position", user.position);
                    query.Parameters.AddWithValue("organization", user.organization);
                    query.Parameters.AddWithValue("created_by", user.createdBy);
                    query.Parameters.AddWithValue("role", "user");
                    query.ExecuteNonQuery();
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при добавлении записи пользователя!\n");
                }

            }
            catch(Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Изменение информации о пользователе
        public bool editUser(User user, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;

            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;
                try
                {
                    query = new NpgsqlCommand("UPDATE public.users SET (login, surname, name, patronymic, birthday, gender, email, password, position, organization) = (@login, @surname, @name, @patronymic, @birthday::timestamp, @gender::boolean, @email, @password, @position, @organization) WHERE id = @id::uuid;", conn);
                    query.Parameters.AddWithValue("login", user.login);
                    query.Parameters.AddWithValue("surname", user.surname);
                    query.Parameters.AddWithValue("name", user.name);
                    query.Parameters.AddWithValue("patronymic", user.patronymic);
                    query.Parameters.AddWithValue("birthday", user.birthday.ToString());
                    query.Parameters.AddWithValue("gender", user.gender);
                    query.Parameters.AddWithValue("email", user.email);
                    query.Parameters.AddWithValue("password", user.passwordHash);
                    query.Parameters.AddWithValue("position", user.position);
                    query.Parameters.AddWithValue("organization", user.organization);
                    query.Parameters.AddWithValue("id", user.id);
                    query.ExecuteNonQuery();
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception error)
                {
                    string s = error.Message;
                    throw new Exception("Ошибка доступа к базе данных при изменении записи пользователя!\n");
                }

            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Сохранение результата в БД
        public bool saveResult(Result res, out string errorMessage)
        {
            errorMessage = "";
            NpgsqlConnection conn = null;

            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }
                NpgsqlCommand query = null;

                res.id = Guid.NewGuid(); // генерация нового id для результата

                query = new NpgsqlCommand("INSERT INTO public.results (id, created_date, user_id, level, t, l, c, n, s, p, o) VALUES (@id::uuid, @date::timestamp, @user_id::uuid, @level, @t, @l, @c, @n, @s, @p, @o);", conn);
                query.Parameters.AddWithValue("id", res.id);
                query.Parameters.AddWithValue("date", res.dateCreated.ToString());
                query.Parameters.AddWithValue("user_id", res.userID);
                query.Parameters.AddWithValue("level", res.level);
                query.Parameters.AddWithValue("t", res.t);
                query.Parameters.AddWithValue("l", res.L);
                query.Parameters.AddWithValue("c", res.C);
                query.Parameters.AddWithValue("n", res.n);
                query.Parameters.AddWithValue("s", res.S);
                query.Parameters.AddWithValue("p", res.P);
                query.Parameters.AddWithValue("o", res.O);
                query.ExecuteNonQuery();
                if (conn != null) conn.Close();
                return true;
            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Загрузка всех результатов одного пользователя
        public bool loadResultsUser(Guid userID, out List<Result> listRes, out string errorMessage)
        {
            listRes = new List<Result>();
            errorMessage = "";
            NpgsqlConnection conn = null;
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }

                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, created_date, user_id, level, t, l, c, n, s, p, o FROM public.results WHERE user_id = @user_id::uuid;", conn);
                    query.Parameters.AddWithValue("user_id", userID.ToString());
                    sqlReader = query.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
                try
                {
                    while (sqlReader.Read() == true)
                    {
                        Result temp = new Result();

                        temp.id = sqlReader.GetGuid(0);
                        temp.dateCreated = sqlReader.GetDateTime(1);
                        temp.userID = sqlReader.GetGuid(2);
                        temp.level = sqlReader.GetInt32(3);
                        temp.t = sqlReader.GetInt32(4);
                        temp.L = sqlReader.GetInt32(5);
                        temp.C = sqlReader.GetInt32(6);
                        temp.n = sqlReader.GetInt32(7);
                        temp.S = sqlReader.GetInt32(8);
                        temp.P = sqlReader.GetInt32(9);
                        temp.O = sqlReader.GetInt32(10);

                        listRes.Add(temp);
                    }
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Загрузка всех результатов всех пользователей
        public bool loadResultsAllUsers(out List<Result> listRes, out string errorMessage)
        {
            listRes = new List<Result>();
            errorMessage = "";
            NpgsqlConnection conn = null;
            try
            {
                if (this.openConnection(Database.connectionString, out conn, out string message) == false)
                {
                    throw new Exception(message);
                }

                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, created_date, user_id, level, t, l, c, n, s, p, o FROM public.results ORDER BY created_date DESC;", conn);
                    sqlReader = query.ExecuteReader();
                }
                catch (Exception error)
                {
                    throw new Exception("Ошибка доступа к базе данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
                try
                {
                    while (sqlReader.Read() == true)
                    {
                        Result temp = new Result();

                        temp.id = sqlReader.GetGuid(0);
                        temp.dateCreated = sqlReader.GetDateTime(1);
                        temp.userID = sqlReader.GetGuid(2);
                        temp.level = sqlReader.GetInt32(3);
                        temp.t = sqlReader.GetInt32(4);
                        temp.L = sqlReader.GetInt32(5);
                        temp.C = sqlReader.GetInt32(6);
                        temp.n = sqlReader.GetInt32(7);
                        temp.S = sqlReader.GetInt32(8);
                        temp.P = sqlReader.GetInt32(9);
                        temp.O = sqlReader.GetInt32(10);

                        listRes.Add(temp);
                    }
                    if (conn != null) conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Ошибка получения данных из базы данных при выполнении sql-запроса!\nПожалуйста, повторите попытку позже...");
                }
            }
            catch (Exception error)
            {
                if (conn != null) conn.Close();
                errorMessage = error.Message;
                return false;
            }
        }

        // Сохранение результата локально в файл
        public bool saveResultFile(string path, Result res, out string errorMessage)
        {
            errorMessage = "";
            string strSave = "";
            string symb = "=";

            try
            {
                strSave += res.id.ToString() + symb;
                strSave += res.dateCreated.ToString() + symb;
                strSave += res.userID.ToString() + symb;
                strSave += res.level + "=";
                strSave += res.t + symb;
                strSave += res.L + symb;
                strSave += res.C + symb;
                strSave += res.n + symb;
                strSave += res.S + symb;
                strSave += res.P + symb;
                strSave += res.O;

                System.IO.File.WriteAllText(path, strSave, Encoding.UTF8);
                errorMessage = "Результат успешно записан в файл:\n" + path;
                return true;
            }
            catch (Exception error)
            {
                errorMessage = "Не удалось сохранить результат в файл локально.\n" + error.Message;
                return false;
            }
        }

        // Загрузка результата из файла
        public bool readResultFile(string path, out Result res, out string errorMessage)
        {
            errorMessage = "";
            res = new Result();
            string strRead = "";
            char symb = '=';
            string[] words;

            try
            {
                strRead = System.IO.File.ReadAllText(path, Encoding.UTF8);
                words = strRead.Split(new char[] { symb }, StringSplitOptions.RemoveEmptyEntries);
                res.id = Guid.Parse(words[0]);
                res.dateCreated = DateTime.Parse(words[1]);
                res.userID = Guid.Parse(words[2]);
                res.level = Convert.ToInt32(words[3]);
                res.t = Convert.ToInt32(words[4]);
                res.L = Convert.ToInt32(words[5]);
                res.C = Convert.ToInt32(words[6]);
                res.n = Convert.ToInt32(words[7]);
                res.S = Convert.ToInt32(words[8]);
                res.P = Convert.ToInt32(words[9]);
                res.O = Convert.ToInt32(words[10]);

                return true;
            }
            catch (Exception error)
            {
                errorMessage = "Не удалось загрузить результат из файл, возможно он поврежден.\n" + error.Message;
                return false;
            }
        }
    }
}
