using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Атрибут сущности (колонка).
    /// </summary>
    public class NetworkAttribute
    {
        /// <summary>
        /// Максимальное значение атрибута.
        /// </summary>
        public decimal Max { get; set; }

        /// <summary>
        /// Минимальное значение атрибута.
        /// </summary>
        public decimal Min { get; set; }

        /// <summary>
        /// Название атрибута.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер атрибута.
        /// </summary>
        public int OrderNumber { get; set; }
    }
}
