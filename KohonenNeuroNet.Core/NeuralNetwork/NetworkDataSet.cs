using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
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
