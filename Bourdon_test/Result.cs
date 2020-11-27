using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourdon_test
{
    public class Result
    {
        public Guid id = Guid.Empty;
        public DateTime dateCreated = DateTime.Parse("01.01.1970");
        public Guid userID = Guid.Empty;
        public int level;

        public int t; // потраченое время в секундах
        public int L; // общее количество просмотренных до последнего выбранного
        public int C = 0; // число просмотренных строк
        public int n = 0; // общее количество, сколько нужно было выбрать ячеек

        public int S; // число верно выбранных
        public int P; // число пропущенных, которые нужно было выбрать
        public int O; // число ошибочно выбранных

        

        public int M() // общее число выбранных символов (S + O)
        {
            return this.S + this.O;
        }

        public double A() // скорость внимания L/t
        {
            double A = this.L / Convert.ToDouble(this.t);
            A = Math.Round(A, 3);
            return A;
        }

        public double T2() // показатель точности работы S/n
        {
            double T2 = this.S / Convert.ToDouble(this.n);
            T2 = Math.Round(T2, 3);
            return T2;
        }

        public double E() // коэффициент умственной продуктивности N*T2
        {
            double E = Convert.ToDouble(this.L) * this.T2();
            E = Math.Round(E, 3);
            return E;
        }

        public double Au() // умственная работоспособность (L/t)*((M-(O+P))/n)
        {
            double Au = (Convert.ToDouble(this.L) / Convert.ToDouble(this.t)) * (Convert.ToDouble(this.M() - (this.O + this.P)) / Convert.ToDouble(this.n));
            Au = Math.Round(Au, 3);
            return Au;
        }

        public double K() // концентрация внимания
        {
            double K = (this.M() - this.O) * 100 / Convert.ToDouble(this.n);
            K = Math.Round(K, 3);
            return K;
        }

        public string getInterpretation()
        {
            string str1 = "";
            double countErr = this.O + this.P * 100 / (Convert.ToDouble(this.level * 10) * Convert.ToDouble(this.level * 10));
            int countErrInt = Convert.ToInt32(countErr);

            if (countErr >= 0 && countErr <= 20)
                str1 = "\tДопущение " + (this.O + this.P) + " ошибок - это значение выше нормы уровня концентрации внимания для взрослого человека. ";
            else if (countErr > 20 && countErr <= 50)
                str1 = "\tДопущение " + (this.O + this.P) + " ошибок - это норма уровня концентрации внимания для взрослого человека. ";
            else if (countErr > 50)
                str1 = "\tДопущение " + (this.O + this.P) + " ошибок - это значение ниже нормы уровня концентрации внимания для взрослого человека. ";

            str1 += "Имейте в виду, что пропущенные буквы в массиве уже проверенных рядов букв расцениваются как ошибки и влияют общий результат.\n";

            int k = Convert.ToInt32(this.K());
            string str2 = "\tБыло выполнено примерно " + k + " процентов таблицы. ";
            if (k >= 0 && k <= 30)
                str2 += "Это очень плохой результат, который соответствует значению ниже нормы объема внимания взрослого человека, вам нужно тренировать свое внимание.";
            else if (k > 30 && k <= 50)
                str2 += "Это плохой результат, который соответствует значению ниже нормы объема внимания взрослого человека, вам нужно тренировать свое внимание.";
            else if (k > 50 && k <= 70)
                str2 += "Это средний результат, который соответствует значению ниже нормы объема внимания взрослого человека, вам еще есть куда улучшать возможности своего внимания.";
            else if (k > 70 && k <= 90)
                str2 += "Это хороший результат, который соответствует норме объема внимания взрослого человека, однако вам еще есть куда улучшать возможности своего внимания.";
            else if (k > 90 && k <= 100)
                str2 += "Это отличный результат, который соответствует значению выше нормы объема внимания взрослого человека.";

            return str1 +"\n"+ str2;
        }
    }
}
