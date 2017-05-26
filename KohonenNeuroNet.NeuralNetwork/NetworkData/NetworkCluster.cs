using KohonenNeuroNet.Core.Model.Business;
using System.Collections.Generic;

namespace KohonenNeuroNet.NeuralNetwork.NetworkData
{
    /// <summary>
    /// Кластер.
    /// </summary>
    public class NetworkCluster
    {
        /// <summary>
        /// Номер кластера.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Сущности этого кластера.
        /// </summary>
        public List<NetworkDataEntity> Entities { get; set; } = new List<NetworkDataEntity>();
        
        /// <summary>
        /// Дочерние кластеры.
        /// </summary>
        public List<NetworkCluster> Clusters { get; set; }
    }
}
