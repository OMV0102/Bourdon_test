using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using System.Numerics;
using System.Collections;

namespace Bourdon_test
{
    class Test
    {
        public DataTable generateTable(int difficulty)
        {
            int size = difficulty * 10;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();// объект класса генератора псевдослучайных чисел
            DataTable table = new DataTable();
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
                for(int j = 0; j < size; j++)
                    row[j] = this.PRNG(0, 10, rng);
                table.Rows.Add(row);
            }

            return table;
        }

        // Генератор случайного числа
        //       min включается в промежуток, max НЕ включается
        //       Использовать ТОЛЬКО , если выделена память для rng
        //       min обязательно меньше max
        private Int64 PRNG(Int64 min, Int64 max, RNGCryptoServiceProvider rng)
        {
            Int64 result = 0;
            if (rng != null || min < max)
            {
                byte[] b = new byte[7]; // Место под 7 байт числа
                rng.GetBytes(b); // Сгенерировали случайны байты
                BitArray bits = new BitArray(b); // Байты в биты
                result = this.binToDec(bits); // Из битов в число 
                result = result % (max - min) + min; // Сделали число в нужном промежутке
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
