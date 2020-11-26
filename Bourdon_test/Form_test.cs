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
        public Form_test(Guid id, int difficulty)
        {
            InitializeComponent();
            this.iserID = id;
            this.size = difficulty * 10;
            this.level = difficulty;
        }

        private readonly Guid iserID;
        private Test test;
        private bool[,] arrayCellSelected; // массив выбора ячеек
        private List<int> arrayDigit; // список цифр, которые нужно отмечать
        private int colLastCell = 0;
        private int rowLastCell = 0;
        private readonly int size;
        private readonly int level;

        private int seconds;
        private int timerInterval;
        private bool isPaused;


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
            this.test = new Test();
            grid.DataSource = test.generateTable(size); // генерация таблицы и заполнения грида

            // список цифр, котрые нужно отмечать
            this.arrayDigit = test.generateListDigit(this.level);
            for (int i = 0; i < arrayDigit.Count; i++)
                this.labelDigits.Text += arrayDigit[i].ToString() + "  ";

            // просчет размера грида и ячеек
            int cellWidth = 25; // ширина ячейки
            int cellHeight = 22; // высота ячейки
            int heightTop = 130; // Высота пространства над гридом
            int widthMargin = 10; // отступы от края формы

            this.Width = widthMargin + widthMargin + size* cellWidth + 3; // ширина формы
            this.Height = heightTop + widthMargin + widthMargin + size*cellHeight + 3; // высота формы
            grid.RowTemplate.Height = cellHeight; // высота ячейки
            Point p = grid.Location; p.X = widthMargin; p.Y = heightTop; grid.Location = p; // начальное положение грида
            grid.Width = size * cellWidth + 3; // ширина грида
            grid.Height = size * cellHeight + 2; // высота грида
            this.CenterToScreen(); // форму по центру экрана после изменения размеров

            for (int j = 0; j < grid.Columns.Count; j++) // выставление параметров для ячеек
            {
                grid.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable; // НЕсортирумые столбцы
                grid.Columns[j].Width = cellWidth; // ширина ячейки
                for (int i = 0; i < grid.Rows.Count; i++)
                    grid.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // цифра по центру ячейки
            }

            // массив выбора ячеек
            arrayCellSelected = new bool[size, size];
            for (int i = 0; i < grid.Columns.Count; i++)
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    arrayCellSelected[i, j] = false;
                }

            // установки таймера
            if (this.level == 1) timerInterval = 1;
            else timerInterval = 5; // интервал тика в сек
            timer.Interval = timerInterval * 1000; // интервал тика в мс
            this.isPaused = false; // паузы нет
            timer.Start(); // запуск таймера
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
                    arrayCellSelected[i, j] = true;
                    grid.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    grid.Rows[i].Cells[j].Style.ForeColor = Color.DarkGray;
                }

            // закрасить все ячейки вместе с выбранной ячейки в строке 
            for (int j = 0; j < col+1; j++)
            {
                arrayCellSelected[row, j] = true; 
                grid.Rows[row].Cells[j].Style.BackColor = Color.LightGray;
                grid.Rows[row].Cells[j].Style.ForeColor = Color.DarkGray;
            }
            this.colLastCell = col;
            this.rowLastCell = row;
        }

        // кнопка Пауза
        private void btnPause_Click(object sender, EventArgs e)
        {
            if(isPaused == false) // если паузы нет
            {
                timer.Stop();
                btnPause.Text = "Продолжить";
                grid.Visible = false;
                isPaused = true;
            }
            else
            {
                btnPause.Text = "Пауза";
                grid.Visible = true;
                isPaused = false;
                timer.Start();
            }
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

        // событие при каждом тике таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            seconds += this.timerInterval;

            TimeSpan span = TimeSpan.FromSeconds(seconds);
            labelTime.Text = span.ToString(@"mm\:ss");
        }
    }
}
