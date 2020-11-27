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
            // вывод результата на экран
            this.labelDateCreated.Text = result.dateCreated.ToShortDateString() + result.dateCreated.ToShortTimeString();
            this.labelt.Text = result.t.ToString() + " сек.";
            this.labelS.Text = result.S.ToString() + " зн.";
            this.labelO.Text = result.O.ToString() + " зн.";
            this.labelP.Text = result.P.ToString() + " зн.";

            this.labelA.Text = result.A().ToString() + " зн./сек.";
            this.labelT2.Text = result.T2().ToString();
            this.labelE.Text = result.E().ToString() +" зн.";
            this.labelAu.Text = result.Au().ToString() + " зн./сек.";
            this.labelK.Text = result.K().ToString() + " %";

            this.txtInterpretation.Text = result.getInterpretation();

            // если форма открылась сразу после теста, то нужно сохранить в БД
            if (this.isNeedSave == true)
            {
                bool result = false;
                DialogResult dres;
                Database db = new Database();
                do
                {
                    result = db.saveResult(this.result, out string message);
                    if (result == false)
                    {
                        dres = MessageBox.Show("Результат не удалось сохранить удаленно в базу данных.\n\t\"Повторить\" - еще раз попробовать загрузить в базу данных;\n\t\"Отмена\" - сохранить результат локально на компьютер;", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if(dres == DialogResult.Cancel) // сохранить локально
                        {
                            SaveFileDialog sfd = new SaveFileDialog();
                            sfd.Title = "Сохранить результат как...";
                            sfd.DefaultExt = "br"; // расширение файла
                            sfd.InitialDirectory = Application.StartupPath; // начальная папка
                            sfd.Filter = "Text files(*.br)|*.br"; // сохранять только как специальный формат
                            sfd.AddExtension = true;  // добавить расширение к имени если не указали

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                // получаем выбранный файл
                                string filename = sfd.FileName;
                                bool resSRF = db.saveResultFile(filename, this.result, out string sfdMessage);
                                if (resSRF == true)
                                {
                                    MessageBox.Show(sfdMessage, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                    result = true;
                                }
                                else
                                    MessageBox.Show(sfdMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                            sfd.Dispose();
                        }
                    }
                    else
                        MessageBox.Show("Результат теста успешно сохранен в базу данных.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                while (result == false);
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
