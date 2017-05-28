using KohonenNeuroNet.NeuralNetwork.NetworkData;
using System;

namespace KohonenNeuroNet.NeuralNetwork.NormalizationType
{
	/// <summary>
	/// Линейная нормализация, от 0 до 1.
	/// </summary>
	public class LinearNormalizationType_0_1 : INormalizatiionType
    {
        /// <summary>
        /// Получить нормализованное значение атрибута.
        /// </summary>
        /// <param name="attribute">Атрибут сущности.</param>
        /// <returns>Нормализованное значение атрибута.</returns>
        public double GetAttributeValue(NetworkEntityAttributeValue attribute)
        {
            return attribute.Attribute.Max == attribute.Attribute.Min 
                ? 0 
                : Math.Abs(attribute.Value - attribute.Attribute.Min) / Math.Abs(attribute.Attribute.Max - attribute.Attribute.Min);
        }

        /// <summary>
        /// Получить нормализованное значение веса нейрона.
        /// </summary>
        /// <param name="inputsCount">Количество элементов входа.</param>
        /// <returns>Нормализованное значение веса нейрона.</returns>
        public double GetNeuronWeight(int inputsCount)
        {
            double nextDouble = 0;
            var minValue = 0.5 - 1 / Math.Sqrt(inputsCount);
            var maxValue = 0.5 + 1 / Math.Sqrt(inputsCount);

            while (true)
            {
                nextDouble = Randomizer.Instance.NextDouble();
                if (nextDouble >= minValue && nextDouble <= maxValue)
                {
                    return nextDouble;
                }
            }
        }
    }
}
