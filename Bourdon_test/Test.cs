using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Bourdon_test
{
    class Test
    {
        DataTable table;

        void fff()
        {
            table = new DataTable("Альтернативы и оценки");
            table.Clear();
            table.Columns.Clear();
            table.Rows.Clear();

            table.Columns.Add(new DataColumn("Альтернатива"));
            table.Columns[0].ReadOnly = true; // альтернативы можно только смотреть
            table.Columns.Add(new DataColumn("Оценка"));

            for (int j = 0; j < list_sol.Count; j++)
            {
                DataRow dr = table.NewRow();
                dr[0] = list_sol[j];
                dr[1] = tmp[j];
                table.Rows.Add(dr);
            }

            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 600; // ширина столбца альтерантив
            dataGridView1.Columns[1].Width = 97; // ширина столбца оценок
                                                 // шобы столбцы нельзя было сортировать
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

    }
}
