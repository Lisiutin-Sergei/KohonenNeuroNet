using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Нейронная сеть.
    /// </summary>
    public class Network
    {
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
            for (int i = 0; i < neuronsCount; i++)
            {
                Neuron neuron = new Neuron(i, inputsCount);
                Neurons.Add(neuron);
            }
        }

        /// <summary>
        /// Обучить нейронную сеть.
        /// </summary>
        /// <param name="inputDataSet">Набор входных данных для обучения.</param>
        /// <param name="neuronsCount">Количество нейронов.</param>
        public void Study(NetworkDataSet inputDataSet, int neuronsCount)
        {
            GenerateNeurons(inputDataSet?.Attributes?.Count ?? 0, neuronsCount);

            for (int iteration = 0; iteration < inputDataSet.Entities.Count; iteration++)
            {
                var error = StudyInputEntity(inputDataSet.Entities[iteration], iteration);
            }
        }

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="iteration">Номер итерации.</param>
        /// <returns>Ошибка обучения.</returns>
        public double StudyInputEntity(NetworkDataEntity inputEntity, int iteration)
        {
            var neuronWinner = GetNeuronWinner(inputEntity);

            var learningRate = GetLearningRate(iteration);
            StudyNeuron(neuronWinner, inputEntity, learningRate);

            var attributeValues = inputEntity.AttributeValues.Select(v => v.NormalizedValue);
            double error = GetEuclideanDistance(neuronWinner.Weights, attributeValues);
            return error;
        }

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        public Neuron GetNeuronWinner(NetworkDataEntity inputEntity)
        {
            var attributeValues = inputEntity.AttributeValues.Select(v => v.NormalizedValue);
            double minDistance = GetEuclideanDistance(Neurons[0].Weights, attributeValues);
            Neuron neuronWinner = Neurons[0];
            for (int i = 1; i < Neurons.Count; i++)
            {
                double currentDistance = GetEuclideanDistance(Neurons[i].Weights, attributeValues);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    neuronWinner = Neurons[i];
                }
            }
            return neuronWinner;
        }

        /// <summary>
        /// Обучить нейрон-победитель.
        /// </summary>
        /// <param name="neuronWinner">Нейрон-победитель.</param>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="learningRate">Скорость обучения.</param>
        public void StudyNeuron(Neuron neuronWinner, NetworkDataEntity inputEntity, double learningRate)
        {
            for (int i = 0; i < neuronWinner.Weights.Count(); i++)
            {
                neuronWinner.Weights[i] = neuronWinner.Weights[i] + 
                    learningRate * (inputEntity.AttributeValues[i].NormalizedValue - neuronWinner.Weights[i]);
            }
        }

        /// <summary>
        /// Функция соседства.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="winnerCoordinate"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private double hc(int k, double winnerCoordinate, double coordinate)
        {
            double dist = Math.Abs(winnerCoordinate - coordinate);
            double s = 1 * Math.Exp(-k / 5);
            return Math.Exp(-dist * dist / (2 * Math.Pow(s, 2)));
        }

        /// <summary>
        /// Получить скорость обучения на текущем цикле обучения.
        /// </summary>
        /// <param name="k">Цикл обучения.</param>
        /// <returns>Скорость обучения.</returns>
        public double GetLearningRate(int k)
        {
            return 0.1 * Math.Exp(-k / 1000);
        }

        /// <summary>
        /// Найти евклидово расстояние от входного вектора до центра кластера.
        /// </summary>
        /// <param name="neuronWeights">Веса нейрона, который представляет кластер.</param>
        /// <param name="inputVector">Входной вектор.</param>
        /// <returns>Евклидово расстояние от входного вектора до центра кластера.</returns>
        public double GetEuclideanDistance(IEnumerable<double> neuronWeights, IEnumerable<double> inputVector)
        {
            double sum = 0;
            for (int i = 0; i < inputVector.Count(); i++)
            {
                sum += Math.Pow((inputVector.ElementAt(i) - neuronWeights.ElementAt(i)), 2);
            }
            return Math.Sqrt(sum);
        }

    }
}
