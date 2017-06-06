using System.Collections.Generic;
using System.Linq;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
    /// <summary>
    /// Набор данных.
    /// </summary>
    public class NetworkDataSet
    {
        /// <summary>
        /// Список атрибутов (колонок) набора данных.
        /// </summary>
        public List<NetworkAttribute> Attributes { get; set; }

        /// <summary>
        /// Список элементов данных (строк).
        /// </summary>
        public List<NetworkDataEntity> Entities { get; set; }

		public object Clone()
		{
			var attributes = new List<NetworkAttribute>();
			attributes.AddRange(Attributes.Select(a => a.Clone() as NetworkAttribute));

			var entities = new List<NetworkDataEntity>();
			entities.AddRange(Entities.Select(a => a.Clone() as NetworkDataEntity));

			return new NetworkDataSet
			{
				Attributes = attributes,
				Entities = entities
			};
		}
    }
}
