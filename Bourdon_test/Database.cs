﻿using System;
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
                if (this.openConnection(Database.connectionString, out conn, out errorMessage) == false)
                {
                    throw new Exception(errorMessage);
                }
                NpgsqlCommand query = null;
                NpgsqlDataReader sqlReader = null;
                try
                {
                    query = new NpgsqlCommand("SELECT id, login, surname, name, patronymic, birthday, sex, role, email, password, organization FROM public.users WHERE TRIM(login) = TRIM(@login);", conn);
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
                            userObject.sex = sqlReader.GetBoolean(6);
                            userObject.role = sqlReader.GetString(7);
                            userObject.email = sqlReader.GetString(8);
                            userObject.organization = sqlReader.GetString(10);

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
                conn = null;
                if(conn != null) conn.Close();
                errorMessage = error.Message;
                return 0;
            }
            
            return 0;
        }
    }
}
