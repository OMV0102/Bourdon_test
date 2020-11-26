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
    public partial class Form_rules : Form
    {
        public Form_rules(Guid id)
        {
            InitializeComponent();
            this.iserID = id;
        }

        private readonly Guid iserID;

        // кнопка Назад
        private void btnBack_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }

        // кнопка Начать тестирование
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            int difficult = boxDifficulty.SelectedIndex + 1;
            Form_test form = new Form_test(iserID, boxDifficulty.SelectedIndex + 1);
            form.Show(this.Owner); // родительская форма - меню пользователя
            this.Close();
        }

        // перетаскивание окна по экрану
        private void Form_rules_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        // при загрузке формы
        private void Form_rules_Load(object sender, EventArgs e)
        {
            boxDifficulty.SelectedIndex = 2;
        }

        // при выборе уровня сложности в выпадающем списке
        private void boxDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int level = boxDifficulty.SelectedIndex + 1;
            int size = level * 10;
            string strNumeric = "";

            if(level == 1)
                strNumeric = "некоторую одну цифру, какую";
            else if (level == 2)
                strNumeric = "некоторые две цифры, какие";
            else if (level == 3)
                strNumeric = "некоторые три цифры, какие";

            txtRules.Text = "";
            txtRules.Text += "Размер: " + size + " на " + size +"; Количество цифр для поиска: " + (boxDifficulty.SelectedIndex + 1) + ".\n";
            txtRules.Text += "\t\t\t\t\t\tПодробнее:\n";
            txtRules.Text += "* В ходе данного тестирования вам будет предложена одна таблица с " + size + " строками, по " + size + " цифр в каждой.\n";
            txtRules.Text += "* Вы должны находить и отмечать " + strNumeric + " именно, вам будет сообщено далее на окне тестирования.\n";
            txtRules.Text += "* Вам необходимо работать как можно быстрее и отмечать только приведенные цифры. Выбор цифры осуществляется путем клика по ячейке таблицы.\n";
            txtRules.Text += "* Просматривать таблицу следует построчно, слева-направо. Возврат по тесту назад невозможен. Выбранные и пропущенные вами ячейки становятся неактивными.\n";
            txtRules.Text += "* При каждом выборе цифры будет изменяться статус на \"Верно\" или \"НЕверно\".\n";
            txtRules.Text += "  Ошибками являются:  1) пропущенные цифры, которые нужно отметить;\n\t\t\t\t2) выбранные цифры, которые нужно пропускать;";
        }
    }
}
