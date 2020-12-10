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
    public partial class FormResultsAll : Form
    {
        public FormResultsAll()
        {
            InitializeComponent();
        }

        List<Result> listResults;
        List<User> listUsers;

        // кнопка Назад
        private void btnBack_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }

        // при загрузке формы
        private void FormResultsAll_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            bool res1 = db.loadResultsAllUsers(out this.listResults, out string message1);
            bool res2 = db.loadAllUsers(out this.listUsers, out string message2);

            if (res1 == false) // Если ошибка то закрываем форму с выводом сообщения
            {
                MessageBox.Show(message1, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btnBack.PerformClick(); // назад
            }
            else if (res2 == false) // Если ошибка то закрываем форму с выводом сообщения
            {
                MessageBox.Show(message2, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btnBack.PerformClick(); // назад
            }
            else
            {
                int dim = this.listResults.Count;
                string item = "";
                for (int i = 0; i < dim; i++)
                {
                    User findUser = this.findUserInList(listResults[i].userID);
                    // выводим дату/время,уровень, секунды
                    item = listResults[i].dateCreated.ToShortDateString() + "  " + listResults[i].dateCreated.ToShortTimeString() + "\t";
                    if (findUser.patronymic == "")
                        item += findUser.surname + " " + findUser.name[0] + "." + "\t\t";
                    else
                        item += findUser.surname + " " + findUser.name[0] + "." + findUser.patronymic[0] + "." + "\t";
                    item += listResults[i].level + "\t" + listResults[i].t;
                    this.listBoxResultsAll.Items.Add(item);
                }
            }
        }

        // поиск пользователя в списке по id
        private User findUserInList(Guid idUser)
        {
            bool isFind = false;
            int n = this.listUsers.Count;
            int i = 0;
            User findUser = null;
            while (isFind == false && i < n)
            {
                if (this.listUsers[i].id == idUser)
                {
                    findUser = this.listUsers[i];
                    isFind = true;
                }
                i++;
            }
            return findUser;
        }

        // перетаксивание формы
        private void FormResultsAll_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        // при выборе результата двойным щелчком мыши
        private void listBoxResultsAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxResultsAll.SelectedIndex;

            string fio = "";
            User findUser = this.findUserInList(listResults[index].userID);
            if (findUser.patronymic == "")
                fio = findUser.surname + " " + findUser.name[0] + ".";
            else
                fio = findUser.surname + " " + findUser.name[0] + "." + findUser.patronymic[0] + ".";

            Form_result form = new Form_result(this.listResults[index], fio, false);
            form.ShowDialog(this);
        }
    }
}
