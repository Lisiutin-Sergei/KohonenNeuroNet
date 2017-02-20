using System.Collections.Generic;

namespace KohonenNeuroNet.Core.NetworkData
{
    /// <summary>
    /// Элемент данных (строка).
    /// </summary>
    public class NetworkDataEntity
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
    }
}
