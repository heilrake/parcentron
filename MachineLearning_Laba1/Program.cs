using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning_Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose program 1 or 2");
            string variant = Convert.ToString(Console.ReadLine());
            if (variant == "1")
            {
                FirstTask();
            }
            else
            {
                SecondMethod();
            }
            Console.ReadKey();
        
        }
        static void FirstTask()
        {
            // Дані для тренування персептрону
            double[][] input = new double[10][];
            input[0] = new double[] { 1.0, 1.0 };
            input[1] = new double[] { 9.4, 6.4 };
            input[2] = new double[] { 2.5, 2.1 };
            input[3] = new double[] { 8.0, 7.7 };
            input[4] = new double[] { 0.5, 2.2 };
            input[5] = new double[] { 7.9, 8.4 };
            input[6] = new double[] { 7.0, 7.0 };
            input[7] = new double[] { 2.8, 0.8 };
            input[8] = new double[] { 1.2, 3.0 };
            input[9] = new double[] { 7.8, 6.1 };

            int[] output = new int[] { 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1 }; // Очікувані результати для кожного входу


            // Створюємо персептрон
            Parcentron perceptron = new Parcentron(2);

            // Тренуємо персептрон
            perceptron.Train(input, output);

            // Перевіряємо результат
            Console.WriteLine(perceptron.Compute(new double[] { 0, 0 })); // 0
            Console.WriteLine(perceptron.Compute(new double[] { 0, 1 })); // 1
            Console.WriteLine(perceptron.Compute(new double[] { 1, 0 })); // 1
            Console.WriteLine(perceptron.Compute(new double[] { 1, 1 })); // 1

            while (true)
            {
                double x, y;
                Console.Write("x:");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("y:");
                y = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("( {0}, {1} ): {2}", x, y, (perceptron.Compute(new double[] { x, y })));
            }

           /* double[][] inputs = new double[][]
        {
            new double[] { 1.0, 1.0 },
            new double[] { 9.4, 6.4 },
            new double[] { 2.5, 2.1 },
            new double[] { 8.0, 7.7 },
            new double[] { 0.5, 2.2 },
            new double[] { 7.9, 8.4 },
            new double[] { 7.0, 7.0 },
            new double[] { 2.8, 0.8 },
            new double[] { 1.2, 3.0 },
            new double[] { 7.8, 6.1 },};

            int[] targets = new int[] { 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1 };

            double[] weights = new double[] { 0.1, 0.4 };
            double bias = -1.2;
            double learningRate = 0.5;
            int maxIterations = 100000;

            for (int i = 0; i < maxIterations; i++)
            {
                bool error = false;
                for (int j = 0; j < inputs.Length; j++)
                {
                    double output = CalculateOutput(inputs[j], weights, bias);
                    double delta = targets[j] - (output >= 0 ? 1 : 0);
                    if (delta != 0)
                    {
                        error = true;
                        for (int k = 0; k < weights.Length; k++)
                        {
                            weights[k] += learningRate * delta * inputs[j][k];
                        }
                        bias += learningRate * delta;
                    }
                }
                if (!error)
                {
                    Console.WriteLine("Навчання завершено на {0} iтерацiї.", i);
                    Console.WriteLine("W1: {0}\nW2: {1}\nBias: {2}", Math.Round(weights[0], 3), Math.Round(weights[1], 3), Math.Round(bias, 3));
                    Console.WriteLine("\nПряма роздiлення:\np1( {0}, {1} )\np2( {2}, {3} )",
                        1, Math.Round(-weights[0] / weights[1] * 1 - (bias / weights[1]), 3), 10, Math.Round(-weights[0] / weights[1] * 10 - (bias / weights[1]), 3));
                    Console.WriteLine();
                    break;
                }
            }

            Console.WriteLine("Тестування:");
            Console.WriteLine("( -1, 0 ): " + (CalculateOutput(new double[] { -1, 0 }, weights, bias) >= 0 ? 1 : 0));
            Console.WriteLine("( 1, 0 ): " + (CalculateOutput(new double[] { 1, 0 }, weights, bias) >= 0 ? 1 : 0));
            Console.WriteLine("( 0, -1 ): " + (CalculateOutput(new double[] { 0, -1 }, weights, bias) >= 0 ? 1 : 0));
            Console.WriteLine("( 0, 1 ): " + (CalculateOutput(new double[] { 0, 1 }, weights, bias) >= 0 ? 1 : 0));
            Console.WriteLine("( 7.3, 6.2 ): " + (CalculateOutput(new double[] { 7.3, 6.2 }, weights, bias) >= 0 ? 1 : 0));
            Console.WriteLine("( 5.5, 4 ): " + (CalculateOutput(new double[] { 5.5, 4 }, weights, bias) >= 0 ? 1 : 0));
            Console.WriteLine();

            while (true)
            {
                double x, y;
                Console.Write("Enter x: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter y: ");
                y = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("( {0}, {1} ): {2}", x, y, (CalculateOutput(new double[] { x, y }, weights, bias) >= 0 ? 1 : 0));
            }*/
        }

        static void SecondMethod()
        {
            double[] x = {0.125, 0.15, 0.175, 0.2, 0.225, 0.25, 0.275};
            double[] y = {2.77, 3.42, 3.85, 4.33, 4.95, 5.38, 6.027};

            double[] result = Prognosing(x, y);
            Console.WriteLine($"y = {Math.Round(result[0], 4)}x + {Math.Round(result[1], 4)}");
        }
        static double[] Prognosing(double[] x, double[] y)
        {
            double k = 0.0, b = 0.0, Xsum = 0.0, Ysum = 0.0, XYsum = 0.0, Xsqrsum = 0.0;
            for (int i = 0; i < x.Length; i++)
            {
                Xsum += x[i];
                Ysum += y[i];
                XYsum += x[i] * y[i];
                Xsqrsum += x[i] * x[i];
            }

            k = (x.Length * XYsum - Xsum * Ysum) / (x.Length * Xsqrsum - Xsum * Xsum);
            b = (Ysum - k * Xsum) / x.Length;

            return new double[] { k, b };
        }
    }
}

