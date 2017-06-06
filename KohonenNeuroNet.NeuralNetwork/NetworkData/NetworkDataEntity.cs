using System;
using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
    /// <summary>
    /// Элемент данных (строка).
    /// </summary>
    public class NetworkDataEntity : ICloneable
	{
        /// <summary>
        /// Значения атрибутов.
        /// </summary>
        public List<NetworkEntityAttributeValue> AttributeValues { get; set; } = new List<NetworkEntityAttributeValue>();

        /// <summary>
        /// Название элемента данных.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер элемента данных.
        /// </summary>
        public int OrderNumber { get; set; }

		public object Clone()
		{
			var attributes = new List<NetworkEntityAttributeValue>();
			attributes.AddRange(AttributeValues.Select(a => a.Clone() as NetworkEntityAttributeValue));

			var obj = this.MemberwiseClone() as NetworkDataEntity;
			obj.AttributeValues = attributes;

			return obj;
		}
	}
}
