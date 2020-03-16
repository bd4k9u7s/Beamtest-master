using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static double GetKND(double[] F, double dth)
        {
            double sum = 0;
            for (int i = 0; i < F.Length; i++)
            {
                sum = sum + F[i] * F[i] * Math.Cos(i * dth * Math.PI / 180);
            }
            return 2 / (sum * dth * Math.PI / 180);
        }
        static double Beam(double th, double k, double l)
        {
            double kl = k * l;
            double result = (Math.Cos(kl * Math.Sin(th)) - Math.Sin(kl)) / (Math.Cos(th) * (1 - Math.Sin(kl)));
            return result;
        }
        static void Main(string[] args)
        {
            const double f0 = 3; // ГГц
            const double lambda0 = 30 / f0; // cm
            const double k0 = 2 * Math.PI / lambda0;  //wave number
            const double thetta1 = -180;
            const double thetta2 = 180;
            const double dth = 0.1;
            int N = (int)((thetta2 - thetta1) / dth) + 1; // privedenie tipov, кол-во ячеек
            double[] Th = new double[N];
            for (int i = 0; i < N; i++)
            {
                Th[i] = i * dth + thetta1;
            }
            double[] F = new double[N];
            for (int i = 0; i < N; i++)
            {
                F[i] = Beam(Th[i] * Math.PI / 180, k0, lambda0 / 2);
            }
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("{0}-{1}", Th[i], F[i]);
            }
            Console.WriteLine("Расчет КНД:");
            double D = GetKND(F, dth); // Здесь расчитывается КНД
            Console.WriteLine("КНД=" + D);
            Console.ReadLine();
        }

    }
}
