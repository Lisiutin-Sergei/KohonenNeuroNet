using KohonenNeuroNet.Core.NetworkData;
using KohonenNeuroNet.Core.NormalizationType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Абстрактная нейронная сеть.
    /// </summary>
    public abstract class AbstractNetwork
    {
        /// <summary>
        /// Тип нормализации.
        /// </summary>
        public abstract INormalizatiionType NormalizationType { get; }

        /// <summary>
        /// Список нейронов сети.
        /// </summary>
        public List<Neuron> Neurons { get; set; } = new List<Neuron>();

        /// <summary>
        /// Сгенерировать нейроны сети.
        /// </summary>
        /// <param name="inputsCount">Количество параметров входящего вектора.</param>
        /// <param name="neuronsCount">Количество нейронов.</param>
        public void GenerateNeurons(int inputsCount, int neuronsCount)
        {
            Neurons.Clear();
            for (int i = 0; i < neuronsCount; i++)
            {
                Neuron neuron = new Neuron(i, inputsCount, NormalizationType);
                Neurons.Add(neuron);
            }
        }

        /// <summary>
        /// Обучить нейронную сеть.
        /// </summary>
        /// <param name="inputDataSet">Набор входных данных для обучения.</param>
        /// <param name="neuronsCount">Количество нейронов.</param>
        /// <param name="epochCount">Количество эпох.</param>
        public virtual void Study(NetworkDataSet inputDataSet, int neuronsCount, int epochCount)
        {
            GenerateNeurons(inputDataSet?.Attributes?.Count ?? 0, neuronsCount);

            double totalError = 0;
            for (int epoch = 0; epoch < epochCount; epoch++)
            {
                for (int iteration = 0; iteration < inputDataSet.Entities.Count; iteration++)
                {
                    totalError += StudyInputEntity(inputDataSet.Entities[iteration], epoch);
                }
            }
            totalError /= inputDataSet.Entities.Count;
        }

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="epoch">Номер эпохи обучения.</param>
        /// <returns>Ошибка обучения.</returns>
        public abstract double StudyInputEntity(NetworkDataEntity inputEntity, int epoch);

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        public abstract Neuron GetNeuronWinner(NetworkDataEntity inputEntity);

        /// <summary>
        /// Обучить нейрон-победитель.
        /// </summary>
        /// <param name="neuronWinner">Нейрон-победитель.</param>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="learningRate">Скорость обучения.</param>
        public abstract void StudyNeuron(Neuron neuronWinner, NetworkDataEntity inputEntity, double learningRate);

        /// <summary>
        /// Получить скорость обучения на текущем цикле обучения.
        /// </summary>
        /// <param name="k">Цикл обучения.</param>
        /// <returns>Скорость обучения.</returns>
        public abstract double GetLearningRate(int k);

        /// <summary>
        /// Найти евклидово расстояние от входного вектора до центра кластера.
        /// </summary>
        /// <param name="neuronWeights">Веса нейрона, который представляет кластер.</param>
        /// <param name="inputVector">Входной вектор.</param>
        /// <returns>Евклидово расстояние от входного вектора до центра кластера.</returns>
        public double GetEuclideanDistance(IEnumerable<double> neuronWeights, IEnumerable<double> inputVector)
        {
            double distance = 0;
            for (int i = 0; i < inputVector.Count(); i++)
            {
                distance += Math.Pow((inputVector.ElementAt(i) - neuronWeights.ElementAt(i)), 2);
            }
            return Math.Sqrt(distance);
        }
    }
}
