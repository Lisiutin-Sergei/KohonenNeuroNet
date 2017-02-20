using System.Collections.Generic;

namespace KohonenNeuroNet.Core.NetworkData
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
    }
}
