using KohonenNeuroNet.Core.NetworkData;
using System;

namespace KohonenNeuroNet.Core.NormalizationType
{
    /// <summary>
    /// Линейная нормализация, от -1 до 1.
    /// </summary>
    public class LinearNormalizationType__1_1 : INormalizatiionType
    {
        /// <summary>
        /// Получить нормализованное значение атрибута.
        /// </summary>
        /// <param name="attribute">Атрибут сущности.</param>
        /// <returns>Нормализованное значение атрибута.</returns>
        public double GetAttributeValue(NetworkEntityAttributeValue attribute)
        {
            return attribute.Attribute.Max == attribute.Attribute.Min
                ? -1
                : 2 * Math.Abs(attribute.Value - attribute.Attribute.Min) / Math.Abs(attribute.Attribute.Max - attribute.Attribute.Min) - 1;
        }

        /// <summary>
        /// Получить нормализованное значение веса нейрона.
        /// </summary>
        /// <param name="inputsCount">Количество элементов входа.</param>
        /// <returns>Нормализованное значение веса нейрона.</returns>
        public double GetNeuronWeight(int inputsCount)
        {
            double nextDouble = 0;

            while (true)
            {
                nextDouble = (Randomizer.Instance.NextDouble() - 0.5) * 2;
                if (Math.Abs(nextDouble) <= 1 / Math.Sqrt(inputsCount))
                {
                    return nextDouble;
                }
            }
        }
    }
}
