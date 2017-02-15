using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Значение атрибута элемента данных (ячейка).
    /// </summary>
    public class NetworkEntityAttributeValue
    {
        /// <summary>
        /// Атрибут сущности.
        /// </summary>
        public NetworkAttribute Attribute { get; set; }

        /// <summary>
        /// Значение атрибута.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Нормализованное значение от 0 до 1.
        /// </summary>
        public decimal NormalizedValue
        {
            get
            {
                if (Attribute == null)
                {
                    throw new Exception("Не определен атрибут данных");
                }
                if (Attribute.Max == Attribute.Min)
                {
                    return 0M;
                }

                return Value / (Attribute.Max - Attribute.Min);
            }
        }
    }
}
