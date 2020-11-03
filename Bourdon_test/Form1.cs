using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Bourdon_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string str1 = "27.07.1998";
            string str2 = "05.04.2045";
            string strDateCheck = textBox1.Text;

            var d1 = DateTime.Parse(str1);
            var d2 = DateTime.Parse(str2);
            var dCheck = DateTime.Parse(strDateCheck);

            if (d1 < dCheck && dCheck < d2)
                label.Text = "ДА";
            else
                label.Text = "НЕТ";

        }
    }
}
