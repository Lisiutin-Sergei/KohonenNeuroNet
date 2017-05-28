using KohonenNeuroNet.Core.Model.Business;
using KohonenNeuroNet.Core.Model.Domain;
using KohonenNeuroNet.NeuralNetwork.NormalizationType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.NeuralNetwork.NeuralNetwork
{
	/// <summary>
	/// СОМ Кохонена.
	/// </summary>
	public class SelfOrganizingMap : AbstractNetwork
    {
        /// <summary>
        /// Тип нормализации.
        /// </summary>
        public override INormalizatiionType NormalizationType => new LinearNormalizationType__1_1();

		/// <summary>
		/// Обучить входной вектор (провести итерацию обучения).
		/// </summary>
		/// <param name="attributes">Значения входных атрибутов.</param>
		/// <param name="currentIteration">Номер текущей итерации обучения.</param>
		/// <param name="iterationsCount">Общее количество итераций обучения.</param>
		/// <returns>Ошибка обучения.</returns>
		public override double StudyInputEntity(List<InputAttributeValue> attributes, int currentIteration, int iterationsCount)
		{
			var neuronWinner = GetNeuronWinner(attributes);
            var learningRate = GetLearningRate(currentIteration, iterationsCount);

			foreach(var currentNeuron in Neurons)
			{
				var distanceToNeuronWinner = GetEuclideanDistance(currentNeuron, neuronWinner);
				var influenceCoefficient = GetInfluenceCoefficient(currentIteration, iterationsCount, distanceToNeuronWinner);

				foreach(var inputEntityAttribute in attributes)
				{
					var currentWeight = Weights.FirstOrDefault(e =>
						e.NeuronNumber == currentNeuron.NeuronNumber &&
						e.InputAttributeNumber == inputEntityAttribute.InputAttributeNumber);

					currentWeight.Value = currentWeight.Value +
						influenceCoefficient * learningRate * (inputEntityAttribute.Value - currentWeight.Value);
				}
			}

			// Ошибка
			return GetEuclideanDistance(neuronWinner, attributes);
        }

        /// <summary>
        /// Функция влияния изменений на веса.
        /// </summary>
        /// <param name="currentIteration">Номер итерации.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <param name="distanceToNeuronWinner">Расстояние до нейрона-победителя.</param>
        /// <returns>Коэффициент влияния.</returns>
        public double GetInfluenceCoefficient(int currentIteration, int iterationsCount, double distanceToNeuronWinner)
        {
            var nc = GetNeighboorhoodCoefficient(currentIteration, iterationsCount, Neurons.Count);
            return Math.Exp(-Math.Pow(distanceToNeuronWinner, 2) / (2 * Math.Pow(nc, 2)));
        }

        /// <summary>
        /// Функция соседства.
        /// </summary>
        /// <param name="currentIteration">Номер итерации.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <param name="neuronsCount">Количество нейронов.</param>
        /// <returns>Коэффициент соседства.</returns>
        public double GetNeighboorhoodCoefficient(int currentIteration, int iterationsCount, int neuronsCount)
        {
            var n = iterationsCount / Math.Log10(neuronsCount);
            return Math.Exp(-currentIteration / n);
        }

        /// <summary>
        /// Получить нейрон-победитель.
        /// </summary>
        /// <param name="inputEntity">Входной вектор.</param>
        /// <returns>Нейрон-победитель для входного вектора.</returns>
        public override NeuronBase GetNeuronWinner(IEnumerable<InputAttributeValue> attributeValues)
        {
            double minDistance = GetEuclideanDistance(Neurons[0], attributeValues);
            NeuronBase neuronWinner = Neurons[0];

            for (int i = 1; i < Neurons.Count; i++)
			{
				double currentDistance = GetEuclideanDistance(Neurons[i], attributeValues);
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
            return 0.1 * Math.Exp(-(double)currentIteration / iterationsCount);
        }
    }
}
