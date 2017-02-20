using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
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
