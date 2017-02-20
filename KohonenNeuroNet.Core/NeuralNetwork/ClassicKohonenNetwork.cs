using KohonenNeuroNet.Core.NetworkData;
using KohonenNeuroNet.Core.Types;
using System;
using System.Linq;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Нейронная сеть.
    /// </summary>
    public class ClassicKohonenNetwork : AbstractNetwork
    {
        /// <summary>
        /// Тип нормализации.
        /// </summary>
        public override NormalizationTypes NormalizationType
        {
            get
            {
                return NormalizationTypes.Linear_0_1;
            }
        }

        /// <summary>
        /// Обучить входной вектор (провести итерацию обучения).
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="epoch">Номер эпохи обучения.</param>
        /// <returns>Ошибка обучения.</returns>
        public override double StudyInputEntity(NetworkDataEntity inputEntity, int epoch)
        {
            var neuronWinner = GetNeuronWinner(inputEntity);

            var learningRate = GetLearningRate(epoch);
            StudyNeuron(neuronWinner, inputEntity, learningRate);

            var attributeValues = inputEntity.AttributeValues.Select(v => v.GetNormalizedValue(NormalizationType));
            double error = GetEuclideanDistance(neuronWinner.Weights, attributeValues);
            return error;
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
        /// Обучить нейрон-победитель.
        /// </summary>
        /// <param name="neuronWinner">Нейрон-победитель.</param>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <param name="learningRate">Скорость обучения.</param>
        public override void StudyNeuron(Neuron neuronWinner, NetworkDataEntity inputEntity, double learningRate)
        {
            for (int i = 0; i < neuronWinner.Weights.Count(); i++)
            {
                neuronWinner.Weights[i] = neuronWinner.Weights[i] +
                    learningRate * (inputEntity.AttributeValues[i].GetNormalizedValue(NormalizationType) - neuronWinner.Weights[i]);
            }
        }

        /// <summary>
        /// Получить скорость обучения на текущем цикле обучения.
        /// </summary>
        /// <param name="epoch">Эпоха обучения.</param>
        /// <returns>Скорость обучения.</returns>
        public override double GetLearningRate(int epoch)
        {
            return 0.3 - epoch * 0.05;
            //return 0.1 * Math.Exp(-k / 1000);
        }
    }
}
