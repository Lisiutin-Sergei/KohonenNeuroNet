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
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Минимальная ошибка обучения.
        /// </summary>
        public const double LEARNING_ERROR = 0.01;

        public event EventHandler IterationCompleted;

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
        /// <param name="iterationsCount">Количество эпох.</param>
        public virtual void Study(NetworkDataSet inputDataSet, int neuronsCount, int iterationsCount)
        {
            GenerateNeurons(inputDataSet?.Attributes?.Count ?? 0, neuronsCount);

            for (int iteration = 0; iteration < iterationsCount; iteration++)
            {
                var randomNumber = _random.Next(0, inputDataSet.Entities.Count - 1);
                var randomEntity = inputDataSet.Entities[randomNumber];
                var totalError = StudyInputEntity(randomEntity, iteration, iterationsCount);
                IterationCompleted?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="epoch">Номер эпохи обучения.</param>
        /// <returns>Ошибка обучения.</returns>
        public abstract double StudyInputEntity(NetworkDataEntity inputEntity, int epoch, int epochCount);

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        public abstract Neuron GetNeuronWinner(NetworkDataEntity inputEntity);

        /// <summary>
        /// Получить скорость обучения на текущем цикле обучения.
        /// </summary>
        /// <param name="currentIteration">Текущая итерация обучения.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <returns>Скорость обучения.</returns>
        public abstract double GetLearningRate(int currentIteration, int iterationsCount);

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
