using System;

namespace Pr9_10_Chislennie_Metody
{
    internal class Program
    {
        static double[] SetXis(double x0, double h, double n)
        {
            double[] xis = new double[(int)n + 1];
            xis[0] = x0;

            for (int i = 1; i < xis.Length; i++)
            {
                xis[i] = Math.Round(xis[i - 1] + h, 1);
            }

            return xis;
        }

        static int MethodOfStandartEuler(double[] xis, double y0, double h, int top)
        {
            double[] yis = new double[xis.Length], yhD2 = new double[xis.Length], ris = new double[xis.Length];

            int left = 1, startleft = 1;
            yis[0] = y0; yhD2[0] = y0; ris[0] = Math.Abs(yhD2[0] - yis[0]);

            Console.SetCursorPosition(0, top);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Метод стандартного Эйлера");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" i   xi      yi      y(h/2)      Ri    ");
            Console.ResetColor();
            top += 3;

            for (int i = 0; i < yis.Length; i++)
            {
                if (yis[i] != 0.2)
                {
                    yis[i] = (yis[i - 1]) + (h * (Math.Cos((1.5 * xis[i-1]) - Math.Pow(yis[i-1], 2)) - 1.3));
                    yhD2[i] = yis[i - 1] + (h / 2 * (Math.Cos(1.5 * xis[i-1] - Math.Pow(yis[i - 1], 2)) - 1.3));
                    ris[i] = Math.Abs(yhD2[i] - yis[i]);
                }

                left = startleft;
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left += 3;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(xis[i], 1));
                left += 7;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(yis[i], 4));
                left += 10;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(yhD2[i], 4));
                left += 10;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(ris[i], 4));
                top++;
            }

            top++;
            Console.SetCursorPosition(0, top);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ResetColor();
            Console.Write($" = {Math.Round(ris[1], 4)}");
            top += 3;

            return top;
        }

        static int MethodOf1stModifiedEuler(double[] xis, double y0, double h, int top)
        {
            double[] yis = new double[xis.Length], hD2_f_xi_yi = new double[xis.Length], xiPlus1D2 = new double[xis.Length], yiPlus1D2 = new double[xis.Length], hfiPLus1D2 = new double[xis.Length], yhD2 = new double[xis.Length], ris = new double[xis.Length];
            int left = 1, leftstart = 1;

            Console.SetCursorPosition(0, top);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1-ый модифицированный метод Эйлера");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" i   xi      yi   h/2 f(xi, yi)  x(i+1/2)    y(i+1/2)    hf(i+1/2)    y(h/2)     Ri ");
            Console.ResetColor();
            top += 3;

            for (int i = 0; i < xis.Length; i++)
            {
                if (i == 0)
                {
                    yis[i] = y0;
                } else
                {
                    yis[i] = yis[i - 1] + hfiPLus1D2[i - 1];
                }

                hD2_f_xi_yi[i] = (h / 2) * (Math.Cos((1.5 * xis[i] - Math.Pow(yis[i], 2))) - 1.3);
                xiPlus1D2[i] = xis[i] + h / 2;
                yiPlus1D2[i] = yis[i] + hD2_f_xi_yi[i];
                hfiPLus1D2[i] = h * (Math.Cos(1.5 * xiPlus1D2[i] - Math.Pow(yiPlus1D2[i], 2)) - 1.3);

                if (i == 0)
                {
                    yhD2[i] = 0.2;
                } else
                {
                    yhD2[i] = yis[i-1] + (h / 2) * (Math.Cos(1.5 * xis[i - 1] - Math.Pow(yis[i - 1], 2)) - 1.3);
                }

                ris[i] = Math.Abs(yhD2[i] - yis[i]);

                left = leftstart;
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left += 3;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(xis[i], 1));
                left += 7;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(yis[i], 4));
                left += 10;
                if (i != xis.Length - 1)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(hD2_f_xi_yi[i], 4));
                    left += 15;
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(xiPlus1D2[i], 4));
                    left += 10;
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(yiPlus1D2[i], 4));
                    left += 10;
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(hfiPLus1D2[i], 4));
                    left += 15;
                }
                else
                {
                    left += 50;
                }                
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(yhD2[i], 4));
                left += 10;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(ris[i], 4));
                top++;
            }

            top++;
            Console.SetCursorPosition(0, top);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ResetColor();
            Console.Write($" = {Math.Round(ris[1], 4)}");
            top += 3;

            return top;
        }

        static int MethodOfRungeKutt(double[] xis, double y0, double h, int top)
        {
            double[] yis = new double[xis.Length], k1 = new double[xis.Length], k2 = new double[xis.Length], k3 = new double[xis.Length], k4 = new double[xis.Length], yxi = new double[xis.Length], ei = new double[xis.Length];
            int left = 1, leftstart = 1;

            Console.SetCursorPosition(0, top);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Метод Рунге-Кутта");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" i   xi      yi        k1         k2         k3        k4    y(xi)    Ri ");
            Console.ResetColor();
            top += 3;

            for (int i = 0; i < xis.Length; i++)
            {
                if (i == 0)
                {
                    yis[i] = y0;
                } else
                {
                    yis[i] = (yis[i - 1]) + ((h / 6) * ((k1[i - 1]) + (2 * (k2[i - 1])) + (2 * (k3[i - 1])) + (k4[i - 1])));
                }

                k1[i] = Math.Round(Math.Cos(1.5 * xis[i] - Math.Pow(yis[i], 2)) - 1.3, 4);
                k2[i] = Math.Round(Math.Cos(1.5 * (xis[i] + h / 2) - Math.Pow((yis[i] + h / 2 * k1[i]), 2)) - 1.3, 4);
                k3[i] = Math.Round(Math.Cos(1.5 * (xis[i] + h / 2) - Math.Pow((yis[i] + h / 2 * k2[i]), 2)) - 1.3, 4);
                k4[i] = Math.Round(Math.Cos(1.5 * (xis[i] + h) - Math.Pow((yis[i] + h * k3[i]), 2)) - 1.3, 4);

                if (i == 0)
                {
                    yxi[i] = y0;
                } else
                {
                    yxi[i] = yis[i - 1] + h / 2 * (Math.Cos(1.5 * xis[i - 1] - Math.Pow(yis[i - 1], 2)) - 1.3);
                }
                
                ei[i] = Math.Abs(yxi[i] - yis[i]) / 15;

                left = leftstart;
                Console.SetCursorPosition(left, top);
                Console.Write(i);
                left += 3;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(xis[i], 1));
                left += 7;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(yis[i], 4));
                left += 10;
                if (i != xis.Length - 1)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(k1[i], 4));
                    left += 10;
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(k2[i], 4));
                    left += 10;
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(k3[i], 4));
                    left += 10;
                    Console.SetCursorPosition(left, top);
                    Console.Write(Math.Round(k4[i], 4));
                    left += 10;
                }
                else
                {
                    left += 40;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(yxi[i], 4));
                left += 10;
                Console.SetCursorPosition(left, top);
                Console.Write(Math.Round(ei[i], 4));
                top++;
            }

            top++;
            Console.SetCursorPosition(0, top);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ResetColor();
            Console.Write($" = {Math.Round(ei[1], 4)}");
            top += 3;

            return top;
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            int left = 0, top = 0;
            double X = 1, x0 = -1, h = 0.2, n = (X - x0) / h, y0 = 0.2; 
            double[] xis = SetXis(x0, h, n);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Практическая работа #9-10");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Сделал студент Долгунов Егор 3ПКС-220");
            Console.WriteLine("Вариант 3");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            top += 5;

            top = MethodOfStandartEuler(xis, y0, h, top);
            top = MethodOf1stModifiedEuler(xis, y0, h, top);
            top = MethodOfRungeKutt(xis, y0, h, top);

            Console.SetCursorPosition(left, top);
        }
    }
}
