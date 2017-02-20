using System.Collections.Generic;

namespace KohonenNeuroNet.Core.NetworkData
{
    /// <summary>
    /// Кластер.
    /// </summary>
    public class NetworkClaster
    {
        /// <summary>
        /// Номер кластера.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Сущности этого кластера.
        /// </summary>
        public List<NetworkDataEntity> Entities { get; set; } = new List<NetworkDataEntity>();
    }
}
