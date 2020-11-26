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
        private int colLastCell = 0;
        private int rowLastCell = 0;
        private readonly int size;
        private readonly int level;

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
            if (level == 1) labelStatus.Visible = false; // при размере 1 не показывать галочку и крестик

            this.test = new Test(); // создание объекта класса теста
            // список цифр, которые нужно отмечать
            this.test.generateListDigit(this.level); // сгенерировали случайные цифры
            for (int i = 0; i < this.test.arrayDigit.Count; i++)
                this.labelDigits.Text += this.test.arrayDigit[i].ToString() + "  ";
            // таблица цифр
            grid.DataSource = test.generateTable(size); // генерация таблицы и заполнения грида

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
            this.test.result.t = 0; // 0 секунд при старте
            timer.Start(); // запуск таймера
        }

        // кнопка Закончить
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.test.result.t < this.timerInterval)
                this.test.result.t = this.timerInterval;

            this.test.result.C = this.rowLastCell + 1; // число просмотренных строк
            this.test.result.L = this.rowLastCell * grid.Columns.Count + this.colLastCell; // общее количество просмотренных до последнего выбранного

            // Форма отображения результата
            // true т.к. необходимо сохранение в БД
            Form_result form = new Form_result(this.iserID, this.test.result, true);
            form.Show(this.Owner);
            this.Close();
        }

        // при нажатии на ячейку
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            int n = grid.Columns.Count;

            // событие работает, если ячейка еще не была выбрана
            if (arrayCellSelected[row, col] == false)
            {
                // установка статуса
                if (labelStatus.Visible == true)
                    if (this.test.arrayDigit.Contains(Convert.ToInt32(grid.Rows[row].Cells[col].Value)) == true)
                    {
                        labelStatus.Text = "✔";
                        labelStatus.ForeColor = Color.Green;
                        this.test.result.S++; // +1 к верно выбранным
                    }
                    else
                    {
                        labelStatus.Text = "✖";
                        labelStatus.ForeColor = Color.Red;
                        this.test.result.O++; // +1 к ошибочно выбранным
                    }

                // если это нулевая ячейка и она не выбрана
                if (arrayCellSelected[0, 0] == false && (row != this.rowLastCell || col != 0))
                {
                    arrayCellSelected[0, 0] = true;
                    grid.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
                    grid.Rows[0].Cells[0].Style.ForeColor = Color.DarkGray;
                    // подсчет пропущенных, которые нужно отметить
                    if (this.test.arrayDigit.Contains(Convert.ToInt32(grid.Rows[0].Cells[0].Value)) == true)
                        this.test.result.P++;
                }

                if (row == this.rowLastCell) // если ячейка на той же строке что и прошлая
                {
                    // обработка ячеек если строка та же самая 
                    for (int j = colLastCell + 1; j < col; j++)
                    {
                        arrayCellSelected[row, j] = true;
                        grid.Rows[row].Cells[j].Style.BackColor = Color.LightGray;
                        grid.Rows[row].Cells[j].Style.ForeColor = Color.DarkGray;
                        // подсчет пропущенных, которые нужно отметить
                        if (this.test.arrayDigit.Contains(Convert.ToInt32(grid.Rows[row].Cells[j].Value)) == true)
                            this.test.result.P++;
                    }
                }
                else if (row > this.rowLastCell) // если ячейка на другой строке
                {
                    // обработка ячеек на строке прошлой ячейки 
                    for (int j = colLastCell + 1; j < n; j++)
                    {
                        arrayCellSelected[rowLastCell, j] = true;
                        grid.Rows[rowLastCell].Cells[j].Style.BackColor = Color.LightGray;
                        grid.Rows[rowLastCell].Cells[j].Style.ForeColor = Color.DarkGray;
                        // подсчет пропущенных, которые нужно отметить
                        if (this.test.arrayDigit.Contains(Convert.ToInt32(grid.Rows[rowLastCell].Cells[j].Value)) == true)
                            this.test.result.P++;
                    }

                    // закрасить все ячейки после предыдущей до строки с выбранной ячейкой
                    for (int i = rowLastCell+1; i < row; i++)
                        for (int j = 0; j < n; j++)
                        {
                            arrayCellSelected[i, j] = true;
                            grid.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                            grid.Rows[i].Cells[j].Style.ForeColor = Color.DarkGray;
                            // подсчет пропущенных, которые нужно отметить
                            if (this.test.arrayDigit.Contains(Convert.ToInt32(grid.Rows[i].Cells[j].Value)) == true)
                                this.test.result.P++;
                        }

                    // закрасить все ячейки в текущей строке без выбранной ячейки 
                    for (int j = 0; j < col; j++)
                    {
                        arrayCellSelected[row, j] = true;
                        grid.Rows[row].Cells[j].Style.BackColor = Color.LightGray;
                        grid.Rows[row].Cells[j].Style.ForeColor = Color.DarkGray;
                        // подсчет пропущенных, которые нужно отметить
                        if (this.test.arrayDigit.Contains(Convert.ToInt32(grid.Rows[row].Cells[j].Value)) == true)
                            this.test.result.P++;
                    }
                }
                // отдельная обработка самой выбранной ячейки
                arrayCellSelected[row, col] = true;
                grid.Rows[row].Cells[col].Style.BackColor = Color.LightGray;
                grid.Rows[row].Cells[col].Style.ForeColor = Color.DarkGray;

                this.colLastCell = col;
                this.rowLastCell = row;

            }
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
            test.result.t += this.timerInterval;

            TimeSpan span = TimeSpan.FromSeconds(test.result.t);
            labelTime.Text = span.ToString(@"mm\:ss");
        }
    }
}
