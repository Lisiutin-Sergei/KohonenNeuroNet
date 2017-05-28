using KohonenNeuroNet.NeuralNetwork.NetworkData;
using System;

namespace KohonenNeuroNet.NeuralNetwork.NormalizationType
{
	/// <summary>
	/// Без нормализации.
	/// </summary>
	public class NoNormalization : INormalizatiionType
    {
        /// <summary>
        /// Получить нормализованное значение атрибута.
        /// </summary>
        /// <param name="attribute">Атрибут сущности.</param>
        /// <returns>Нормализованное значение атрибута.</returns>
        public double GetAttributeValue(NetworkEntityAttributeValue attribute)
        {
            return attribute.Value;
        }

        /// <summary>
        /// Получить нормализованное значение веса нейрона.
        /// </summary>
        /// <param name="inputsCount">Количество элементов входа.</param>
        /// <returns>Нормализованное значение веса нейрона.</returns>
        public double GetNeuronWeight(int inputsCount)
        {
            return Randomizer.Instance.NextDouble();
        }
    }
}
