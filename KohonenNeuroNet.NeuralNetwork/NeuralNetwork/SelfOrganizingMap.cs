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
        public override INormalizatiionType NormalizationType => new LinearNormalizationType_0_1();

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
            // Сигма
            var nc = GetNeighboorhoodCoefficient(currentIteration, iterationsCount);

            return distanceToNeuronWinner >= nc
                ? 0
                : Math.Exp(-Math.Pow(distanceToNeuronWinner, 2) / (2 * Math.Pow(nc, 2)));
        }

        /// <summary>
        /// Начальное значение коэффициента соседства.
        /// </summary>
        private const double INITIAL_NEIGHBOORHOOD_COEFFICIENT = 0.1;

        /// <summary>
        /// Функция соседства.
        /// </summary>
        /// <param name="currentIteration">Номер итерации.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <returns>Коэффициент соседства.</returns>
        private double GetNeighboorhoodCoefficient(int currentIteration, int iterationsCount)
        {
            var n = iterationsCount / Math.Log10(INITIAL_NEIGHBOORHOOD_COEFFICIENT);
            return INITIAL_NEIGHBOORHOOD_COEFFICIENT * Math.Exp(-(currentIteration + 1) / n);
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
        /// Начальное значение скорости обучения.
        /// </summary>
        private const double INITIAL_LEARNING_RATE = 0.1;

        /// <summary>
        /// Получить скорость обучения на текущем цикле обучения.
        /// </summary>
        /// <param name="currentIteration">Текущая итерация обучения.</param>
        /// <param name="iterationsCount">Общее количество итераций обучения.</param>
        /// <returns>Скорость обучения.</returns>
        public override double GetLearningRate(int currentIteration, int iterationsCount)
        {
            return INITIAL_LEARNING_RATE * Math.Exp(-(double)(currentIteration + 1) / iterationsCount);
        }
    }
}
