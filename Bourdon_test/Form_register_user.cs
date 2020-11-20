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

        public Form_register_user(Guid adminID)
        {
            this.idCreatedBy = adminID;
            InitializeComponent();
        }

        private Guid idCreatedBy = Guid.Empty;

        //при загрузке формы
        private void Form_register_user_Load(object sender, EventArgs e)
        {
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
                User user = new User(this.idCreatedBy);
                user.login = txtLogin.Text;
                user.name = txtSurname.Text;
                user.surname = txtName.Text;
                user.patronymic = txtPatronymic.Text;
                user.birthday = txtBirthday.Value;
                if (txtGender.SelectedItem.ToString() == "м") 
                    user.gender = true;
                else if(txtGender.SelectedItem.ToString() == "ж")
                    user.gender = false;
                user.email = txtEmail.Text;
                user.position = txtPosition.Text;
                user.organization = txtOrganization.Text;

                Database db = new Database();
                bool result = db.registerNewUser(user, out string message);

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




        }
    }
}
