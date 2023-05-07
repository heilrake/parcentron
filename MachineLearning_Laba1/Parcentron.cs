using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning_Laba1
{
    internal class Parcentron
    {

        private double[] weights; // Ваги
        private double bias = 1; // Зміщення
        private double learningRate = 0.1;
        private int maxIterations = 100000;


        // Конструктор
        public Parcentron(int numInputs)
        {
            weights = new double[numInputs];
            for (int i = 0; i < numInputs; i++)
            {
                weights[i] = new Random().NextDouble(); // Ініціалізуємо ваги випадковими значеннями
            }
        }

        // Функція активації - сигмоїда
        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        // Розрахунок вихідного значення персептрону для заданого входу
        public int Compute(double[] inputs)
        {
            double sum = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * weights[i];
            }
            sum += bias;

            return Sigmoid(sum) >= 0.5 ? 1 : 0; // Повертаємо 1, якщо вихід більше або дорівнює 0.5, інакше повертаємо 0
        }

        // Тренування персептрону
        public void Train(double[][] input, int[] output)
        {
            for (int iteration = 0; iteration < maxIterations; iteration++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int predictedOutput = Compute(input[i]);
                    int error = (int)(output[i] - predictedOutput);

                    for (int j = 0; j < weights.Length; j++)
                    {
                        weights[j] += learningRate * error * input[i][j]; // Оновлюємо ваги
                    }

                    bias += learningRate * error; // Оновлюємо зміщення
                }
            }
        }
    }
}
