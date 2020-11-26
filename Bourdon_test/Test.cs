using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using System.Numerics;
using System.Collections;
using System.Windows.Forms;

namespace Bourdon_test
{
    class Test
    {
        public DataTable table;
        public List<int> arrayDigit;
        public Results result = new Results();

        // генерация таблицы типа DataTable
        public DataTable generateTable(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); // объект класса генератора псевдослучайных чисел
            table = new DataTable();
            table.Clear();
            table.Columns.Clear();
            table.Rows.Clear();

            for(int i = 0; i < size; i++)
            {
                table.Columns.Add();
                table.Columns[i].ReadOnly = true; // только чтение
            }
            for (int i = 0; i < size; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < size; j++)
                {
                    int digitRandom = this.PRNG(0, 10, rng);
                    if (this.arrayDigit.Contains(digitRandom) == true)
                        this.result.L++;
                    row[j] = digitRandom;
                }
                table.Rows.Add(row);
            }

            return table;
        }

        // генерация списка размера dim с неповторяющимися цифрами
        public List<int> generateListDigit(int dim)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); // объект класса генератора псевдослучайных чисел
            // список возможных цифр
            List<int> digits = new List<int>(); ;
            for (int i = 1; i < 10; i++)
            {
                digits.Add(i);
            }

            arrayDigit = new List<int>();
            for(int i = 0; i < dim; i++)
            {
                int digitsIndex = this.PRNG(1, digits.Count, rng);
                arrayDigit.Add(digits[digitsIndex]);
                digits.RemoveAt(digitsIndex);
            }
            return arrayDigit;
        }

        // Генератор случайного числа
        //       min включается в промежуток, max НЕ включается
        //       Использовать ТОЛЬКО , если выделена память для rng
        //       min обязательно меньше max
        private int PRNG(Int64 min, Int64 max, RNGCryptoServiceProvider rng)
        {
            Int64 result64 = 0;
            int result = 0;
            if (rng != null || min < max)
            {
                byte[] b = new byte[7]; // Место под 7 байт числа
                rng.GetBytes(b); // Сгенерировали случайны байты
                BitArray bits = new BitArray(b); // Байты в биты
                result64 = this.binToDec(bits); // Из битов в число 
                result64 = result64 % (max - min) + min; // Сделали число в нужном промежутке
                result = Convert.ToInt32(result64);
            }
            return result;
        }

        // Перевод из двоичного числа (иассив бит) в число десятичное 
        // Используется в PRNG
        private Int64 binToDec(BitArray bits_in)
        {
            BitArray b = new BitArray(bits_in);
            Int64 result = 0;
            int N = b.Length;
            for (int i = N - 1; i >= 0; i--)
            {
                if (b[i] == true)
                {
                    result += Convert.ToInt64(Math.Pow(2, N - 1 - i));
                }
            }
            return result;
        }
    }
}
