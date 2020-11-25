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
    public partial class Form_test : Form
    {
        public Form_test(User userObject)
        {
            InitializeComponent();
            this.user = userObject;
        }

        private User user;
        private Test test;

        // перетаскивание окна по экрану
        private void Form_test_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        // при загрузке формы
        private void Form_test_Load(object sender, EventArgs e)
        {
            test = new Test();
            grid.DataSource = test.generateTable(3);
            //dataGridView1.Columns[0].Width = 600; // ширина столбца альтерантив
            //dataGridView1.Columns[1].Width = 97; // ширина столбца оценок
            //                                     // шобы столбцы нельзя было сортировать

            for(int i = 0; i < grid.Columns.Count; i++)
            {
                //grid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // при нажатии на ячейку
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            for(int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {

                }

            for (int j = 0; j < col; j++)
            {
                grid.Rows[row].Cells[j].
            }
        }
    }
}
