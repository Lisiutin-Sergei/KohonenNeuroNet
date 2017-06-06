using KohonenNeuroNet.NeuralNetwork.NormalizationType;
using System;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
	/// <summary>
	/// Значение атрибута элемента данных (ячейка).
	/// </summary>
	public class NetworkEntityAttributeValue : ICloneable
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
		/// <returns>Нормальное значение атрибута.</returns>
		public double GetNormalizedValue(INormalizatiionType normalizationType)
        {
            return normalizationType.GetAttributeValue(this);
        }

		public object Clone()
		{
			var obj = this.MemberwiseClone() as NetworkEntityAttributeValue;
			obj.Attribute = Attribute.Clone() as NetworkAttribute;
			return obj;
		}
    }
}
