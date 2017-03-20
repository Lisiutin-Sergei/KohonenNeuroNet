using KohonenNeuroNet.NeuralNetwork.NetworkData;
using KohonenNeuroNet.NeuralNetwork.NormalizationType;
using System;
using System.Linq;

namespace KohonenNeuroNet.NeuralNetwork.NeuralNetwork
{
	/// <summary>
	/// Нейронная сеть.
	/// </summary>
	public class ClassicKohonenNetwork : AbstractNetwork
    {
        /// <summary>
        /// Тип нормализации.
        /// </summary>
        public override INormalizatiionType NormalizationType => new LinearNormalizationType_0_1();

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="currentIteration">Номер текущей итерации обучения.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <returns>Ошибка обучения.</returns>
        public override double StudyInputEntity(NetworkDataEntity inputEntity, int currentIteration, int iterationsCount)
        {
            var neuronWinner = GetNeuronWinner(inputEntity);

            var learningRate = GetLearningRate(currentIteration, iterationsCount);
            StudyNeuron(neuronWinner, inputEntity, learningRate);

            var attributeValues = inputEntity.AttributeValues.Select(v => v.GetNormalizedValue(NormalizationType));
            double error = GetEuclideanDistance(neuronWinner.Weights, attributeValues);
            return error;
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
                    learningRate * (inputEntity.AttributeValues[i].GetNormalizedValue(NormalizationType) - neuronWinner.Weights[i]);
            }
        }

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        public override Neuron GetNeuronWinner(NetworkDataEntity inputEntity)
        {
            var attributeValues = inputEntity.AttributeValues.Select(v => v.GetNormalizedValue(NormalizationType));
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
        /// Получить скорость обучения на текущем цикле обучения.
        /// </summary>
        /// <param name="currentIteration">Текущая итерация обучения.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <returns>Скорость обучения.</returns>
        public override double GetLearningRate(int currentIteration, int iterationsCount)
        {
            return 0.1 * Math.Exp(-currentIteration / iterationsCount);
        }
    }
}
