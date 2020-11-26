using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourdon_test
{
    public class Result
    {
        public int t; // потраченое время в секундах
        public int L; // общее количество просмотренных до последнего выбранного
        public int C = 0; // число просмотренных строк
        public int n = 0; // общее количество, сколько нужно было выбрать ячеек

        public int S; // число верно выбранных
        public int P; // число пропущенных, которые нужно было выбрать
        public int O; // число ошибочно выбранных

        public Guid id = Guid.Empty;
        public DateTime dateCreated = DateTime.Parse("01.01.1970");
        public Guid userID = Guid.Empty;

        public int M() // общее число выбранных символов (S + O)
        {
            return this.S + this.O;
        }
    }
}
