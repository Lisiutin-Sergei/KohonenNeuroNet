using KohonenNeuroNet.Core.Model.Business;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.NeuralNetwork.NetworkData;
using KohonenNeuroNet.NeuralNetwork.NormalizationType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.NeuralNetwork.NeuralNetwork
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
        public List<NeuronBase> Neurons { get; set; } = new List<NeuronBase>();

        /// <summary>
        /// Входной слой.
        /// </summary>
        public List<InputAttributeBase> InputAttributes { get; set; } = new List<InputAttributeBase>();

        /// <summary>
        /// Веса нейрона - синапсы, связывающие нейрон с входным слоем.
        /// </summary>
        public List<WeightBase> Weights { get; set; } = new List<WeightBase>();

        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Минимальная ошибка обучения.
        /// </summary>
        public const double LEARNING_ERROR = 0.01;

        /// <summary>
        /// Событие об окончании итерации обучения.
        /// </summary>
        public event EventHandler IterationCompleted;

        /// <summary>
        /// Сгенерировать нейроны сети.
        /// </summary>
        /// <param name="attributes">Количество параметров входящего вектора.</param>
        /// <param name="neuronsCount">Количество нейронов.</param>
        public void GenerateNeurons(List<NetworkAttribute> attributes, int neuronsCount)
        {
            Neurons.Clear();
            Weights.Clear();
            InputAttributes.Clear();

            InputAttributes.AddRange(attributes.Select(a => new InputAttributeBase
            {
                InputAttributeNumber = a.OrderNumber,
                Name = a.Name
            })
            .ToList());

            for (int i = 0; i < neuronsCount; i++)
            {
                Neurons.Add(new NeuronBase
                {
                    NeuronNumber = i
                });
            }

            foreach (var inputAttribute in InputAttributes)
            {
                foreach (var neuron in Neurons)
                {
                    var randomWeight = NormalizationType.GetNeuronWeight(attributes.Count);
                    Weights.Add(new WeightBase
                    {
                        InputAttributeNumber = inputAttribute.InputAttributeNumber,
                        NeuronNumber = neuron.NeuronNumber,
                        Value = randomWeight
                    });
                }
            }
        }

        /// <summary>
        /// Инициализировать сеть.
        /// </summary>
        /// <param name="neurons">Нейроны.</param>
        /// <param name="inputAttributes">Входные атрибуты.</param>
        /// <param name="weights">Веса.</param>
        public void InitializeNetwork(List<NeuronBase> neurons, List<InputAttributeBase> inputAttributes, List<WeightBase> weights)
        {
            Neurons = neurons;
            InputAttributes = inputAttributes;
            Weights = weights;
        }

        /// <summary>
        /// Обучить нейронную сеть.
        /// </summary>
        /// <param name="inputDataSet">Набор входных данных для обучения.</param>
        /// <param name="neuronsCount">Количество нейронов.</param>
        /// <param name="iterationsCount">Количество эпох.</param>
        public virtual void Study(NetworkDataSet inputDataSet, int neuronsCount, int iterationsCount)
        {
            GenerateNeurons(inputDataSet?.Attributes, neuronsCount);

            for (int iteration = 0; iteration < iterationsCount; iteration++)
            {
                var randomNumber = _random.Next(0, inputDataSet.Entities.Count - 1);
                var randomEntity = inputDataSet.Entities[randomNumber];

                var attributeValues = randomEntity.AttributeValues
                    .Select(e => new InputAttributeValue
                    {
                        InputAttributeNumber = e.Attribute.OrderNumber,
                        Value = e.GetNormalizedValue(NormalizationType)
                    })
                    .ToList();

                var totalError = StudyInputEntity(attributeValues, iteration, iterationsCount);
                IterationCompleted?.Invoke(this, null);
            }
        }

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="attributes">Значения входных атрибутов.</param>
        /// <param name="currentIteration">Номер текущей итерации обучения.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <returns>Ошибка обучения.</returns>
        public abstract double StudyInputEntity(List<InputAttributeValue> attributes, int currentIteration, int iterationsCount);

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="attributeValues">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        public abstract NeuronBase GetNeuronWinner(IEnumerable<InputAttributeValue> attributeValues);

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
        /// <param name="neuron">Нейрон.</param>
        /// <param name="inputVector">Входной вектор.</param>
        /// <returns>Евклидово расстояние от входного вектора до центра кластера.</returns>
        public double GetEuclideanDistance(NeuronBase neuron, IEnumerable<InputAttributeValue> inputVector)
        {
            double distance = 0;

            var neuronWeights = Weights
                    .Where(e => e.NeuronNumber == neuron.NeuronNumber);

            foreach (var input in inputVector)
            {
                var neuronWeight = neuronWeights
                    .FirstOrDefault(e => e.InputAttributeNumber == input.InputAttributeNumber);

                distance += Math.Pow(neuronWeight.Value - input.Value, 2);
            }

            return Math.Sqrt(distance);
        }

        /// <summary>
        /// Найти евклидово расстояние между 2 нейронами.
        /// </summary>
        /// <param name="neuron1">Первый нейрон.</param>
        /// <param name="neuron2">Второй нейрон.</param>
        /// <returns>Евклидово расстояние между 2 нейронами.</returns>
        public double GetEuclideanDistance(NeuronBase neuron1, NeuronBase neuron2)
        {
            double distance = 0;

            var firstNeuronWeights = Weights
                    .Where(e => e.NeuronNumber == neuron1.NeuronNumber);
            var secondNeuronWeights = Weights
                    .Where(e => e.NeuronNumber == neuron2.NeuronNumber);

            foreach (var firstNeuronWeight in firstNeuronWeights)
            {
                var secondNeuronWeight = secondNeuronWeights
                    .FirstOrDefault(e => e.InputAttributeNumber == firstNeuronWeight.InputAttributeNumber);

                distance += Math.Pow(firstNeuronWeight.Value - secondNeuronWeight.Value, 2);
            }

            return Math.Sqrt(distance);
        }
    }
}
