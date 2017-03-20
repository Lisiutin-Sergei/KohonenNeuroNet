using KohonenNeuroNet.NeuralNetwork.NormalizationType;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
	/// <summary>
	/// Значение атрибута элемента данных (ячейка).
	/// </summary>
	public class NetworkEntityAttributeValue
    {
        /// <summary>
        /// Атрибут сущности.
        /// </summary>
        public NetworkAttribute Attribute { get; set; }

        /// <summary>
        /// Значение атрибута.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Получить нормальное значение.
        /// </summary>
        /// <param name="normalizationType">Тип нормализации</param>
        /// <returns></returns>
        public double GetNormalizedValue(INormalizatiionType normalizationType)
        {
            return normalizationType.GetAttributeValue(this);
        }
    }
}
