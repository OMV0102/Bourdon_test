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

        // кнопка Назад
        private void btbBack_Click(object sender, EventArgs e)
        {
            var form = this.Owner;
            form.Show();
            this.Close();
        }

        // при загрузке формы
        private void FormResultsAll_Load(object sender, EventArgs e)
        {

        }
    }
}
