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
    public partial class FormUsersAllShow : Form
    {
        public FormUsersAllShow()
        {
            InitializeComponent();
        }

        private List<User> listUsers;

        // кнопка Назад
        private void btnBack_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }

        // при загрузке формы
        private void FormUsersAllShow_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            bool res = db.loadAllUsers(out this.listUsers, out string message);

            if (res == false) // Если ошибка то закрываем форму с выводом сообщения
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btnBack.PerformClick(); // назад
            }
            else
            {
                int dim = this.listUsers.Count;
                string item = "";
                for (int i = 0; i < dim; i++)
                {
                    // добавляем пользователя в список
                    item = listUsers[i].login + "\t";
                    if (listUsers[i].patronymic == "")
                        item += listUsers[i].surname + " " + listUsers[i].name[0] + "." + "\t\t";
                    else
                        item += listUsers[i].surname + " " + listUsers[i].name[0] + "." + listUsers[i].patronymic[0] + "." + "\t";
                    if(listUsers[i].gender == true)
                        item += "м";
                    else
                        item += "ж";
                    this.listBoxUsers.Items.Add(item);
                }
            }
        }

        // при выборе пользователя двойным щелчком
        private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxUsers.SelectedIndex;

            Form_register_user form = new Form_register_user(this.listUsers[index], false);
            form.ShowDialog(this);
            User tempUser = form.getUserChange();
            string item = "";
            // добавляем пользователя в список
            item = tempUser.login + "\t";
            if (tempUser.patronymic == "")
                item += tempUser.surname + " " + tempUser.name[0] + "." + "\t\t";
            else
                item += tempUser.surname + " " + tempUser.name[0] + "." + tempUser.patronymic[0] + "." + "\t";
            if (tempUser.gender == true)
                item += "м";
            else
                item += "ж";
            this.listBoxUsers.Items.Insert(index, item);
            this.listBoxUsers.Items.RemoveAt(index+1);
        }

        // перетаксивание формы
        private void FormUsersAllShow_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
