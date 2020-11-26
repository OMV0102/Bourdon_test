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
    public partial class Form_result : Form
    {
        public Form_result(Result res, bool saveOrNot)
        {
            InitializeComponent();
            this.result = res;
            this.isNeedSave = saveOrNot;
        }

        private Result result;
        private bool isNeedSave;

        // перетаскивание окна по экрану
        private void Form_result_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        
        // при загрузке формы
        private void Form_result_Load(object sender, EventArgs e)
        {
            // вывод результатат на экран


            // если форма открылась сразу после теста, то нудно сохранить в БД
            if(this.isNeedSave == true)
            {
                Database db = new Database();
                db.saveResult(this.result, out string message); 
            }
        }

        // кнопка Закрыть
        private void btnExit_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }
    }
}
