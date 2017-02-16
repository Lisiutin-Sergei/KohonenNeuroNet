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
        /// Конструктор нейронной сети.
        /// </summary>
        /// <param name="inputsCount">Количество элементов входного слоя.</param>
        /// <param name="neuronsCount">Количество нейронов сети/кластеров.</param>
        public Network(int inputsCount, int neuronsCount)
        {
            for (int i = 0; i < neuronsCount; i++)
            {
                Neuron neuron = new Neuron(i, inputsCount);
                Neurons.Add(neuron);
            }
        }

        /// <summary>
        /// Тестирование нейронной сети.
        /// </summary>
        /// <param name="input">Входной вектор для тестирования.</param>
        /// <returns>Нейрон-победитель.</returns>
        private int Test(double[] input)
        {
            var neuronWinner = GetNeuronWinner(input);
            return neuronWinner.Number;
        }

        /// <summary>
        /// Обучить нейронную сеть.
        /// </summary>
        /// <param name="inputVectors">Набор входных данных для обучения.</param>
        private void Study(double[][] inputVectors)
        {
            for (int iteration = 0; iteration < inputVectors.Length; iteration++)
            {
                var error = StudyInputVector(inputVectors[iteration], iteration);
            }
        }

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="input">Входной вектор.</param>
        /// <param name="iteration">Номер итерации.</param>
        /// <returns>Ошибка обучения.</returns>
        public double StudyInputVector(double[] input, int iteration)
        {
            var neuronWinner = GetNeuronWinner(input);

            var learningRate = GetLearningRate(k);
            StudyNeuron(neuronWinner, input, learningRate);

            double error = GetEuclideanDistance(neuronWinner.Weights, input);
            return error;
        }

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="input">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        private Neuron GetNeuronWinner(double[] input)
        {
            double minDistance = GetEuclideanDistance(Neurons[0].Weights, input);
            Neuron neuronWinner = Neurons[0];
            for (int i = 1; i < Neurons.Count; i++)
            {
                double currentDistance = GetEuclideanDistance(Neurons[i].Weights, input);
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
        /// <param name="input">Входной вектор.</param>
        /// <param name="learningRate">Скорость обучения.</param>
        private void StudyNeuron(Neuron neuronWinner, double[] input, double learningRate)
        {
            for (int i = 0; i < neuronWinner.Weights.Count(); i++)
            {
                neuronWinner.Weights[i] = neuronWinner.Weights[i] + learningRate * (input[i] - neuronWinner.Weights[i]);
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
        private double GetLearningRate(int k)
        {
            return 0.1 * Math.Exp(-k / 1000);
        }

        /// <summary>
        /// Найти евклидово расстояние от входного вектора до центра кластера.
        /// </summary>
        /// <param name="neuronWeights">Веса нейрона, который представляет кластер.</param>
        /// <param name="inputVector">Входной вектор.</param>
        /// <returns>Евклидово расстояние от входного вектора до центра кластера.</returns>
        private double GetEuclideanDistance(IEnumerable<double> neuronWeights, IEnumerable<double> inputVector)
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
