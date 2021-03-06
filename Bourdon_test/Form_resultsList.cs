﻿using System;
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
    public partial class Form_resultsList : Form
    {
        public Form_resultsList(Guid id)
        {
            InitializeComponent();
            this.userID = id;
        }

        private readonly Guid userID;
        private List<Result> listResults;

        // перетаскивание формы по экрану
        private void Form_resultsList_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        // при загрузке формы
        private void Form_resultsList_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            bool res = db.loadResultsUser(this.userID, out this.listResults, out string message);

            if(res == false) // Если ошибка то закрываем форму с выводом сообщения
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btnBack.PerformClick(); // назад
            }
            else
            {
                int dim = this.listResults.Count;
                string item = "";
                for(int i = 0; i < dim; i++)
                {
                    // выводим дату/время,уровень, секунды
                    item = listResults[i].dateCreated.ToShortDateString() + "  " + listResults[i].dateCreated.ToShortTimeString() + "\t" + listResults[i].level + "\t\t" + listResults[i].t;
                    this.listBox.Items.Add(item);
                }
            }
        }

        // кнопка Назад
        private void btnBack_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }

        // при выборе элемента в списке двойным щелчком
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox.SelectedIndex;

            Form_result form = new Form_result(this.listResults[index], false);
            form.ShowDialog(this);
        }
    }
}
