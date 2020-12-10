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
                        item += listUsers[i].surname + " " + listUsers[i].name[0] + ".";
                    else
                        item += listUsers[i].surname + " " + listUsers[i].name[0] + "." + listUsers[i].patronymic[0] + ".";
                    item += "\t";
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
