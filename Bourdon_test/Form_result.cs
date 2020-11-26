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
        public Form_result(Guid id, Results res, bool saveOrNot)
        {
            InitializeComponent();
            this.iserID = id;
            this.results = res;
            this.isNeedSave = saveOrNot;
        }

        private readonly Guid iserID;
        private Results results;
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

        }
    }
}
