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
    public partial class Form_menu_admin : Form
    {
        public Form_menu_admin(User userObject)
        {
            InitializeComponent();
            this.user = userObject;
        }

        private User user;

        // Зарегестрировать пользователя
        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            Form_register_user formRegisterUser = new Form_register_user(user.id, true);
            formRegisterUser.Show(this);
            this.Hide();
        }

        // перетаскивание окна по экрану
        private void Form_menu_admin_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        // кнопка Выход
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Owner.Close();
        }

        // загрузка формы
        private void Form_menu_admin_Load(object sender, EventArgs e)
        {
            lblName.Text = this.user.surname + " " + this.user.name[0] + ".";
            if (this.user.patronymic != String.Empty) lblName.Text += this.user.patronymic[0] + ".";
        }

        //TODO // кнопка Просмотр всех результатов
        private void btnResultAllShow_Click(object sender, EventArgs e)
        {
            FormResultsAll form = new FormResultsAll();
            form.Show(this);
            this.Hide();

        }
    }
}
