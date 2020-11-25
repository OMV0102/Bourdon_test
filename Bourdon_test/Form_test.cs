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
        public Form_test(User userObject, int difficulty)
        {
            InitializeComponent();
            this.user = userObject;
            this.size = difficulty * 10;
        }

        private readonly User user;
        private Test test;
        private bool[,] gridCellSelected;
        private int colLastCell = 0;
        private int rowLastCell = 0;
        private readonly int size;

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
            grid.DataSource = test.generateTable(size);
            // просчет размера грида и ячеек
            int cellWidth = 25;
            this.Width = 10 + 10 + size* cellWidth + grid.RowTemplate.DividerHeight*(size-1);
            this.Height = 800;


            

            for (int j = 0; j < grid.Columns.Count; j++)
            {
                grid.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid.Columns[j].Width = cellWidth;
                for (int i = 0; i < grid.Rows.Count; i++)
                    grid.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            gridCellSelected = new bool[size, size];
            for (int i = 0; i < grid.Columns.Count; i++)
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    gridCellSelected[i, j] = false;
                }
        }

        // кнопка Выход
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // при нажатии на ячейку
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            int n = grid.Columns.Count;

            // закрасить все ячейки после предыдущей до строки с выбранной ячейкой
            for (int i = rowLastCell; i < row; i++)
                for (int j = 0; j < n; j++)
                {
                    gridCellSelected[i, j] = true;
                    grid.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    grid.Rows[i].Cells[j].Style.ForeColor = Color.DarkGray;
                }

            // закрасить все ячейки вместе с выбранной ячейки в строке 
            for (int j = 0; j < col+1; j++)
            {
                gridCellSelected[row, j] = true; 
                grid.Rows[row].Cells[j].Style.BackColor = Color.LightGray;
                grid.Rows[row].Cells[j].Style.ForeColor = Color.DarkGray;
            }
            this.colLastCell = col;
            this.rowLastCell = row;
        }

        // кнопка Пауза
        private void btnPause_Click(object sender, EventArgs e)
        {
            grid.Visible = false;
        }
        
        // при выборе ячейки не подсвечивать ее
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }
    }
}
