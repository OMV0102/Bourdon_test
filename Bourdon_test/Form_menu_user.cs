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
    public partial class Form_menu_user : Form
    {
        public Form_menu_user(User userObject)
        {
            InitializeComponent();
            this.user = userObject;
        }

        private User user;

        // загрузка формы
        private void Form_menu_user_Load(object sender, EventArgs e)
        {
            lblName.Text = this.user.surname + " " + this.user.name[0] + ".";
            if (this.user.patronymic != String.Empty) lblName.Text += this.user.patronymic[0] + ".";
        }

        // перетаскивание окна по экрану
        private void Form_menu_user_MouseDown(object sender, MouseEventArgs e)
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

        //кнопка Пройти Тест
        private void btnTest_Click(object sender, EventArgs e)
        {
            Form_test formTest = new Form_test(user, 3);
            formTest.Show(this);
            this.Hide();
        }
    }
}
