using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bourdon_test
{
    public partial class Form_register_user : Form
    {
        public Form_register_user()
        {
            InitializeComponent();
            this.idCreatedBy = Guid.Empty;
        }

        public Form_register_user(Guid adminID, bool isRegOrEdit)
        {
            this.idCreatedBy = adminID;
            this.regOrEdit = isRegOrEdit;
            InitializeComponent();
        }

        public Form_register_user(bool isRegOrEdit)
        {
            this.regOrEdit = isRegOrEdit;
            InitializeComponent();
        }

        public Form_register_user(User userObject, bool isRegOrEdit)
        {
            this.user = userObject;
            this.regOrEdit = isRegOrEdit;
            InitializeComponent();
        }

        private Guid idCreatedBy = Guid.Empty;
        private bool regOrEdit;
        private User user;

        //при загрузке формы
        private void Form_register_user_Load(object sender, EventArgs e)
        {
            if(this.regOrEdit == false)
            {
                txtLogin.Text = user.login;
                txtSurname.Text = user.surname;
                txtName.Text = user.name;
                txtPatronymic.Text = user.patronymic;
                txtBirthday.Value = user.birthday;
                if (user.gender == true)
                    txtGender.SelectedItem = "м";
                else if (user.gender == false)
                    txtGender.SelectedItem = "ж";
                txtEmail.Text = user.email;
                txtPosition.Text = user.position;
                txtOrganization.Text = user.organization;
            }
            else
                txtGender.SelectedIndex = 0;
        }

        private void Form_register_user_MouseDown(object sender, MouseEventArgs e)
        {
            // перетаскивание окна по экрану
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        //кнопка Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }

        //кнопка Сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == String.Empty)
                MessageBox.Show("Не заполнено поле \"Логин\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            else if (txtSurname.Text == String.Empty)
                MessageBox.Show("Не заполнено поле \"Фамилия\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            else if (txtName.Text == String.Empty)
                MessageBox.Show("Не заполнено поле \"Имя\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            else if (txtBirthday.Value > DateTime.Now)
                MessageBox.Show("Дата рождения должна быть не позже текущей даты!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            else
            {
                Database db = new Database();
                User user1;
                if (this.regOrEdit == true)
                    user1 = new User(this.idCreatedBy);
                else
                    user1 = this.user;
                user1.id = Guid.NewGuid();
                user1.login = txtLogin.Text;
                user1.surname = txtSurname.Text;
                user1.name = txtName.Text;
                user1.patronymic = txtPatronymic.Text;
                user1.birthday = txtBirthday.Value;
                if (txtGender.SelectedItem.ToString() == "м")
                    user1.gender = true;
                else if(txtGender.SelectedItem.ToString() == "ж")
                    user1.gender = false;
                user1.email = txtEmail.Text;
                if (this.regOrEdit == true)
                    if(txtPassword.Text == "")
                        user1.passwordHash = db.getHash(user1.login);
                    else
                        user1.passwordHash = db.getHash(txtPassword.Text);
                else
                    if(txtPassword.Text != "") user1.passwordHash = db.getHash(txtPassword.Text);
                user1.position = txtPosition.Text;
                user1.organization = txtOrganization.Text;
                if (user1.createdBy == Guid.Empty)
                    user1.createdBy = user.id;


                if (this.regOrEdit == true)
                {
                    bool result = db.registerNewUser(user1, out string message);

                    if (result)
                    {
                        MessageBox.Show("Пользователь успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        var form = this.Owner;
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении нового пользователя:\n" + message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    bool result = db.editUser(user1, out string message);
                    if (result)
                    {
                        MessageBox.Show("Информация успешно обновлена!", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        var form = this.Owner;
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при сохранении информации пользователя:\n" + message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }




        }
    }
}
