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
        /// Рандомайзер.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Конструктор нейрона.
        /// </summary>
        /// <param name="neuronNumber">Порядковый номер нейрона.</param>
        /// <param name="inputsCount">Количество элементов входного слоя.</param>
        public Neuron(int neuronNumber, int inputsCount)
        {
            Number = neuronNumber;
            SetRandomWeights(inputsCount);
        }

        /// <summary>
        /// Задать веса новыми рандомными значениями от 0 до 1.
        /// </summary>
        /// <param name="inputsCount">Количество элементов входного слоя.</param>
        public void SetRandomWeights(int inputsCount)
        {
            Weights.Clear();
            for (int i = 0; i < inputsCount; i++)
            {
                Weights.Add(_random.NextDouble());
            }
        }
    }
}
