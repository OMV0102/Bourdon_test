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
    public partial class Form_authorization : Form
    {
        public Form_authorization()
        {
            InitializeComponent();
        }

        // При загрузке приложения
        private void Form_log_in_Load(object sender, EventArgs e)
        {
            checkBox_showPassword.Checked = false; // пароль скрыт по умолчанию
        }

        // кнопка ВХОД
        private void btn_entry_Click(object sender, EventArgs e)
        {
            this.btn_entry.Enabled = false;
            this.Cursor = Cursors.AppStarting;
            txt_login.Enabled = false;
            txt_password.Enabled = false;
            Database db;
            int resultAuthorization = 0; 
            try
            {
                db = new Database();
                resultAuthorization = db.authorization(txt_login.Text, txt_password.Text, out string errorMessage, out User userObject);
                
                if (resultAuthorization == 0) // код ошибки или неверного пароля
                {
                    throw new Exception(errorMessage);
                }
                else if(resultAuthorization == 1) // вход как пользователь
                {
                    Form_menu_user formUser = new Form_menu_user(userObject);
                    formUser.Show(this);
                    this.Hide();
                }
                else if (resultAuthorization == 2) // если есть права администратора
                {
                    string text = "Вы имеете права администратора. Войти как админиcтратор?\n\nДА - войти как администратор\nНЕТ- войти как пользователь";
                    DialogResult answer = MessageBox.Show(text, "Выбор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if(answer == DialogResult.Yes) // войти как администратор
                    {
                        Form_menu_admin formAdmin = new Form_menu_admin(userObject);
                        formAdmin.Show(this);
                        this.Hide();
                    }
                    else if (answer == DialogResult.No) // войти как пользователь
                    {
                        Form_menu_user formUser = new Form_menu_user(userObject);
                        formUser.Show(this);
                        this.Hide();
                    }
                }
                this.btn_entry.Enabled = true;
                this.Cursor = Cursors.Arrow;
                txt_login.Enabled = true;
                txt_password.Enabled = true;
                txt_password.Text = "";
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.btn_entry.Enabled = true;
                this.Cursor = Cursors.Arrow;
                txt_login.Enabled = true;
                txt_password.Enabled = true;
                txt_password.Text = "";
                return;
            }
        }

        // Пароль показать
        private void checkBox_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox_showPassword.Checked == true)
            {
                this.txt_password.UseSystemPasswordChar = false;
                this.checkBox_showPassword.Text = "Пароль виден";
            }
            else
            {
                this.txt_password.UseSystemPasswordChar = true;
                this.checkBox_showPassword.Text = "Пароль скрыт";
            }
        }

        // отладочная кнопка  // выключена для пользователей (visible = false)
        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                NpgsqlConnection conn = new NpgsqlConnection(global.connectionString);
                try
                {
                    conn.Open();
                }
                catch(Exception err)
                {
                    MessageBox.Show("Не удалось установить соединение с базой данных!\nПожалуйста, повторите попытку позже...", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                NpgsqlCommand n = new NpgsqlCommand("INSERT INTO pmib6602.users (id, login, password, role) VALUES (pmib6602.get_uuid(),  @login, @password, @role);", conn);

                n.Parameters.AddWithValue("login", "orlov"); // логин
                n.Parameters.AddWithValue("password", Database.getHash("orlov")); // пароль
                n.Parameters.AddWithValue("role", "user premium"); // роль

                var sqlReader = n.ExecuteNonQuery();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }*/
        }
    }
}
