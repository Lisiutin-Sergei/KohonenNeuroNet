using KohonenNeuroNet.Core.Types;
using System;
using System.Collections.Generic;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Нейрон сети.
    /// </summary>
    public class Neuron
    {
        /// <summary>
        /// Порядковый номер нейрона.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Веса нейрона - синапсы, связывающие нейрон с входным слоем.
        /// </summary>
        public List<double> Weights { get; set; } = new List<double>();

        /// <summary>
        /// Тип нормализации.
        /// </summary>
        public NormalizationTypes NormalizationType { get; set; }

        /// <summary>
        /// Рандомайзер.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Конструктор нейрона.
        /// </summary>
        /// <param name="neuronNumber">Порядковый номер нейрона.</param>
        /// <param name="inputsCount">Количество параметров входящего вектора.</param>
        public Neuron(int neuronNumber, int inputsCount, NormalizationTypes normalizationType)
        {
            Number = neuronNumber;
            NormalizationType = normalizationType;
            SetRandomWeights(inputsCount);
        }

        /// <summary>
        /// Задать веса новыми рандомными значениями от 0 до 1.
        /// </summary>
        /// <param name="inputsCount">Количество параметров входящего вектора.</param>
        public void SetRandomWeights(int inputsCount)
        {
            Weights.Clear();
            for (int i = 0; i < inputsCount; i++)
            {
                var randomWeight = GetRandomValue(inputsCount, NormalizationType);
                Weights.Add(randomWeight);
            }
        }

        /// <summary>
        /// Получить случайное значение веса в зависимости от типа нормализации.
        /// </summary>
        /// <param name="inputsCount">Количество параметров на входе сети.</param>
        /// <param name="normalizationType">Тип нормализации.</param>
        /// <returns>Случайное значение веса.</returns>
        public double GetRandomValue(int inputsCount, NormalizationTypes normalizationType)
        {
            double nextDouble = 0;
            while (true)
            {
                nextDouble = _random.NextDouble();
                switch (NormalizationType)
                {
                    case NormalizationTypes.Linear_0_1:
                        if (nextDouble >= 0.5 - 1 / Math.Sqrt(inputsCount) && nextDouble <= 0.5 + 1 / Math.Sqrt(inputsCount))
                        {
                            return nextDouble;
                        }
                        break;
                    case NormalizationTypes.Linear__1_1:
                        nextDouble = (nextDouble - 0.5) * 2;
                        if (Math.Abs(nextDouble) <= 1 / Math.Sqrt(inputsCount))
                        {
                            return nextDouble;
                        }
                        break;
                    default:
                        throw new Exception("Некорректно задан тип нормализации");
                }
            }            
        }
    }
}
