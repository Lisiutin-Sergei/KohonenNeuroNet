using System;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
    /// <summary>
    /// Атрибут сущности (колонка).
    /// </summary>
    public class NetworkAttribute : ICloneable
    {
        /// <summary>
        /// Максимальное значение атрибута.
        /// </summary>
        public double Max { get; set; }

        /// <summary>
        /// Минимальное значение атрибута.
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Название атрибута.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер атрибута.
        /// </summary>
        public int OrderNumber { get; set; }

		public object Clone()
		{
			return this.MemberwiseClone();
		}
    }
}
