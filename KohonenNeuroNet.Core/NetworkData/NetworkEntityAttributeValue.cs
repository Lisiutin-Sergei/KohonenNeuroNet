using KohonenNeuroNet.Core.Types;
using System;

namespace KohonenNeuroNet.Core.NetworkData
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
        public double Value { get; set; }

        /// <summary>
        /// Получить нормальное значение.
        /// </summary>
        /// <param name="normalizationType">Тип нормализации</param>
        /// <returns></returns>
        public double GetNormalizedValue(NormalizationTypes normalizationType)
        {
            if (Attribute == null)
            {
                throw new Exception("Не определен атрибут данных");
            }
            switch (normalizationType)
            {
                case NormalizationTypes.Linear_0_1:
                    return Attribute.Max == Attribute.Min ? 0 : Math.Abs(Value - Attribute.Min) / Math.Abs(Attribute.Max - Attribute.Min);
                case NormalizationTypes.Linear__1_1:
                    return Attribute.Max == Attribute.Min ? -1 : 2 * Math.Abs(Value - Attribute.Min) / Math.Abs(Attribute.Max - Attribute.Min) - 1;
                default:
                    throw new Exception("Некорректно задан тип нормализации");
            }
        }
    }
}
