using KohonenNeuroNet.Core.NormalizationType;
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
        public INormalizatiionType NormalizationType { get; set; }

        /// <summary>
        /// Конструктор нейрона.
        /// </summary>
        /// <param name="neuronNumber">Порядковый номер нейрона.</param>
        /// <param name="inputsCount">Количество параметров входящего вектора.</param>
        public Neuron(int neuronNumber, int inputsCount, INormalizatiionType normalizationType)
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
                var randomWeight = NormalizationType.GetNeuronWeight(inputsCount);
                Weights.Add(randomWeight);
            }
        }
    }
}
